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
    public partial class AddSongForm : Form
    {
        private MainForm mainForm;
        private string[]? playlists;
        private string songPath;
        public AddSongForm(MainForm mainForm, string[]? playlists, string songPath)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.playlists = playlists;
            this.songPath = songPath;
        }
        //~AddSongForm() => MessageBox.Show("Destricted");

        private void AddSongForm_Load(object sender, EventArgs e)
        {
            playlistslistBox.DataSource = playlists;
            playlistslistBox.SelectedItem = null;
        }

        private void confirmAdditionButton_Click(object sender, EventArgs e)
        {
            string? selectedPlaylist = playlistslistBox?.SelectedItem?.ToString();
            if(selectedPlaylist == null)
            {
                MessageBox.Show("Выберите плейлист, чтобы добавить музыку.");
                return;
            }
            mainForm.AddSoundToPlaylist(selectedPlaylist, songPath);
            Close();
        }
    }
}
