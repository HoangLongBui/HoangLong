using Autodesk.Revit.DB;
using DREXKeynoteCheck.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DREXKeynoteCheck.Service
{
    public class ServiceKeynote
    {
        public List<Keynote> m_lstKeyNote;
        public string m_filePath;

        public ServiceKeynote(string filePath)
        {
            m_filePath = filePath;
            if (File.Exists(m_filePath))
                m_lstKeyNote = LoadKeynotesFromText();
        }

        public string GetNameAndShiyo(string keynote)
        {
            //// 第1第2階層は空文字でよい
            //if (IsFirstLevel(keynote) || IsSecondLevel(keynote))
            //    return "";
            //else if (IsThirdLevel(keynote))
            //    return ThirdLevelName(keynote);
            //else
            //    return ThirdLevelName(keynote) + "-" + FourthLevelName(keynote);

            if (IsFirstLevel(keynote))
                return FirstLevelName(keynote);
            else if (IsSecondLevel(keynote))
            {
                if (FirstLevelName(keynote) != "")
                    return FirstLevelName(keynote) + "-" + SecondLevelName(keynote);
                else
                    return SecondLevelName(keynote);
            }
            else if (IsThirdLevel(keynote))
            {
                return FirstLevelName(keynote) + "-" + SecondLevelName(keynote) + "-" + ThirdLevelName(keynote);
            }
            else
                return FirstLevelName(keynote) + "-" + SecondLevelName(keynote) + "-" + ThirdLevelName(keynote) + "-" + FourthLevelName(keynote);
        }

        /// キーノートが第2階層か調べます
        ///     ''' </summary>
        ///     ''' <param name="keynote">調べたいキーノート</param>
        ///     ''' <returns></returns>
        private bool IsThirdLevel(string keynote)
        {
            return KeynoteLevel(keynote) == 3;
        }

        /// <summary>
        ///     ''' キーノートが第2階層か調べます
        ///     ''' </summary>
        ///     ''' <param name="keynote">調べたいキーノート</param>
        ///     ''' <returns></returns>
        private bool IsSecondLevel(string keynote)
        {
            return KeynoteLevel(keynote) == 2;
        }

        /// <summary>
        ///     ''' キーノートが第1階層か調べます
        ///     ''' </summary>
        ///     ''' <param name="keynote">調べたいキーノート</param>
        ///     ''' <returns></returns>
        private bool IsFirstLevel(string keynote)
        {
            return KeynoteLevel(keynote) == 1;
        }

        /// <summary>
        ///     ''' キーノートの階層を答えます
        ///     ''' </summary>
        ///     ''' <param name="keynote">階層を知りたいキーノート</param>
        ///     ''' <returns></returns>
        private int KeynoteLevel(string keynote)
        {
            return keynote.Split('.').Length;
        }

        /// <summary>
        ///     ''' 第4階層（小項目）の名前を返します。
        ///     ''' </summary>
        ///     ''' <param name="keynote">小項目名を知りたいキーノート</param>
        ///     ''' <returns></returns>
        private string FourthLevelName(string keynote)
        {
            if (IsUpperLevel(keynote, 4))
                return "";

            string fourthLevelKeynote = DownKeynote(keynote, 4);

            return KeynoteDescription(fourthLevelKeynote);
        }

        /// <summary>
        ///     ''' 第3階層（中項目）の名前を返します。
        ///     ''' </summary>
        ///     ''' <param name="keynote">中項目名を知りたいキーノート</param>
        ///     ''' <returns></returns>
        private string ThirdLevelName(string keynote)
        {
            // ✕9.1
            // 〇9.1.1や9.1.1.2や9.1.1.2.1
            if (IsUpperLevel(keynote, 3))
                return "";

            // 9.1.1.2->9.1.1
            string thirdLevelKeynote = DownKeynote(keynote, 3);

            // キーノートの名前欄を返す
            return KeynoteDescription(thirdLevelKeynote);
        }

        /// <summary>
        ///     ''' 第3階層（中項目）の名前を返します。
        ///     ''' </summary>
        ///     ''' <param name="keynote">中項目名を知りたいキーノート</param>
        ///     ''' <returns></returns>
        private string SecondLevelName(string keynote)
        {
            // ✕9.1
            // 〇9.1.1や9.1.1.2や9.1.1.2.1
            if (IsUpperLevel(keynote, 2))
                return "";

            // 9.1.1.2->9.1.1
            string thirdLevelKeynote = DownKeynote(keynote, 2);

            // キーノートの名前欄を返す
            return KeynoteDescription(thirdLevelKeynote);
        }

        /// <summary>
        ///     ''' 第3階層（中項目）の名前を返します。
        ///     ''' </summary>
        ///     ''' <param name="keynote">中項目名を知りたいキーノート</param>
        ///     ''' <returns></returns>
        private string FirstLevelName(string keynote)
        {
            // ✕9.1
            // 〇9.1.1や9.1.1.2や9.1.1.2.1
            if (IsUpperLevel(keynote, 1))
                return "";

            // 9.1.1.2->9.1.1
            string thirdLevelKeynote = DownKeynote(keynote, 1);

            // キーノートの名前欄を返す
            return KeynoteDescription(thirdLevelKeynote);
        }

        /// <summary>
        ///     ''' キーノートの階層が指定数値より上か答えます
        ///     ''' </summary>
        ///     ''' <param name="keynote"></param>
        ///     ''' <param name="v"></param>
        ///     ''' <returns></returns>
        private bool IsUpperLevel(string keynote, int v)
        {
            return KeynoteLevel(keynote) < v;
        }

        /// <summary>
        ///     ''' 階層をあげたキーノートを返します（9.3.2->9.3など）
        ///     ''' </summary>
        ///     ''' <param name="keynote">階層を上げたいキーノート</param>
        ///     ''' <param name="v">あげたい階層</param>
        ///     ''' <returns></returns>
        private string DownKeynote(string keynote, int v)
        {
            // 階層をあげていく一時保存場所
            string temp = keynote;

            // 最後のドットを指定階層まで消していく
            while (!(IsUpperLevel(temp, v + 1)))
            {
                int lastDotIndex = temp.LastIndexOf(".");
                temp = temp.Substring(0, lastDotIndex);
            }

            return temp;
        }

        /// <summary>
        ///     ''' テキストファイルからキーノート番号に対応する説明を取得します。
        ///     ''' </summary>
        ///     ''' <param name="keynoteNumber"></param>
        ///     ''' <returns></returns>
        private string KeynoteDescription(string keynoteNumber)
        {
            foreach (Keynote keynoteInfo in m_lstKeyNote)
            {
                if (keynoteInfo.Number == keynoteNumber)
                    return keynoteInfo.Description;
            }
            return "";
        }

        /// <summary>
        ///     ''' キーノートの記されたテキストファイルからノードを作ります。
        ///     ''' </summary>
        ///     ''' <param name="filePath"></param>
        ///     ''' <param name="keynoteForSelection">ツリー上で選択状態にしたいキーノート</param>
        ///     ''' <returns></returns>
        public List<Keynote> LoadKeynotesFromText()
        {
            if (File.Exists(m_filePath) == false)
                throw new Exception(string.Format("ファイル[{0}]が見つかりませんでした。", m_filePath));

            List<Keynote> returnValue = new List<Keynote>();

            // 一行ずつ読み取りツリーを作っていく
            using (TextFieldParser parser = new TextFieldParser(m_filePath, Encoding.Unicode))
            {
                // カンマ区切りの指定
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(Constants.vbTab);

                // フィールドが引用符で囲まれているか
                parser.HasFieldsEnclosedInQuotes = true;
                // フィールドの空白トリム設定
                parser.TrimWhiteSpace = false;

                // ファイルの終端までループ
                while (!parser.EndOfData)
                {
                    // フィールドを読込
                    string[] row = parser.ReadFields();
                    // 長さチェック
                    if (row.Length < 3)
                        continue;

                    // ノードを作成
                    string keynote = row[0];
                    string keynoteName = row[1];
                    string parentKeynote = row[2];

                    returnValue.Add(new Keynote(keynote, keynoteName, parentKeynote));
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Get Keynote Data
        /// </summary>
        /// <param name="familySymbol"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public List<KeynoteData> GetKeynoteDatas(List<FamilySymbol> familySymbol, List<FamilyInstance> familyInstances)
        {
            List<KeynoteData> allKeynoteData = new List<KeynoteData>();

            foreach (var symbol in familySymbol)
            {
                KeynoteData keynoteData = new KeynoteData();

                if (symbol.Category == null)
                    continue;

                keynoteData.Category = symbol.Category.Name;
                keynoteData.Family = symbol.FamilyName;
                keynoteData.Type = symbol.Name;

                Parameter keynotePara = symbol.get_Parameter(BuiltInParameter.KEYNOTE_PARAM);
                if (keynotePara != null && keynotePara.HasValue)
                {
                    string keynote = keynotePara.AsString();
                    keynoteData.Keynote = keynote;
                }

                keynoteData.FamilySymbol = symbol;
                keynoteData.FamilyInstances = familyInstances.Where(x => x.Symbol.Id.IntegerValue == symbol.Id.IntegerValue).ToList();
                allKeynoteData.Add(keynoteData);
            }

            return allKeynoteData;
        }
    }
}