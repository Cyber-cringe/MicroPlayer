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
            this.playlistsBox = new Micro_Player.SlotBox();
            this.musicBox = new Micro_Player.SlotBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backToRootDirButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.currentPlaylistName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playlistsBox
            // 
            this.playlistsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistsBox.AutoScroll = true;
            this.playlistsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.playlistsBox.Location = new System.Drawing.Point(12, 12);
            this.playlistsBox.Name = "playlistsBox";
            //this.playlistsBox.selectedSlot = null;
            this.playlistsBox.Size = new System.Drawing.Size(776, 170);
            this.playlistsBox.TabIndex = 0;
            // 
            // musicBox
            // 
            this.musicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.musicBox.AutoScroll = true;
            this.musicBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.musicBox.Location = new System.Drawing.Point(12, 250);
            this.musicBox.Name = "musicBox";
            //this.musicBox.selectedSlot = null;
            this.musicBox.Size = new System.Drawing.Size(776, 384);
            this.musicBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(253, 649);
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
            this.panel1.Controls.Add(this.backToRootDirButton);
            this.panel1.Location = new System.Drawing.Point(12, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(94, 49);
            this.panel1.TabIndex = 0;
            // 
            // backToRootDirButton
            // 
            this.backToRootDirButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.backToRootDirButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backToRootDirButton.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backToRootDirButton.ForeColor = System.Drawing.Color.Teal;
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
            this.button2.Location = new System.Drawing.Point(112, 649);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 649);
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
            this.currentPlaylistName.Location = new System.Drawing.Point(112, 219);
            this.currentPlaylistName.Name = "currentPlaylistName";
            this.currentPlaylistName.Size = new System.Drawing.Size(65, 28);
            this.currentPlaylistName.TabIndex = 4;
            this.currentPlaylistName.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(800, 707);
            this.Controls.Add(this.currentPlaylistName);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.musicBox);
            this.Controls.Add(this.playlistsBox);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Opacity = 0.99D;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Slot slot1;
        private Slot slot2;
        private SlotBox playlistsBox;
        private SlotBox musicBox;
        private Button button1;
        private Panel panel1;
        private Button backToRootDirButton;
        private Button button2;
        private Button button3;
        private Label currentPlaylistName;
    }
}