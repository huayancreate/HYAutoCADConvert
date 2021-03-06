﻿using System;
using System.Collections.Generic;
using System.Data;
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

        public List<string> GetDrwingsList()
        {
            var strSql = "SELECT filepath FROM history";
            DataSet ds = MysqlDBUtil.Query(strSql);
            List<string> _list = new List<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                _list.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            return _list;
        }
        public HistoryDto GetDrwingsDto(string filename)
        {
            HistoryDto dto = new HistoryDto();
            var strSql = "SELECT * FROM history WHERE filename='" + filename + "'";
            DataSet ds = MysqlDBUtil.Query(strSql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dto.Id = ds.Tables[0].Rows[i]["id"].ToString();
                dto.FileName = ds.Tables[0].Rows[i]["filename"].ToString();
                dto.FilePath = ds.Tables[0].Rows[i]["filepath"].ToString();
                dto.FileStatus = ds.Tables[0].Rows[i]["id"].ToString();
                return dto;
            }
            return null;
        }

        public void UpdateHistory(HistoryDto dto)
        {
            var strSql = "UPDATE history SET FileName = '" + dto.FileName + "',FileStatus='" + dto.FileStatus + "',FilePath='" + dto.FilePath + "' WHERE id='" + dto.Id + "'";
            MysqlDBUtil.ExecuteSql(strSql);
        }
    }
}
