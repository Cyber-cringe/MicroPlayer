namespace Micro_Player
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.playlistsBox = new Micro_Player.SlotBox();
            this.musicBox = new Micro_Player.SlotBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addSongButton = new System.Windows.Forms.Button();
            this.backToRootDirButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.currentPlaylistName = new System.Windows.Forms.Label();
            this.playerStoppedCheckerTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.createPlaylistButton = new System.Windows.Forms.Button();
            this.addSongFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // playlistsBox
            // 
            this.playlistsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistsBox.AutoScroll = true;
            this.playlistsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.playlistsBox.Location = new System.Drawing.Point(12, 40);
            this.playlistsBox.Name = "playlistsBox";
            this.playlistsBox.SelectedSlot = null;
            this.playlistsBox.Size = new System.Drawing.Size(733, 210);
            this.playlistsBox.TabIndex = 0;
            // 
            // musicBox
            // 
            this.musicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.musicBox.AutoScroll = true;
            this.musicBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.musicBox.Location = new System.Drawing.Point(12, 298);
            this.musicBox.Name = "musicBox";
            this.musicBox.SelectedSlot = null;
            this.musicBox.Size = new System.Drawing.Size(776, 378);
            this.musicBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(253, 705);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "ТЕСТ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.addSongButton);
            this.panel1.Controls.Add(this.backToRootDirButton);
            this.panel1.Location = new System.Drawing.Point(12, 252);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(94, 49);
            this.panel1.TabIndex = 0;
            // 
            // addSongButton
            // 
            this.addSongButton.BackColor = System.Drawing.Color.Black;
            this.addSongButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSongButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addSongButton.ForeColor = System.Drawing.Color.Peru;
            this.addSongButton.Location = new System.Drawing.Point(56, 5);
            this.addSongButton.Name = "addSongButton";
            this.addSongButton.Size = new System.Drawing.Size(35, 35);
            this.addSongButton.TabIndex = 1;
            this.addSongButton.Text = "+";
            this.addSongButton.UseVisualStyleBackColor = false;
            this.addSongButton.Click += new System.EventHandler(this.addSongButton_Click);
            // 
            // backToRootDirButton
            // 
            this.backToRootDirButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.backToRootDirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backToRootDirButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backToRootDirButton.ForeColor = System.Drawing.Color.Peru;
            this.backToRootDirButton.Location = new System.Drawing.Point(3, 5);
            this.backToRootDirButton.Name = "backToRootDirButton";
            this.backToRootDirButton.Size = new System.Drawing.Size(35, 35);
            this.backToRootDirButton.TabIndex = 0;
            this.backToRootDirButton.Text = "<";
            this.backToRootDirButton.UseVisualStyleBackColor = false;
            this.backToRootDirButton.Click += new System.EventHandler(this.backToRootDirButton_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(112, 705);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(12, 705);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 3;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // currentPlaylistName
            // 
            this.currentPlaylistName.AutoSize = true;
            this.currentPlaylistName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentPlaylistName.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.currentPlaylistName.Location = new System.Drawing.Point(112, 267);
            this.currentPlaylistName.Name = "currentPlaylistName";
            this.currentPlaylistName.Size = new System.Drawing.Size(65, 28);
            this.currentPlaylistName.TabIndex = 4;
            this.currentPlaylistName.Text = "label1";
            // 
            // playerStoppedCheckerTimer
            // 
            this.playerStoppedCheckerTimer.Tick += new System.EventHandler(this.playerStoppedCheckerTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Плейлисты";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.panel2.Controls.Add(this.createPlaylistButton);
            this.panel2.Location = new System.Drawing.Point(751, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(35, 210);
            this.panel2.TabIndex = 0;
            // 
            // createPlaylistButton
            // 
            this.createPlaylistButton.BackColor = System.Drawing.Color.Black;
            this.createPlaylistButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createPlaylistButton.ForeColor = System.Drawing.Color.Peru;
            this.createPlaylistButton.Location = new System.Drawing.Point(3, 3);
            this.createPlaylistButton.Name = "createPlaylistButton";
            this.createPlaylistButton.Size = new System.Drawing.Size(29, 29);
            this.createPlaylistButton.TabIndex = 7;
            this.createPlaylistButton.Text = "+";
            this.createPlaylistButton.UseVisualStyleBackColor = false;
            this.createPlaylistButton.Click += new System.EventHandler(this.createPlaylistButton_Click);
            // 
            // addSongFileDialog
            // 
            this.addSongFileDialog.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(800, 746);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentPlaylistName);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.musicBox);
            this.Controls.Add(this.playlistsBox);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private Slot slot1;
        //private Slot slot2;
        private SlotBox playlistsBox;
        private SlotBox musicBox;
        private Button button1;
        private Panel panel1;
        private Button backToRootDirButton;
        private Button button2;
        private Button button3;
        private Label currentPlaylistName;
        private System.Windows.Forms.Timer playerStoppedCheckerTimer;
        private Label label1;
        private Panel panel2;
        private Button createPlaylistButton;
        private Button addSongButton;
        private OpenFileDialog addSongFileDialog;
    }
}