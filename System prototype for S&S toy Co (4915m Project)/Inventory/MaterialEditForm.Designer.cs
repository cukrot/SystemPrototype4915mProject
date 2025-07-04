namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    partial class MaterialEditForm
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
            lblMaterialid = new Label();
            lblMaterialName = new Label();
            lblMaterialDescription = new Label();
            lblMaterialCategory = new Label();
            txtMaterialID = new TextBox();
            txtName = new TextBox();
            txtDesc = new TextBox();
            textBox4 = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblMaterialid
            // 
            lblMaterialid.Font = new Font("Bahnschrift SemiLight", 15F);
            lblMaterialid.Location = new Point(127, 98);
            lblMaterialid.Name = "lblMaterialid";
            lblMaterialid.Size = new Size(121, 43);
            lblMaterialid.TabIndex = 0;
            lblMaterialid.Text = "Material ID:";
            lblMaterialid.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaterialName
            // 
            lblMaterialName.Font = new Font("Bahnschrift SemiLight", 15F);
            lblMaterialName.Location = new Point(127, 173);
            lblMaterialName.Name = "lblMaterialName";
            lblMaterialName.Size = new Size(121, 43);
            lblMaterialName.TabIndex = 1;
            lblMaterialName.Text = "Name:  ";
            lblMaterialName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaterialDescription
            // 
            lblMaterialDescription.Font = new Font("Bahnschrift SemiLight", 15F);
            lblMaterialDescription.Location = new Point(127, 323);
            lblMaterialDescription.Name = "lblMaterialDescription";
            lblMaterialDescription.Size = new Size(121, 43);
            lblMaterialDescription.TabIndex = 2;
            lblMaterialDescription.Text = "Description:";
            lblMaterialDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaterialCategory
            // 
            lblMaterialCategory.Font = new Font("Bahnschrift SemiLight", 15F);
            lblMaterialCategory.Location = new Point(127, 248);
            lblMaterialCategory.Name = "lblMaterialCategory";
            lblMaterialCategory.Size = new Size(121, 43);
            lblMaterialCategory.TabIndex = 3;
            lblMaterialCategory.Text = "Category:";
            lblMaterialCategory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtMaterialID
            // 
            txtMaterialID.Font = new Font("Microsoft JhengHei UI", 15F);
            txtMaterialID.Location = new Point(271, 104);
            txtMaterialID.Name = "txtMaterialID";
            txtMaterialID.Size = new Size(278, 33);
            txtMaterialID.TabIndex = 4;
            // 
            // txtName
            // 
            txtName.Font = new Font("Microsoft JhengHei UI", 15F);
            txtName.Location = new Point(271, 179);
            txtName.Name = "txtName";
            txtName.Size = new Size(278, 33);
            txtName.TabIndex = 5;
            // 
            // txtDesc
            // 
            txtDesc.Font = new Font("Microsoft JhengHei UI", 15F);
            txtDesc.Location = new Point(271, 254);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(278, 33);
            txtDesc.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Microsoft JhengHei UI", 15F);
            textBox4.Location = new Point(271, 333);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(587, 33);
            textBox4.TabIndex = 7;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("Bahnschrift SemiLight", 15F);
            btnOK.Location = new Point(174, 451);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(152, 50);
            btnOK.TabIndex = 8;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Bahnschrift SemiLight", 15F);
            btnCancel.Location = new Point(400, 451);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(149, 50);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // MaterialEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1009, 627);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(textBox4);
            Controls.Add(txtDesc);
            Controls.Add(txtName);
            Controls.Add(txtMaterialID);
            Controls.Add(lblMaterialCategory);
            Controls.Add(lblMaterialDescription);
            Controls.Add(lblMaterialName);
            Controls.Add(lblMaterialid);
            Name = "MaterialEditForm";
            Text = "MaterialEditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaterialid;
        private Label lblMaterialName;
        private Label lblMaterialDescription;
        private Label lblMaterialCategory;
        private TextBox txtMaterialID;
        private TextBox txtName;
        private TextBox txtDesc;
        private TextBox textBox4;
        private Button btnOK;
        private Button btnCancel;
    }
}