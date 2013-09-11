using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelHandle.Bussiness
{
    public class CodeDto
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string newCode;

        public string NewCode
        {
            get { return newCode; }
            set { newCode = value; }
        }
        private string oldCode;

        public string OldCode
        {
            get { return oldCode; }
            set { oldCode = value; }
        }
    }
}
