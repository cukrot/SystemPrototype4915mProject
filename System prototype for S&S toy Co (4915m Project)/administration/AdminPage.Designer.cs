namespace System_prototype_for_S_S_toy_Co__4915m_Project_.MasterData
{
    partial class AdminPage
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
            label2 = new Label();
            txtMessage = new Label();
            textBox1 = new TextBox();
            btnFindByID = new Button();
            btnReloadData = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtUserName = new TextBox();
            cbDept = new ComboBox();
            cbRole = new ComboBox();
            plModify = new Panel();
            txtEmpName = new TextBox();
            label8 = new Label();
            cbUserStatus = new ComboBox();
            cbEmpStatus = new ComboBox();
            label9 = new Label();
            btnUser = new Button();
            btnUpdate = new Button();
            btnReloadPage = new Button();
            plModify.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 37);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 0;
            label1.Text = "EmployeeID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 78);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Message";
            // 
            // txtMessage
            // 
            txtMessage.BorderStyle = BorderStyle.Fixed3D;
            txtMessage.Location = new Point(117, 78);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(509, 38);
            txtMessage.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(117, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            // 
            // btnFindByID
            // 
            btnFindByID.Location = new Point(258, 37);
            btnFindByID.Name = "btnFindByID";
            btnFindByID.Size = new Size(75, 23);
            btnFindByID.TabIndex = 4;
            btnFindByID.Text = "Find";
            btnFindByID.UseVisualStyleBackColor = true;
            btnFindByID.Click += btnFindByID_Click;
            // 
            // btnReloadData
            // 
            btnReloadData.Location = new Point(531, 228);
            btnReloadData.Name = "btnReloadData";
            btnReloadData.Size = new Size(102, 23);
            btnReloadData.TabIndex = 5;
            btnReloadData.Text = "Reload  Data";
            btnReloadData.UseVisualStyleBackColor = true;
            btnReloadData.Click += btnReloadData_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 41);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 6;
            label4.Text = "Employee Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 80);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 7;
            label5.Text = "Department";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(94, 116);
            label6.Name = "label6";
            label6.Size = new Size(33, 15);
            label6.TabIndex = 8;
            label6.Text = "Role";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(381, 40);
            label7.Name = "label7";
            label7.Size = new Size(70, 15);
            label7.TabIndex = 9;
            label7.Text = "User Name";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(467, 38);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(166, 23);
            txtUserName.TabIndex = 10;
            // 
            // cbDept
            // 
            cbDept.FormattingEnabled = true;
            cbDept.Location = new Point(143, 78);
            cbDept.Name = "cbDept";
            cbDept.Size = new Size(131, 23);
            cbDept.TabIndex = 12;
            // 
            // cbRole
            // 
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(143, 114);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(131, 23);
            cbRole.TabIndex = 13;
            // 
            // plModify
            // 
            plModify.BorderStyle = BorderStyle.Fixed3D;
            plModify.Controls.Add(txtEmpName);
            plModify.Controls.Add(label8);
            plModify.Controls.Add(btnReloadData);
            plModify.Controls.Add(cbUserStatus);
            plModify.Controls.Add(cbEmpStatus);
            plModify.Controls.Add(label9);
            plModify.Controls.Add(btnUser);
            plModify.Controls.Add(btnUpdate);
            plModify.Controls.Add(cbDept);
            plModify.Controls.Add(cbRole);
            plModify.Controls.Add(label4);
            plModify.Controls.Add(label5);
            plModify.Controls.Add(label6);
            plModify.Controls.Add(txtUserName);
            plModify.Controls.Add(label7);
            plModify.Location = new Point(21, 130);
            plModify.Name = "plModify";
            plModify.Size = new Size(672, 291);
            plModify.TabIndex = 14;
            // 
            // txtEmpName
            // 
            txtEmpName.Location = new Point(143, 38);
            txtEmpName.Name = "txtEmpName";
            txtEmpName.Size = new Size(154, 23);
            txtEmpName.TabIndex = 21;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(382, 80);
            label8.Name = "label8";
            label8.Size = new Size(69, 15);
            label8.TabIndex = 20;
            label8.Text = "User Status";
            // 
            // cbUserStatus
            // 
            cbUserStatus.FormattingEnabled = true;
            cbUserStatus.Location = new Point(467, 80);
            cbUserStatus.Name = "cbUserStatus";
            cbUserStatus.Size = new Size(166, 23);
            cbUserStatus.TabIndex = 19;
            // 
            // cbEmpStatus
            // 
            cbEmpStatus.FormattingEnabled = true;
            cbEmpStatus.Location = new Point(143, 150);
            cbEmpStatus.Name = "cbEmpStatus";
            cbEmpStatus.Size = new Size(131, 23);
            cbEmpStatus.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(58, 152);
            label9.Name = "label9";
            label9.Size = new Size(101, 15);
            label9.TabIndex = 17;
            label9.Text = "Employee Status";
            // 
            // btnUser
            // 
            btnUser.Location = new Point(502, 114);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(131, 41);
            btnUser.TabIndex = 15;
            btnUser.Text = "Reset User Name and Password";
            btnUser.UseVisualStyleBackColor = true;
            btnUser.Click += btnUser_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(199, 228);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Modify";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnReloadPage
            // 
            btnReloadPage.Location = new Point(363, 36);
            btnReloadPage.Name = "btnReloadPage";
            btnReloadPage.Size = new Size(84, 23);
            btnReloadPage.TabIndex = 16;
            btnReloadPage.Text = "Reload Page";
            btnReloadPage.UseVisualStyleBackColor = true;
            btnReloadPage.Click += btnReloadPage_Click;
            // 
            // AdminPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(plModify);
            Controls.Add(btnFindByID);
            Controls.Add(textBox1);
            Controls.Add(txtMessage);
            Controls.Add(label2);
            Controls.Add(btnReloadPage);
            Controls.Add(label1);
            Name = "AdminPage";
            Text = "UserAccountPage";
            Load += UserAccountPage_Load;
            plModify.ResumeLayout(false);
            plModify.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label txtMessage;
        private TextBox textBox1;
        private Button btnFindByID;
        private Button btnReloadData;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtUserName;
        private ComboBox cbDept;
        private ComboBox cbRole;
        private Panel plModify;
        private ComboBox cbEmpStatus;
        private Label label9;
        private Button btnReloadPage;
        private Button btnUser;
        private Button btnUpdate;
        private Label label8;
        private ComboBox cbUserStatus;
        private TextBox txtEmpName;
    }
}