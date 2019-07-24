namespace AllocateTool.ui
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UploadRecordsButton = new System.Windows.Forms.Button();
            this.UsingDBText = new System.Windows.Forms.TextBox();
            this.SumDBText = new System.Windows.Forms.TextBox();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.dateTimePickerStopDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "UsingDB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "SumDB";
            // 
            // UploadRecordsButton
            // 
            this.UploadRecordsButton.ForeColor = System.Drawing.Color.Red;
            this.UploadRecordsButton.Location = new System.Drawing.Point(481, 85);
            this.UploadRecordsButton.Name = "UploadRecordsButton";
            this.UploadRecordsButton.Size = new System.Drawing.Size(108, 30);
            this.UploadRecordsButton.TabIndex = 12;
            this.UploadRecordsButton.Text = "UploadRecords";
            this.UploadRecordsButton.UseVisualStyleBackColor = true;
            this.UploadRecordsButton.Click += new System.EventHandler(this.UploadRecordsButton_Click);
            // 
            // UsingDBText
            // 
            this.UsingDBText.Enabled = false;
            this.UsingDBText.Location = new System.Drawing.Point(30, 91);
            this.UsingDBText.Name = "UsingDBText";
            this.UsingDBText.Size = new System.Drawing.Size(193, 21);
            this.UsingDBText.TabIndex = 10;
            this.UsingDBText.Text = "TWdb.accdb";
            // 
            // SumDBText
            // 
            this.SumDBText.Enabled = false;
            this.SumDBText.Location = new System.Drawing.Point(254, 91);
            this.SumDBText.Name = "SumDBText";
            this.SumDBText.Size = new System.Drawing.Size(193, 21);
            this.SumDBText.TabIndex = 11;
            this.SumDBText.Text = "TWdb-Sum.accdb";
            // 
            // btnExportReport
            // 
            this.btnExportReport.Location = new System.Drawing.Point(481, 163);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(108, 23);
            this.btnExportReport.TabIndex = 24;
            this.btnExportReport.Text = "ExportReport";
            this.btnExportReport.UseVisualStyleBackColor = true;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // dateTimePickerStopDate
            // 
            this.dateTimePickerStopDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerStopDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStopDate.Location = new System.Drawing.Point(251, 165);
            this.dateTimePickerStopDate.Name = "dateTimePickerStopDate";
            this.dateTimePickerStopDate.Size = new System.Drawing.Size(123, 21);
            this.dateTimePickerStopDate.TabIndex = 23;
            this.dateTimePickerStopDate.Value = new System.DateTime(2019, 7, 31, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "StopDate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "StartDate";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(30, 165);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(123, 21);
            this.dateTimePickerStartDate.TabIndex = 20;
            this.dateTimePickerStartDate.Value = new System.DateTime(2019, 7, 1, 0, 0, 0, 0);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 316);
            this.Controls.Add(this.btnExportReport);
            this.Controls.Add(this.dateTimePickerStopDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.SumDBText);
            this.Controls.Add(this.UsingDBText);
            this.Controls.Add(this.UploadRecordsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "AllocateTW-ReportTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UploadRecordsButton;
        private System.Windows.Forms.TextBox UsingDBText;
        private System.Windows.Forms.TextBox SumDBText;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.DateTimePicker dateTimePickerStopDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
    }
}