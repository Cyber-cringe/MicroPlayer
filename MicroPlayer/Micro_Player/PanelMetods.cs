using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro_Player
{
    public partial class MainForm : Form
    {
        private void PlayPauseButton_Click(object sender, EventArgs e)
        {
            ChangePlayerState();
            MusicTimer.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            MusicTimer.Stop();
            player.controls.stop();
        }
        private void MusicBoxSelectedSlotStartPanel(object? sender)
        {
            MusicPanelBox.Show();
            MusicTrackBar.Maximum = (int)player.currentMedia.duration;
            label2.Text = player.currentMedia.durationString;
            MusicTimer.Start();

        }

        private void MusicTimer_Tick(object sender, EventArgs e)
        {
            MusicTrackBar.Value = (int)player.controls.currentPosition;

            if (player != null)
            {
                label1.Text = player.controls.currentPosition.ToString();
            }
        }
    }
}
