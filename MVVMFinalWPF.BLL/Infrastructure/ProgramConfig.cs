using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFinalWPF.BLL.Infrastructure
{
    [Serializable]
    public class ProgramConfig
    {        
        public string Language { get; set; }
        public int SelectedLanguageIndex { get; set; }

        public string Themes { get; set; }
        public int SelectedThemesIndex { get; set; }

        public ProgramConfig() { }
    }
}
