using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelHandle.Bussiness
{
    public class ExcelProcess
    {
        private IWorkbook workbook;

        public IWorkbook Workbook
        {
            get { return workbook; }
            set { workbook = value; }
        }

        private string targetfileName;

        public string TargetfileName
        {
            get { return targetfileName; }
            set { targetfileName = value; }
        }
        private string targetFilePath;

        public string TargetFilePath
        {
            get { return targetFilePath; }
            set { targetFilePath = value; }
        }
        public void Run()
        {
            ISheet sheet = workbook.GetSheetAt(0);
            for (int j = 0; j <= sheet.LastRowNum; j++)  //LastRowNum 是当前表的总行数
            {
                IRow row = sheet.GetRow(j);  //读取当前行数据
                if (row != null)
                {
                    for (int k = 0; k <= row.LastCellNum; k++)  //LastCellNum 是当前行的总列数
                    {
                        ICell cell = row.GetCell(k);  //当前表格
                        if (cell != null)
                        {
                            this.Replace(cell);
                        }
                    }
                }
            }

            WorkbokkSave();
        }

        private void WorkbokkSave()
        {
            FileStream fs = File.OpenWrite(targetFilePath + targetfileName);
            Workbook.Write(fs);
            fs.Close();
        }

        private void Replace(ICell cell)
        {
            if (cell.CellType == NPOI.SS.UserModel.CellType.STRING)
            {
                string temp = FindCodeFromDB(cell.StringCellValue);
                if (temp != "")
                {
                    cell.SetCellValue(temp);
                }
            }
        }

        private string FindCodeFromDB(string value)
        {
            //TODO DB 查询
            var strSql = "select newcode from code where oldcode = '" + value + "'";
            DataSet ds = MysqlDBUtil.Query(strSql);
            if (ds == null)
            {
                return "";
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                return ds.Tables[0].Rows[i]["NewCode"].ToString();
            }
            return "";
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
                    if (extension.Equals(".xls") || extension.Equals(".xlsx"))
                    {
                        list.Add(info.FullName);
                    }
                }
            }
            return list;
        }

    }
}
