using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DREXKeynoteCheck.Data
{
    public class SettingData
    {
        public string SearchName { get; set; }

        public List<string> ListParamName { get; set; }

        public SettingData(string searchName, List<string> listParamName)
        {
            SearchName = searchName;
            ListParamName = listParamName;
        }
    }
}