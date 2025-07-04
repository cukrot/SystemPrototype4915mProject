namespace System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting2
{
    partial class Test_Insert
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtName = new TextBox();
            txtPhoneNum = new TextBox();
            txtAddress = new TextBox();
            txtEmail = new TextBox();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 84);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(80, 124);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 3;
            label3.Text = "PhoneNum";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(80, 164);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 4;
            label4.Text = "Address";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(80, 204);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 5;
            label5.Text = "Email";
            // 
            // txtName
            // 
            txtName.Location = new Point(163, 81);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 7;
            // 
            // txtPhoneNum
            // 
            txtPhoneNum.Location = new Point(163, 121);
            txtPhoneNum.Name = "txtPhoneNum";
            txtPhoneNum.Size = new Size(100, 23);
            txtPhoneNum.TabIndex = 8;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(163, 161);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(100, 23);
            txtAddress.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(163, 201);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 10;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(163, 265);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 11;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // Test_Insert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 360);
            Controls.Add(btnSubmit);
            Controls.Add(txtEmail);
            Controls.Add(txtAddress);
            Controls.Add(txtPhoneNum);
            Controls.Add(txtName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "Test_Insert";
            Text = "Insert Customer Data";
            Load += Test_Insert_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtName;
        private TextBox txtPhoneNum;
        private TextBox txtAddress;
        private TextBox txtEmail;
        private Button btnSubmit;
    }
}