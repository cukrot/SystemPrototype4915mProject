namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    partial class MaterialProcurementListForm
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
            txtKeyword = new TextBox();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            btnSearch = new Button();
            dgvProcurement = new DataGridView();
            dtpEnd = new DateTimePicker();
            dtpStart = new DateTimePicker();
            btnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProcurement).BeginInit();
            SuspendLayout();
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(80, 116);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(218, 23);
            txtKeyword.TabIndex = 15;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(590, 261);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 35);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(590, 200);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(80, 35);
            btnEdit.TabIndex = 13;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(452, 105);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(87, 40);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(339, 105);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(91, 40);
            btnSearch.TabIndex = 11;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvProcurement
            // 
            dgvProcurement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProcurement.Location = new Point(78, 187);
            dgvProcurement.Name = "dgvProcurement";
            dgvProcurement.Size = new Size(436, 203);
            dgvProcurement.TabIndex = 10;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(339, 41);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(200, 23);
            dtpEnd.TabIndex = 9;
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(78, 41);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(200, 23);
            dtpStart.TabIndex = 8;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(590, 334);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(80, 34);
            btnExport.TabIndex = 16;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // MaterialProcurementListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExport);
            Controls.Add(txtKeyword);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(btnSearch);
            Controls.Add(dgvProcurement);
            Controls.Add(dtpEnd);
            Controls.Add(dtpStart);
            Name = "MaterialProcurementListForm";
            Text = "MaterialProcurementListForm";
            ((System.ComponentModel.ISupportInitialize)dgvProcurement).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtKeyword;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnSearch;
        private DataGridView dgvProcurement;
        private DateTimePicker dtpEnd;
        private DateTimePicker dtpStart;
        private Button btnExport;
    }
}