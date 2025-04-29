using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Text;

namespace PygmyModManager.Internals
{
    public class TextPlusPlus
    {
        private static bool LineContainsCharacters(string line)
        {
            string validChars = "abcdefghijklmnopqrstuvwxyz123456789$";

            foreach (char c in line)
            {
                if (!validChars.ToLower().Contains(c))
                    return false; break;
            }

            return true;
        }

        private static Dictionary<string, string> Variables = new();

        public static void DefineVariable(string name, string value) => Variables.Add(name, value);

        public static string ParseLineForVariables(string line)
        {
            string nl = line;

            if (line.Contains("$"))
            {
                string thisVarName = "";

                for (int idx = line.IndexOf("$") + 1 /* skips the $ */; idx < line.Length; idx++)
                {
                    // remember your raw C syntax folks!
                    // "" = string
                    // '' = char

                    if (line[idx] != ' ')
                        thisVarName += line[idx];
                    else
                        break;
                }

                if (Variables.ContainsKey(thisVarName))
                    nl.Replace($"${thisVarName}", Variables[thisVarName]);
            }

            return nl;
        }

        public static List<string> ParseSourceFile(string path)
        {
            List<string> fileLiteral = new List<string>(File.ReadAllLines(path));
            List<string> literalContents = new();

            foreach (string line in fileLiteral)
            {
                if (LineContainsCharacters(line))
                    literalContents.Add(ParseLineForVariables(line));
            }

            return literalContents;
        }
    }
}
