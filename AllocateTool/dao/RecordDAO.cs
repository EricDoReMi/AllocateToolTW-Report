using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AllocateTool.utils;
using AllocateTool.Entity;
using System.Data;

namespace AllocateTool.dao
{
    public partial class RecordDAO : BaseDAO<Record>
    {
        /**//// <summary>   
            /// 根据id查找对应员工
            /// </summary>   
            /// <param name="conn">数据库连接</param> 
            /// <param name="sqlStr">sql语句</param>   
            /// <param name="paras">参数,默认值null</param>  
            /// <returns>OleDbDataAdapter</returns>   
        public Record FindRecordByIdDAO(OleDbConnection conn, long id)
        {

            string sqlStr = @"SELECT * FROM records WHERE m_id=@M_id";
            OleDbParameter[] paras = { new OleDbParameter("@M_id", id) };
            List<Record> list = queryEntity(conn, sqlStr, paras);

            if (list.Count() > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据时间区间查找RecordSum
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<Record> FindRecordSumDur(OleDbConnection conn, DateTime? startDate, DateTime? endDate)
        {
            string sql = "Select * from records WHERE m_mailincometime BETWEEN @startDate AND @endDate";

            OleDbParameter[] ps = {
                new OleDbParameter("@startDate", EntityUtils.SqlNull(startDate)),
                new OleDbParameter("@endDate", EntityUtils.SqlNull(endDate)),
            };

            List<Record> list = queryEntity(conn, sql, ps);


            return list;

        }

        /// <summary>
        /// 查找前一天去重后的Subject
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="beforeDate"></param>
        /// <returns></returns>
        public HashSet<string> GetUniqueSubject(OleDbConnection conn, DateTime? beforeDate)
        {

            HashSet<string> uniqueSub = null;
            string sql = "Select distinct m_requestID from records WHERE m_mailincometime<@beforeDate";

            OleDbParameter p = new OleDbParameter("@beforeDate", EntityUtils.SqlNull(beforeDate));
            //调用query返回结果集
            DataTable tb = SelectToDataTable(conn, sql, p);

            if (tb.Rows.Count > 0)
            {
                uniqueSub = new HashSet<string>();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    uniqueSub.Add(tb.Rows[i]["m_requestID"].ToString().Trim());
                }
            }

            return uniqueSub;

        }


        /// <summary>
        /// 查找所有的Completed和Incompleted的数据
        /// </summary>
        /// <param name="conn">连接名</param>
        /// <returns></returns>
        public List<Record> FindRecordsCompletedAndIncompleted(OleDbConnection conn) {
            string sqlStr = @"SELECT * FROM records WHERE (m_statu='2' OR m_statu='3') AND m_isupload=@M_isupload;";
            OleDbParameter[] paras = { new OleDbParameter("@M_isupload", "N") };
            List<Record> list = queryEntity(conn, sqlStr,paras);
            return list;
        }

        public void AddRecordItemDAO(OleDbConnection conn, Record record)
        {

            string sqlStr = @"INSERT INTO records (JOBID,T1,UserName,m_subject,m_requestID,m_importance,m_actiontype,m_sender,m_acceptby,m_asign,m_accepttime,m_completetime,m_incompletetime,m_mailincometime,m_incompleteStatue,m_priority,m_text,m_statu,m_filePath,m_businessType,m_cw1ID,m_mailNum,m_isupload) VALUES(@JOBID,@T1,@UserName,@M_subject,@M_requestID,@M_importance,@M_actiontype,@M_sender,@M_acceptby,@M_asign,@M_accepttime,@M_completetime,@M_incompletetime,@M_mailincometime,@M_incompleteStatue,@M_priority,@M_text,@M_statu,@M_filePath,@M_businessType,@M_cw1ID,@M_mailNum,@M_isupload)";
            OleDbParameter[] paras = record.ToInsertByParamArray();

            ExecuteSQLNonquery(conn, sqlStr, paras);

        }

        public void UpdateRecordItemDAO(OleDbConnection conn, Record record)
        {

            string sqlStr = @"UPDATE records SET JOBID=@JOBID,T1=@T1,UserName=@UserName,m_subject=@M_subject,m_requestID=@M_requestID,m_importance=@M_importance,m_actiontype=@M_actiontype,m_sender=@M_sender,m_acceptby=@M_acceptby,m_asign=@M_asign,m_accepttime=@M_accepttime,m_completetime=@M_completetime,m_incompletetime=@M_incompletetime,m_mailincometime=@M_mailincometime,m_incompleteStatue=@M_incompleteStatue,m_priority=@M_priority,m_text=@M_text,m_statu=@M_statu,m_filePath=@M_filePath,m_businessType=@M_businessType,m_cw1ID=@M_cw1ID,m_mailNum=@M_mailNum,m_isupload=@M_isupload WHERE m_id=@M_id;";
            OleDbParameter[] paras = record.ToUpdateByParamArray();

            ExecuteSQLNonquery(conn, sqlStr, paras);

        }


        public override Record ToEntity(OleDbDataReader reader)
        {
            Record record = new Record();
            EntityUtils.FillEntity<Record>(reader, record);
            return record;
        }

        public  Record ToEntity(DataRow dataRow)
        {
            Record record = new Record();
            record.M_id = Convert.ToInt32(dataRow["m_id"].ToString());
            record.M_requestID = dataRow["m_requestID"].ToString();
            record.M_actiontype = dataRow["m_actiontype"].ToString();
            record.M_businessType = dataRow["m_businessType"].ToString();

            record.M_mailincometime = Convert.ToDateTime(dataRow["m_mailincometime"]);
            
            return record;
        }

    }
}
