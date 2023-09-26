#region Name spaces

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DREXKeynoteCheck.Data;
using DREXKeynoteCheck.Service;
using DREXKeynoteCheck.UI;
using DREXKeynoteCheck.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

#endregion Name spaces

namespace DREXKeynoteCheck.Command
{
    [Transaction(TransactionMode.Manual)]
    public class cmdCheckKeynote : IExternalCommand
    {
        private UIDocument _uiDoc;
        private Document _doc;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            _uiDoc = uiapp.ActiveUIDocument;
            _doc = _uiDoc.Document;

            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string keynoteConfigFileName = Path.Combine(assemblyFolder, "KeynoteConfig.csv");
            if (!File.Exists(keynoteConfigFileName))
            {
                Common.ShowError("Can not find the setting!");
                return Result.Cancelled;
            }

            List<SettingData> settingDatas = GetSettingData(keynoteConfigFileName);

            FilteredElementCollector symbolCollector = new FilteredElementCollector(_doc);
            List<FamilySymbol> elementTypes = symbolCollector.WhereElementIsElementType()
                                                             .OfClass(typeof(FamilySymbol))
                                                             .OfCategory(BuiltInCategory.OST_Site)
                                                             .Cast<FamilySymbol>()
                                                             .Where(x => Common.IsSymbolHasKeynoteParam(x))
                                                             .ToList();

            List<FamilyInstance> familyInstances = new FilteredElementCollector(_doc).OfClass(typeof(FamilyInstance))
                                                                                     .Cast<FamilyInstance>()
                                                                                     .ToList();

            ServiceKeynote serviceKeynote = new ServiceKeynote("");
            List<KeynoteData> elementDatas = serviceKeynote.GetKeynoteDatas(elementTypes, familyInstances).OrderBy(x => x.Keynote).ToList();

            FormMain formMain = new FormMain(_uiDoc,
                                             elementDatas,
                                             serviceKeynote,
                                             settingDatas);
            formMain.Show();

            return Result.Succeeded;
        }

        /// <summary>
        /// Get setting data
        /// </summary>
        /// <param name="keynoteConfigFileName"></param>
        /// <returns></returns>
        private List<SettingData> GetSettingData(string keynoteConfigFileName)
        {
            try
            {
                List<SettingData> retVal = new List<SettingData>();
                string[] FileImport = System.IO.File.ReadAllLines(keynoteConfigFileName, System.Text.Encoding.GetEncoding("Shift_JIS"));

                for (int i = 1; i < FileImport.Length; i++)
                {
                    string[] split = FileImport[i].Split(',');
                    List<string> lstParamName = new List<string>();
                    for (int j = 1; j < split.Length; j++)
                    {
                        lstParamName.Add(split[j]);
                    }

                    retVal.Add(new SettingData(split[0], lstParamName));
                }

                return retVal;
            }
            catch (System.Exception ex)
            {
                string mess = ex.Message;
                return new List<SettingData>();
            }
        }
    }
}