using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCadTestDemo
{
    public class MysqlOperate
    {
        public void InsertHistory(HistoryDto dto)
        {
            var strSql = "INSERT INTO history(Id,FileName,FileStatus,FilePath) VALUES('" + dto.Id + "','" + dto.FileName + "','" + dto.FileStatus + "','" + dto.FilePath + "')";
            MysqlDBUtil.ExecuteSql(strSql);
        }

        public void InsertCode(CodeDto dto)
        {
            var strSql = "INSERT INTO code(Id,oldcode,newcode) VALUES('" + dto.Id + "','" + dto.OldCode + "','" + dto.NewCode + "')";
            MysqlDBUtil.ExecuteSql(strSql);
        }
    }
}
