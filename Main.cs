using PygmyModManager.Classes;
using PygmyModManager.Internals;
using PygmyModManager.UtilForms;
using System.Diagnostics;
using System.Reflection;

namespace PygmyModManager
{
    public partial class Main : Form
    {
        public List<ReleaseInfo> Mods = new();

        public Main()
        {
            InitializeComponent();

            quitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;

            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;

            preferencesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;

            Mods = SourceAgent.GatherSources();

            RenderMods();

            this.Text = "PygmyModManager";
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            RenderMods();
        }

        public ListViewGroup GrabLVGroupFromString(string group)
        {
            foreach (ListViewGroup lvGroup in modView.Groups)
            {
                if (lvGroup.Name == group)
                    return lvGroup; break;
            }

            return null;
        }

        public void RenderMods()
        {
            modView.Clear();

            string searchQuery = searchBox.Text.ToLower();

            foreach (ReleaseInfo thisMod in Mods)
            {
                if (thisMod.Name.ToLower().Contains(searchQuery))
                {
                    ListViewItem assignedItem = new ListViewItem(thisMod.Name);
                    modView.Items.Add(assignedItem);

                    if (GrabLVGroupFromString(thisMod.Group) != null)
                    {
                        assignedItem.Group = GrabLVGroupFromString(thisMod.Group);
                    }
                    else
                    {
                        ListViewGroup nGroup = new ListViewGroup(thisMod.Group);
                        modView.Groups.Add(nGroup);
                    }

                    assignedItem.SubItems.Add(thisMod.Author);
                }
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
    }
}
