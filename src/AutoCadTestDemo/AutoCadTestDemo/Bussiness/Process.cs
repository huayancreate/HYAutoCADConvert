using AutoCadTestDemo.Config;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutoCadTestDemo.Bussiness
{
    public class Process
    {
        public List<AbstractTask> taskList;
        private Rules rules;
        private AbstractTask task;

        public void Init()
        {
            InitThreadPool();
            InitRules();
            InitTask();
            Run();
        }

        private void Run()
        {
            foreach (AbstractTask task in taskList)
            {
                ThreadPool.QueueUserWorkItem(task.GetWaitCallback());
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
            return new Rules();
        }

        private void InitTask()
        {
            //TODO 获取需要执行的任务
            task = TaskFactroy.CreateTaskByType(TaskType.DefaultTask);
            task.SetDefaultRules(rules);
            task.TaskName = "test";
            task.Init();
            task.SetWaitCallback();
            taskList.Add(task);
        }

    }
}
