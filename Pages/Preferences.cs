using Microsoft.Win32;
using PygmyModManager.Classes;
using PygmyModManager.Internals;
using PygmyModManager.Utils;
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

namespace PygmyModManager.Pages
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
            LoadSourcesVisual();

            modMgrDisplayName.Text = Main.DisplayName != null ? Main.DisplayName : "PygmyModManager";
            prefLoadSourcesOnStartup.Checked = Main.LoadMods;

            textBox1.Text = Main.InstallDir; // install directory textbox

            switch (Main.PreferenceInstall)
            {
                case "steam":
                    steambtn.Select();
                    break;
                case "oculus":
                    oculusbtn.Select();
                    break;
                case "custom":
                    oculusbtn.Select();
                    break;
            }

            sourcesListVisual.ItemSelectionChanged += ItemSelected;
        }

        void LoadSourcesVisual()
        {
            sourcesListVisual.Clear();

            foreach (string sourceURL in SourceAgent.sources)
            {
                ListViewItem t;
                if (SourceAgent.IsTrustedSource(sourceURL))
                {
                    SourceInfo thisThing = SourceAgent.GetSourceInfo(sourceURL);
                    t = sourcesListVisual.Items.Add("[Verified] " + thisThing.Title);
                }
                else
                {
                    t = sourcesListVisual.Items.Add(sourceURL);
                }

                t.Checked = true;
                t.SubItems.Add(sourceURL);

                // add item & check it by default
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SourceAgent.sources = new List<string>();

            foreach (ListViewItem checkedItem in sourcesListVisual.CheckedItems)
            {
                SourceAgent.sources.Add(checkedItem.Text);
            }

            // (Sources) Load Sources on Startup
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\PygmyModManager", "LoadModsOnStartup", this.prefLoadSourcesOnStartup.Checked ? "YES" : "NO");

            // (Appearance) Display Name
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\PygmyModManager", "DisplayName", this.modMgrDisplayName.Text);

            string preferenceInstall = "steam";

            if (steambtn.Checked) preferenceInstall = "steam";
            if (oculusbtn.Checked) preferenceInstall = "oculus";
            if (custombutton.Checked) preferenceInstall = "custom";

            // (Gorilla Tag) Default Loaded Install
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\PygmyModManager", "PrefInstallDir", preferenceInstall);

            this.Close();
        }

        private void sourcesAddBtnVisual_Click(object sender, EventArgs e)
        {
            SourceAgent.sources.Add(sourcesAddTxtVisual.Text);
            LoadSourcesVisual();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Editor(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sources.pygmysources").ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(Main.InstallDir + @"\");
        }

        private void sourcesListVisual_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ItemSelected(object sender, EventArgs e)
        {
            if (sourcesListVisual.SelectedItems.Count == 0) return;

            new ListInspector(sourcesListVisual.SelectedItems[0].SubItems[0].Text).ShowDialog();
        }
    }
}
