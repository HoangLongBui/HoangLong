using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DREXKeynoteCheck.Data
{
    public class KeynoteData
    {
        public string Category { get; set; }
        public string Family { get; set; }
        public string Type { get; set; }
        public string Keynote { get; set; }
        public string KeynoteName { get; set; }
        public string NumberOfPlacements { get; set; }
        public string SizeConfirmationResult { get; set; }

        public FamilySymbol FamilySymbol { get; set; }

        public List<FamilyInstance> FamilyInstances { get; set; }
    }
}