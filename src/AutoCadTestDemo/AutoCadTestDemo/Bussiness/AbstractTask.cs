using System;
using System.Collections.Generic;
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
        }

        public WaitCallback GetWaitCallback()
        {
            return waitCallback;
        }

        public void SetDefaultRules(Rules rules)
        {
            defaultRules = rules;
        }

        public abstract void SetWaitCallback();

        public abstract void Run(object state);
    }
}
