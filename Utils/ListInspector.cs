using PygmyModManager.Classes;
using PygmyModManager.Internals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PygmyModManager.Utils
{
    public partial class ListInspector : Form
    {
        public ListInspector(string listURL = "")
        {
            InitializeComponent();

            if (listURL != "")
            {
                LoadURL(listURL);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowAllTheThings(bool show)
        {
            listTitle.Visible = show;
            listAuthor.Visible = show;
            listDescription.Visible = show;
            listDescriptionLabel.Visible = show;
        }

        public void LoadURL(string URL)
        {
            ShowAllTheThings(false);

            if (SourceAgent.IsTrustedSource(URL))
            {
                SourceInfo t = SourceAgent.GetSourceInfo(URL);
                listTitle.Text = t.Title;
                listAuthor.Text = "by " + t.Author;
                listDescription.Text = t.Description;
            }
            else
            {
                listTitle.Text = Path.GetFileNameWithoutExtension(URL);
                listAuthor.Text = "by Unknown";
                listDescription.Text = "This is an unknown list, so we aren't sure what this is.";
            }

            ShowAllTheThings(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadURL(textBox1.Text);
        }
    }
}
