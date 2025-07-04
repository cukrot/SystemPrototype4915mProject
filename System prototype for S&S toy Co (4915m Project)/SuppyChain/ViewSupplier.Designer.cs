namespace System_prototype_for_S_S_toy_Co__4915m_Project_.SuppyChain
{
    partial class ViewSupplier
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
            panel2 = new Panel();
            btnReload = new Button();
            btnFindByID = new Button();
            label1 = new Label();
            txtFindByID = new TextBox();
            dgv = new DataGridView();
            panel1 = new Panel();
            btnFindByName = new Button();
            label2 = new Label();
            txtName = new TextBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(btnReload);
            panel2.Controls.Add(btnFindByID);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtFindByID);
            panel2.Location = new Point(70, 19);
            panel2.Name = "panel2";
            panel2.Size = new Size(295, 115);
            panel2.TabIndex = 19;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(217, 48);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(75, 23);
            btnReload.TabIndex = 18;
            btnReload.Text = "Reload";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // btnFindByID
            // 
            btnFindByID.Location = new Point(117, 48);
            btnFindByID.Name = "btnFindByID";
            btnFindByID.Size = new Size(75, 23);
            btnFindByID.TabIndex = 4;
            btnFindByID.Text = "Find";
            btnFindByID.UseVisualStyleBackColor = true;
            btnFindByID.Click += btnFindByID_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 15);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Find by ID";
            // 
            // txtFindByID
            // 
            txtFindByID.Location = new Point(12, 48);
            txtFindByID.Name = "txtFindByID";
            txtFindByID.Size = new Size(89, 23);
            txtFindByID.TabIndex = 5;
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(61, 151);
            dgv.Name = "dgv";
            dgv.Size = new Size(525, 287);
            dgv.TabIndex = 18;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnFindByName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtName);
            panel1.Location = new Point(400, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(295, 115);
            panel1.TabIndex = 20;
            // 
            // btnFindByName
            // 
            btnFindByName.Location = new Point(117, 48);
            btnFindByName.Name = "btnFindByName";
            btnFindByName.Size = new Size(75, 23);
            btnFindByName.TabIndex = 4;
            btnFindByName.Text = "Find";
            btnFindByName.UseVisualStyleBackColor = true;
            btnFindByName.Click += btnFindByName_Click;
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
            // txtName
            // 
            txtName.Location = new Point(12, 48);
            txtName.Name = "txtName";
            txtName.Size = new Size(89, 23);
            txtName.TabIndex = 5;
            // 
            // ViewSupplier
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(dgv);
            Name = "ViewSupplier";
            Text = "ViewSupplier";
            Load += ViewSupplier_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button btnReload;
        private Button btnFindByID;
        private Label label1;
        private TextBox txtFindByID;
        private DataGridView dgv;
        private Panel panel1;
        private Button btnFindByName;
        private Label label2;
        private TextBox txtName;
    }
}