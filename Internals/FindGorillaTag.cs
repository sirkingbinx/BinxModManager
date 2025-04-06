using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PygmyModManager.Internals
{
    public class FindGorillaTag
    {
        /*
         * Some of this code is refactored code from original MMM so I felt I had to give credit to it
         * BTW whoever ends up managing MMM in the long run PLEASE make the switch to storing your path
         * in the registry instead of .txt files
         * 
         * Yes it is incredibly refactored and you almost can't recognize it but I'd rather add an extra
         * license to the source than get the repo taken down for not doing that
         * 
         * - binx
          
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

        public static string TrySteam()
        {
            string steamL = GetSteamLocation();

            if (Directory.Exists(steamL)) {
                return steamL;
            } else
            {
                if (Directory.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Gorilla Tag"))
                {
                    return "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Gorilla Tag";
                }
            }

            return "";
        }

        public static string TryOculus()
        {
            // Oculus

            // path to install dir is HKEY_CURRENT_USER\SOFTWARE\Oculus VR, LLC\Oculus\Libraries\7d86f29a-10d1-4d60-abca-7e96666fda76 OriginalPath
            // it returns the first software, equiv to C:\Program Files\Oculus\Software

            string oculusL = GetOculusLocation();

            if (Directory.Exists(oculusL))
            {
                return oculusL;
            } else
            {
                if (Directory.Exists(@"C:\Program Files\Oculus\Software\Software\another-axiom-gorilla-tag"))
                {
                    return @"C:\Program Files\Oculus\Software\Software\another-axiom-gorilla-tag";
                }
            }

            return "";
        }

        public static string TryCustom()
        {
            string customL = GetCustomLocation();

            if (Directory.Exists(customL))
            {
                return customL;
            }

            return "";
        }

        public static string GetLocation(string preference = "steam")
        {
            string r = "";

            switch (preference)
            {
                case "steam":
                    r = TrySteam();
                    break;
                case "oculus":
                    r = TryOculus();
                    break;
                case "custom":
                    r = TryCustom();
                    break;
            }

            if (r != null)
            {
                return r;
            } else
            {
                OpenFileDialog thing = new();
                thing.Title = "Select Gorilla Tag.exe";

                DialogResult selectIt = thing.ShowDialog();
                if (selectIt == DialogResult.Cancel) Application.Exit();

                if (thing.SafeFileName == "Gorilla Tag.exe")
                {
                    return Path.GetDirectoryName(thing.FileName);
                } else
                {
                    MessageBox.Show("The file was not Gorilla Tag.exe. Reopen and try again?", "That's not Gorilla Tag!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }

            return "";
        }

        private static string GetSteamLocation()
        {
            return (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 1533390", "InstallLocation", "");
        }

        private static string GetOculusLocation()
        {
            string p = (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Oculus VR, LLC\Oculus\Libraries\7d86f29a-10d1-4d60-abca-7e96666fda76", "OriginalPath", "");
            
            if (p != "")
                return p + @"\Software\another-axiom-gorilla-tag";

            return "";
        }

        private static string GetCustomLocation()
        {
            return (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\PygmyModManager", "LocalUserGTPath", "");
        }
    }
}
