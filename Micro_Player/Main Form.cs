using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using WMPLib;
namespace Micro_Player
{
    public partial class MainForm : Form
    {
        WindowsMediaPlayer wmp = new WindowsMediaPlayer();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateDirs();
            ShowAllMusic();
            ShowPlaylists();
            currentPlaylistName.Text = "Вся музыка";
            //подписываемся на события плеера
            player.CurrentItemChange += CurrentItemChangeEventHandler;
            player.MediaChange+= CurrentMediaChangeEventHandler;
            player.StatusChange += PlayerStatusChangeEventHandler;
            SetStartSpeedComboBoxSettings(new double[] { 0.25, 0.5, 0.75, 1, 1.25, 1.5, 1.75, 2 });
            CheckDate();
        }

        //возврат в папку с музыкой
        private void backToRootDirButton_Click(object sender, EventArgs e)
        {
            if(currentPlaylistSlot == null) return;
            ShowAllMusic();
            currentPlaylistName.Text = "Вся музыка";
            addSongButton.Enabled = true;
            currentPlaylistSlot.DeleteSlotButton.Enabled = true;
            currentPlaylistSlot = null;
        }

        //добавление нового трека в папку Music
        private void addSongButton_Click(object sender, EventArgs e)
        {
            addSongFileDialog.Filter = "MP3 files|*.mp3";
            addSongFileDialog.FileName = "";
            addSongFileDialog.Title = "Выберите песню";
            addSongFileDialog.ShowDialog();
            string fullFileName = addSongFileDialog.FileName;
            if (string.IsNullOrEmpty(fullFileName)) return;
            string fileName = Path.GetFileName(fullFileName);
            string newFullFileName = musicDir + @$"\{fileName}";
            if (File.Exists(newFullFileName))
            {
                MessageBox.Show("Песня уже добавлена");
                return;
            }
            File.Copy(fullFileName, newFullFileName);
            ShowAllMusic();
        }

        //включить следующий трек
        private void nextSongButton_Click(object sender, EventArgs e)
        {
            musicBox.ActivateNextSlot(true);
        }

        //включить предыдущий трек
        private void previousSongButton_Click(object sender, EventArgs e)
        {
            musicBox.ActivatePreviousSlot(true);
        }

        //открываем форму создания нового плейлиста
        private void createPlaylistButton_Click(object sender, EventArgs e)
        {
            CreatePlaylistForm createPlaylistForm = new CreatePlaylistForm(this);
            createPlaylistForm.ShowDialog();
        }

        //Обработчик события нажатия на кнопку смены трека
        private void musicBox_SlotActivated(object sender, SlotBoxEventArgs e)
        {
            if (!playerStoppedCheckerTimer.Enabled)
                playerStoppedCheckerTimer.Start();
            Slot activatedSlot = e.slot;
            TrySwitchSongSlots(activatedSlot);
        }

        //Обработчик события нажатия на кнопку удаления слота трека
        private void musicBox_DeletedSlotSelected(object sender, SlotBoxEventArgs e)
        {
            Slot activatedSlot = e.slot;
            string songName = e.slot.name;
            ConfirmForm confirmForm = new ConfirmForm(ObjectTypes.Трек, songName);

            if (currentPlaylistSlot == null)//если пользователь находится не в плейлисте, а во всей музыке.
            {
                confirmForm.SubscribeToConfirmButtonClick((sender, e) =>
                {
                    DeleteSongFromMusicDir(activatedSlot.path);
                    musicBox.DeleteSlot(activatedSlot);
                });
            }
            else
            {
                confirmForm.SubscribeToConfirmButtonClick((sender, e) =>
                {
                    DeleteSongFromPlaylistMusicFile(currentPlaylistSlot.path, activatedSlot.path);
                    musicBox.DeleteSlot(activatedSlot);
                });
            }
            confirmForm.ShowDialog();
        }

        //Обаботчик события нажатия кнопки дополнительного действия слота трека (добавить трек в плейлист)
        private void musicBox_AdditionalActionInvoke(object sender, SlotBoxEventArgs e)
        {
            string songPath = e.slot.path;
            List<string> fullplaylistNames = new List<string>(Directory.GetDirectories(playlistsDir));
            fullplaylistNames.Remove(currentPlaylistSlot?.path);
            string[]? playlistNames = new DirectoryWorker().GetDirNames(fullplaylistNames.ToArray());
            AddSongForm addSongForm = new AddSongForm(this, playlistNames, songPath);
            addSongForm.ShowDialog();
        }

