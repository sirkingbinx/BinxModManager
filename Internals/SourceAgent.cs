using BinxModManager.Classes;
using BinxModManager.Internals.SimpleJSON;
using BinxModManager.Properties;
using System.Diagnostics;
using System.Net;

namespace BinxModManager.Internals
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

        public static bool LineContainsCharacters(string line)
        {
            string validChars = "abcdefghijklmnopqrstuvwxyz123456789";

            foreach (char c in line)
            {
                if (line.ToLower().Contains(c))
                    return true; break;
            }

            return false;
        }

        public static List<string> ParseSourceFile(string path)
        {
            List<string> fileLiteral = new List<string>(File.ReadAllLines(path));
            List<string> literalContents = new();

            foreach (string line in fileLiteral)
            {
                if (LineContainsCharacters(line) && 
                    (line.StartsWith("http://") || line.StartsWith("https://"))
                )
                {
                    literalContents.Add(line);
                }
            }

            return literalContents;
        }

        public static List<ReleaseInfo> GatherSources()
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sources.atxt"))
            {
                // sets a default file
                List<string> newFile = new();

                newFile.Add("# This is the sources file for Binx's Mod Manager");
                newFile.Add("# You can make comments by using \"#\"");
                newFile.Add("");
                newFile.Add("https://raw.githubusercontent.com/The-Graze/MonkeModInfo/master/modinfo.json");

                File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sources.atxt", newFile);
            }

            sources = ParseSourceFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sources.atxt");
            
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
            var srclist = JSON.Parse(GatherWebContent("https://raw.githubusercontent.com/sirkingbinx/BinxModManager/refs/heads/master/trusted_sources.json"));
            var allSrc = srclist.AsArray;

            var thisCurrent = allSrc[0];
            Pygmy_API_Endpoint = "https://api.github.com/repos/sirkingbinx/BinxModManager/";
            Repo_API_Endpoint = "https://api.github.com/repos/";

            for (int i = 0; i < allSrc.Count; i++)
            {
                JSONNode current = allSrc[i];
                SourceInfo release = new SourceInfo(current["title"], current["link"]);
                TrustSourceList.Add(release);
            }

            return mods;
        }
    }
}
