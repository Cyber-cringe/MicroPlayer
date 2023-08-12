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
            this.createPlaylistButton.Location = new System.Drawing.Point(12, 45);
            this.createPlaylistButton.Name = "createPlaylistButton";
            this.createPlaylistButton.Size = new System.Drawing.Size(308, 29);
            this.createPlaylistButton.TabIndex = 0;
            this.createPlaylistButton.Text = "Создать плелист";
            this.createPlaylistButton.UseVisualStyleBackColor = true;
            this.createPlaylistButton.Click += new System.EventHandler(this.createPlaylistButton_Click);
            // 
            // playlistNameTextBox
            // 
            this.playlistNameTextBox.Location = new System.Drawing.Point(12, 12);
            this.playlistNameTextBox.Name = "playlistNameTextBox";
            this.playlistNameTextBox.Size = new System.Drawing.Size(308, 27);
            this.playlistNameTextBox.TabIndex = 1;
            // 
            // CreatePlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 90);
            this.Controls.Add(this.playlistNameTextBox);
            this.Controls.Add(this.createPlaylistButton);
            this.Name = "CreatePlaylistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание плейлисть";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button createPlaylistButton;
        private TextBox playlistNameTextBox;
    }
}