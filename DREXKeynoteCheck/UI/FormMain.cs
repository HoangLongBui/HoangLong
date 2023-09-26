using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DREXKeynoteCheck.Data;
using DREXKeynoteCheck.Service;
using DREXKeynoteCheck.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DREXKeynoteCheck.UI
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        private List<KeynoteData> m_keynoteDatas;
        private UIDocument m_uIDocument;
        private ServiceKeynote m_serviceKeynote;
        private List<SettingData> m_settingDatas;

        public FormMain(UIDocument uIDocument,
                        List<KeynoteData> keynoteDatas,
                        ServiceKeynote serviceKeynote,
                        List<SettingData> settingDatas)
        {
            InitializeComponent();
            m_uIDocument = uIDocument;
            m_keynoteDatas = keynoteDatas;
            m_serviceKeynote = serviceKeynote;
            m_settingDatas = settingDatas;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            foreach (KeynoteData element in m_keynoteDatas)
            {
                int index = dgvElement.Rows.Add(element.Category,
                                                element.Family,
                                                element.Type,
                                                element.Keynote,
                                                element.KeynoteName,
                                                element.FamilyInstances.Count,
                                                "未チェック");

                dgvElement.Rows[index].Tag = element;
            }

            //Get default setting
            string pathKeyNote = Microsoft.VisualBasic.Interaction.GetSetting(Assembly.GetExecutingAssembly().GetName().Name, "DREXKeynoteCheck", "KeyNotePath", "");
            if (File.Exists(pathKeyNote))
            {
                textLoadPath.Text = pathKeyNote;
                m_serviceKeynote.m_filePath = pathKeyNote;
                m_serviceKeynote.m_lstKeyNote = m_serviceKeynote.LoadKeynotesFromText();
                UpdateKeyNoteDataGrid();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvElement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                KeynoteData keynoteData = dgvElement.Rows[e.RowIndex].Tag as KeynoteData;
                if (keynoteData != null)
                    m_uIDocument.Selection.SetElementIds(keynoteData.FamilyInstances.Select(x => x.Id).ToList());
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.InitialDirectory = textLoadPath.Text;
            var result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                textLoadPath.Text = dlg.FileName;
                m_serviceKeynote.m_filePath = dlg.FileName;
                m_serviceKeynote.m_lstKeyNote = m_serviceKeynote.LoadKeynotesFromText();
                UpdateKeyNoteDataGrid();

                //Save saetting
                Microsoft.VisualBasic.Interaction.SaveSetting(Assembly.GetExecutingAssembly().GetName().Name, "DREXKeynoteCheck", "KeyNotePath", textLoadPath.Text);
            }
        }

        /// <summary>
        /// Update keynote datagrid
        /// </summary>
        /// <returns></returns>
        private bool UpdateKeyNoteDataGrid()
        {
            try
            {
                for (int i = 0; i < dgvElement.Rows.Count; i++)
                {
                    KeynoteData keynoteData = dgvElement.Rows[i].Tag as KeynoteData;
                    if (keynoteData != null)
                    {
                        keynoteData.KeynoteName = m_serviceKeynote.GetNameAndShiyo(keynoteData.Keynote);
                        dgvElement.Rows[i].Cells[4].Value = keynoteData.KeynoteName;

                        //Check
                        SettingData settingFind = m_settingDatas.FirstOrDefault(x => Common.ExtractMatchingString(keynoteData.KeynoteName, x.SearchName) != null);
                        if (settingFind != null)
                        {
                            string matchType = Common.ExtractMatchingString(keynoteData.KeynoteName, settingFind.SearchName).Trim();
                            string characSplit = Common.ExtractNonNumericCharacters(matchType);

                            if (settingFind.SearchName.Contains("ｘ") || settingFind.SearchName.Contains("x"))
                            {
                                string[] splitX = matchType.Split(characSplit.ToCharArray());
                                if (splitX.Length == 2)
                                {
                                    string valueW = splitX[0].Trim();
                                    string valueH = splitX[1].Trim();

                                    Parameter parameterW = null;
                                    Parameter parameterH = null;
                                    Common.GetParameterWHFromListSetting(keynoteData.FamilySymbol, settingFind.ListParamName, characSplit, ref parameterW, ref parameterH);
                                    if (parameterW != null && parameterH != null)
                                    {
                                        string valueFromParamW = Common.GetValueFromType(parameterW).ToString();
                                        string valueFromParamH = Common.GetValueFromType(parameterH).ToString();

                                        if (valueFromParamW == valueW && valueFromParamH == valueH)
                                            dgvElement.Rows[i].Cells[6].Value = "OK";
                                        else
                                            dgvElement.Rows[i].Cells[6].Value = "要素のサイズとキーノートのサイズが一致していません。" + "  {  " + parameterW.Definition.Name + ":" + valueFromParamW + "," + parameterH.Definition.Name + ":" + valueFromParamH + "  }";
                                    }
                                }
                            }
                            else if (settingFind.SearchName.Contains("H"))
                            {
                                string value = matchType.Replace(characSplit, "");
                                Parameter parameter = Common.GetParameterFromListSetting(keynoteData.FamilySymbol, settingFind.ListParamName);
                                if (parameter != null)
                                {
                                    string valueFromParam = Common.GetValueFromType(parameter).ToString();
                                    if (valueFromParam == value)
                                        dgvElement.Rows[i].Cells[6].Value = "OK";
                                    else
                                        dgvElement.Rows[i].Cells[6].Value = "要素のサイズとキーノートのサイズが一致していません。" + "  {  " + parameter.Definition.Name + ":" + valueFromParam + "  }";
                                }
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                string mess = ex.Message;
                return false;
            }
        }
    }
}