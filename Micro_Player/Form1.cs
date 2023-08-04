using WMPLib;
namespace Micro_Player
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer wmp = new WindowsMediaPlayer();
        SlotBox sb = new SlotBox();
        string[] music = Directory.GetFileSystemEntries(@"C:\Users\HP\Desktop\GTA\other music");

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Controls.Add(sb);
            for(int i = 0; i<10000; i++)
            {
                sb.SetData(music);
            }
            sb.ShowSlots();
            sb.GlobalVisualizationSetup((a) => a.BackColor = Color.Orange);
            sb.SelectedSlotChanged += (s, e) => wmp.URL = e.slot.path;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}