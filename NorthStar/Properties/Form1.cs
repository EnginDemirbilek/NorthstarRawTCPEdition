using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthStar.Properties
{
    public partial class Notes : Form
    {
        public Notes()
        {
            InitializeComponent();
        }

        private void buttonSaveNotes_Click(object sender, EventArgs e)
        {
            string a = richTextBoxNotes.Text;
        }
    }
}
