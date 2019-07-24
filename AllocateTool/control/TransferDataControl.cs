using System.Configuration;
using AllocateTool.dao;
using AllocateTool.Entity;
using AllocateTool.utils;
using System.Data.OleDb;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AllocateTool.AllocateToolException;
using System.IO;

namespace AllocateTool.control
{
    public partial class TransferDataControl
    {
        private EmpDAO empDao = new EmpDAO();
        private RecordDAO recordDao = new RecordDAO();
        private SenderListDAO senderListDao = new SenderListDAO();

        /// <summary>
        /// 转移数据库的Record表，用于合并数据库
        /// </summary>
        /// <param name="DesDataBase">被合并到的总库</param>
        /// <param name="SourceDataBases">要合并的原数据库</param>
        public  void TransferRecordDataBases(string DesDataBase,string SourceDataBases)
        {
          
            List<Record> desDataRecords = new List<Record>();
 
           OLDBHelper.dataSourceStr = SourceDataBases;
                List<Record> sourceDataRecords = FindSourceCompletedAndIncompletedRecords();
                 for (int i = 0; i < sourceDataRecords.Count; i++)
                {

                sourceDataRecords[i].M_isupload = "Y";
                Record desRecord = sourceDataRecords[i].QainClone();


                    string shipmentConsolNo= RegexHelper.GetFirstStrByRegex(@"(S|C){1}[0-9]{10}", sourceDataRecords[i].M_requestID.Trim());

                if (shipmentConsolNo.Length>0) {
                    desRecord.M_requestID =   shipmentConsolNo;
                }
                
                
                
                 desDataRecords.Add(desRecord);
                    
                }

           

            
            if (desDataRecords.Count > 0) {
                BathUpdateRecordsToDB(sourceDataRecords);
                OLDBHelper.DisposeDB();
                OLDBHelper.dataSourceStr = DesDataBase;
                BathAddRecordsToDB(desDataRecords);
            }

            OLDBHelper.DisposeDB();

        }

        public void TransferEmpDataBases(string DesDataBase, string SourceDataBases)
        {
            OLDBHelper.dataSourceStr = SourceDataBases;
            List<Emp> emps = FindAllEmpFromSourceData();
            OLDBHelper.dataSourceStr = DesDataBase;
            InitEmpsFromDesData();
            BathUpAddEmpsToDB(emps);
            OLDBHelper.DisposeDB();

        }

        public void TransferSenderListDataBases(string DesDataBase, string SourceDataBases)
        {
            OLDBHelper.dataSourceStr = SourceDataBases;
            List<SenderList> senders = FindAllSenderListFromSourceData();
            OLDBHelper.dataSourceStr = DesDataBase;
            InitSenderListFromDesData();
            BathAddSenderListToDB(senders);
            OLDBHelper.DisposeDB();

        }


        /// <summary>
        /// 寻找SourceData中所有的员工
        /// </summary>
        /// <returns></returns>
        private List<Emp> FindAllEmpFromSourceData() {
            List<Emp> empsList = null;
            try
            {
                OleDbConnection con = empDao.Begin();
                empsList = empDao.FindAllEmpDAO(con);
                empDao.Commit();
                return empsList;
            }
            catch (Exception)
            {
                empDao.RollBack();
                throw;
            }
            finally
            {
                empDao.Close();
            }
        }

        private List<SenderList> FindAllSenderListFromSourceData()
        {
            List<SenderList> senderList = null;
            try
            {
                OleDbConnection con = senderListDao.Begin();
                senderList = senderListDao.FindAllSenderListDAO(con);
                senderListDao.Commit();
                return senderList;
            }
            catch (Exception)
            {
                senderListDao.RollBack();
                throw;
            }
            finally
            {
                senderListDao.Close();
            }
        }

        /// <summary>
        /// 初始化DesData的emp表
        /// </summary>
        private void InitEmpsFromDesData()
        {
            
            try
            {
                OleDbConnection con = empDao.Begin();
                empDao.DeleteAllEmpsDAO(con);
                empDao.Commit();
                
            }
            catch (Exception)
            {
                empDao.RollBack();
                throw;
            }
            finally
            {
                empDao.Close();
            }
        }

        private void InitSenderListFromDesData()
        {

            try
            {
                OleDbConnection con = senderListDao.Begin();
                senderListDao.DeleteAllSenderListDAO(con);
                senderListDao.Commit();

            }
            catch (Exception)
            {
                senderListDao.RollBack();
                throw;
            }
            finally
            {
                senderListDao.Close();
            }
        }

        /// <summary>
        /// 寻找所有的Completed和Incompleted的case
        /// </summary>
        /// <returns></returns>
        private List<Record> FindSourceCompletedAndIncompletedRecords()
        {
            List<Record> records = null;
            try
            {
                OleDbConnection con = recordDao.Begin();
                records = recordDao.FindRecordsCompletedAndIncompleted(con);
                recordDao.Commit();
                return records;
            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }

        }

