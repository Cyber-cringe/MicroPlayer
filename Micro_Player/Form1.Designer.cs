namespace Micro_Player
{
    partial class Form1
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
            slotBox1 = new SlotBox();
            slotBox2 = new SlotBox();
            SuspendLayout();
            // 
            // slotBox1
            // 
            slotBox1.AutoScroll = true;
            slotBox1.BackColor = SystemColors.ButtonFace;
            slotBox1.Location = new Point(12, 12);
            slotBox1.Name = "slotBox1";
            slotBox1.Size = new Size(776, 107);
            slotBox1.TabIndex = 0;
            // 
            // slotBox2
            // 
            slotBox2.AutoScroll = true;
            slotBox2.BackColor = SystemColors.ButtonFace;
            slotBox2.Location = new Point(12, 125);
            slotBox2.Name = "slotBox2";
            slotBox2.Size = new Size(776, 313);
            slotBox2.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(slotBox2);
            Controls.Add(slotBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Slot slot1;
        private Slot slot2;
        private SlotBox slotBox1;
        private SlotBox slotBox2;
    }
}