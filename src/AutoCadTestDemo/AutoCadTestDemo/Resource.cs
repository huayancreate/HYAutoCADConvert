using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace AutoCadTestDemo
{
    class Resource
    {
        Hashtable modify;
        List<Task> threadPool;

        public Hashtable Modify
        {
            get { return modify; }
            set { modify = value; }
        }
    }
}