        public void GetReport(string sourceDateBaseStr, DateTime startDate, DateTime stopDate)
        {
           

            OLDBHelper.dataSourceStr = sourceDateBaseStr;
            OleDbConnection con = recordDao.Begin();

            DateTime inputDate = startDate;

            string outputPath = @".\resultDatas\";

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            while (DateTime.Compare(inputDate, stopDate) < 0)
            {
                List<Record> listsRecordSum = recordDao.FindRecordSumDur(con, inputDate, inputDate.AddDays(1));
                HashSet<string> uniqueSub = recordDao.GetUniqueSubject(con, inputDate);
                //写入CSV文件

                using (StreamWriter sw = new StreamWriter(outputPath + inputDate.ToString
                ("yyyyMMdd") + ".csv", false, Encoding.Default))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("RequestID,BsType,ActionType,MailIncomeDate");

                    sw.WriteLine(sb.ToString());

                    for (int i = 0; i < listsRecordSum.Count; i++)
                    {
                        Record recordSum = listsRecordSum[i];

                        string m_RequestID = recordSum.M_requestID.ToUpper().Trim();

                        if (m_RequestID.StartsWith("S"))
                        {
                            if (!uniqueSub.Contains(m_RequestID))
                            {
                                uniqueSub.Add(m_RequestID);
                                sw.WriteLine("\"" + m_RequestID + "\""+","+ "\"" + recordSum.M_businessType+ "\""+"," + "\"" + recordSum.M_actiontype + "\"" +","+ "\"" + recordSum.M_mailincometime.ToString() + "\"");

                            }
                        }


                        if (m_RequestID.StartsWith("C"))
                        {
                            if (recordSum.M_businessType.ToLower().Trim() == "import")
                            {
                                if (recordSum.M_actiontype.Contains("2") || recordSum.M_actiontype.ToUpper().Contains("IM") || recordSum.M_actiontype.ToUpper().Contains("FL"))
                                {
                                    sw.WriteLine("\"" + m_RequestID + "\"" + "," + "\"" + recordSum.M_businessType + "\"" + "," + "\"" + recordSum.M_actiontype + "\"" + "," + "\"" + recordSum.M_mailincometime.ToString() + "\"");
                                }
                                
                            }
                            else if (recordSum.M_businessType.ToLower().Trim() == "export")
                            {
                                if (recordSum.M_actiontype.Contains("1"))
                                {
                                    sw.WriteLine("\"" + m_RequestID + "\"" + "," + "\"" + recordSum.M_businessType + "\"" + "," + "\"" + recordSum.M_actiontype + "\"" + "," + "\"" + recordSum.M_mailincometime.ToString() + "\"");
                                }
                            }

                        }

                       



                    }
                }



                inputDate = inputDate.AddDays(1);

            }






            recordDao.Close();
            OLDBHelper.DisposeDB();





        }
        private void UpdateRecordToDB(Record record)
        {
            try
            {
                OleDbConnection con = recordDao.Begin();
                recordDao.UpdateRecordItemDAO(con, record);
                recordDao.Commit();

            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }
        }



        private void BathUpdateRecordsToDB(List<Record> records)
        {
            try
            {
                OleDbConnection con = recordDao.Begin();
                foreach (Record record in records)
                {
                    recordDao.UpdateRecordItemDAO(con, record);
                }

                recordDao.Commit();

            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }
        }

        private void BathUpdateEmpsToDB(List<Emp> emps)
        {
            try
            {
                OleDbConnection con = empDao.Begin();
                foreach (Emp emp in emps)
                {
                    empDao.UpdateEmpItemDAO(con, emp);
                }

                empDao.Commit();

            }
            catch (Exception)
            {
                empDao.RollBack();
                throw;
            }
            finally
            {
                empDao.Close();
            }
        }


        /// <summary>
        /// 将emp添加至数据库
        /// </summary>
        /// <param name="emp"></param>
        private void AddEmpToDB(Emp emp)
        {
            try
            {
                OleDbConnection con = empDao.Begin();
                empDao.AddEmpItemDAO(con, emp);
                empDao.Commit();

            }
            catch (Exception)
            {
                empDao.RollBack();
                throw;
            }
            finally
            {
                empDao.Close();
            }
        }

        private void BathUpAddEmpsToDB(List<Emp> emps)
        {
            try
            {
                OleDbConnection con = empDao.Begin();
                foreach (Emp emp in emps)
                {
                    empDao.AddEmpItemDAO(con, emp);
                }

                empDao.Commit();

            }
            catch (Exception)
            {
                empDao.RollBack();
                throw;
            }
            finally
            {
                empDao.Close();
            }
        }

        private void BathAddSenderListToDB(List<SenderList> senders)
        {
            try
            {
                OleDbConnection con = senderListDao.Begin();
                foreach (SenderList sender in senders)
                {
                    senderListDao.AddSenderListItemDAO(con, sender);
                }

                senderListDao.Commit();

            }
            catch (Exception)
            {
                senderListDao.RollBack();
                throw;
            }
            finally
            {
                senderListDao.Close();
            }
        }

        /// <summary>
        /// 向数据库添加单条Record的记录 
        /// </summary>
        /// <param name="record"></param>
        private void AddRecordToDB(Record record)
        {
            try
            {
                OleDbConnection con = recordDao.Begin();
                recordDao.AddRecordItemDAO(con, record);
                recordDao.Commit();

            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }
        }

        private void BathAddRecordsToDB(List<Record> records)
        {
            try
            {
                OleDbConnection con = recordDao.Begin();
                foreach (Record record in records)
                {
                    recordDao.AddRecordItemDAO(con, record);
                }

                recordDao.Commit();

            }
            catch (Exception)
            {
                recordDao.RollBack();
                throw;
            }
            finally
            {
                recordDao.Close();
            }
        }


    }
}
