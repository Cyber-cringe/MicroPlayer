namespace Micro_Player
{
    partial class CreatePlaylistForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createPlaylistButton = new System.Windows.Forms.Button();
            this.playlistNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // createPlaylistButton
            // 
            this.createPlaylistButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createPlaylistButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.createPlaylistButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createPlaylistButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.createPlaylistButton.Location = new System.Drawing.Point(12, 47);
            this.createPlaylistButton.Name = "createPlaylistButton";
            this.createPlaylistButton.Size = new System.Drawing.Size(333, 29);
            this.createPlaylistButton.TabIndex = 0;
            this.createPlaylistButton.Text = "Создать плелист";
            this.createPlaylistButton.UseVisualStyleBackColor = false;
            this.createPlaylistButton.Click += new System.EventHandler(this.createPlaylistButton_Click);
            // 
            // playlistNameTextBox
            // 
            this.playlistNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.playlistNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playlistNameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.playlistNameTextBox.Location = new System.Drawing.Point(12, 12);
            this.playlistNameTextBox.Name = "playlistNameTextBox";
            this.playlistNameTextBox.PlaceholderText = "Название плейлиста";
            this.playlistNameTextBox.Size = new System.Drawing.Size(333, 27);
            this.playlistNameTextBox.TabIndex = 1;
            // 
            // CreatePlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(357, 88);
            this.Controls.Add(this.playlistNameTextBox);
            this.Controls.Add(this.createPlaylistButton);
            this.MinimumSize = new System.Drawing.Size(200, 135);
            this.Name = "CreatePlaylistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание плейлиста";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button createPlaylistButton;
        private TextBox playlistNameTextBox;
    }
}