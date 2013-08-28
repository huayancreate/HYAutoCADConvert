using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutoCadTestDemo.Bussiness
{
    public class DefaultTask : AbstractTask
    {

        public override void SetWaitCallback()
        {

           this.waitCallback = new WaitCallback(Run);
        }

        public override void Run(object state)
        {
            //TODO 相应方法
        }
    }
}
