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

        public static string GatherWebContent(string URL)
        {
            var webRequest = WebRequest.Create(URL);

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                return reader.ReadToEnd();
            }
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
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sources.pygmysources"))
            {
                // sets a default file
                List<string> newFile = new();

                newFile.Add("# This is the sources file for the PygmyModManager application");
                newFile.Add("# You can make comments by using \"#\"");
                newFile.Add("");
                newFile.Add("# Blank lines with no characters will be ignored.");
                newFile.Add("# Please do not delete this file.");
                newFile.Add("");
                newFile.Add("# This is the default source for MonkeModManager");
                newFile.Add("https://raw.githubusercontent.com/The-Graze/MonkeModInfo/master/modinfo.json");

                File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sources.pygmysources", newFile);
            }

            sources = ParseSourceFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sources.pygmysources");
            
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

            return mods;
        }
    }
}
