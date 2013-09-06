using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor
{
    public class HistoryDto
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
        private string fileStatus;

        public string FileStatus
        {
            get { return fileStatus; }
            set { fileStatus = value; }
        }

        private string fileCode;

        public string FileCode
        {
            get { return fileCode; }
            set { fileCode = value; }
        }

        private string fileTips;

        public string FileTips
        {
            get { return fileTips; }
            set { fileTips = value; }
        }
    }
}
