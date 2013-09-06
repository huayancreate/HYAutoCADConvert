using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common
{
    public class MysqlOperate
    {
        public void InsertHistory(HistoryDto dto)
        {
            var strSql = "INSERT INTO history(Id,FileName,FileStatus,FilePath,FileTips,FileCode) VALUES('" + dto.Id + "','" + dto.FileName + "','" + dto.FileStatus + "','" + dto.FilePath + "','" + dto.FileTips + "','" + dto.FileCode + "')";
            MysqlDBUtil.ExecuteSql(strSql);
        }

        public void InsertCode(CodeDto dto)
        {
            var strSql = "INSERT INTO code(Id,oldcode,newcode) VALUES('" + dto.Id + "','" + dto.OldCode + "','" + dto.NewCode + "')";
            MysqlDBUtil.ExecuteSql(strSql);
        }

        public List<HistoryDto> GetDrwingsList()
        {
            var strSql = "SELECT * FROM history";
            DataSet ds = MysqlDBUtil.Query(strSql);
            List<HistoryDto> _list = new List<HistoryDto>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                HistoryDto dto = new HistoryDto();
                dto.Id = ds.Tables[0].Rows[i]["Id"].ToString();
                dto.FileName = ds.Tables[0].Rows[i]["FileName"].ToString();
                dto.FilePath = ds.Tables[0].Rows[i]["FilePath"].ToString();
                dto.FileStatus = ds.Tables[0].Rows[i]["FileStatus"].ToString();
                dto.FileTips = ds.Tables[0].Rows[i]["FileTips"].ToString();
                dto.FileCode = ds.Tables[0].Rows[i]["FileCode"].ToString();
                _list.Add(dto);
            }
            //_list.Add(ds.Tables[0].Rows[i][0].ToString());
            return _list;
        }
        public HistoryDto GetDrwingsDto(string filename)
        {
            HistoryDto dto = new HistoryDto();
            var strSql = "SELECT * FROM history WHERE filename='" + filename + "'";
            DataSet ds = MysqlDBUtil.Query(strSql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dto.Id = ds.Tables[0].Rows[i]["Id"].ToString();
                dto.FileName = ds.Tables[0].Rows[i]["FileName"].ToString();
                dto.FilePath = ds.Tables[0].Rows[i]["FilePath"].ToString();
                dto.FileStatus = ds.Tables[0].Rows[i]["FileStatus"].ToString();
                dto.FileTips = ds.Tables[0].Rows[i]["FileTips"].ToString();
                dto.FileCode = ds.Tables[0].Rows[i]["FileCode"].ToString();
                return dto;
            }
            return null;
        }

        public void UpdateHistory(HistoryDto dto)
        {
            var strSql = "UPDATE history SET FileName = '" + dto.FileName + "',FileStatus='" + dto.FileStatus + "',FilePath='" + dto.FilePath + "',FileTips='" + dto.FileTips + "',FileCode='" + dto.FileCode + "' WHERE id='" + dto.Id + "'";
            MysqlDBUtil.ExecuteSql(strSql);
        }

        /// <summary>
        /// 分页获取待处理的数据
        /// </summary>
        /// <param name="currentPage">当前页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        public List<HistoryDto> Page(int currentPage, int pageSize)
        {
            var strSql = "select * from history where filestatus='0' order by FileCode desc limit " + currentPage * pageSize + ", " + pageSize + "";
            DataSet ds = MysqlDBUtil.Query(strSql);
            List<HistoryDto> _list = new List<HistoryDto>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                HistoryDto dto = new HistoryDto();
                dto.Id = ds.Tables[0].Rows[i]["Id"].ToString();
                dto.FileName = ds.Tables[0].Rows[i]["FileName"].ToString();
                dto.FilePath = ds.Tables[0].Rows[i]["FilePath"].ToString();
                dto.FileStatus = ds.Tables[0].Rows[i]["FileStatus"].ToString();
                dto.FileTips = ds.Tables[0].Rows[i]["FileTips"].ToString();
                dto.FileCode = ds.Tables[0].Rows[i]["FileCode"].ToString();
                _list.Add(dto);
            }
            return _list;
        }

        public void InitDateTime()
        {
            var strSql = "insert into config values('" + Guid.NewGuid() + "'," + DateTime.Now + ")";
            MysqlDBUtil.ExecuteSql(strSql);
        }

        public DateTime GetInitDateTime()
        {
            var strSql = "select inittime from config";
            DataSet ds = MysqlDBUtil.Query(strSql);
            DateTime dateTime = new DateTime();
            if (ds.Tables.Count > 0)
            {
                dateTime = Convert.ToDateTime(ds.Tables[0].Rows[0][0]);
            }
            return dateTime;
        }
    }
}
