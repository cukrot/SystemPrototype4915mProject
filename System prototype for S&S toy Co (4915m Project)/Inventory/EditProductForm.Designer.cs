namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    partial class EditProductForm
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
            btnAdd = new Button();
            txtProductSearch = new TextBox();
            btnSearch = new Button();
            dtProduct = new DataGridView();
            btnDelete = new Button();
            btnEdit = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtProduct).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(560, 110);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(91, 40);
            btnAdd.TabIndex = 15;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // txtProductSearch
            // 
            txtProductSearch.Location = new Point(86, 127);
            txtProductSearch.Name = "txtProductSearch";
            txtProductSearch.Size = new Size(306, 23);
            txtProductSearch.TabIndex = 14;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(425, 110);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(103, 40);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dtProduct
            // 
            dtProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtProduct.Location = new Point(64, 202);
            dtProduct.Name = "dtProduct";
            dtProduct.Size = new Size(684, 301);
            dtProduct.TabIndex = 12;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(870, 322);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(93, 40);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(870, 226);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(92, 40);
            btnEdit.TabIndex = 16;
            btnEdit.Text = "Update";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 40);
            label1.Name = "label1";
            label1.Size = new Size(146, 15);
            label1.TabIndex = 18;
            label1.Text = "Edit product information";
            // 
            // EditProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 608);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtProductSearch);
            Controls.Add(btnSearch);
            Controls.Add(dtProduct);
            Name = "EditProductForm";
            Text = "EditProductForm";
            Load += EditProductForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)dtProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private TextBox txtProductSearch;
        private Button btnSearch;
        private DataGridView dtProduct;
        private Button btnDelete;
        private Button btnEdit;
        private Label label1;
    }
}