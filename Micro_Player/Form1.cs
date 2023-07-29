using WMPLib;
namespace Micro_Player
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer wmp = new WindowsMediaPlayer();
        SlotBox sb = new SlotBox();
        string[] music = { "Eminem", "Metallica", "Gorillaz" };

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Controls.Add(sb);
            sb.SetData(music);
            sb.ShowSlots();
            sb.GlobalVisualizationSetup((a) => a.BackColor = Color.Orange);
        }

    }
}