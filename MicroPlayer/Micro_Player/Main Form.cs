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
            ShowMusic(musicDir);
            currentPlaylistName.Text = "��� ������";
            musicBox.SelectedSlotChanged += MusicBoxSelectedSlotChangedEventHandler;
            player.MediaChange += MusicBoxSelectedSlotStartPanel;
            playlistsBox.SelectedSlotChanged += PlayListsBoxSelectedSlotChangedEventHandler;
            MusicTimer.Interval = 10;
            MusicPanelBox.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"����������:{previousSlot?.path}  �������:{currentSlot?.path}");
        }

        private void backToRootDirButton_Click(object sender, EventArgs e)
        {
            ShowMusic(musicDir);
            currentPlaylistName.Text = "��� ������";
            currentPlaylist = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musicBox.ActivateNextSlot();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            musicBox.ActivatePreviousSlot();
        }

        private void MusicTrackBar_Scroll(object sender, EventArgs e)
        {
            player.controls.currentPosition = MusicTrackBar.Value;
        }

        private void VolumeTrackBar_Scroll(object sender, EventArgs e)
        {
            player.settings.volume = MusicTrackBar.Value;
        }
    }
}