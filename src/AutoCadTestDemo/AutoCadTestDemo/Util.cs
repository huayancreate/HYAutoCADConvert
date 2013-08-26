using AutoCAD;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using SymBBAuto;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AutoCadTestDemo
{
    public abstract class Util
    {
        private static HSSFWorkbook hssfworkbook;
        private static DataSet ds = new DataSet();

        private static string ReplaceStr(string str)
        {
            var startStr = str.Substring(0, RegexCode(str));
            var endStr = str.Substring(RegexCode(str), str.Length - RegexCode(str));
            if (endStr.Contains("O") || endStr.Contains("o"))
            {
                endStr = endStr.Replace("o", "0");
                endStr = endStr.Replace("O", "0");
            }
            if (endStr.Contains("I") || endStr.Contains("i"))
            {
                endStr = endStr.Replace("I", "1");
                endStr = endStr.Replace("i", "1");
            }
            if (endStr.Contains("Z") || endStr.Contains("z"))
            {
                endStr = endStr.Replace("Z", "2");
                endStr = endStr.Replace("z", "2");
            }
            return startStr + endStr;
        }

        private static string Rand(string str)
        {
            Random random = new Random();
            if (RegexCode(str) == 2) return random.Next(0, 99999).ToString();
            else return random.Next(0, 9999).ToString();
        }

        /// <summary>
        /// 图纸类型
        /// </summary>
        public enum DrawingType
        {
            Parts, Assembly
        }

        /// <summary>
        /// 替换审核者、设计者、日期等属性
        /// </summary>
        /// <param name="entity"></param>
        public static void ReplaceProperty(AcadEntity entity)
        {
            if (entity.ObjectName == "AcDbBlockReference")
            {
                var s = ((AcadBlockReference)entity);
                if (s.HasAttributes)
                {
                    AcadAttributeReference bb;
                    object[] aa = (object[])s.GetAttributes();
                    for (int i = 0; i < aa.Length; i++)
                    {
                        bb = aa[i] as AcadAttributeReference;
                        if (bb != null)
                        {
                            if (bb.TagString != "---------" && bb.TagString != "------" && !bb.TagString.Contains("GEN-TITLE-MAT") && !bb.TagString.Contains("GEN-TITLE-DES") && bb.TagString != "01" && !bb.TagString.Contains("GEN-TITLE-SCA{6.14,1}"))
                            {
                                bb.TextString = "";
                            }
                            //if (regex.IsMatch(bb.TextString))
                            //{
                            //    OleDbParameter[] parameters = new OleDbParameter[2];
                            //    parameters[0] = new OleDbParameter("@OldCode", OleDbType.VarChar, 50);
                            //    parameters[0].Value = bb.TextString;
                            //    parameters[1] = new OleDbParameter("@NewCode", OleDbType.VarChar, 50);
                            //    parameters[1].Value = bb.TextString;
                            //    AccessDBUtil.ExecuteInsert("insert into code (OldCode,NewCode) values(?,?)", parameters);
                            //}
                        }
                    }
                }
            }
            else if (entity.ObjectName == "AcDbMText")
            {
                AcadMText mtext = entity as AcadMText;
                if (mtext != null)
                {
                    if (mtext.TextString.Contains("FAX") || mtext.TextString.Contains("TEL") || mtext.TextString.Contains("TOMITA"))
                    {
                        mtext.TextString = "";
                    }
                }
            }
        }

        /// <summary>
        /// 替换装配图中的明细表中的编号
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="acAppComObj"></param>
        /// <param name="ds"></param>
        public static void ReplaceDrawingCode(AcadEntity entity, AcadApplication acAppComObj, DataSet ds)
        {
            if (entity.ObjectName == "AcmPartRef")
            {
                AXDBLib.AcadObject obj = entity as AXDBLib.AcadObject;
                McadSymbolBBMgr symbb = (McadSymbolBBMgr)acAppComObj.GetInterfaceObject("SymBBAuto.McadSymbolBBMgr");
                McadBOMMgr bommgr = (McadBOMMgr)symbb.BOMMgr;
                var oldCode = bommgr.GetPartAttribute(obj, "DESCR", false);
                oldCode = ReplaceStr(oldCode);
                Regex regex = new Regex(@"[A-Z]");
                var startCode = oldCode.Substring(0, RegexCode(oldCode));
                var endCode = oldCode.Substring(RegexCode(oldCode), oldCode.Length - RegexCode(oldCode));
                for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (startCode == ds.Tables[0].Rows[i][0].ToString())
                    {
                        startCode = ds.Tables[0].Rows[i][1].ToString();
                    }
                }
                //endCode
                //var newCode = temp + endStr;
                //bommgr.SetPartAttribute(obj, "DESCR", newCode);
                //showInfo += "\n" + number;

                //if (regex.IsMatch(number))
                //{
                //    string newCode = getByNewCode(number);
                //    if (!string.IsNullOrEmpty(newCode))
                //        bommgr.SetPartAttribute(obj, "DESCR", newCode);
                //}
            }
        }

        /// <summary>
        /// 读取Excel
        /// </summary>
        /// <param name="path"></param>
        public static void InitializeWorkbook(string path)
        {
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
                ConvertToDataTable();
            }
        }

        /// <summary>
        /// 读取Excel数据转化为DataTable
        /// </summary>
        static void ConvertToDataTable()
        {
            ds.Clear();
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            DataTable dt = new DataTable();
            for (int j = 0; j < 5; j++)
            {
                dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
            }
            while (rows.MoveNext())
            {
                IRow row = (HSSFRow)rows.Current;
                DataRow dr = dt.NewRow();
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);
        }

        static int RegexCode(string code)
        {
            Regex regex = new Regex(@"[A-Z]");
            if (regex.IsMatch(code.Substring(0, 3))) return 3;
            else return 2;
        }
    }
}
