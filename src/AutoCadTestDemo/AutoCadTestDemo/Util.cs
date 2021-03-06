﻿using AutoCAD;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using SymBBAuto;
using System;
using System.Collections;
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
        public static string oldCode = "";
        public static string newCode = "";
        //public static Bussiness.Rules rules = new Bussiness.Rules();
        public static List<string> drwings = new List<string>();
        private static Random rand = new Random(99999999);
        private static MysqlOperate operate = new MysqlOperate();

        private static string ReplaceStr(string oldCode)
        {
            var startStr = oldCode.Substring(0, RegexCode());
            var endStr = oldCode.Substring(RegexCode(), oldCode.Length - RegexCode());
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

        private static string Rand()
        {
            Random random = new Random();
            if (RegexCode() == 2) return random.Next(10000, 99999).ToString();
            else return random.Next(1000, 9999).ToString();
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
        public static void ReplaceProperty(AcadEntity entity, AcadBlocks blocks, Bussiness.Rules rules)
        {
            if (entity.ObjectName == "AcDbBlockReference")
            {
                var s = ((AcadBlockReference)entity);
                var name = blocks.Item(s.Name).Name;
                blocks.Item(s.Name).Name = rand.Next().ToString();
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
                            if (bb.TagString == "---------")
                            {
                                oldCode = bb.TextString;
                                oldCode = ReplaceStr(oldCode);
                                var startCode = oldCode.Substring(0, RegexCode());
                                var endCode = oldCode.Substring(RegexCode(), oldCode.Length - RegexCode());
                                Hashtable hash = rules.GetRules();
                                foreach (DictionaryEntry de in hash)
                                {
                                    if (startCode == de.Key.ToString())
                                    {
                                        startCode = de.Value.ToString();
                                    }
                                }
                                newCode = startCode + "0" + Rand();
                                if (!string.IsNullOrEmpty(newCode)) bb.TextString = newCode;
                            }
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
        public static void ReplaceDrawingCode(AcadEntity entity, AcadApplication acAppComObj)
        {
            if (entity.ObjectName == "AcmPartRef")
            {
                AXDBLib.AcadObject obj = entity as AXDBLib.AcadObject;
                McadSymbolBBMgr symbb = (McadSymbolBBMgr)acAppComObj.GetInterfaceObject("SymBBAuto.McadSymbolBBMgr");
                McadBOMMgr bommgr = (McadBOMMgr)symbb.BOMMgr;
                oldCode = bommgr.GetPartAttribute(obj, "DESCR", false);
                string newCode = getByNewCode(oldCode);
                if (!string.IsNullOrEmpty(newCode)) bommgr.SetPartAttribute(obj, "DESCR", newCode);
            }
        }

        /// <summary>
        /// 读取Excel
        /// </summary>
        /// <param name="path"></param>
        public static DataSet InitializeWorkbook(string path)
        {
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
                return ConvertToDataTable();
            }
        }

        /// <summary>
        /// 读取Excel数据转化为DataTable
        /// </summary>
        static DataSet ConvertToDataTable()
        {
            DataSet dsExcelValue = new DataSet();
            dsExcelValue.Tables.Clear();
            dsExcelValue.Clear();
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
            dsExcelValue.Tables.Add(dt);
            return dsExcelValue;
        }

        static int RegexCode()
        {
            Regex regex = new Regex(@"^[A-Za-z]+$");
            if (regex.IsMatch(oldCode.Substring(0, 3))) return 3;
            else return 2;
        }

        static string getByNewCode(string oldCode)
        {
            string sql = "select newcode from code where oldcode='" + oldCode + "'";
            DataSet dataSet = MysqlDBUtil.Query(sql);
            if (dataSet.Tables.Count > 0)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    DataRow row = dataSet.Tables[0].Rows[0];
                    return row["newcode"].ToString();
                }
            }
            return "";
        }
        /// <summary>
        /// 获取所选文件夹的文件
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static void GetAllFiles(DirectoryInfo dir)
        {
            List<HistoryDto> listHis = new List<HistoryDto>();
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
            foreach (FileSystemInfo info in fileinfo)
            {
                if (info is DirectoryInfo)
                {
                    GetAllFiles((DirectoryInfo)info);
                }
                else
                {
                    var extension = info.Extension;
                    if (extension.Equals(".dwg") || extension.Equals(".dwt") || extension.Equals(".dws") || extension.Equals(".dxf"))
                    {
                        if (Util.GetDrwingsDto(info.Name) == null)
                        {
                            HistoryDto dto = new HistoryDto();
                            dto.Id = Guid.NewGuid().ToString();
                            dto.FileName = info.Name;
                            dto.FilePath = info.FullName.Replace("\\", "\\\\");
                            dto.FileStatus = "未处理";
                            listHis.Add(dto);
                        }
                    }
                }
            }
            InsertHistory(listHis);
            listHis.Clear();
        }

        public static List<HistoryDto> RandomSortList(List<HistoryDto> listHis)
        {
            Random random = new Random();
            List<HistoryDto> newList = new List<HistoryDto>();
            foreach (HistoryDto item in listHis)
            {
                newList.Insert(random.Next(newList.Count + 1), item);
            }
            return newList;
        }

        /// <summary>
        /// 添加历史记录
        /// </summary>
        /// <param name="dto"></param>
        public static void InsertHistory(List<HistoryDto> dtos)
        {
            //MysqlOperate operate = new MysqlOperate();
            List<HistoryDto> list = RandomSortList(dtos);
            foreach (HistoryDto dto in list)
            {
                operate.InsertHistory(dto);
            }
        }
        /// <summary>
        /// 添加新的图纸编号
        /// </summary>
        /// <param name="dto"></param>
        public static void InsertCode(CodeDto dto)
        {
            //MysqlOperate operate = new MysqlOperate();
            operate.InsertCode(dto);
        }

        public static void GetDrwingsList()
        {
            //MysqlOperate operate = new MysqlOperate();
            drwings = operate.GetDrwingsList();
        }

        public static HistoryDto GetDrwingsDto(string path)
        {
            //MysqlOperate operate = new MysqlOperate();
            HistoryDto dto = operate.GetDrwingsDto(path);
            return dto;
        }

        public static void UpdateHistory(HistoryDto dto)
        {
            //MysqlOperate operate = new MysqlOperate();
            operate.UpdateHistory(dto);
        }

        public static string SplitCode(string value)
        {
            Regex regex = new Regex(@"^[A-Za-z]+$");
            if (regex.IsMatch(value.Substring(0, 3))) return value.Substring(0, 3);
            else return value.Substring(0, 2);
        }
    }
}
