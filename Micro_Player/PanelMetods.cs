using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro_Player
{
    public partial class MainForm : Form
    {
        Image pauseImage = Properties.Resources.playbutton;
        Image playimage = Properties.Resources.pausebutton;
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
            PlayPauseButton.Image = pauseImage;
        }

    }
}
