namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    partial class ViewProducts
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
            dtProduct = new DataGridView();
            btnExport = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            txtProductSearch = new TextBox();
            btnSearch = new Button();
            btnStockOut = new Button();
            btnStockIn = new Button();
            numStockQty = new NumericUpDown();
            btnRecord = new Button();
            cbWh = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dtProduct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockQty).BeginInit();
            SuspendLayout();
            // 
            // dtProduct
            // 
            dtProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtProduct.Location = new Point(51, 146);
            dtProduct.Name = "dtProduct";
            dtProduct.Size = new Size(715, 421);
            dtProduct.TabIndex = 0;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(855, 409);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(93, 39);
            btnExport.TabIndex = 14;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(856, 203);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(92, 40);
            btnEdit.TabIndex = 12;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(473, 59);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(91, 40);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtProductSearch
            // 
            txtProductSearch.Location = new Point(84, 76);
            txtProductSearch.Name = "txtProductSearch";
            txtProductSearch.Size = new Size(225, 23);
            txtProductSearch.TabIndex = 10;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(345, 59);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(103, 40);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnStockOut
            // 
            btnStockOut.Location = new Point(866, 53);
            btnStockOut.Name = "btnStockOut";
            btnStockOut.Size = new Size(84, 40);
            btnStockOut.TabIndex = 16;
            btnStockOut.Text = "Stock Out";
            btnStockOut.UseVisualStyleBackColor = true;
            btnStockOut.Click += btnStockOut_Click;
            // 
            // btnStockIn
            // 
            btnStockIn.Location = new Point(765, 53);
            btnStockIn.Name = "btnStockIn";
            btnStockIn.Size = new Size(86, 40);
            btnStockIn.TabIndex = 15;
            btnStockIn.Text = "Stock In";
            btnStockIn.UseVisualStyleBackColor = true;
            btnStockIn.Click += btnStockIn_Click;
            // 
            // numStockQty
            // 
            numStockQty.Location = new Point(611, 70);
            numStockQty.Name = "numStockQty";
            numStockQty.Size = new Size(120, 23);
            numStockQty.TabIndex = 17;
            // 
            // btnRecord
            // 
            btnRecord.Location = new Point(856, 295);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(92, 41);
            btnRecord.TabIndex = 18;
            btnRecord.Text = "Record";
            btnRecord.UseVisualStyleBackColor = true;
            btnRecord.Click += btnRecord_Click;
            // 
            // cbWh
            // 
            cbWh.FormattingEnabled = true;
            cbWh.Location = new Point(829, 146);
            cbWh.Name = "cbWh";
            cbWh.Size = new Size(121, 23);
            cbWh.TabIndex = 19;
            cbWh.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // ViewProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1170, 650);
            Controls.Add(cbWh);
            Controls.Add(btnRecord);
            Controls.Add(numStockQty);
            Controls.Add(btnStockOut);
            Controls.Add(btnStockIn);
            Controls.Add(btnExport);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtProductSearch);
            Controls.Add(btnSearch);
            Controls.Add(dtProduct);
            Name = "ViewProducts";
            Text = "ViewProducts";
            Load += ViewProducts_Load;
            ((System.ComponentModel.ISupportInitialize)dtProduct).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockQty).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtProduct;
        private Button btnExport;
        private Button btnEdit;
        private Button btnAdd;
        private TextBox txtProductSearch;
        private Button btnSearch;
        private Button btnStockOut;
        private Button btnStockIn;
        private NumericUpDown numStockQty;
        private Button btnRecord;
        private ComboBox cbWh;
    }
}