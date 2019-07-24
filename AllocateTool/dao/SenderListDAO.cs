using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using AllocateTool.Entity;
using AllocateTool.utils;

namespace AllocateTool.dao
{
    public partial class SenderListDAO : BaseDAO<SenderList>
    {

        public void AddSenderListItemDAO(OleDbConnection conn, SenderList sender)
        {

            string sqlStr = @"INSERT INTO senderList(CW1ID,NameColumn,InPosition) VALUES(@CW1ID,@NameColumn,@InPosition);";
            OleDbParameter[] paras = sender.ToInsertByParamArray();
            ExecuteSQLNonquery(conn, sqlStr, paras);

        }

        public void UpdateSenderListItemDAO(OleDbConnection conn, SenderList sender)
        {
            string sqlStr = @"UPDATE senderList SET CW1ID=@CW1ID,NameColumn=@NameColumn,InPosition=@InPosition WHERE ID=@ID;";
            OleDbParameter[] paras = sender.ToUpdateByParamArray();
            ExecuteSQLNonquery(conn, sqlStr, paras);
        }



        public List<SenderList> FindAllSenderListDAO(OleDbConnection conn)
        {
            string sqlStr = @"SELECT * From senderList;";
            List<SenderList> list = queryEntity(conn, sqlStr);
            return list;
        }



        public void DeleteSenderListByIdDAO(OleDbConnection conn, int id)
        {
            string sqlStr = @"DELETE * FROM senderList WHERE ID=@ID";
            OleDbParameter[] paras = new OleDbParameter[] { new OleDbParameter("@ID", id) };
            ExecuteSQLNonquery(conn, sqlStr, paras);
        }

        public void DeleteAllSenderListDAO(OleDbConnection conn)
        {
            string sqlStr = @"DELETE * FROM senderList;";
            ExecuteSQLNonquery(conn, sqlStr);
            sqlStr = @"ALTER TABLE senderList ALTER COLUMN ID COUNTER(1,1);";
            ExecuteSQLNonquery(conn, sqlStr);
        }
        public override SenderList ToEntity(OleDbDataReader reader)
        {
            SenderList senderList = new SenderList();
            EntityUtils.FillEntity<SenderList>(reader, senderList);
            return senderList;
        }
    }
}
