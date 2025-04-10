using System;

namespace PygmyModManager.Internals {
    public class TextPlusPlus {
        #region Comments
        /*
        cool format for config files
        
        this is a WIP thing but i'll do a lot more with it in the future
        file extension .txp
        */

        #endregion
        #region Checks

        private static bool LineContainsCharacters(string line)
        {
            string validChars = "abcdefghijklmnopqrstuvwxyz123456789";

            foreach (char c in line)
            {
                if (line.ToLower().Contains(c))
                    return true; break;
            }

            return false;
        }

        #endregion
        #region Var handling

        Dictionary<string, string> vars = new();

        public static void DeclareVariable(string name, object defaultValue)
        {
            vars.Add(name, defaultValue.ToString());
        }

        private static bool IsVar(string thing) { return vars.ContainsKey(thing); }
        private static string GrabVar(string thing) { return vars[thing]; }

        #endregion
        #region Parsing

        private void IsSpecialCharacter(char character) {
            string specialChars = "$= ";

            foreach (char specialC in specialChars) {
                if (character == specialC) return true;
            }

            return false;
        }

        // in this case, it returns:
        // Literal line contents (if success), error (0 = no, 1 = yes), error info ("Success" if no errors)
        public static (List<string>, int, string) ParseSourceFile(string path)
        {
            List<string> fileLiteral = new List<string>(File.ReadAllLines(path));
            List<string> literalContents = new();

            for (int i = 0; i < fileLiteral.Count; i++)
            {
                string line = fileLiteral[i];
                string visualLine = (i + 1).ToString();

                bool gatheringVarDetails = false;
                string varNameCurrent = "";

                if (LineContainsCharacters(line)) {
                    string literalMeaning = "";

                    foreach (char tc in line) do {
                        // vars (get)
                        if (IsSpecialCharacter(tc) && tc == "$" && gatheringVarDetails == false) {
                            gatheringVarDetails = true;
                            varNameCurrent = "";
                        }

                        // space
                        if (IsSpecialCharacter(tc) && tc == " ") {
                            if (gatheringVarDetails) {
                                gatheringVarDetails = false;

                                if (IsVar(varNameCurrent)) {
                                literalMeaning += GrabVar(varNameCurrent);
                                } else {
                                    if (varNameCurrent == "") 
                                        return (new List<string>(), 1, $"(txp) Line {visualLine}: GET Variable name cannot be empty or blank. Did you forget to add the name?");
                                    else
                                        return (new List<string>(), 1, $"(txp) Line {visualLine}: Undefined variable {varNameCurrent}. Check docs for correct vars?");
                                
                                }
                            }
                        }

                        if (!IsSpecialCharacter(tc) && gatheringVarDetails == false)
                            literalMeaning += tc;
                        
                        if (!IsSpecialCharacter(tc) && gatheringVarDetails == true)
                            varNameCurrent += tc;
                    }

                    literalContents.Add(literalMeaning);
                }
            }

            return (literalContents, 0, "Success");
        }

        #endregion
    }
}