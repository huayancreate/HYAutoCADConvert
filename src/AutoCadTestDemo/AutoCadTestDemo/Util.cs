using AutoCAD;
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
using Common;
using System.Xml;
using System.Windows.Forms;


namespace AutoCadConvert
{
    public abstract class Util
    {
        private static IWorkbook hssfworkbook;
        private static DataSet ds = new DataSet();
        public static string oldCode = "";
        public static string newCode = "";
        static List<HistoryDto> listHis = new List<HistoryDto>();
        public static Bussiness.Rules rules = new Bussiness.Rules();
        public static List<HistoryDto> drwings = new List<HistoryDto>();
        private static Random rand = new Random(99999999);
        private static MysqlOperate operate = new MysqlOperate();
        private static double bili = 1.0;

        private static int dirIndex = 0;

        //private static string ReplaceStr(string oldCode)
        //{
        //    var startStr = oldCode.Substring(0, RegexCode());
        //    var endStr = oldCode.Substring(RegexCode(), oldCode.Length - RegexCode());
        //    if (endStr.Contains("O") || endStr.Contains("o"))
        //    {
        //        endStr = endStr.Replace("o", "0");
        //        endStr = endStr.Replace("O", "0");
        //    }
        //    if (endStr.Contains("I") || endStr.Contains("i"))
        //    {
        //        endStr = endStr.Replace("I", "1");
        //        endStr = endStr.Replace("i", "1");
        //    }
        //    if (endStr.Contains("Z") || endStr.Contains("z"))
        //    {
        //        endStr = endStr.Replace("Z", "2");
        //        endStr = endStr.Replace("z", "2");
        //    }
        //    return startStr + endStr;
        //}

        //private static string Rand()
        //{
        //    Random random = new Random();
        //    if (RegexCode() == 2) return random.Next(10000, 99999).ToString();
        //    else return random.Next(1000, 9999).ToString();
        //}

        /// <summary>
        /// 图纸类型
        /// </summary>
        //public enum DrawingType
        //{
        //    Parts, Assembly
        //}

