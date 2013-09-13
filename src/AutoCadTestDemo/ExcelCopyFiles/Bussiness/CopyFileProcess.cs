using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace ExcelCopyFiles.Bussiness
{
    public class CopyFileProcess
    {
        private string sourceFilePath;
        private string targetFilePath;

        public string TargetFilePath
        {
            get { return targetFilePath; }
            set { targetFilePath = value; }
        }

        public string SourceFilePath
        {
            get { return sourceFilePath; }
            set { sourceFilePath = value; }
        }

        private IWorkbook workbook;

        public IWorkbook Workbook
        {
            get { return workbook; }
            set { workbook = value; }
        }

        private string SplitPath(string srcFile)
        {
            return srcFile.Substring(sourceFilePath.Length, (srcFile.Length - sourceFilePath.Length));
        }

        public void Run()
        {
            ISheet sheet = workbook.GetSheetAt(0);
            for (int j = 0; j <= sheet.LastRowNum; j++)
            {
                IRow row = sheet.GetRow(j);
                if (row != null)
                {
                    string sourceFileName = null;
                    if (row.Cells[0].CellType == CellType.STRING)
                    { 
                        sourceFileName = row.Cells[0].StringCellValue + ConfigurationManager.AppSettings["extension"].ToString();
                    }
                    if (row.Cells[0].CellType == CellType.NUMERIC)
                    {
                        sourceFileName = row.Cells[0].NumericCellValue.ToString() + ConfigurationManager.AppSettings["extension"].ToString();
                    }
                    string sourceFullName = FindFilePathBySrcFileName(sourceFileName);
                    if (sourceFullName == null)
                    {
                        row.CreateCell(1).SetCellValue("失败");
                        continue;
                    }

                    string fileName = this.SplitPath(sourceFullName);
                    string tempTargetFilePath = this.SplitFileName(fileName, sourceFileName);
                    tempTargetFilePath = targetFilePath + tempTargetFilePath;
                    CopyFileTask cft = new CopyFileTask(sourceFullName, targetFilePath, fileName, tempTargetFilePath);
                    if (!cft.Move())
                    {
                        row.CreateCell(1).SetCellValue("失败");
                        //ErrorMsg(sourceFileName, targetFilePath, sourceFullName);
                    }
                    row.CreateCell(1).SetCellValue("成功");
                }
            }
            FileStream fs = File.OpenWrite(ExcelFullName);
            Workbook.Write(fs);
            fs.Close();
        }

        private string SplitFileName(string fileName, string sourceFileName)
        {
            return fileName.Substring(0, (fileName.Length - sourceFileName.Length));
        }

        private string FindFilePathBySrcFileName(string sourceFileName)
        {
            string[] list = Directory.GetFiles(sourceFilePath, sourceFileName, SearchOption.AllDirectories);
            if (list.Length > 0)
            {
                foreach (string fileName in list)
                {
                    fileName.Contains(sourceFileName);
                    FileInfo info = new FileInfo(fileName);
                    return info.FullName;
                }
            }
            return null;
        }

        public string ExcelFullName { get; set; }
    }
}
