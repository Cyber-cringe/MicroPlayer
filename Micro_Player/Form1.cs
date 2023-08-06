using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using WMPLib;
namespace Micro_Player
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer wmp = new WindowsMediaPlayer();
        SlotBox playlists = new SlotBox();
        SlotBox music = new SlotBox();
        string? way = @"C:\musicaboba";
        bool FirstStart = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string[]? dir = Directory.GetDirectories(way);
            MusicTimer.Interval = 1000;
            slotBox1.SetData(dir);
            slotBox1.ShowSlots(0, 0, true);
            slotBox1.GlobalVisualizationSetup((a) => a.BackColor = Color.Orange);
            slotBox1.SelectedSlotChanged += Showmusic;
            slotBox1.DeletedSlotSelected += (peris, nibba) => nibba.slot.Hide();
            MusicPanel.Hide();
            MusicPanel.BorderStyle = BorderStyle.FixedSingle;
            VolumeTracker.Value = 100;
        }
        public void Showmusic(object sender, SlotBoxEventArgs e)
        {
            string? selectedplaylist = e.slot.path;
            string[]? musicis = Directory.GetFiles(selectedplaylist);
            Controls.Add(music);
            slotBox2.SetData(musicis);
            slotBox2.ShowSlots(100, 10);
            slotBox2.GlobalVisualizationSetup((a) => a.BackColor = Color.Aqua);
            slotBox2.SelectedSlotChanged += musico;
            slotBox2.DeletedSlotSelected += (peris, nibba) => nibba.slot.Hide();

        }
        public bool IsPlaying()
        {
            if (wmp.playState == WMPPlayState.wmppsPlaying) return true;
            return false;
        }
        public void musico(object sender, SlotBoxEventArgs e)
        {
            wmp.URL = e.slot.path;
            MusicTimer.Start();
            e.slot.MoveSlot(20);
            MusicPanel.Show();

        }


        private void PlayPauseButton_Click(object sender, EventArgs e)
        {
            bool playtest = IsPlaying();
            if (playtest) wmp.controls.pause();

            if (!playtest)
            {

                if (FirstStart)
                {
                    MusicTimer.Start();
                    FirstStart = false;
                }
                wmp.controls.play();
                return;
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            MusicTimer.Stop();
            wmp.controls.stop();
            FirstStart = true;
        }

        private void MusicTimer_Tick(object sender, EventArgs e)
        {
            MusicTracker.Maximum = (int)wmp.currentMedia.duration;
            MusicTracker.Value = (int)wmp.controls.currentPosition;

            if (wmp != null)
            {
                int s = (int)wmp.currentMedia.duration;
                int h = s / 3600;
                int m = (s - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);
                label2.Text = String.Format("{1:D2}:{2:D2}", h, m, s);

                s = (int)wmp.controls.currentPosition;
                h = s / 3600;
                m = (s - (h * 3600)) / 60;
                s = s - (h * 3600 + m * 60);
                label1.Text = String.Format("{1:D2}:{2:D2}", h, m, s);
            }
            else
            {
                label2.Text = "00:00";
                label1.Text = "00:00";
            }
        }

        private void MusicTracker_Scroll(object sender, EventArgs e)
        {
            wmp.controls.currentPosition = MusicTracker.Value;
        }

        private void VolumeTracker_Scroll(object sender, EventArgs e)
        {
            wmp.settings.volume = VolumeTracker.Value;
        }
    }
}