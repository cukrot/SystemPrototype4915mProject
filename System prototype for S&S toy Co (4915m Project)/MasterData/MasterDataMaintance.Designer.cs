namespace System_prototype_for_S_S_toy_Co__4915m_Project_.MasterData
{
    partial class MasterDataMaintance
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
            btnFindByID = new Button();
            label1 = new Label();
            txtFindByID = new TextBox();
            panel1 = new Panel();
            btnRemoveFilter = new Button();
            sbSelFilter = new ComboBox();
            label3 = new Label();
            sbFilter = new ComboBox();
            btnFilterAdd = new Button();
            txtFilter = new TextBox();
            label2 = new Label();
            btnUpdate = new Button();
            btnReload = new Button();
            dataGridView1 = new DataGridView();
            sbTable = new ComboBox();
            btnGet = new Button();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(btnFindByID);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtFindByID);
            panel2.Location = new Point(34, 33);
            panel2.Name = "panel2";
            panel2.Size = new Size(234, 100);
            panel2.TabIndex = 16;
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
            txtFindByID.Location = new Point(14, 49);
            txtFindByID.Name = "txtFindByID";
            txtFindByID.Size = new Size(89, 23);
            txtFindByID.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnRemoveFilter);
            panel1.Controls.Add(sbSelFilter);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(sbFilter);
            panel1.Controls.Add(btnFilterAdd);
            panel1.Controls.Add(txtFilter);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(374, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(387, 191);
            panel1.TabIndex = 15;
            // 
            // btnRemoveFilter
            // 
            btnRemoveFilter.Location = new Point(156, 141);
            btnRemoveFilter.Name = "btnRemoveFilter";
            btnRemoveFilter.Size = new Size(150, 23);
            btnRemoveFilter.TabIndex = 13;
            btnRemoveFilter.Text = "Remover Selected Filter";
            btnRemoveFilter.UseVisualStyleBackColor = true;
            btnRemoveFilter.Click += btnRemoveFilter_Click;
            // 
            // sbSelFilter
            // 
            sbSelFilter.FormattingEnabled = true;
            sbSelFilter.Location = new Point(13, 141);
            sbSelFilter.Name = "sbSelFilter";
            sbSelFilter.Size = new Size(121, 23);
            sbSelFilter.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 100);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 11;
            label3.Text = "Selected Filtered";
            // 
            // sbFilter
            // 
            sbFilter.FormattingEnabled = true;
            sbFilter.Location = new Point(13, 49);
            sbFilter.Name = "sbFilter";
            sbFilter.Size = new Size(121, 23);
            sbFilter.TabIndex = 7;
            sbFilter.SelectedIndexChanged += sbFilter_SelectedIndexChanged;
            // 
            // btnFilterAdd
            // 
            btnFilterAdd.Location = new Point(309, 50);
            btnFilterAdd.Name = "btnFilterAdd";
            btnFilterAdd.Size = new Size(75, 23);
            btnFilterAdd.TabIndex = 9;
            btnFilterAdd.Text = "Add";
            btnFilterAdd.UseVisualStyleBackColor = true;
            btnFilterAdd.Click += btnFilterAdd_Click;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(156, 50);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(121, 23);
            txtFilter.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 15);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 8;
            label2.Text = "Filter";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(170, 215);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(48, 215);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(75, 23);
            btnReload.TabIndex = 13;
            btnReload.Text = "Reload";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(34, 279);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(464, 211);
            dataGridView1.TabIndex = 12;
            // 
            // sbTable
            // 
            sbTable.FormattingEnabled = true;
            sbTable.Location = new Point(34, 174);
            sbTable.Name = "sbTable";
            sbTable.Size = new Size(121, 23);
            sbTable.TabIndex = 17;
            // 
            // btnGet
            // 
            btnGet.Location = new Point(193, 173);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(75, 23);
            btnGet.TabIndex = 18;
            btnGet.Text = "Get";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // MasterDataMaintance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 535);
            Controls.Add(btnGet);
            Controls.Add(sbTable);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnUpdate);
            Controls.Add(btnReload);
            Controls.Add(dataGridView1);
            Name = "MasterDataMaintance";
            Text = "MasterDataMaintance";
            Load += MasterDataMaintance_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button btnFindByID;
        private Label label1;
        private TextBox txtFindByID;
        private Panel panel1;
        private Button btnRemoveFilter;
        private ComboBox sbSelFilter;
        private Label label3;
        private ComboBox sbFilter;
        private Button btnFilterAdd;
        private TextBox txtFilter;
        private Label label2;
        private Button btnUpdate;
        private Button btnReload;
        private DataGridView dataGridView1;
        private ComboBox sbTable;
        private Button btnGet;
    }
}