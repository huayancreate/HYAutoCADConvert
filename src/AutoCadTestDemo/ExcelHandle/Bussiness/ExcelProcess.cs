using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace ExcelHandle.Bussiness
{
    public class ExcelProcess
    {
        private HSSFWorkbook workbook;
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

        public HSSFWorkbook Workbook
        {
            get { return workbook; }
            set { workbook = value; }
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

            WorkbokkSave(sheet);
        }

        private void WorkbokkSave(ISheet sheet)
        {
            HSSFWorkbook wk = new HSSFWorkbook();
            ISheet destSheet = wk.CreateSheet();
            destSheet = sheet;
            using (FileStream fs = File.OpenWrite(targetFilePath + targetfileName))
            {
                wk.Write(fs); 
            }
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



    }
}
