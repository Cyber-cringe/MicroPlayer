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

        private void Form1_Load(object sender, EventArgs e)
        {
            /*string? way = @"C:\musicaboba";
            string[]? dir = Directory.GetDirectories(way);

            playlistsBox.SetData(dir);
            playlistsBox.ShowSlots(0, 0, true);
            playlistsBox.GlobalVisualizationSetup((a) => a.BackColor = Color.Orange);
            playlistsBox.SelectedSlotChanged += Showmusic;
            playlistsBox.DeletedSlotSelected += (peris, nibba) => nibba.slot.Hide();*/
        }
        public void Showmusic(object sender, SlotBoxEventArgs e)
        {
            /*string? selectedplaylist = e.slot.path;
            string[]? musicis = Directory.GetFiles(selectedplaylist);
            Controls.Add(music);
            musicBox.SetData(musicis);
            musicBox.ShowSlots(100, 100);
            musicBox.GlobalVisualizationSetup((a) => a.BackColor = Color.Aqua);
            musicBox.SelectedSlotChanged += musico;
            musicBox.DeletedSlotSelected += (peris, nibba) => nibba.slot.Hide();*/

        }
        public void musico(object sender, SlotBoxEventArgs e)
        {
            wmp.URL = e.slot.path;
            e.slot.MoveSlot(20);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateDirs();
            ShowPlaylists();
            ShowMusic(musicDir);
            currentPlaylistName.Text = "Вся музыка";
            musicBox.SelectedSlotChanged += MusicBoxSelectedSlotChangedEventHandler;
            playlistsBox.SelectedSlotChanged += PlayListsBoxSelectedSlotChangedEventHandler;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"предыдущий:{previousSlot?.path}  текущий:{currentSlot?.path}");
        }

        private void backToRootDirButton_Click(object sender, EventArgs e)
        {
            ShowMusic(musicDir);
            currentPlaylistName.Text = "Вся музыка";
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
    }
}