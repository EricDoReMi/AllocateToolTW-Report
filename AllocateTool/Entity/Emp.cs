using System;
using System.Data.OleDb;
using AllocateTool.utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllocateTool.Entity
{
    public partial class Emp
    {
        public Emp() {
            M_name = "";
            M_login = "0";
            M_statue = "1";
            M_mgid = 0;
           
        }

      

        public int M_id { get; set; }


        public string M_name { get; set; }

        public string M_title { get; set; }

        //是否登录了
        //0 未登录 1 登录
        public string M_login { get; set; }

        //是否在职了
        //0 不在职 1 在职
        public string M_statue { get; set; }

        //TeamLeaderId
        //0 TeamLeader
        public int? M_mgid { get; set; }

        public string M_shift { get; set; }



        public OleDbParameter[] ToInsertByParamArray()
        {
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@M_Name",EntityUtils.SqlNull(M_name)),new OleDbParameter("@M_title",EntityUtils.SqlNull(M_title)),new OleDbParameter("@M_login",EntityUtils.SqlNull(M_login)),new OleDbParameter("@M_statue",EntityUtils.SqlNull(M_statue)),new OleDbParameter("@M_mgid",EntityUtils.SqlNull(M_mgid)),new OleDbParameter("@M_shift",EntityUtils.SqlNull(M_shift))
            };

            for (int i = 0; i < param.Length; i++)
            {
                param[i].IsNullable = true;
            }

            return param;
        }

        public OleDbParameter[] ToUpdateByParamArray() {
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@M_Name",EntityUtils.SqlNull(M_name)),new OleDbParameter("@M_title",EntityUtils.SqlNull(M_title)),new OleDbParameter("@M_login",EntityUtils.SqlNull(M_login)),new OleDbParameter("@M_statue",EntityUtils.SqlNull(M_statue)),new OleDbParameter("@M_mgid",EntityUtils.SqlNull(M_mgid)),new OleDbParameter("@M_shift",EntityUtils.SqlNull(M_shift)),
                new OleDbParameter("@M_id",EntityUtils.SqlNull(M_id))
            };

            for (int i = 0; i < param.Length; i++)
            {
                param[i].IsNullable = true;
            }

            return param;

        }

        public override string ToString()
        {
            return String.Format("id:{0},Name:{1},Title:{2},登录状态:{3},在职状态:{4},LeaderId:{5},LeaderName:{6}", M_id, M_name, M_title, M_login, M_statue, M_mgid,M_leaderName);
        }
    }
}
