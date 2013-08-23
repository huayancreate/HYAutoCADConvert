using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutoCadTestDemo
{
    public class Task
    {
        protected string taskName;
        protected ManualResetEvent _doneEvent;

        protected void run() { 
            //具体需要做的事
        }

        public void ThreadPoolCallback(Object threadContext)
        {
            run();
            _doneEvent.Set();
        }
    }
}
