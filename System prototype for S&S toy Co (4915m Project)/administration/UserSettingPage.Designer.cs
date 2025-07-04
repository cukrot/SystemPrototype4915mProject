namespace System_prototype_for_S_S_toy_Co__4915m_Project_.administration
{
    partial class UserSettingPage
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
            txtUserName = new TextBox();
            txtUserPW = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnSumbit = new Button();
            SuspendLayout();
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(134, 60);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(100, 23);
            txtUserName.TabIndex = 0;
            // 
            // txtUserPW
            // 
            txtUserPW.Location = new Point(134, 104);
            txtUserPW.Name = "txtUserPW";
            txtUserPW.Size = new Size(100, 23);
            txtUserPW.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 60);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 2;
            label1.Text = "New User Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 104);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 3;
            label2.Text = "New Password";
            // 
            // btnSumbit
            // 
            btnSumbit.Location = new Point(159, 160);
            btnSumbit.Name = "btnSumbit";
            btnSumbit.Size = new Size(75, 23);
            btnSumbit.TabIndex = 4;
            btnSumbit.Text = "Set";
            btnSumbit.UseVisualStyleBackColor = true;
            btnSumbit.Click += btnSumbit_Click;
            // 
            // UserSettingPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 252);
            Controls.Add(btnSumbit);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtUserPW);
            Controls.Add(txtUserName);
            Name = "UserSettingPage";
            Text = "UserSettingPage";
            Load += UserSettingPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUserName;
        private TextBox txtUserPW;
        private Label label1;
        private Label label2;
        private Button btnSumbit;
    }
}