using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AllocateTool.utils;

namespace AllocateTool.Entity
{
    public partial class Record
    {

        public Record()
        {

            //数据库要求必须提供的默认值
            JOBID = "";
            M_acceptby = 0;//默认值
            UserName = "";
            M_subject = "";
            M_requestID = "";
            M_asign = 0;//默认值
            M_priority = 0;
            M_statu = "0";
            M_businessType = "";
            M_cw1ID = "";
            M_incompleteStatue = "";
            M_text = "";
            M_isupload = "N";

        }
        public long M_id { get; set; }

        public string JOBID { get; set; }

        public DateTime? T1 { get; set; }


        public string UserName { get; set; }

        public string M_subject { get; set; }


        public string M_requestID { get; set; }

        public string M_importance { get; set; }

        public string M_actiontype { get; set; }

        public string M_sender { get; set; }

        public int? M_acceptby { get; set; }

        public int? M_asign { get; set; }

        public DateTime? M_accepttime { get; set; }
        public DateTime? M_completetime { get; set; }
        public DateTime? M_incompletetime { get; set; }
        public DateTime? M_mailincometime { get; set; }
        public string M_incompleteStatue { get; set; }
        public double? M_priority { get; set; }
        public string M_text { get; set; }
        public string M_statu { get; set; }
        public string M_filePath { get; set; }

        public string M_businessType { get; set; }

        public string M_cw1ID { get; set; }

        public int? M_mailNum { get; set; }


        //是否有更新
        public string M_isupload { get; set; }


        public OleDbParameter[] ToInsertByParamArray()
        {
            OleDbParameter[] param = {
                    new OleDbParameter("@JOBID",EntityUtils.SqlNull(JOBID)),
                    new OleDbParameter("@T1",EntityUtils.SqlNull(T1)),
                    new OleDbParameter("@UserName",EntityUtils.SqlNull(UserName)),
                    new OleDbParameter("@M_subject",EntityUtils.SqlNull(M_subject)),
                    new OleDbParameter("@M_requestID",EntityUtils.SqlNull(M_requestID)),
                    new OleDbParameter("@M_importance",EntityUtils.SqlNull(M_importance)),
                    new OleDbParameter("@M_actiontype",EntityUtils.SqlNull(M_actiontype)),
                    new OleDbParameter("@M_sender",EntityUtils.SqlNull(M_sender)),
                    new OleDbParameter("@M_acceptby",EntityUtils.SqlNull(M_acceptby)),
                    new OleDbParameter("@M_asign",EntityUtils.SqlNull(M_asign)),
                    new OleDbParameter("@M_accepttime",EntityUtils.SqlNull(M_accepttime)),
                    new OleDbParameter("@M_completetime",EntityUtils.SqlNull(M_completetime)),
                    new OleDbParameter("@M_incompletetime",EntityUtils.SqlNull(M_incompletetime)),
                    new OleDbParameter("@M_mailincometime",EntityUtils.SqlNull(M_mailincometime)),
                    new OleDbParameter("@M_incompleteStatue",EntityUtils.SqlNull(M_incompleteStatue)),
                    new OleDbParameter("@M_priority",EntityUtils.SqlNull(M_priority)),
                    new OleDbParameter("@M_text",EntityUtils.SqlNull(M_text)),
                    new OleDbParameter("@M_statu",EntityUtils.SqlNull(M_statu)),
                    new OleDbParameter("@M_filePath",EntityUtils.SqlNull(M_filePath)),
                new OleDbParameter("@M_businessType",EntityUtils.SqlNull(M_businessType)),
                new OleDbParameter("@M_cw1ID",EntityUtils.SqlNull(M_cw1ID)),
                new OleDbParameter("@M_mailNum",EntityUtils.SqlNull(M_mailNum)),

                     new OleDbParameter("@M_isupload",EntityUtils.SqlNull(M_isupload))
            };

            for (int i = 0; i < param.Length; i++)
            {
                param[i].IsNullable = true;
            }



            return param;

        }

        public OleDbParameter[] ToUpdateByParamArray()
        {
            OleDbParameter[] param = {
                    new OleDbParameter("@JOBID",EntityUtils.SqlNull(JOBID)),
                    new OleDbParameter("@T1",EntityUtils.SqlNull(T1)),
                    new OleDbParameter("@UserName",EntityUtils.SqlNull(UserName)),
                    new OleDbParameter("@M_subject",EntityUtils.SqlNull(M_subject)),
                    new OleDbParameter("@M_requestID",EntityUtils.SqlNull(M_requestID)),
                    new OleDbParameter("@M_importance",EntityUtils.SqlNull(M_importance)),
                    new OleDbParameter("@M_actiontype",EntityUtils.SqlNull(M_actiontype)),
                    new OleDbParameter("@M_sender",EntityUtils.SqlNull(M_sender)),
                    new OleDbParameter("@M_acceptby",EntityUtils.SqlNull(M_acceptby)),
                    new OleDbParameter("@M_asign",EntityUtils.SqlNull(M_asign)),
                    new OleDbParameter("@M_accepttime",EntityUtils.SqlNull(M_accepttime)),
                    new OleDbParameter("@M_completetime",EntityUtils.SqlNull(M_completetime)),
                    new OleDbParameter("@M_incompletetime",EntityUtils.SqlNull(M_incompletetime)),
                    new OleDbParameter("@M_mailincometime",EntityUtils.SqlNull(M_mailincometime)),
                    new OleDbParameter("@M_incompleteStatue",EntityUtils.SqlNull(M_incompleteStatue)),
                    new OleDbParameter("@M_priority",EntityUtils.SqlNull(M_priority)),
                    new OleDbParameter("@M_text",EntityUtils.SqlNull(M_text)),
                    new OleDbParameter("@M_statu",EntityUtils.SqlNull(M_statu)),
                    new OleDbParameter("@M_filePath",EntityUtils.SqlNull(M_filePath)),
                      new OleDbParameter("@M_businessType",EntityUtils.SqlNull(M_businessType)),
                new OleDbParameter("@M_cw1ID",EntityUtils.SqlNull(M_cw1ID)),
                new OleDbParameter("@M_mailNum",EntityUtils.SqlNull(M_mailNum)),

                    new OleDbParameter("@M_isupload",EntityUtils.SqlNull(M_isupload)),
               new OleDbParameter("@M_id",M_id)
            };

            for (int i = 0; i < param.Length; i++)
            {
                param[i].IsNullable = true;
            }



            return param;

        }

        public override string ToString()
        {
            return String.Format("id:{0},Subject:{1},RequestId:{2},ActionType:{3},mailincomeTime:{4},filePath:{5},", M_id, M_subject, M_requestID, M_actiontype, M_mailincometime, M_filePath);
        }

        /// <summary>
        /// Record类的浅拷贝
        /// </summary>
        /// <returns></returns>
        public Record QainClone() {
            return MemberwiseClone() as Record;
        }
    }
}
