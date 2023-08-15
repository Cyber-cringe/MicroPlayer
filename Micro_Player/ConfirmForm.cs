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

    public partial class ConfirmForm : Form
    {
        private ObjectTypes objectType;
        private string objectName; 

        public ConfirmForm(ObjectTypes objectType, string? objectName)
        {
            InitializeComponent();
            this.objectType = objectType;
            this.objectName = objectName ?? "";
        }
        //~ConfirmForm() => MessageBox.Show("пока");

        //подписываем извне делигат на события нажатия на кнопку подтверждения
        public void SubscribeToConfirmButtonClick(EventHandler act) =>ConfirmButton.Click += act;

        private void ConfirmForm_Load(object sender, EventArgs e)
        {
            string message = $"Удалить {objectType.ToString().ToLower()}: {objectName}?";
            messageLabel.Text = message;
            if(this.Width < messageLabel.Width)
            {
                this.Width = messageLabel.Width + 40;
            }  
        }

        private void ConfirmButton_Click(object sender, EventArgs e) => this.Close();

        private void CancelButton_Click_1(object sender, EventArgs e) => this.Close();

    }
}
