using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExcelCopyFiles.Bussiness
{
    public class CopyFileProcess
    {
        private string sourceFilePath;

        public string SourceFilePath
        {
            get { return sourceFilePath; }
            set { sourceFilePath = value; }
        }

        private HSSFWorkbook workbook;

        public HSSFWorkbook Workbook
        {
            get { return workbook; }
            set { workbook = value; }
        }

        public void Run()
        {
            ISheet sheet = workbook.GetSheetAt(0);
            for (int j = 0; j <= sheet.LastRowNum; j++)
            {
                IRow row = sheet.GetRow(j);
                if (row != null)
                {
                    string sourceFileName = row.Cells[0].StringCellValue;
                    string targetFilePath = row.Cells[1].StringCellValue;
                    string sourcePath = FindFilePathBySrcFileName(sourceFileName);
                    CopyFileTask cft = new CopyFileTask(sourcePath, targetFilePath, sourceFileName);
                    if (!cft.Move())
                    {
                        ErrorMsg(sourceFileName,targetFilePath,sourcePath);
                    }
                }
            }
        }

        private void ErrorMsg(string sourceFileName, string targetFilePath, string sourcePath)
        {
            throw new NotImplementedException();
        }

        private string FindFilePathBySrcFileName(string sourceFileName)
        {
            string[] list = Directory.GetFiles(sourceFilePath, sourceFileName, SearchOption.AllDirectories);
            if(list.Length > 0)
            {
                foreach (string fileName in list)
                {
                    fileName.Contains(sourceFileName);
                    FileInfo info = new FileInfo(fileName);
                    return info.DirectoryName;
                }
            }
            return null;
        }


    }
}