        //обработчик события смены плейлиста
        private void playlistsBox_SlotActivated(object sender, SlotBoxEventArgs e)
        {
            Slot activatedSlot = e.slot;
            TrySwitchPlaylistSlots(activatedSlot);
            addSongButton.Enabled = false;
            currentPlaylistName.Text = currentPlaylistSlot?.name;
        }

        //обработчик события удаления плейлиста
        private void playlistsBox_DeletedSlotSelected(object sender, SlotBoxEventArgs e)
        {
            Slot activatedSlot = e.slot;
            string playlistName = activatedSlot.name;
            ConfirmForm confirmForm = new ConfirmForm(ObjectTypes.Плейлист, playlistName);
            confirmForm.SubscribeToConfirmButtonClick((sender, e) =>
            {
                playlistsBox.DeleteSlot(activatedSlot);
                string activatedSlotPath = activatedSlot.path;
                DeletePlaylist(activatedSlotPath);
            });
            confirmForm.ShowDialog();
        }

        //Обаботчик события нажатия кнопки дополнительного действия слота трека (загрузить абложку трека)
        private void playlistsBox_AdditionalActionInvoke(object sender, SlotBoxEventArgs e)
        {
            addPlaylistImageFileDialog.Filter = "png files|*.png";
            addPlaylistImageFileDialog.FileName = "";
            addPlaylistImageFileDialog.Title = "Загрузить обложку плейлиста";
            addPlaylistImageFileDialog.ShowDialog();
            string imagePath = addPlaylistImageFileDialog.FileName;
            if (string.IsNullOrEmpty(imagePath)) return;
            string fullPlaylistPath = e.slot.path;
            string newImagePath = $@"{fullPlaylistPath}{playlistImage}";
            e.slot.SlotPicture.Image?.Dispose();
            File.Copy(imagePath, newImagePath, true);
            e.slot.SlotPicture.Image = new Bitmap(newImagePath);
        }

        //проверяем факт остановки плеера (завершения трека)
        private void playerStoppedCheckerTimer_Tick(object sender, EventArgs e)
        {
            if (player.playState == WMPPlayState.wmppsStopped)
            {
                playerStoppedCheckerTimer.Stop();
                if (currentSongSlot != null)
                    SetPauseText(currentSongSlot.ActivateSlotButton);
                musicBox.ActivateNextSlot(true);
            }
        }

        //обработчик нажатия на кнопку play в нижней панеле
        private void playSongButton_Click(object sender, EventArgs e)
        {
            if (currentSongSlot == null) return;
            ChangePlayerState();
        }

        //обработчик таймера игры текущего трека
        private void songTimer_Tick(object sender, EventArgs e)
        {
            string currentTime = player.controls.currentPositionString;
            songTimeTrackBar.Value = (int)player.controls.currentPosition;
            currentSongTime.Text = currentTime == "" ? "00:00" : currentTime;
        }

        //перемотка трека
        private void songTimeTrackBar_Scroll(object sender, EventArgs e)
        {
            player.controls.currentPosition = songTimeTrackBar.Value;
        }

        //регулировка громкости
        private void volumeTrackBar_Scroll(object sender, EventArgs e)
        {
            player.settings.volume = volumeTrackBar.Value;
            volumeLabel.Text = $"🔈{volumeTrackBar.Value}%";
        }

        //смена скорости плеера
        private void speedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            player.settings.rate= (double)speedComboBox.SelectedItem;
        }

        //описание кнопок при наведении на них
        private void createPlaylistButton_MouseEnter(object sender, EventArgs e)
        {
            string message = "Создать новый плейлист";
            assistantToolTip.RemoveAll();
            assistantToolTip.SetToolTip(createPlaylistButton, message);
        }

        private void addSongButton_MouseEnter(object sender, EventArgs e)
        {
            string message = "Добавить песню";
            assistantToolTip.RemoveAll();
            assistantToolTip.SetToolTip(addSongButton, message);
        }

        private void backToRootDirButton_MouseEnter(object sender, EventArgs e)
        {
            string message = "Вернуться в раздел 'Вся музыка'";
            assistantToolTip.RemoveAll();
            assistantToolTip.SetToolTip(backToRootDirButton, message);
        }

        //отрисовка assistantToolTip
        private void assistantToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        //обработчик закрытия формы
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            player.CurrentItemChange -= CurrentMediaChangeEventHandler;
            player.MediaChange -= CurrentMediaChangeEventHandler;
            player.StatusChange -= PlayerStatusChangeEventHandler;
            songTimer.Stop();
            playerStoppedCheckerTimer.Stop();
            player.controls.stop();
            player = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }

}