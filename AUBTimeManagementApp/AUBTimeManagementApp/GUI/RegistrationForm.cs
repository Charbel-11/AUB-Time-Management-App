using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUBTimeManagementApp.GUI
{
    public partial class RegistrationForm : Form
    {
        Form2 parent;
        public RegistrationForm(Form2 _parent)
        {
            parent = _parent;
            InitializeComponent();
        }
    }
}
