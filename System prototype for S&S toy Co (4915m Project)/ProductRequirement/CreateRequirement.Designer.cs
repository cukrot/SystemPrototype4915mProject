namespace System_prototype_for_S_S_toy_Co__4915m_Project_.ProductRequirement
{
    partial class CreateRequirement
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
            lblDate = new Label();
            lblEmpID = new Label();
            label1 = new Label();
            panel2 = new Panel();
            btnFindByID = new Button();
            label2 = new Label();
            txtFindByID = new TextBox();
            panel1 = new Panel();
            btnFindByName = new Button();
            txtFilter = new TextBox();
            label4 = new Label();
            dtOrderline = new DataGridView();
            dtProductInfo = new DataGridView();
            btnAddProduct = new Button();
            btnRemoveProduct = new Button();
            btnSubmit = new Button();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtOrderline).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtProductInfo).BeginInit();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(221, 34);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(42, 15);
            lblDate.TabIndex = 0;
            lblDate.Text = "label1";
            // 
            // lblEmpID
            // 
            lblEmpID.AutoSize = true;
            lblEmpID.Location = new Point(94, 34);
            lblEmpID.Name = "lblEmpID";
            lblEmpID.Size = new Size(42, 15);
            lblEmpID.TabIndex = 1;
            lblEmpID.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 34);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 2;
            label1.Text = "SaleID :";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnFindByID);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtFindByID);
            panel2.Location = new Point(27, 66);
            panel2.Name = "panel2";
            panel2.Size = new Size(234, 100);
            panel2.TabIndex = 14;
            // 
            // btnFindByID
            // 
            btnFindByID.Location = new Point(136, 49);
            btnFindByID.Name = "btnFindByID";
            btnFindByID.Size = new Size(75, 23);
            btnFindByID.TabIndex = 4;
            btnFindByID.Text = "Find";
            btnFindByID.UseVisualStyleBackColor = true;
            btnFindByID.Click += btnFindByID_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 15);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "Find by ID";
            // 
            // txtFindByID
            // 
            txtFindByID.Location = new Point(14, 49);
            txtFindByID.Name = "txtFindByID";
            txtFindByID.Size = new Size(89, 23);
            txtFindByID.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnFindByName);
            panel1.Controls.Add(txtFilter);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(284, 66);
            panel1.Name = "panel1";
            panel1.Size = new Size(266, 100);
            panel1.TabIndex = 13;
            // 
            // btnFindByName
            // 
            btnFindByName.Location = new Point(172, 51);
            btnFindByName.Name = "btnFindByName";
            btnFindByName.Size = new Size(75, 23);
            btnFindByName.TabIndex = 9;
            btnFindByName.Text = "Find";
            btnFindByName.UseVisualStyleBackColor = true;
            btnFindByName.Click += btnFilterAdd_Click;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(13, 51);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(121, 23);
            txtFilter.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 15);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 8;
            label4.Text = "Find By Name";
            // 
            // dtOrderline
            // 
            dtOrderline.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtOrderline.Location = new Point(27, 297);
            dtOrderline.Name = "dtOrderline";
            dtOrderline.Size = new Size(523, 200);
            dtOrderline.TabIndex = 12;
            // 
            // dtProductInfo
            // 
            dtProductInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtProductInfo.Location = new Point(27, 199);
            dtProductInfo.Name = "dtProductInfo";
            dtProductInfo.Size = new Size(523, 69);
            dtProductInfo.TabIndex = 15;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(595, 245);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(97, 23);
            btnAddProduct.TabIndex = 16;
            btnAddProduct.Text = "Add Product";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnRemoveProduct
            // 
            btnRemoveProduct.Location = new Point(595, 297);
            btnRemoveProduct.Name = "btnRemoveProduct";
            btnRemoveProduct.Size = new Size(97, 23);
            btnRemoveProduct.TabIndex = 17;
            btnRemoveProduct.Text = "Add Product";
            btnRemoveProduct.UseVisualStyleBackColor = true;
            btnRemoveProduct.Click += btnRemoveProduct_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(595, 474);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(97, 23);
            btnSubmit.TabIndex = 18;
            btnSubmit.Text = "Add Product";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // CreateRequirement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 535);
            Controls.Add(btnSubmit);
            Controls.Add(btnRemoveProduct);
            Controls.Add(btnAddProduct);
            Controls.Add(dtProductInfo);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dtOrderline);
            Controls.Add(label1);
            Controls.Add(lblEmpID);
            Controls.Add(lblDate);
            Name = "CreateRequirement";
            Text = "CreateRequirement";
            Load += CreateRequirement_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtOrderline).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtProductInfo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDate;
        private Label lblEmpID;
        private Label label1;
        private Panel panel2;
        private Button btnFindByID;
        private Label label2;
        private TextBox txtFindByID;
        private Panel panel1;
        private Button btnFindByName;
        private TextBox txtFilter;
        private Label label4;
        private DataGridView dtOrderline;
        private DataGridView dtProductInfo;
        private Button btnAddProduct;
        private Button btnRemoveProduct;
        private Button btnSubmit;
    }
}