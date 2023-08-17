using System.Security.Cryptography.X509Certificates;
using System.Xml;
using WMPLib;
namespace Micro_Player
{
    public partial class MainForm : Form
    {
        WindowsMediaPlayer wmp = new WindowsMediaPlayer();
        SlotBox playlists = new SlotBox();
        SlotBox music = new SlotBox();


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateDirs();
            ShowPlaylists();
            currentPlaylistName.Text = "Вся музыка";
            ShowMusic(musicDir);
            //подписываемся на события смены слота в слотбоксах
            musicBox.SelectedSlotChanged += MusicBoxSelectedSlotChangedEventHandler;
            musicBox.AdditionalActionInvoke += MusicBoxAdditionalActionInvokeEventHandler;
            player.MediaChange += MusicBoxSelectedSlotStartPanel;
            musicBox.DeletedSlotSelected += (sender, e) => MessageBox.Show("удаление");
            playlistsBox.SelectedSlotChanged += PlayListsBoxSelectedSlotChangedEventHandler;
            MusicPanelBox.Hide();
            playlistsBox.BackColor = Color.FromArgb(20, 20, 20);

            //подписываемся на события плеера
            player.CurrentItemChange += MediaChangeEventHandler;
            player.StatusChange += () => ChangePlayButtonState(currentSlot?.ActivateSlotButton);
        }

        //возврат в папку с музыкой
        private void backToRootDirButton_Click(object sender, EventArgs e)
        {
            if (currentPlaylist == null) return;
            ShowMusic(musicDir);
            currentPlaylistName.Text = "Вся музыка";
            addSongButton.Enabled = true;
            currentPlaylist = null;
        }

        //добавление нового трека
        private void addSongButton_Click(object sender, EventArgs e)
        {
            SetUpAddSongFileDialog();
            addSongFileDialog.ShowDialog();
            string fullFileName = addSongFileDialog.FileName;
            if (String.IsNullOrEmpty(fullFileName)) return;
            string fileName = Path.GetFileName(fullFileName);
            string newFullFileName = musicDir + @$"\{fileName}";
            if (File.Exists(newFullFileName))
            {
                MessageBox.Show("Песня уже добавлена");
                return;
            }
            File.Copy(fullFileName, newFullFileName);
            ShowMusic();
        }

        //проверяем факт остановки плеера (завершения трека)
        private void playerStoppedCheckerTimer_Tick(object sender, EventArgs e)
        {
            if (player.playState == WMPPlayState.wmppsStopped)
            {
                playerStoppedCheckerTimer.Stop();
                if (currentSlot != null)
                    SetPauseText(currentSlot.ActivateSlotButton);
                musicBox.ActivateNextSlot();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.currentPosition += 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musicBox.ActivateNextSlot();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            musicBox.ActivatePreviousSlot();
        }

        //открываем форму создания нового плейлиста
        private void createPlaylistButton_Click(object sender, EventArgs e)
        {
            CreatePlaylistForm createPlaylistForm = new CreatePlaylistForm(this);
            createPlaylistForm.ShowDialog();
        }
        private void MusicTrackBar_Scroll(object sender, EventArgs e)
        {
            player.controls.currentPosition = MusicTrackBar.Value;
        }

        private void VolumeTrackBar_Scroll(object sender, EventArgs e)
        {
            player.settings.volume = MusicTrackBar.Value;
        }

        private void MusicTimer_Tick(object sender, EventArgs e)
        {
            MusicTrackBar.Value = (int)player.controls.currentPosition;

            if (player != null)
            {
                label5.Text = player.controls.currentPosition.ToString();
            }
        }

        private void VolumeTrackBar_Scroll_1(object sender, EventArgs e)
        {
            player.settings.volume = MusicTrackBar.Value;
        }
    }
}