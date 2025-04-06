using PygmyModManager.Classes;
using PygmyModManager.Internals.SimpleJSON;
using System.Diagnostics;
using System.Net;

namespace PygmyModManager.Internals
{
    public class SourceAgent
    {
        static List<string> sources = new();

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

        public static List<ReleaseInfo> GatherSources()
        {
            try {
                sources = new List<string>(File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\sources.pygmysources"));
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
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
                    ReleaseInfo release = new ReleaseInfo(current["name"], current["author"], current["version"], current["group"], current["download_url"], current["install_location"], current["git_path"], current["dependencies"].AsArray);
                    mods.Add(release);
                }
            }

            return mods;
        }
    }
}
