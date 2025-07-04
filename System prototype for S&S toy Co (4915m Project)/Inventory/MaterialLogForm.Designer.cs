namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    partial class MaterialLogForm
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
            label1 = new Label();
            btnExport = new Button();
            btnQuery = new Button();
            dtLog = new DataGridView();
            dtpEnd = new DateTimePicker();
            dtpStart = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dtLog).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(98, 48);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 11;
            label1.Text = "RECORD";
            // 
            // btnExport
            // 
            btnExport.Location = new Point(604, 290);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(95, 43);
            btnExport.TabIndex = 10;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(604, 222);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(95, 38);
            btnQuery.TabIndex = 9;
            btnQuery.Text = "Query";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click;
            // 
            // dtLog
            // 
            dtLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtLog.Location = new Point(77, 114);
            dtLog.Name = "dtLog";
            dtLog.Size = new Size(466, 258);
            dtLog.TabIndex = 8;
            // 
            // dtpEnd
            // 
            dtpEnd.CalendarTrailingForeColor = Color.Gainsboro;
            dtpEnd.Location = new Point(579, 164);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(153, 23);
            dtpEnd.TabIndex = 7;
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(579, 114);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(153, 23);
            dtpStart.TabIndex = 6;
            // 
            // MaterialLogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnExport);
            Controls.Add(btnQuery);
            Controls.Add(dtLog);
            Controls.Add(dtpEnd);
            Controls.Add(dtpStart);
            Name = "MaterialLogForm";
            Text = "MaterialLogForm";
            ((System.ComponentModel.ISupportInitialize)dtLog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnExport;
        private Button btnQuery;
        private DataGridView dtLog;
        private DateTimePicker dtpEnd;
        private DateTimePicker dtpStart;
    }
}