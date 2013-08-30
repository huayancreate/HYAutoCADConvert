using AutoCAD;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace AutoCadTestDemo.Bussiness
{
    public abstract class AbstractTask
    {
        private Rules singleRules = null;
        private Rules defaultRules = null;
        protected WaitCallback waitCallback = null;
        private string taskName;
        private string absPath;
        private AcadApplication acAppComObj;

        public AcadApplication AcAppComObj
        {
            get { return acAppComObj; }
            set { acAppComObj = value; }
        }
        private AcadDocument acadDoc;

        public AcadDocument AcadDoc
        {
            get { return acadDoc; }
            set { acadDoc = value; }
        }
        private string savePath;

        public string SavePath
        {
            get { return savePath; }
            set { savePath = value; }
        }

        public string AbsPath
        {
            get { return absPath; }
            set { absPath = value; }
        }

        public string TaskName
        {
            get { return taskName; }
            set { taskName = value; }
        }

        public void Init()
        {
            if (singleRules != null)
            {
                defaultRules = singleRules;
            }
            //this.Open();
        }

        public void SetDefaultRules(Rules rules)
        {
            defaultRules = rules;
        }

        public Rules GetDefaultRules()
        {
            return this.defaultRules;
        }

        public abstract void Run();
    }
}
