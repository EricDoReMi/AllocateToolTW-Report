using AllocateTool.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace AllocateTool.Entity
{
    public partial class SenderList
    {

        
        public int ID { get; set; }


        public string CW1ID { get; set; }

        public string NameColumn { get; set; }

        public bool InPosition { get; set; }

        public SenderList()
        {
            CW1ID = "";
            NameColumn = "";
            InPosition = true;
        }

        public OleDbParameter[] ToInsertByParamArray()
        {
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@CW1ID",EntityUtils.SqlNull(CW1ID)),new OleDbParameter("@NameColumn",EntityUtils.SqlNull(NameColumn)),new OleDbParameter("@InPosition",EntityUtils.SqlNull(InPosition))
            };

            for (int i = 0; i < param.Length; i++)
            {
                param[i].IsNullable = true;
            }

            return param;
        }

        public OleDbParameter[] ToUpdateByParamArray()
        {
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@CW1ID",EntityUtils.SqlNull(CW1ID)),new OleDbParameter("@NameColumn",EntityUtils.SqlNull(NameColumn)),new OleDbParameter("@InPosition",EntityUtils.SqlNull(InPosition)),
                new OleDbParameter("@ID",EntityUtils.SqlNull(ID))
            };

            for (int i = 0; i < param.Length; i++)
            {
                param[i].IsNullable = true;
            }

            return param;

        }
    }
}
