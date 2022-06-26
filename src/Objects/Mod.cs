using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtDMMAdonis.src.Objects {
    public class Mod {
        public string modURL { get; set; }
        public DateTime modCreatedTime { get; set; }
        public DateTime modLastUpdatedTime { get; set; }
        public string modName { get; set; }
        public string[] modImages { get; set; }
        public string modShortDescription { get; set; }
        public string modDescription { get; set; }
        public ModDownload[] modDownloadURLs { get; set; }
        public bool modPotentialyOutdated { get; set; }
        public string[] modAuthors { get; set; }
        public string[] modTags { get; set; }

    }
}
