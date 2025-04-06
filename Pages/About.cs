using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PygmyModManager.UtilForms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/sirkingbinx/PygmyModManager");
        }

        private void About_Load(object sender, EventArgs e)
        {
            this.Text = "About " + Main.DisplayName;
            this.displayNameLabel.Text = Main.DisplayName;
        }
    }
}
