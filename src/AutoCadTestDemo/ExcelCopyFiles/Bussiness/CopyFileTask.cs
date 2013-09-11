using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExcelCopyFiles.Bussiness
{
    public class CopyFileTask
    {
        public CopyFileTask(string sourceFileFullPath, string targetFileFullPath, string fileName)
        {
            this.sourceFileFullPath = sourceFileFullPath;
            this.targetFileFullPath = targetFileFullPath;
            this.fileName = fileName;

        }

        private string sourceFileFullPath = null;
        private string targetFileFullPath = null;
        private string fileName = null;

        public  bool Move()
        {
            if (sourceFileFullPath == null || targetFileFullPath == null || fileName == null)
                return false;
            string sourceFile = Path.Combine(sourceFileFullPath, fileName);
            string destFile = Path.Combine(targetFileFullPath, fileName);
            if (!Directory.Exists(targetFileFullPath))
            {
                Directory.CreateDirectory(targetFileFullPath);
            }
            File.Copy(sourceFile, destFile, true);
            return true;
        }
    }
}
