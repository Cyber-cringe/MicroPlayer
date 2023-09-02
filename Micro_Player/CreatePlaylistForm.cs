using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micro_Player
{
    public partial class CreatePlaylistForm : Form
    {
        private MainForm mainForm;
        public CreatePlaylistForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        //~CreatePlaylistForm() => MessageBox.Show("форма create уничтожена");

        private void createPlaylistButton_Click(object sender, EventArgs e)
        {
            string playlistName = playlistNameTextBox.Text;
            if (String.IsNullOrEmpty(playlistName))
            {
                MessageBox.Show("Введите название плейлиста.");
                return;
            }
            mainForm.CreatePlaylist(playlistName, out bool CreationIsCompleted);
            if (CreationIsCompleted) this.Close();
        }

        private void CreatePlaylistForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }
    }
}
