using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AllocateTool.control;
using Microsoft.VisualBasic;
using AllocateTool.control;

namespace AllocateTool.ui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        TransferDataControl tsfDataCon = new TransferDataControl();

        /// <summary>
        /// 更新records表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadRecordsButton_Click(object sender, EventArgs e)
        {
            if (this.UsingDBText.Text.Length > 0 && this.SumDBText.Text.Length > 0)
            {

              try
                {
                    tsfDataCon.TransferRecordDataBases(this.SumDBText.Text, this.UsingDBText.Text);
                    MessageBox.Show("UploadRecords Sucess!");

                }
                catch (Exception)
                {
                    MessageBox.Show("UploadRecords Failed,Please contact OETeam!");

                }



            }
            else
            {
                MessageBox.Show("Please Select DataBases");
            }
            
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            DateTime startDate = Convert.ToDateTime(dateTimePickerStartDate.Text);
            DateTime stopDate = Convert.ToDateTime(dateTimePickerStopDate.Text);
            if (DateTime.Compare(startDate, stopDate) > 0)
            {
                MessageBox.Show("StartDate应小于StopDate");
                return;
            }
            //try
            //{
                tsfDataCon.GetReport(this.SumDBText.Text, startDate, stopDate);
                MessageBox.Show("导出完成了");
            //}
            //catch (Exception)
            //{
              //  MessageBox.Show("Genarate Report Failed,Please contact OETeam!");
               // throw;
            //}
        }
    }
}
