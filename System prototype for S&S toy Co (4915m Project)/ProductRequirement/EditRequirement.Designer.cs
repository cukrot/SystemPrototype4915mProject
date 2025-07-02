namespace System_prototype_for_S_S_toy_Co__4915m_Project_.ProductRequirement
{
    partial class EditRequirement
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
            btnFindByID = new Button();
            label1 = new Label();
            txtFindByID = new TextBox();
            sbIDType = new ComboBox();
            txtSaleID = new TextBox();
            txtDate = new TextBox();
            txtCustID = new TextBox();
            txtOrderID = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dateTimePicker = new DateTimePicker();
            label6 = new Label();
            cbStatus = new ComboBox();
            btnEdit = new Button();
            SuspendLayout();
            // 
            // btnFindByID
            // 
            btnFindByID.Location = new Point(138, 165);
            btnFindByID.Name = "btnFindByID";
            btnFindByID.Size = new Size(75, 23);
            btnFindByID.TabIndex = 7;
            btnFindByID.Text = "Find";
            btnFindByID.UseVisualStyleBackColor = true;
            btnFindByID.Click += btnFindByID_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 91);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 6;
            label1.Text = "Find by ID";
            // 
            // txtFindByID
            // 
            txtFindByID.Location = new Point(31, 166);
            txtFindByID.Name = "txtFindByID";
            txtFindByID.Size = new Size(89, 23);
            txtFindByID.TabIndex = 8;
            // 
            // sbIDType
            // 
            sbIDType.FormattingEnabled = true;
            sbIDType.Location = new Point(31, 127);
            sbIDType.Name = "sbIDType";
            sbIDType.Size = new Size(121, 23);
            sbIDType.TabIndex = 9;
            // 
            // txtSaleID
            // 
            txtSaleID.Location = new Point(404, 302);
            txtSaleID.Name = "txtSaleID";
            txtSaleID.Size = new Size(100, 23);
            txtSaleID.TabIndex = 11;
            // 
            // txtDate
            // 
            txtDate.Location = new Point(404, 181);
            txtDate.Name = "txtDate";
            txtDate.ReadOnly = true;
            txtDate.Size = new Size(100, 23);
            txtDate.TabIndex = 12;
            // 
            // txtCustID
            // 
            txtCustID.Location = new Point(404, 136);
            txtCustID.Name = "txtCustID";
            txtCustID.ReadOnly = true;
            txtCustID.Size = new Size(100, 23);
            txtCustID.TabIndex = 13;
            // 
            // txtOrderID
            // 
            txtOrderID.Location = new Point(404, 91);
            txtOrderID.Name = "txtOrderID";
            txtOrderID.ReadOnly = true;
            txtOrderID.Size = new Size(100, 23);
            txtOrderID.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(346, 91);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 15;
            label2.Text = "OrderID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(325, 137);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 16;
            label3.Text = "CustomerID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(357, 255);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 17;
            label4.Text = "Status";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(331, 183);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 18;
            label5.Text = "OrderDate";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(325, 210);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(200, 23);
            dateTimePicker.TabIndex = 19;
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(357, 302);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 20;
            label6.Text = "SaleID";
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(404, 255);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(121, 23);
            cbStatus.TabIndex = 21;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(450, 354);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 22;
            btnEdit.Text = "Modify";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // EditRequirement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEdit);
            Controls.Add(cbStatus);
            Controls.Add(label6);
            Controls.Add(dateTimePicker);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtOrderID);
            Controls.Add(txtCustID);
            Controls.Add(txtDate);
            Controls.Add(txtSaleID);
            Controls.Add(sbIDType);
            Controls.Add(btnFindByID);
            Controls.Add(label1);
            Controls.Add(txtFindByID);
            Name = "EditRequirement";
            Text = "EditRequirement";
            FormClosing += EditRequirement_FormClosing;
            Load += EditRequirement_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnFindByID;
        private Label label1;
        private TextBox txtFindByID;
        private ComboBox sbIDType;
        private TextBox txtSaleID;
        private TextBox txtDate;
        private TextBox txtCustID;
        private TextBox txtOrderID;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DateTimePicker dateTimePicker;
        private Label label6;
        private ComboBox cbStatus;
        private Button btnEdit;
    }
}