using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUBTimeManagementApp.GUI {
    public partial class MessageForm : Form {
        public MessageForm(string text1, string text2) {
            InitializeComponent();
            textBox1.Text = text1;
            textBox2.Text = text2;
        }

        private void closeButton_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
