namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    partial class ViewMaterial
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
            dtMaterials = new DataGridView();
            btnSearch = new Button();
            txtSearch = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnExport = new Button();
            btnStockIn = new Button();
            btnStockOut = new Button();
            btnRecord = new Button();
            numMaterialStockQty = new NumericUpDown();
            btnProcurement = new Button();
            ((System.ComponentModel.ISupportInitialize)dtMaterials).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaterialStockQty).BeginInit();
            SuspendLayout();
            // 
            // dtMaterials
            // 
            dtMaterials.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtMaterials.Location = new Point(69, 114);
            dtMaterials.Name = "dtMaterials";
            dtMaterials.Size = new Size(759, 434);
            dtMaterials.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(366, 42);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(103, 40);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click_1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(97, 52);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(226, 23);
            txtSearch.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(507, 42);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(91, 40);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(865, 185);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(82, 40);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Update";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(865, 279);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 40);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(976, 279);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(82, 39);
            btnExport.TabIndex = 7;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnStockIn
            // 
            btnStockIn.Location = new Point(823, 42);
            btnStockIn.Name = "btnStockIn";
            btnStockIn.Size = new Size(86, 40);
            btnStockIn.TabIndex = 8;
            btnStockIn.Text = "Stock In";
            btnStockIn.UseVisualStyleBackColor = true;
            btnStockIn.Click += btnStockIn_Click;
            // 
            // btnStockOut
            // 
            btnStockOut.Location = new Point(924, 42);
            btnStockOut.Name = "btnStockOut";
            btnStockOut.Size = new Size(84, 40);
            btnStockOut.TabIndex = 9;
            btnStockOut.Text = "Stock Out";
            btnStockOut.UseVisualStyleBackColor = true;
            btnStockOut.Click += btnStockOut_Click;
            // 
            // btnRecord
            // 
            btnRecord.Location = new Point(976, 185);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(82, 37);
            btnRecord.TabIndex = 10;
            btnRecord.Text = "Record";
            btnRecord.UseVisualStyleBackColor = true;
            btnRecord.Click += btnRecord_Click;
            // 
            // numMaterialStockQty
            // 
            numMaterialStockQty.Location = new Point(677, 53);
            numMaterialStockQty.Name = "numMaterialStockQty";
            numMaterialStockQty.Size = new Size(120, 23);
            numMaterialStockQty.TabIndex = 11;
            // 
            // btnProcurement
            // 
            btnProcurement.Location = new Point(865, 386);
            btnProcurement.Name = "btnProcurement";
            btnProcurement.Size = new Size(100, 40);
            btnProcurement.TabIndex = 12;
            btnProcurement.Text = "Procurement";
            btnProcurement.UseVisualStyleBackColor = true;
            btnProcurement.Click += btnProcurement_Click;
            // 
            // ViewMaterial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1094, 620);
            Controls.Add(btnProcurement);
            Controls.Add(numMaterialStockQty);
            Controls.Add(btnRecord);
            Controls.Add(btnStockOut);
            Controls.Add(btnStockIn);
            Controls.Add(btnExport);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(dtMaterials);
            Name = "ViewMaterial";
            Text = "ViewMaterial";
            Load += ViewMaterial_Load;
            ((System.ComponentModel.ISupportInitialize)dtMaterials).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaterialStockQty).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtMaterials;
        private Button btnSearch;
        private TextBox txtSearch;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnExport;
        private Button btnStockIn;
        private Button btnStockOut;
        private Button btnRecord;
        private NumericUpDown numMaterialStockQty;
        private Button btnProcurement;
    }
}