namespace System_prototype_for_S_S_toy_Co__4915m_Project_.SuppyChain
{
    partial class ViewPurchase
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
            btnReload = new Button();
            panel2 = new Panel();
            btnFindByID = new Button();
            label1 = new Label();
            txtFindByID = new TextBox();
            dtPurchase = new DataGridView();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtPurchase).BeginInit();
            SuspendLayout();
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
            // panel2
            // 
            panel2.Controls.Add(btnReload);
            panel2.Controls.Add(btnFindByID);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtFindByID);
            panel2.Location = new Point(31, 33);
            panel2.Name = "panel2";
            panel2.Size = new Size(295, 115);
            panel2.TabIndex = 17;
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
            // dtPurchase
            // 
            dtPurchase.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtPurchase.Location = new Point(12, 247);
            dtPurchase.Name = "dtPurchase";
            dtPurchase.Size = new Size(525, 287);
            dtPurchase.TabIndex = 15;
            // 
            // ViewPurchase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 614);
            Controls.Add(panel2);
            Controls.Add(dtPurchase);
            Name = "ViewPurchase";
            Text = "ViewPurchase";
            Load += ViewPurchase_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtPurchase).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnReload;
        private Panel panel2;
        private Button btnFindByID;
        private Label label1;
        private TextBox txtFindByID;
        private DataGridView dtPurchase;
    }
}