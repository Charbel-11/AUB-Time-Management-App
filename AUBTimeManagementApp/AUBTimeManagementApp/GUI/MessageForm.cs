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
        /// <summary>
        /// Opens the form and displays text1 as a title and text2 as a message
        /// </summary>
        /// <param name="text1">The title</param>
        /// <param name="text2">The message</param>
        public MessageForm(string text1, string text2) {
            InitializeComponent();
            textBox1.Text = text1;
            textBox2.Text = text2;
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        private void closeButton_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