        /// <summary>
        /// 替换审核者、设计者、日期等属性
        /// </summary>
        /// <param name="entity"></param>
        public static void ReplaceProperty(AcadEntity entity, AcadBlocks blocks, double[] limit, string type, double bili)
        {
            var height = 0.0;
            var width = 0.0;
            var blockHeight = 0.0;
            var blockWidth = 0.0;

            if (type == "1")
            {
                width = 268 * bili;
                height = 39 * bili;
                blockHeight = 23 * bili;
                blockWidth = 81 * bili;
            }
            else
            {
                width = 253 * bili;
                height = 37 * bili;
                blockHeight = 20 * bili;
                blockWidth = 78 * bili;
            }

            var startLimitX = limit[0];
            var startLimitY = limit[1];
            var endLimitX = limit[2];
            var endLimitY = limit[3];

            var BottomRightLimitX = limit[0];
            var BottomRightLimitY = limit[1];
            var BottomLeftLimitX = limit[0];
            var BottomLeftLimitY = limit[1];
            var TittleLeftX = 0.0;
            var TittleLeftY = 0.0;
            var OutLeftX = 0.0;
            var OutLeftY = 0.0;

            //TODO 计算左下角坐标点
            if (startLimitX > endLimitX)
            {
                BottomLeftLimitX = endLimitX;
            }
            if (startLimitY > endLimitY)
            {
                BottomLeftLimitY = endLimitY;
            }
            TittleLeftX = BottomLeftLimitX;
            TittleLeftY = BottomLeftLimitY + height;
            OutLeftX = BottomLeftLimitX;
            OutLeftY = BottomLeftLimitY + 20 * bili;

            //TODO 计算右下角坐标点
            if (startLimitX < endLimitX)
            {
                BottomRightLimitX = endLimitX;
            }
            if (startLimitY > endLimitY)
            {
                BottomRightLimitY = endLimitY;
            }

            if (entity.ObjectName == "AcDbBlockReference")
            {
                var dto = GetDrwingsDto(entity.Document.Name);
                if (dto != null)
                {
                    if (!string.IsNullOrEmpty(dto.FileCode))
                        newCode = dto.FileCode;
                }
                var s = ((AcadBlockReference)entity);
                double[] point = s.InsertionPoint;
                if (point[0] > TittleLeftX && point[0] < BottomRightLimitX && point[1] < TittleLeftY && point[1] > BottomRightLimitY)
                {
                    if (s.HasAttributes)
                    {
                        AcadAttributeReference bb;
                        object[] aa = (object[])s.GetAttributes();
                        for (int i = 0; i < aa.Length; i++)
                        {
                            bb = aa[i] as AcadAttributeReference;
                            if (bb != null)
                            {
                                if (bb.TagString != "---------" && bb.TagString != "------" && !bb.TagString.Contains("GEN-TITLE-MAT") && !bb.TagString.Contains("GEN-TITLE-DES") && bb.TagString != "01" && !bb.TagString.Contains("GEN-TITLE-SCA{6.14,1}") && bb.TagString != "----" && bb.TagString != "-----")
                                {
                                    bb.TextString = "";
                                }
                                if (type == "1" && bb.TagString == "----")
                                {
                                    bb.TextString = "";
                                }
                                if (type == "0" && bb.TagString == "-----")
                                {
                                    bb.TextString = "";
                                }
                                if (type == "0" && bb.TagString == "-")
                                {
                                    bb.TextString = "";
                                }
                                if (type == "0" && bb.TagString == "--")
                                {
                                    bb.TextString = "";
                                }
                                if (type == "0" && bb.TagString == "---")
                                {
                                    bb.TextString = "";
                                }
                                if (bb.TagString == "---------")
                                {
                                    oldCode = bb.TextString;
                                    bb.TextString = dto.FileCode;
                                }
                            }
                        }
                    }
                }
                var name = blocks.Item(s.Name).Name;
                blocks.Item(s.Name).Name = "ftjg" + Guid.NewGuid().ToString();
                //}
            }
            else if (entity.ObjectName == "AcDbMText")
            {
                AcadMText mtext = entity as AcadMText;
                var obj = mtext.InsertionPoint;
                //TODO 计算相对位置
                var blockLeftTopX = BottomRightLimitX - width;
                var blockLeftTopY = BottomRightLimitY + height;
                var blockRightBottomX = blockLeftTopX + blockWidth + 5 * bili;
                var blockRightBottomY = blockLeftTopY - blockHeight - 5 * bili;

                if (obj[0] > blockLeftTopX && obj[0] < blockRightBottomX && obj[1] < blockLeftTopY && obj[1] > blockRightBottomY)
                {
                    mtext.TextString = "";
                }
                else
                {
                    if (obj[1] < OutLeftY && obj[0] > TittleLeftX && obj[1] < BottomRightLimitX)
                    {
                        if (!mtext.TextString.Contains("要求"))
                        {
                            mtext.TextString = "";
                        }
                    }
                    if (obj[1] < BottomRightLimitY)
                    {
                        mtext.TextString = "";
                    }
                    if (mtext != null)
                    {
                        if (mtext.TextString.Contains("FAX") || mtext.TextString.Contains("TEL") || mtext.TextString.Contains("CORPORATION"))
                        {
                            mtext.TextString = "";
                        }
                    }

                }
            }
            if (entity.ObjectName != "AcmPartRef")
            {
                entity.Update();
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
                hssfworkbook = WorkbookFactory.Create(file);
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

        //static int RegexCode()
        //{
        //    Regex regex = new Regex(@"^[A-Za-z]+$");
        //    if (regex.IsMatch(oldCode.Substring(0, 3))) return 3;
        //    else return 2;
        //}

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
        public static void GetAllFiles(DirectoryInfo dir, Bussiness.Rules rules)
        {
            foreach (DirectoryInfo _dir in dir.GetDirectories())
            {
                var flag = 500;
                List<string> list = new List<string>();
                GetAllFiles(_dir, list);
                for (int i = 0; i < list.Count; i++)
                {
                    var fileName = Path.GetFileName(list[i].ToString());
                    if (Util.GetDrwingsDto(fileName) == null)
                    {
                        HistoryDto dto = new HistoryDto();
                        dto.Id = Guid.NewGuid().ToString();
                        dto.FileName = fileName;
                        dto.FilePath = list[i].Replace("\\", "\\\\");
                        dto.FileTips = "未处理";
                        dto.FileStatus = "0";//0：未处理，1：已处理
                        var startCode = SplitCode(fileName);
                        foreach (DictionaryEntry de in rules.GetRules())
                        {
                            if (startCode == de.Key.ToString())
                            {
                                startCode = de.Value.ToString();
                            }
                        }
                        if (startCode.Length == 2)
                        {
                            dto.FileCode = startCode + string.Format("{0:D6}", flag + i);
                        }
                        else
                        {
                            dto.FileCode = startCode + string.Format("{0:D5}", flag + i);
                        }
                        listHis.Add(dto);
                    }
                }
                InsertHistory(listHis);
                listHis.Clear();
            }
        }

        public static List<string> GetAllFiles(DirectoryInfo dir, List<string> list)
        {
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
            foreach (FileSystemInfo info in fileinfo)
            {
                if (info is DirectoryInfo)
                {
                    GetAllFiles((DirectoryInfo)info, list);
                }
                else
                {
                    var extension = info.Extension;
                    if (extension.Equals(".dwg") || extension.Equals(".dwt") || extension.Equals(".dws") || extension.Equals(".dxf"))
                    {
                        list.Add(info.FullName);
                    }
                }
            }
            return list;
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
            operate.InsertCode(dto);
        }
        public static void InsertCode(string oldCode, string newCode)
        {
            CodeDto dto = new CodeDto();
            dto.Id = Guid.NewGuid().ToString();
            dto.OldCode = oldCode;
            dto.NewCode = newCode;
            operate.InsertCode(dto);
        }

        public static List<HistoryDto> GetDrwingsList(int currentPage)
        {
            int pageSize = 10;
            List<HistoryDto> drwings = operate.Page(currentPage, pageSize);
            return drwings;
        }

        public static HistoryDto GetDrwingsDto(string filename)
        {
            HistoryDto dto = operate.GetDrwingsDto(filename);
            return dto;
        }

        public static void UpdateHistory(HistoryDto dto)
        {
            operate.UpdateHistory(dto);
        }

        public static string SplitCode(string value)
        {
            Regex regex = new Regex(@"^[A-Za-z]+$");
            if (regex.IsMatch(value.Substring(0, 3))) return value.Substring(0, 3);
            else return value.Substring(0, 2);
        }

        /// <summary>
        /// 文件移动
        /// </summary>
        /// <param name="path"></param>
        /// <param name="newPath"></param>
        public static void MoveFile(string path, string newPath)
        {
            if (File.Exists(path))
            {
                File.Copy(path, newPath, true);
            }
        }

        public static void InitDateTime()
        {
            operate.InitDateTime();
        }

        public static string GetInitTime()
        {
            return operate.GetInitDateTime();
        }

        public static double CountBili(AcadEntity entity)
        {
            if (entity.ObjectName == "AcDbBlockReference")
            {
                var s = ((AcadBlockReference)entity);
                if (s.Name.Contains("标题栏"))
                {
                    //Console.WriteLine("装配s.XScaleFactor" + s.XScaleFactor + "--" + entity.Document.Name + "\n");
                    bili = Convert.ToDouble(s.XScaleFactor.ToString());
                }
            }
            return bili;
        }

        public static string GetXmlValue(string AppKey)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.ExecutablePath + ".config");
            XmlNode node = doc.SelectSingleNode(@"//add[@key='" + AppKey + "']");
            XmlElement ele = (XmlElement)node;
            if (node != null)
            {
                return ele.GetAttribute("value");
            }
            return null;
        }

        public static void UpdateConfg()
        {
            operate.UpdateConfig();
        }
    }
}
