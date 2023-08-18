using System.ComponentModel;
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
            ShowAllMusic();
            ShowPlaylists();
            currentPlaylistName.Text = "Вся музыка";
            //подписываемся на события смены слота в слотбоксах
            musicBox.SelectedSlotChanged += MusicBoxSelectedSlotChangedEventHandler;
            musicBox.AdditionalActionInvoke += MusicBoxAdditionalActionInvokeEventHandler;
            musicBox.DeletedSlotSelected += MusicBoxDeletedSlotSelectedEventHandler;
            playlistsBox.SelectedSlotChanged += PlayListsBoxSelectedSlotChangedEventHandler;
            playlistsBox.DeletedSlotSelected += PlaylistsBoxDeletedSlotSelectedEventHandler;
            //подписываемся на события плеера
            player.CurrentItemChange += CurrentSongChangeEventHandler;
            player.StatusChange += () => ChangePlayButtonState(currentSongSlot?.ActivateSlotButton);
        }

        //возврат в папку с музыкой
        private void backToRootDirButton_Click(object sender, EventArgs e)
        {
            if(currentPlaylistSlot == null) return;
            ShowAllMusic();
            currentPlaylistName.Text = "Вся музыка";
            addSongButton.Enabled = true;
            currentPlaylistSlot = null;
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
            ShowAllMusic();
        }

        //проверяем факт остановки плеера (завершения трека)
        private void playerStoppedCheckerTimer_Tick(object sender, EventArgs e)
        {
            if (player.playState == WMPPlayState.wmppsStopped)
            {
                playerStoppedCheckerTimer.Stop();
                if (currentSongSlot != null)
                    SetPauseText(currentSongSlot.ActivateSlotButton);
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

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(musicBox.GetSlotCount().ToString());
            GC.Collect();
        }

    }

}