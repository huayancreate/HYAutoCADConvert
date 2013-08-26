using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCadTestDemo
{
    public class MysqlOperate
    {
        public void test()
        {
            MysqlDBUtil.ExecuteSql("INSERT INTO history(Id,FileName,FileStatus,FilePath) VALUES('','','','')");
        }
    }
}
