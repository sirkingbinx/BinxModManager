using Microsoft.Win32;
using PygmyModManager.Classes;
using PygmyModManager.Internals;
using PygmyModManager.UtilForms;
using PygmyModManager.Utils;
using System.Diagnostics;
using System.Reflection;

namespace PygmyModManager
{
    public partial class Main : Form
    {
        public static List<ReleaseInfo> Mods = new();
        public static string DisplayName;
        public static bool LoadMods;
        public static string PreferenceInstall = "steam";

        public static string InstallDir = @"";

        public Main()
        {
            InitializeComponent();

            quitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;

            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;

            preferencesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;

            // load reg values
            try
            {
                LoadMods = ((string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\KingBingus\ModManager", "LoadModsOnStartup", "YES") == "YES");
            }
            catch (Exception _)
            {
                LoadMods = true;
            }

            try
            {
                DisplayName = (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\KingBingus\ModManager", "DisplayName", null);
            }
            catch (Exception _)
            {
                DisplayName = "Binx's Mod Manager";
            }

            try
            {
                PreferenceInstall = (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\KingBingus\ModManager", "PrefInstallDir", "steam");
            }
            catch (Exception _)
            {
                PreferenceInstall = "steam";
            }

            if (LoadMods)
                Mods = SourceAgent.GatherSources();
                RenderMods();

            InstallDir = FindGorillaTag.GetLocation(PreferenceInstall);

            this.Text = DisplayName;
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            RenderMods();
        }

        public void AssignGroupToMod(ReleaseInfo mod, ListViewItem item)
        {
            foreach (ListViewGroup lvGroup in modView.Groups)
            {
                if (mod.Group.ToLower().Contains(lvGroup.Header.ToLower()))
                {
                    item.Group = lvGroup;
                    break;
                }
            }

            ListViewGroup thisBrandNewGroup = new();
            modView.Groups.Add(thisBrandNewGroup);

            thisBrandNewGroup.Header = mod.Group;
        }

        public void RenderMods()
        {
            modView.Items.Clear();

            string searchQuery = searchBox.Text.ToLower();

            foreach (ReleaseInfo thisMod in Mods)
            {
                if (!thisMod.Name.ToLower().StartsWith(searchQuery)) { continue; }

                ListViewItem assignedItem = modView.Items.Add(thisMod.Name);
                assignedItem.SubItems.Add(thisMod.Author);

                AssignGroupToMod(thisMod, assignedItem);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void discordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/monkemod");
        }

        private void binxDiscordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/binx");
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.searchBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.searchBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.searchBox.Paste();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Pages.Preferences().ShowDialog();
            RenderMods();
        }

        private void textEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Utils.Editor().Show();
        }

        private void bepInExConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Editor(Path.Combine(Main.InstallDir, @"BepInEx\config\BepInEx.cfg")).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Installer.InstallMods(modView.CheckedItems, InstallDir);
            button1.Enabled = true;
        }
    }
}
