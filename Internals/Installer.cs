using PygmyModManager.Classes;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PygmyModManager.Internals
{
    public class Installer
    {
        public static ReleaseInfo GetReleaseInfoFromMod(string modName)
        {
            foreach (ReleaseInfo mod in Main.Mods)
            {
                if (mod.Name == modName)
                    return mod;
            }

            return null;
        }

        public static byte[] DownloadFile(string url)
        {
            return new WebClient().DownloadData(url);
        }

        public static void InstallMods(ListView.CheckedListViewItemCollection items2Install, string InstallDir)
        {
            /*
                MIT License

                Copyright (c) 2021 Steven 🎀

                Permission is hereby granted, free of charge, to any person obtaining a copy
                of this software and associated documentation files (the "Software"), to deal
                in the Software without restriction, including without limitation the rights
                to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                copies of the Software, and to permit persons to whom the Software is
                furnished to do so, subject to the following conditions:

                The above copyright notice and this permission notice shall be included in all
                copies or substantial portions of the Software.

                THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
                SOFTWARE.
            */

            foreach (ListViewItem itemToInstall in items2Install)
            {
                ReleaseInfo modInfo = GetReleaseInfoFromMod(itemToInstall.Text);
                if (modInfo == null) continue;

                byte[] content = null;

                try
                {
                    content = DownloadFile(modInfo.Link);
                } catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    continue;
                }

                if (content == null) continue;

                string fileName = Path.GetFileName(modInfo.Link);

                if (Path.GetExtension(fileName).Equals(".dll"))
                {
                    string path = Path.Combine(InstallDir, @"BepInEx\plugins", fileName);

                    if (File.Exists(path))
                        File.Delete(path);

                    File.WriteAllBytes(path, content);
                    
                } else if (Path.GetExtension(fileName).Equals(".zip")) {
                    using (MemoryStream ms = new MemoryStream(content))
                    {
                        using (var unzip = new Unzip(ms))
                        {
                            unzip.ExtractToDirectory((modInfo.InstallLocation != null) ? Path.Combine(InstallDir, modInfo.InstallLocation) : InstallDir);
                        }
                    }
                }
            }
        }
    }
}
