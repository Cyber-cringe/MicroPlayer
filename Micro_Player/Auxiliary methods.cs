using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace Micro_Player
{
    public partial class MainForm
    {
        //директории приложения музыки и плейлистов
        private const string rootDir = @"C:\Micro Player";
        private const string musicDir = rootDir + @"\Music";
        private const string playlistsDir = rootDir + @"\Playlists";
        private const string playlistMusicFile = @"\Play List Music.txt";
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        private Slot? currentSlot = null;
        private Slot? previousSlot = null;
        private Slot? currentPlaylist = null;//если null, то текущая директория- music

        private int SlotMoveDistance = 10;
        private (string play, string pause) playButtonStates = (play: "▍ ▍", pause: "▶");

        //Создаём корневую папку приложения и добавляем в неё остальные папки
        private void CreateDirs()
        {
            TryCreateDir(rootDir);
            TryCreateDir(musicDir);
            TryCreateDir(playlistsDir);
        }

        //-----МУЗЫКА-----
        //получаем список песен
        private void ShowMusic(string path = musicDir)
        {
            string[]? music = Directory.GetFiles(path, "*.mp3");
            if (music == null) return;
            UpdateMusicBox(music);
        }

        //обработчик события смены трека
        private void MusicBoxSelectedSlotChangedEventHandler(object? sender, SlotBoxEventArgs e)
        {
            if (!playerStoppedCheckerTimer.Enabled) 
                playerStoppedCheckerTimer.Start();
            Slot activatedSlot = e.slot;
            string path = e.slot.path!;
            TrySwitchSlots(activatedSlot);
            
        }

        //Обаботчик события нажатия кнопки дополнительного действия слота трека
        private void MusicBoxAdditionalActionInvokeEventHandler(object? sender, SlotBoxEventArgs e)
        {
            string songName = e.slot.path!;
            List<string> fullplaylistNames = new List<string>(Directory.GetDirectories(playlistsDir));
            fullplaylistNames.Remove(currentPlaylist?.path);
            string[]? playlistNames = new DirectoryWorker().GetDirNames(fullplaylistNames.ToArray());
            AddSongForm addSongForm = new AddSongForm(this, playlistNames, songName!);
            addSongForm.ShowDialog();
        }

        //визуальная настройка слотов музыки
        private void SetVisualToMusicBox()
        {
            musicBox.GlobalVisualizationSetup((slot) =>
            {
                //настройки слота
                slot.Size = new Size(750, 50);
                slot.BackColor = Color.FromArgb(55,55,55);
                slot.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                slot.BorderStyle = BorderStyle.FixedSingle;
                //настройки кнопки активации
                slot.ActivateSlotButton.Location = new Point(570, 7);
                slot.ActivateSlotButton.Size = new Size(50, 35);
                slot.ActivateSlotButton.Text = "▶";
                slot.ActivateSlotButton.ForeColor = Color.White;
                slot.ActivateSlotButton.BackColor = Color.FromArgb(27, 27, 27);
                slot.ActivateSlotButton.FlatStyle = FlatStyle.Popup;
                slot.ActivateSlotButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                //настройки кнопки удаления
                slot.DeleteSlotButton.Location = new Point(690, 7);
                slot.DeleteSlotButton.Size = new Size(50, 35);
                slot.DeleteSlotButton.Text = "🗑️";
                slot.DeleteSlotButton.BackColor = Color.FromArgb(27, 27, 27);
                slot.DeleteSlotButton.ForeColor = Color.Red;
                slot.DeleteSlotButton.FlatStyle = FlatStyle.Popup;
                slot.DeleteSlotButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                //настройки кнопки дополнительного действия (добавить музыку в плейлист)
                slot.AdditionalActionButton.Visible = true;
                slot.AdditionalActionButton.Location = new Point(630, 7);
                slot.AdditionalActionButton.Size = new Size(50, 35);
                slot.AdditionalActionButton.Text = "➕";
                slot.AdditionalActionButton.BackColor = Color.FromArgb(27, 27, 27);
                slot.AdditionalActionButton.ForeColor = Color.Green;
                slot.AdditionalActionButton.FlatStyle = FlatStyle.Popup;
                slot.AdditionalActionButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                //настройки label
                slot.NameLabel.Location = new Point(10, 10);
                slot.NameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                slot.NameLabel.ForeColor = Color.FromArgb(190, 190, 190);
            });
        }

        //-----ПЛЕЙЛИСТЫ-----

        //получаем список плейлистов
        private void ShowPlaylists()
        {
            string[]? data = Directory.GetDirectories(playlistsDir);
            playlistsBox.SetData(data);
            SetVisualToPlaylistsBox();
            playlistsBox.ShowSlots(10, 10, true);
            SetVisualToPlaylistsBox();
        }

        //отображает музыку плейлиста (из файла) 
        private void ShowMusicInPlaylist(string PlaylistPath)
        {
            string MusicFilePath = PlaylistPath + playlistMusicFile;
            if (!File.Exists(MusicFilePath))
            {
                MessageBox.Show("Невозможно получить музыку из плейлиста.");
                musicBox.ClearAll();
                return;
            }
            List<string> musicList = GetPathsListFromMusicFile(MusicFilePath);
            musicList.Reverse();
            UpdateMusicBox(musicList.ToArray());
        }

        //обработчик события смены плейлиста
        private void PlayListsBoxSelectedSlotChangedEventHandler(object? sender, SlotBoxEventArgs e)
        {
            if (currentPlaylist == e.slot) return;
            addSongButton.Enabled = false;
            string path = e.slot.path!;
            currentPlaylist = e.slot;
            ShowMusicInPlaylist(path);
            currentPlaylistName.Text = currentPlaylist.name;
        }

        //визуальная настройка слотов playlistBox
        private void SetVisualToPlaylistsBox()
        {
            playlistsBox.GlobalVisualizationSetup((slot) =>
            {
                //настройки слота
                slot.Size = new Size(170,170);
                slot.BackColor = Color.FromArgb(55, 55, 55);
                slot.BorderStyle = BorderStyle.FixedSingle;
                //настройки кнопки активации
                slot.ActivateSlotButton.Location = new Point(130, 5);
                slot.ActivateSlotButton.Size = new Size(35,35);
                slot.ActivateSlotButton.Text = "📁";
                slot.ActivateSlotButton.BackColor= Color.FromArgb(27, 27, 27);
                slot.ActivateSlotButton.ForeColor= Color.White;
                slot.ActivateSlotButton.FlatStyle = FlatStyle.Popup;
                //настройки кнопки удаления
                slot.DeleteSlotButton.Location = new Point(90, 5);
                slot.DeleteSlotButton.Size = new Size(35,35);
                slot.DeleteSlotButton.Text = "🗑️";
                slot.DeleteSlotButton.BackColor= Color.FromArgb(27, 27, 27);
                slot.DeleteSlotButton.ForeColor = Color.Red;
                slot.DeleteSlotButton.FlatStyle = FlatStyle.Popup;
                //настройки label
                slot.NameLabel.Location = new Point(5, 90);
                slot.NameLabel.ForeColor = Color.FromArgb(190, 190, 190);
                slot.Font = new Font("Arial", 12, FontStyle.Regular);
            });
        }

        //-----ПЛЕЕР----
        //включает новый трек, или меняет состояние текущего (не используется)
        private void SwitchSound(string path)
        {
            if (player.URL == path)
                ChangePlayerState();
            else player.URL = path;
        }

        //Меняет состояние плеера
        private void ChangePlayerState()
        {
            if (player.playState == WMPPlayState.wmppsPlaying)
            {
                player.controls.pause();
                PlayPauseButton.Image = pauseImage;
            }
            else if (player.playState == WMPPlayState.wmppsPaused
                    || player.playState == WMPPlayState.wmppsStopped)
            {
                player.controls.play();
                PlayPauseButton.Image = playimage;
            }
        }

        //обработчик события смены трека в плеере
        private void MediaChangeEventHandler(object Item)
        {
            if (previousSlot != null)
                SetPauseText(previousSlot.ActivateSlotButton);
            if (currentSlot != null)
                SetPlayText(currentSlot.ActivateSlotButton);
        }

        //-----ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ-----
        //создание директории
        private void TryCreateDir(string path)
        {
            if (!Directory.Exists(path) && !File.Exists(path))
                Directory.CreateDirectory(path);
        }

        //обновление списка треков
        private void UpdateMusicBox(string[] data)
        {
            musicBox.SetData(data);
            SetVisualToMusicBox();
            musicBox.ShowSlots();
            TryFindAndSwitchCurrentSlotInPlaylist();
        }

        //переключение слотов (треков)
        private void TrySwitchSlots(Slot activatedSlot)
        {
            if (activatedSlot == currentSlot)
            {
                ChangePlayerState();
                return;
            }
            (previousSlot, currentSlot) = (currentSlot, activatedSlot);
            DeactivateSlot(previousSlot);
            ActivateSlot(currentSlot);
            player.URL = currentSlot.path;
        }

        //проверяем, есть ли текущий слот трека в новом плейлисте,
        //если да, то активируем слот
        private void TryFindAndSwitchCurrentSlotInPlaylist()
        {
            musicBox.FindAndSetNewSelectedSlot((slot) => slot.path == currentSlot?.path);
            Slot? selectedSlotInMusicBox = musicBox.SelectedSlot;
            if (selectedSlotInMusicBox == null) return;
            selectedSlotInMusicBox.ActivateSlotButton.Text = currentSlot?.ActivateSlotButton.Text;
            currentSlot = selectedSlotInMusicBox;
            ActivateSlot(currentSlot);
        }

        //делаем слот активным
        private void ActivateSlot(Slot? slot)
        {
            if (slot == null) return;
            slot.MoveSlot(SlotMoveDistance);
            slot.DeleteSlotButton.Enabled = false;
        }

        //делаем слот неактивным
        private void DeactivateSlot(Slot? slot)
        {
            if (slot == null) return;
            slot.MoveSlot(-SlotMoveDistance);
            slot.DeleteSlotButton.Enabled = true;
        }

        //Меняем текст кнопки паузы слота с треком на противоположный
        private void ChangePlayButtonState(Button? button)
        {
            if (button == null) return;
            if (button.Text == playButtonStates.play)
                SetPauseText(button);
            else if (button.Text == playButtonStates.pause)
                SetPlayText(button);
        }

        //меняем текст кнопки каузы
        private void SetPauseText(Button button)=> button.Text = playButtonStates.pause;
        private void SetPlayText(Button button) => button.Text = playButtonStates.play;

        //очищаем файл Play List Music.txt от удаленных песен,
        //получаем список пазов песен плейлиста из  обновленного файла
        private List<string> GetPathsListFromMusicFile(string MusicFilePath)
        {
            List<string> musicList = File.ReadAllLines(MusicFilePath).ToList();
            for (int i = 0; i < musicList.Count; i++)
            {
                if (!File.Exists(musicList[i]))
                {
                    musicList.Remove(musicList[i]);
                    i--;
                }
            }
            File.WriteAllLines(MusicFilePath, musicList);
            return musicList;
        }

        //настраиваем и показываем диалоговое окно выбора mp3 файла
        private void SetUpAddSongFileDialog()
        {
            addSongFileDialog.Filter = "MP3 files|*.mp3";
            addSongFileDialog.FileName = "";
            addSongFileDialog.Title = "Выберите песню";
        }

        //-----МЕТОДЫ ДЛЯ РАБОЬТЫ С ФОРМАМИ-----
        //создание нового плейлиста
        public void CreatePlaylist(string playlistName, out bool CreationIsCompleted)
        {
            CreationIsCompleted = false;
            string fullPlaylistName = playlistsDir + $@"\{playlistName}";
            if (!Directory.Exists(fullPlaylistName))
            {
                Directory.CreateDirectory(fullPlaylistName);
                CreateMusicFileInPlylistDir(fullPlaylistName);
                ShowPlaylists();
                CreationIsCompleted = true;
            }
            else MessageBox.Show("Плейлист с таким названием уже существует");
        }

        //добавляем выбранный трек в файл с музыкой плейлиста
        public void AddSoundInPlaylist(string playlistName, string songName)
        {
            string musicFile = $@"{playlistsDir}\" + @playlistName + playlistMusicFile;
            if (File.Exists(songName))
            {
                File.AppendAllText(musicFile, songName);
            }
            else MessageBox.Show("При добавлении произошла ошибка");
        }

        //создание файла для хранения музыки в плейлисте
        private void CreateMusicFileInPlylistDir(string? fullPlaylistName)
        {
            if (String.IsNullOrEmpty(fullPlaylistName)) return;
            string path = fullPlaylistName + playlistMusicFile;
            if (Directory.Exists(fullPlaylistName))
                using (File.Create(path));
        }

    }
}
