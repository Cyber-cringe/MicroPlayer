using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

        private Slot? currentSongSlot = null;
        private Slot? previousSongSlot = null;
        private Slot? currentPlaylistSlot = null;//если null, то текущая директория- music

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
        //получаем список всех песен из основной директории
        private void ShowAllMusic()
        {
            string[]? music = Directory.GetFiles(musicDir, "*.mp3");
            if (music == null) return;
            UpdateMusicBox(music);
        }

        //обработчик события смены трека
        private void MusicBoxSelectedSlotChangedEventHandler(object? sender, SlotBoxEventArgs e)
        {
            if (!playerStoppedCheckerTimer.Enabled) 
                playerStoppedCheckerTimer.Start();
            Slot activatedSlot = e.slot;
            TrySwitchSongSlots(activatedSlot);
        }

        //обработчик события удаления трека
        private void MusicBoxDeletedSlotSelectedEventHandler(object? sender, SlotBoxEventArgs e)
        {
            Slot activatedSlot= e.slot;
            string songName = e.slot.name;
            ConfirmForm confirmForm = new ConfirmForm(ObjectTypes.Трек, songName);

            if(currentPlaylistSlot == null)
            {
                confirmForm.SubscribeToConfirmButtonClick((sender, e) =>
                {
                    DeleteSongFromMusicDir(activatedSlot.path);
                    ShowAllMusic();
                });
            }
            else
            {
                confirmForm.SubscribeToConfirmButtonClick((sender, e) =>
                {
                    DeleteSongFromPlaylistMusicFile(currentPlaylistSlot.path, activatedSlot.path);
                    ShowMusicInPlaylist(currentPlaylistSlot.path);
                });
            }
            confirmForm.ShowDialog();
        }

        //Обаботчик события нажатия кнопки дополнительного действия слота трека
        private void MusicBoxAdditionalActionInvokeEventHandler(object? sender, SlotBoxEventArgs e)
        {
            string songPath = e.slot.path;
            List<string> fullplaylistNames = new List<string>(Directory.GetDirectories(playlistsDir));
            fullplaylistNames.Remove(currentPlaylistSlot?.path);
            string[]? playlistNames = new DirectoryWorker().GetDirNames(fullplaylistNames.ToArray());
            AddSongForm addSongForm = new AddSongForm(this, playlistNames, songPath);
            addSongForm.ShowDialog();
        }

        //визуальная настройка слотов музыки
        private void SetVisualToMusicBox()
        {
            musicBox.GlobalVisualizationSetup((slot) =>
            {
                //настройки слота
                slot.Size = new Size(750, 50);
                slot.BackColor = Color.Peru;
                slot.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                //настройки кнопки активации
                slot.ActivateSlotButton.Location = new Point(250, 10);
                slot.ActivateSlotButton.Size = new Size(110, 35);
                slot.ActivateSlotButton.Text = "▶";
                slot.ActivateSlotButton.ForeColor = Color.Peru;
                slot.ActivateSlotButton.FlatStyle = FlatStyle.Popup;
                slot.ActivateSlotButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                //настройки кнопки удаления
                slot.DeleteSlotButton.Location = new Point(370, 10);
                slot.DeleteSlotButton.Size = new Size(110, 35);
                slot.DeleteSlotButton.Text = "Удалить";
                slot.DeleteSlotButton.BackColor = Color.Red;
                slot.DeleteSlotButton.ForeColor = Color.Black;
                slot.DeleteSlotButton.FlatStyle = FlatStyle.Popup;
                slot.DeleteSlotButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                //настройки кнопки дополнительного действия (добавить музыку в плейлист)
                slot.AdditionalActionButton.Location = new Point(490, 10);
                slot.AdditionalActionButton.Size = new Size(110, 35);
                slot.AdditionalActionButton.Text = "Добавить";
                slot.AdditionalActionButton.BackColor = Color.Green;
                slot.AdditionalActionButton.ForeColor = Color.Black;
                slot.AdditionalActionButton.FlatStyle = FlatStyle.Popup;
                slot.AdditionalActionButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                //настройки label
                slot.NameLabel.Location = new Point(10, 10);
                slot.NameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
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
        private void ShowMusicInPlaylist(string? playlistPath)
        {
            if (String.IsNullOrEmpty(playlistPath)) return;
            string MusicFilePath = playlistPath + playlistMusicFile;
            if (File.Exists(MusicFilePath))
            {
                List<string> musicList = GetPathsListFromMusicFile(MusicFilePath).ToList();
                musicList.Reverse();
                UpdateMusicBox(musicList.ToArray());
                return;
            }
            MessageBox.Show("Невозможно получить музыку из плейлиста.");
            musicBox.ClearAll();
        }

        //обработчик события смены плейлиста
        private void PlayListsBoxSelectedSlotChangedEventHandler(object? sender, SlotBoxEventArgs e)
        {
            Slot activatedSlot = e.slot;
            TrySwitchPlaylistSlots(activatedSlot);
            addSongButton.Enabled = false;
            currentPlaylistName.Text = currentPlaylistSlot?.name;
        }

        //обработчик события удаления плейлиста
        private void PlaylistsBoxDeletedSlotSelectedEventHandler(object? sender, SlotBoxEventArgs e)
        {
            Slot activatedSlot = e.slot;
            string playlistName = activatedSlot.name;
            ConfirmForm confirmForm = new ConfirmForm(ObjectTypes.Плейлист, playlistName);
            confirmForm.SubscribeToConfirmButtonClick((sender, e) =>
            {
                DeletePlaylist(activatedSlot.path);
                ShowPlaylists();
            });
            confirmForm.ShowDialog();
        }

        //визуальная настройка слотов playlistBox
        private void SetVisualToPlaylistsBox()
        {
            playlistsBox.GlobalVisualizationSetup((slot) =>
            {
                //настройки слота
                slot.Size = new Size(170,170);
                slot.BackColor = Color.Peru;
                //настройки кнопки активации
                slot.ActivateSlotButton.Location = new Point(10,45);
                slot.ActivateSlotButton.Size = new Size(150,35);
                slot.ActivateSlotButton.Text = "Открыть";
                slot.ActivateSlotButton.ForeColor= Color.Peru;
                slot.ActivateSlotButton.FlatStyle = FlatStyle.Popup;
                //настройки кнопки удаления
                slot.DeleteSlotButton.Location = new Point(10,90);
                slot.DeleteSlotButton.Size = new Size(150,35);
                slot.DeleteSlotButton.Text = "Удалить";
                slot.DeleteSlotButton.BackColor= Color.Red;
                slot.DeleteSlotButton.ForeColor = Color.Black;
                slot.DeleteSlotButton.FlatStyle = FlatStyle.Popup;
                //настройки label
                slot.NameLabel.Location = new Point(10, 10);
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
                player.controls.pause();
            else if (player.playState == WMPPlayState.wmppsPaused
                    || player.playState == WMPPlayState.wmppsStopped)
                player.controls.play();
        }

        //обработчик события смены трека в плеере
        private void CurrentSongChangeEventHandler(object Item)
        {
            if (previousSongSlot != null)
                SetPauseText(previousSongSlot.ActivateSlotButton);
            if (currentSongSlot != null)
                SetPlayText(currentSongSlot.ActivateSlotButton);
        }

        //-----ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ-----
        //создание директории
        private void TryCreateDir(string? path)
        {
            if (path == null) return;
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
        private void TrySwitchSongSlots(Slot? activatedSlot)
        {
            if (activatedSlot == null) return;
            if (activatedSlot == currentSongSlot)
            {
                ChangePlayerState();
                return;
            }
            (previousSongSlot, currentSongSlot) = (currentSongSlot, activatedSlot);
            DeactivateSongSlot(previousSongSlot);
            ActivateSongSlot(currentSongSlot);
            player.URL = currentSongSlot.path;
        }

        //переключение слотов (плейлистов)
        private void TrySwitchPlaylistSlots(Slot? activatedSlot)
        {
            if (activatedSlot == currentPlaylistSlot || activatedSlot == null) return;
            if (currentPlaylistSlot != null)
            {
                currentPlaylistSlot.DeleteSlotButton.Enabled = true;
            }
            activatedSlot.DeleteSlotButton.Enabled = false;
            ShowMusicInPlaylist(activatedSlot.path);
            currentPlaylistSlot = activatedSlot;
        }

        //проверяем, есть ли текущий слот трека в новом плейлисте,
        //если да, то активируем слот
        private void TryFindAndSwitchCurrentSlotInPlaylist()
        {
            musicBox.FindAndSetNewSelectedSlot((slot) => slot.path == currentSongSlot?.path);
            Slot? selectedSlotInMusicBox = musicBox.SelectedSlot;
            if (selectedSlotInMusicBox == null) return;
            selectedSlotInMusicBox.ActivateSlotButton.Text = currentSongSlot?.ActivateSlotButton.Text;
            currentSongSlot = selectedSlotInMusicBox;
            ActivateSongSlot(currentSongSlot);
        }

        //делаем слот песни активным
        private void ActivateSongSlot(Slot? slot)
        {
            if (slot == null) return;
            slot.MoveSlot(SlotMoveDistance);
            slot.DeleteSlotButton.Enabled = false;
        }

        //делаем слот песни неактивным
        private void DeactivateSongSlot(Slot? slot)
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
        private string[] GetPathsListFromMusicFile(string musicFilePath)
        {
            string[] playlistMusic = File.ReadAllLines(musicFilePath);
            playlistMusic = playlistMusic.Where(File.Exists).ToArray();
            File.WriteAllLines(musicFilePath, playlistMusic);
            return playlistMusic;
        }

        //настраиваем диалоговое окно выбора mp3 файла
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
            string playlistPath = playlistsDir + $@"\{playlistName}";
            if (!Directory.Exists(playlistPath))
            {
                Directory.CreateDirectory(playlistPath);
                CreateMusicFileInPlylistDir(playlistPath);
                ShowPlaylists();
                CreationIsCompleted = true;
            }
            else MessageBox.Show("Плейлист с таким названием уже существует");
        }

        //добавляем выбранный трек в файл с музыкой плейлиста
        public void AddSoundToPlaylist(string playlistName, string songPath)
        {
            string musicFilePath = $@"{playlistsDir}\" + @playlistName + playlistMusicFile;
            if (File.Exists(songPath))
            {
                File.AppendAllText(musicFilePath, songPath+"\n");
            }
            else MessageBox.Show("При добавлении произошла ошибка");
        }

        //создание файла для хранения музыки в плейлисте
        private void CreateMusicFileInPlylistDir(string? playlistPath)
        {
            if (String.IsNullOrEmpty(playlistPath)) return;
            string musicFilePath = playlistPath + playlistMusicFile;
            if (Directory.Exists(playlistPath))
            {
                var musicFile = File.Create(musicFilePath);
                musicFile.Close();
            }
        }

        //Удаляем мп3 файл из директории с музыкой
        private void DeleteSongFromMusicDir(string? songPath)
        {
            if (String.IsNullOrEmpty(songPath)) return;
            if (File.Exists(songPath))
            {
                File.Delete(songPath);
            }
        }

        //Удаляем мп3 файл из файла плейлиста
        private void DeleteSongFromPlaylistMusicFile(string? playlistPath, string? songPath)
        {
            if (String.IsNullOrEmpty(playlistPath) || String.IsNullOrEmpty(songPath)) return;
            string musicFilePath = playlistPath + playlistMusicFile;
            if (!File.Exists(musicFilePath)) return;
            List<string> playlistMusic = File.ReadAllLines(musicFilePath).ToList();
            playlistMusic.Remove(songPath);
            File.WriteAllLines(musicFilePath, playlistMusic);
        }

        //Удаляем плейлист
        private void DeletePlaylist(string playlistPath)
        {
            if (String.IsNullOrEmpty(playlistPath)) return;
            if (Directory.Exists(playlistPath))
            {
                Directory.Delete(playlistPath, true);
            }
        }

    }

}
