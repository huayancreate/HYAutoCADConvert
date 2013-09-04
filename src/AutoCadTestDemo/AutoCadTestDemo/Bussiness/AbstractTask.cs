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
        private Process parentProcess;
        public bool flag = false;
        private int item;
        private Util util;
        private string saveName;
        private ManualResetEvent doneEvent;

        public ManualResetEvent DoneEvent
        {
            get { return doneEvent; }
            set { doneEvent = value; }
        }

        public string SaveName
        {
            get { return saveName; }
            set { saveName = value; }
        }

        public Util Util
        {
            get { return util; }
            set { util = value; }
        }

        public int Item
        {
            get { return item; }
            set { item = value; }
        }

        

        public void SetWaitCallback()
        {
            this.waitCallback = new WaitCallback(Run);
        }

        public WaitCallback GetWaitCallback()
        {
            return waitCallback;
        }

        public Process ParentProcess
        {
            get { return parentProcess; }
            set { parentProcess = value; }
        }

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
            this.Util = new Util();
            try
            {
                this.AcadDoc = this.AcAppComObj.Documents.Open(this.AbsPath);
            }
            catch (Exception ex)
            {
                //移动文件
                this.flag = false;
                return;
            }
        }

        public void SetDefaultRules(Rules rules)
        {
            defaultRules = rules;
        }

        public Rules GetDefaultRules()
        {
            return this.defaultRules;
        }

        public abstract void Run( object state ) ;

        internal void Save()
        {
                AcAppComObj.Documents.Item(Item).SaveAs(this.SaveName, AcSaveAsType.ac2013_dwg, null);
                this.AcadDoc.Close();
                GC.Collect();
        }
    }
}
