using Microsoft.Win32;
using PygmyModManager.Classes;
using PygmyModManager.Internals;
using PygmyModManager.Internals.SimpleJSON;
using PygmyModManager.UtilForms;
using PygmyModManager.Utils;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace PygmyModManager
{
    public partial class Main : Form
    {
        public static List<ReleaseInfo> Mods = new();
        public static string DisplayName = "BinxModManager";
        public static bool LoadMods = true;
        public static bool UseGithub = true;
        public static string PreferenceInstall = "steam";

        public static string InstallDir = @"";

        public static bool EnableLogging = false;

        public enum ReturnType {
            String = 1,
            Bool = 2,
        }

        public object LoadRegistryValue(string regPath, string regKey, object defaultValue, ReturnType _returnType)
        {
            object regValue = null;
            
            switch (_returnType)
            {
                case (ReturnType.Bool):
                    string reg = (string)Registry.GetValue(regPath, regKey, defaultValue)

                    if (reg != null)
                        regValue = (reg == "YES");
                    else
                        regValue = defaultValue;

                    break;
                case (ReturnType.String):
                    string reg = (string)Registry.GetValue(regPath, regKey, defaultValue)

                    if (reg != null)
                        regValue = reg;
                    else
                        regValue = defaultValue;

                    break;
                default:
                    throw new Exception("no recognized return type was provided");
            }

            return regValue;
        }
        
        public Main()
        {
            InitializeComponent();

            quitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;

            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;

            preferencesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;

            LoadMods = LoadRegistryValue(@"HKEY_CURRENT_USER\SOFTWARE\KingBingus\ModManager", "LoadModsOnStartup", "YES", ReturnType.Bool);
            UseGitHub = LoadRegistryValue(@"HKEY_CURRENT_USER\SOFTWARE\KingBingus\ModManager", "UseGithubAPI", "YES", ReturnType.Bool);
            DisplayName = LoadRegistryValue(@"HKEY_CURRENT_USER\SOFTWARE\KingBingus\ModManager", "DisplayName", "BinxModManager", ReturnType.String);
            PreferenceInstall = LoadRegistryValue(@"HKEY_CURRENT_USER\SOFTWARE\KingBingus\ModManager", "PrefInstallDir", "steam", ReturnType.String);

            if (LoadMods)
                Mods = SourceAgent.GatherSources();

            RenderMods();

            InstallDir = FindGorillaTag.GetLocation(PreferenceInstall);

            this.Text = DisplayName;
        }

        private void searchBox_TextChanged(object sender, EventArgs e) => RenderMods();

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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) =>
            new About().ShowDialog();

        private void discordToolStripMenuItem_Click(object sender, EventArgs e) =>
            try { Process.Start("https://discord.gg/monkemod"); } catch (Exception) { }
            ;

        private void binxDiscordToolStripMenuItem_Click(object sender, EventArgs e) =>
            try { Process.Start("https://discord.gg/NtjvNHAbUj"); } catch (Exception) { }
            ;

        private void quitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void cutToolStripMenuItem_Click(object sender, EventArgs e) => this.searchBox.Cut();
        private void copyToolStripMenuItem_Click(object sender, EventArgs e) => this.searchBox.Copy();
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) => this.searchBox.Paste();

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Pages.Preferences().ShowDialog();
            RenderMods();
        }

        private void textEditorToolStripMenuItem_Click(object sender, EventArgs e) => new Editor().Show();

        private void bepInExConfigToolStripMenuItem_Click(object sender, EventArgs e) =>
            new Editor(Path.Combine(Main.InstallDir, @"BepInEx\config\BepInEx.cfg")).ShowDialog();

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Installer.InstallMods(modView.CheckedItems, InstallDir, UseGithub);
            button1.Enabled = true;
        }
    }
}
