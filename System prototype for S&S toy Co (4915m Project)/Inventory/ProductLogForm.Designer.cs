namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    partial class ProductLogForm
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
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            dtLog = new DataGridView();
            btnQuery = new Button();
            btnExport = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtLog).BeginInit();
            SuspendLayout();
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(581, 100);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(146, 23);
            dtpStart.TabIndex = 0;
            // 
            // dtpEnd
            // 
            dtpEnd.CalendarTrailingForeColor = Color.Gainsboro;
            dtpEnd.Location = new Point(581, 153);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(146, 23);
            dtpEnd.TabIndex = 1;
            // 
            // dtLog
            // 
            dtLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtLog.Location = new Point(76, 100);
            dtLog.Name = "dtLog";
            dtLog.Size = new Size(414, 258);
            dtLog.TabIndex = 2;
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(602, 216);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(95, 38);
            btnQuery.TabIndex = 3;
            btnQuery.Text = "Query";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(602, 281);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(95, 43);
            btnExport.TabIndex = 4;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(97, 34);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 5;
            label1.Text = "RECORD";
            // 
            // ProductLogForm
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
            Name = "ProductLogForm";
            Text = "ProductLogForm";
            ((System.ComponentModel.ISupportInitialize)dtLog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
        private DataGridView dtLog;
        private Button btnQuery;
        private Button btnExport;
        private Label label1;
    }
}