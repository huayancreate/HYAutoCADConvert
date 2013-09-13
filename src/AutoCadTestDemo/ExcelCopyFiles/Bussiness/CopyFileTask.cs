using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExcelCopyFiles.Bussiness
{
    public class CopyFileTask
    {
        private string sourceFileFullPath = null;
        private string targetFileFullPath = null;
        private string fileName = null;
        private string tempTargetFilePath = null;

        public CopyFileTask(string sourceFullName, string targetFilePath, string fileName, string tempTargetFilePath)
        {
            // TODO: Complete member initialization
            this.sourceFileFullPath = sourceFullName;
            this.targetFileFullPath = targetFilePath;
            this.fileName = fileName;
            this.tempTargetFilePath = tempTargetFilePath;
        }



        public  bool Move()
        {
            if (sourceFileFullPath == null || targetFileFullPath == null || fileName == null)
                return false;
            string destFile = targetFileFullPath +  fileName;
            if (!Directory.Exists(tempTargetFilePath))
            {
                Directory.CreateDirectory(tempTargetFilePath);
            }
            File.Copy(sourceFileFullPath, destFile, true);
            return true;
        }
    }
}
