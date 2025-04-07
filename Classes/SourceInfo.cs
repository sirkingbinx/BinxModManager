using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://raw.githubusercontent.com/sirkingbinx/PygmyModManager/refs/heads/master/trusted_sources.json

namespace PygmyModManager.Classes
{
    public class SourceInfo(string _title, string _author, string _description, string _link)
    {
        public string Title = _title;
        public string Author = _author;
        public string Description = _description;
        public string Link = _link;
    }
}
