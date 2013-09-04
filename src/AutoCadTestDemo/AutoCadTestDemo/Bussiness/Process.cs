using AutoCAD;
using AutoCadTestDemo.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace AutoCadTestDemo.Bussiness
{
    public class Process
    {
        public List<AbstractTask> taskList = new List<AbstractTask>();
        private Rules rules;
        private AbstractTask task;
        private AcadApplication acAppComObj = null;
        private Util util;
        private WaitHandle[] handles;

        public WaitHandle[] Handles
        {
            get { return handles; }
            set { handles = value; }
        }

        public void Open()
        {
            const string strProgId = "AutoCAD.Application";
            //获取正在运行的AutoCAD实例；
            try
            {
                acAppComObj = (AcadApplication)Marshal.GetActiveObject(strProgId);
            }
            catch //没有正在运行的实例时出错；
            {
                try
                {
                    //创建新的AutoCAD实例；
                    acAppComObj = (AcadApplication)Activator.CreateInstance(Type.GetTypeFromProgID(strProgId), true);
                }
                catch
                {
                    //创建新实例不成功就显示信息并退出；
                    //MessageBox.Show("创建新实例不成功");
                    return;
                }
            }
        }

        public void Init()
        {
            InitProcess();
            InitThreadPool();
            InitRules();
            InitTask();
            Run();
        }

        private void InitProcess()
        {
            util = new Util();
            handles = new WaitHandle[10];
            this.Open();
            Thread.Sleep(10000);
            string filePath = ConfigurationManager.AppSettings["filePath"].ToString();
            DirectoryInfo dir = new DirectoryInfo(filePath);
            util.GetAllFiles(dir);
            util.GetDrwingsList();
            List<string> list = util.drwings;
        }

        private void Run()
        {
            for (int i = 0; i < taskList.Count;i++ )
            {
                ThreadPool.QueueUserWorkItem(task.GetWaitCallback(), handles[i]);
            }

        }

        private void InitThreadPool()
        {
            ThreadPool.SetMaxThreads(ConfigConstant.MAX_TASKS, ConfigConstant.MAX_TASKS);
        }

        private void InitRules()
        {
            rules = GetRules();
        }

        private Rules GetRules()
        {
            //TODO
            Rules rules = new Rules();
            DataSet ds = util.InitializeWorkbook(ConfigurationManager.AppSettings["xls"].ToString());
            int count = ds.Tables[0].Rows.Count;
            for (int i = 1; i < count; i++)//从第二行开始读取数据
            {
                rules.SetRules(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString());
                CreateDir(ds.Tables[0].Rows[i][1].ToString());
            }
            CreateDir("失败的图纸文件");
            return rules;
        }

        private void InitTask()
        {
            //TODO 获取需要执行的任务
            List<string> drwings = this.util.drwings;
            //drwings.Add(@"C:\Users\wliu\Desktop\chengxu\新建文件夹\DRU0000562.dwg");
            for (int i = 0; i < drwings.Count; i++)
            {
                task = TaskFactroy.CreateTaskByType(TaskType.DefaultTask);
                task.AbsPath = drwings[i];
                task.SavePath = ConfigurationManager.AppSettings["savePath"].ToString();
                task.SetDefaultRules(rules);
                task.TaskName = "drwing_" + i;
                task.AcAppComObj = this.acAppComObj;
                task.Item = i;
                handles.SetValue(new AutoResetEvent(false), i);
                task.Init();
                task.SetWaitCallback();
                taskList.Add(task);
            }
        }
        private void CreateDir(string name)
        {
            var path = ConfigurationManager.AppSettings["savePath"].ToString() + name;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
