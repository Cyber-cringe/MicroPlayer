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
        private const string playlistImage = @"\Screensaver.png";

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

        //визуальная настройка слотов музыки
        private void SetVisualToMusicBox()
        {
            foreach(Slot slot in musicBox)
            {
                //настройки слота
                slot.Size = new Size(775, 50);
                slot.BackColor = Color.FromArgb(55, 55, 55);
                slot.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                slot.BorderStyle = BorderStyle.FixedSingle;
                //настройки кнопки активации
                slot.ActivateSlotButton.Location = new Point(10, 7);
                slot.ActivateSlotButton.Size = new Size(50, 35);
                slot.ActivateSlotButton.Text = "▶";
                slot.ActivateSlotButton.ForeColor = Color.FromArgb(190, 190, 190);
                slot.ActivateSlotButton.BackColor = Color.FromArgb(27, 27, 27);
                slot.ActivateSlotButton.FlatStyle = FlatStyle.Popup;
                slot.ActivateSlotButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                //настройки кнопки удаления
                slot.DeleteSlotButton.Location = new Point(715, 7);
                slot.DeleteSlotButton.Size = new Size(50, 35);
                slot.DeleteSlotButton.Text = "🗑";
                slot.DeleteSlotButton.BackColor = Color.FromArgb(27, 27, 27);
                slot.DeleteSlotButton.ForeColor = Color.Red;
                slot.DeleteSlotButton.FlatStyle = FlatStyle.Popup;
                slot.DeleteSlotButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                //настройки кнопки дополнительного действия (добавить музыку в плейлист)
                slot.AdditionalActionButton.Location = new Point(655, 7);
                slot.AdditionalActionButton.Size = new Size(50, 35);
                slot.AdditionalActionButton.Text = "➕";
                slot.AdditionalActionButton.BackColor = Color.FromArgb(27, 27, 27);
                slot.AdditionalActionButton.ForeColor = Color.Green;
                slot.AdditionalActionButton.FlatStyle = FlatStyle.Popup;
                slot.AdditionalActionButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                //настройки label
                slot.NameLabel.Location = new Point(70, 10);
                slot.NameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                slot.NameLabel.ForeColor = Color.FromArgb(190, 190, 190);
            }
        }

        //-----ПЛЕЙЛИСТЫ-----
        //получаем список плейлистов
        private void ShowPlaylists()
        {
            string[]? data = Directory.GetDirectories(playlistsDir);
            playlistsBox.SetData(data);
            SetVisualToPlaylistsBox();
            playlistsBox.ShowSlots();
            SetVisualToPlaylistsBox();
            TryFindCurrentPlaylistInPlayListsBox();
            ShowPlaylistImages();
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
            musicBox.ClearBox();
        }

        //визуальная настройка слотов playlistBox
        private void SetVisualToPlaylistsBox()
        {
            foreach(Slot slot in playlistsBox)
            {
                slot.Size = new Size(170, 170);
                slot.BackColor = Color.FromArgb(55, 55, 55);
                slot.BorderStyle = BorderStyle.FixedSingle;
                //настройки кнопки активации
                slot.ActivateSlotButton.Location = new Point(45, 10);
                slot.ActivateSlotButton.Size = new Size(35, 35);
                slot.ActivateSlotButton.Text = "♫";
                slot.ActivateSlotButton.BackColor = Color.FromArgb(55, 55, 55);
                slot.ActivateSlotButton.ForeColor = Color.White;
                slot.ActivateSlotButton.FlatStyle = FlatStyle.Popup;
                //настройки кнопки удаления
                slot.DeleteSlotButton.Location = new Point(125, 10);
                slot.DeleteSlotButton.Size = new Size(35, 35);
                slot.DeleteSlotButton.Text = "🗑️";
                slot.DeleteSlotButton.BackColor = Color.FromArgb(55, 55, 55);
                slot.DeleteSlotButton.ForeColor = Color.Red;
                slot.DeleteSlotButton.FlatStyle = FlatStyle.Popup;
                //настройки кнопки дополнительного действия (добавить музыку в плейлист)
                slot.AdditionalActionButton.Location = new Point(85, 10);
                slot.AdditionalActionButton.Size = new Size(35, 35);
                slot.AdditionalActionButton.Text = "🖌";
                slot.AdditionalActionButton.BackColor = Color.FromArgb(55, 55, 55);
                slot.AdditionalActionButton.ForeColor = Color.White;
                slot.AdditionalActionButton.FlatStyle = FlatStyle.Popup;
                slot.AdditionalActionButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                //настройки label
                slot.NameLabel.Location = new Point(5, 140);
                slot.NameLabel.ForeColor = Color.FromArgb(190, 190, 190);
                slot.Font = new Font("Arial", 12, FontStyle.Regular);
                //настройка pictureBox
                slot.SlotPicture.Size = new Size(160, 130);
                slot.SlotPicture.Location = new Point(5, 5);
                slot.SlotPicture.BackColor = Color.FromArgb(27, 27, 27);
                slot.SlotPicture.SizeMode = PictureBoxSizeMode.Zoom;
                slot.Controls.Add(slot.SlotPicture);
            }
        }

        //асинхронно загружаем заставки плейлистов в соответствующие пикчербоксы
        private async void ShowPlaylistImages()
        {
            Task setImagesTask = Task.Run(() =>
            {
                foreach (Slot slot in playlistsBox)
                {
                    try {slot.SlotPicture.Image = new Bitmap($"{slot.path}{playlistImage}");}
                    catch { }
                }
            });
            await setImagesTask;
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

        //обработчики события смены трека в плеере
        private void CurrentItemChangeEventHandler(object Item)
        {
            if (previousSongSlot != null)
                SetPauseText(previousSongSlot.ActivateSlotButton);
            if (currentSongSlot != null)
            {
                SetPlayText(currentSongSlot.ActivateSlotButton);
                SetPlayText(playSongButton);
                currentSongName.Text = currentSongSlot.name;
                speedComboBox.SelectedIndex = 3;//ставим скорость воспроизведения x1
            }
        }

        private void CurrentMediaChangeEventHandler(object Item)
        {
            songTimeTrackBar.Maximum = (int)player.currentMedia.duration;
            songDuration.Text = player.currentMedia.durationString;
            if (!songTimer.Enabled)
                songTimer.Start();
        }

        //обработчик события смены статуса плеера
        private void PlayerStatusChangeEventHandler()
        {
            ChangePlayButtonState(currentSongSlot?.ActivateSlotButton);
            ChangePlayButtonState(playSongButton);
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
            currentPlaylistSlot = activatedSlot;
            ShowMusicInPlaylist(currentPlaylistSlot.path);
        }

        //проверяем, есть ли текущий слот трека в новом плейлисте,
        //если да, то активируем слот
        private void TryFindAndSwitchCurrentSlotInPlaylist()
        {
            musicBox.FindAndSetNewActiveSlot((slot) => slot.path == currentSongSlot?.path);
            Slot? selectedSlotInMusicBox = musicBox.ActiveSlot;
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

        //пытаемся найти текущий плейлист в обновленном playListsBox
        private void TryFindCurrentPlaylistInPlayListsBox()
        {
            if (currentPlaylistSlot == null) return;
            foreach (Slot slot in playlistsBox)
            {
                if (slot.path == currentPlaylistSlot.path)
                {
                    slot.DeleteSlotButton.Enabled = false;
                    currentPlaylistSlot = slot;
                    return;
                }
            }
        }

        //настраиваем комбобокс скорости трека
        public void SetStartSpeedComboBoxSettings(double[] speed)
        {
            foreach (var value in speed)
            {
                speedComboBox.Items.Add(value);
            }
            speedComboBox.SelectedIndex = 3;
        }

        //-----МЕТОДЫ ДЛЯ РАБОЬТЫ С ФОРМАМИ-----
        //создание нового плейлиста
        public void CreatePlaylist(string playlistName, out bool CreationIsCompleted)
        {
            CreationIsCompleted = false;
            string playlistPath = playlistsDir + $@"\{playlistName}";
            if (!Directory.Exists(playlistPath))
            {
                try
                {
                    Directory.CreateDirectory(playlistPath);
                    CreateMusicFileInPlylistDir(playlistPath);
                }
                catch
                {
                    MessageBox.Show("При создании плейлиста произошла ошибка.");
                    return;
                }
                ShowPlaylists();
                CreationIsCompleted = true;
            }
            else MessageBox.Show(text:"Плейлист с таким названием уже существует", caption: "Ошибка");
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
            if (string.IsNullOrEmpty(playlistPath)) return;
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
            if (string.IsNullOrEmpty(playlistPath) || string.IsNullOrEmpty(songPath)) return;
            string musicFilePath = playlistPath + playlistMusicFile;
            if (!File.Exists(musicFilePath)) return;
            List<string> playlistMusic = File.ReadAllLines(musicFilePath).ToList();
            playlistMusic.Remove(songPath);
            File.WriteAllLines(musicFilePath, playlistMusic);
        }

        //Удаляем плейлист
        private void DeletePlaylist(string playlistPath)
        {
            if (string.IsNullOrEmpty(playlistPath)) return;
            if (Directory.Exists(playlistPath))
            {
                Directory.Delete(playlistPath, true);
            }
        }

        //-----ФИЧИ-----
        private void CheckDate()
        {
                if ((DateTime.Today.Day == 31 && DateTime.Today.Month == 10) || //хэллоуин
                    (DateTime.Today.Day == 1 && DateTime.Today.Month == 11))
                {
                    holidaySymbolLabel.Left += 15;
                    holidaySymbolLabel.Text = "🎃";
                    holidaySymbolLabel.ForeColor = Color.OrangeRed;
                    companyName.ForeColor = Color.OrangeRed;
                    Font holidayFont = new Font("Curlz MT", 12);
                    companyName.Font = holidayFont;
                }
                else if ((DateTime.Today.Day == 31 && DateTime.Today.Month == 12) || //новый год
                         (DateTime.Today.Day == 1 && DateTime.Today.Month == 1))
                {
                    holidaySymbolLabel.ForeColor = Color.Green;
                    holidaySymbolLabel.Text = "🎄";
                    companyName.ForeColor = Color.Red;
                    Font holidayFont = new Font("Jokerman", 12);
                    companyName.Font = holidayFont;
                }
        }

    }

}
