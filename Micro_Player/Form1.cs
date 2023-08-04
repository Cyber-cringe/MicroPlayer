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


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string? way = @"C:\musicaboba";
            string[]? dir = Directory.GetDirectories(way);

            slotBox1.SetData(dir);
            slotBox1.ShowSlots(0, 0, true);
            slotBox1.GlobalVisualizationSetup((a) => a.BackColor = Color.Orange);
            slotBox1.SelectedSlotChanged += Showmusic;
            slotBox1.DeletedSlotSelected += (peris, nibba) => nibba.slot.Hide();
        }
        public void Showmusic(object sender, SlotBoxEventArgs e)
        {
            string? selectedplaylist = e.slot.path;
            string[]? musicis = Directory.GetFiles(selectedplaylist);
            Controls.Add(music);
            slotBox2.SetData(musicis);
            slotBox2.ShowSlots(100, 100);
            slotBox2.GlobalVisualizationSetup((a) => a.BackColor = Color.Aqua);
            slotBox2.SelectedSlotChanged += musico;
            slotBox2.DeletedSlotSelected += (peris, nibba) => nibba.slot.Hide();

        }
        public void musico(object sender, SlotBoxEventArgs e)
        {
            wmp.URL = e.slot.path;
            e.slot.MoveSlot(20);
        }
    }
}