using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace DREXKeynoteCheck.Utils
{
    internal class Common
    {
        /// <summary>
        /// Show information to user
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void ShowInfor(string message, string title = "情報")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Show warning to user
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void ShowWarning(string message, string title = "警告")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Show error to user
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void ShowError(string message, string title = "エラー")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Is symbol has parameter keynote
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static bool IsSymbolHasKeynoteParam(FamilySymbol symbol)
        {
            Parameter parameter = symbol.get_Parameter(BuiltInParameter.KEYNOTE_PARAM);

            if (parameter != null)
            {
                if (parameter.AsString() != null && parameter.AsString().Trim() != string.Empty)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Extract matching string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static string ExtractMatchingString(string input, string pattern)
        {
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            if (matches.Count > 0)
                return matches[0].Value;
            else
                return null;
        }

        /// <summary>
        /// Extract nonnumeric character
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ExtractNonNumericCharacters(string input)
        {
            Regex regex = new Regex(@"[^0-9\s]+");

            Match match = regex.Match(input);

            if (match.Success)
                return match.Value;
            else
                return null;
        }

        /// <summary>
        /// Get parameter from list setting
        /// </summary>
        /// <param name="familySymbol"></param>
        /// <param name="lstParamName"></param>
        /// <returns></returns>
        public static Parameter GetParameterFromListSetting(FamilySymbol familySymbol, List<string> lstParamName)
        {
            foreach (var paramName in lstParamName)
            {
                Parameter param = familySymbol.LookupParameter(paramName);
                if (param != null)
                    return param;
            }

            return null;
        }

        /// <summary>
        /// Get parameter width height from setting
        /// </summary>
        /// <param name="familySymbol"></param>
        /// <param name="lstParamName"></param>
        /// <param name="characSplit"></param>
        /// <param name="parameterW"></param>
        /// <param name="parameterH"></param>
        public static void GetParameterWHFromListSetting(FamilySymbol familySymbol,
                                                         List<string> lstParamName,
                                                         string characSplit,
                                                         ref Parameter parameterW,
                                                         ref Parameter parameterH)
        {
            foreach (var paramName in lstParamName)
            {
                string[] splitX = paramName.Split(characSplit.ToCharArray());

                if (splitX.Length == 2)
                {
                    string valueW = splitX[0].Trim();
                    string valueH = splitX[1].Trim();

                    Parameter paramW = familySymbol.LookupParameter(valueW);
                    Parameter paramH = familySymbol.LookupParameter(valueH);
                    if (paramW != null && paramH != null)
                    {
                        parameterW = paramW;
                        parameterH = paramH;
                        break;
                    }
                }
            }
        }

        public static double GetValueFromType(Parameter parameter)
        {
            if (parameter != null && parameter.StorageType == StorageType.Double)
            {
                return UnitUtils.ConvertFromInternalUnits(parameter.AsDouble(), DisplayUnitType.DUT_MILLIMETERS);
            }

            return double.MinValue;
        }
    }
}