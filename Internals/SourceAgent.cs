using PygmyModManager.Classes;
using PygmyModManager.Internals.SimpleJSON;
using PygmyModManager.Properties;
using System.Diagnostics;
using System.Net;

namespace PygmyModManager.Internals
{
    public class SourceAgent
    {
        public static List<string> sources = new();
        public static List<SourceInfo> TrustSourceList = new();

        public static string Repo_API_Endpoint = "";
        public static string Pygmy_API_Endpoint = "";

        public static string GatherWebContent(string URL)
        {
            HttpWebRequest RQuest = (HttpWebRequest)HttpWebRequest.Create(URL);
            RQuest.Method = "GET";
            RQuest.KeepAlive = true;
            RQuest.UserAgent = "Monke-Mod-Manager";

            HttpWebResponse Response = (HttpWebResponse)RQuest.GetResponse();
            StreamReader Sr = new StreamReader(Response.GetResponseStream());
            string Code = Sr.ReadToEnd();
            Sr.Close();
            return Code;

            /*
            var webRequest = WebRequest.Create(URL);

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                return reader.ReadToEnd();
            }
            */
        }

        public static bool IsTrustedSource(string URL)
        {
            foreach (SourceInfo src in TrustSourceList)
            {
                if (src.Link == URL)
                {
                    return true;
                }
            }

            return false;
        }

        public static SourceInfo GetSourceInfo(string URL)
        {
            foreach (SourceInfo src in TrustSourceList)
            {
                if (src.Link == URL)
                {
                    return src;
                }
            }

            return null;
        }

        public static List<ReleaseInfo> GatherSources()
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sources.txp"))
            {
                // sets a default file
                List<string> newFile = new();

                newFile.Add("# This is the sources file for Binx's Mod Manager");
                newFile.Add("# You can make comments by using \"#\"");
                newFile.Add("# Everything's in Txt++ format");
                newFile.Add("");
                newFile.Add("# To put the default MMM list, add a line that says $default");
                newFile.Add("");
                newFile.Add("https://raw.githubusercontent.com/The-Graze/MonkeModInfo/master/modinfo.json");

                File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sources.txp", newFile);
            }

            TextPlusPlus.DeclareVariable("default", "https://raw.githubusercontent.com/The-Graze/MonkeModInfo/master/modinfo.json");
            // $default ^^^^

            int success;
            string errorMsg;

            sources, success, errorMsg = TextPlusPlus.ParseSourceFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sources.txp");
            
            if (success == 0) {
                if (sources.Count == 0)
                {
                    sources.Add("https://raw.githubusercontent.com/The-Graze/MonkeModInfo/master/modinfo.json");
                }

                List<ReleaseInfo> mods = new();
                
                foreach (string sourceURL in sources)
                {
                    var decodedMods = JSON.Parse(GatherWebContent(sourceURL));
                    var allMods = decodedMods.AsArray;

                    for (int i = 0; i < allMods.Count; i++)
                    {
                        JSONNode current = allMods[i];
                        ReleaseInfo release = new ReleaseInfo(current["name"], current["author"], current["group"], current["download_url"], current["install_location"], current["git_path"], current["dependencies"].AsArray);
                        mods.Add(release);
                    }
                }

                // trusted source info
                var srclist = JSON.Parse(GatherWebContent("https://raw.githubusercontent.com/sirkingbinx/PygmyModManager/refs/heads/master/trusted_sources.json"));
                var allSrc = srclist.AsArray;

                var thisCurrent = allSrc[0];
                Pygmy_API_Endpoint = "https://api.github.com/repos/sirkingbinx/PygmyModManager/";
                Repo_API_Endpoint = "https://api.github.com/repos/";

                for (int i = 0; i < allSrc.Count; i++)
                {
                    JSONNode current = allSrc[i];
                    SourceInfo release = new SourceInfo(current["title"], current["link"]);
                    TrustSourceList.Add(release);
                }

                return mods;
            } else {
                MessageBox.Show(errorMsg, "Error parsing sources.txp", MessageBoxButtons.OK, MessageBoxIcons.Error);
                Application.Exit();
            }
        }
    }
}
