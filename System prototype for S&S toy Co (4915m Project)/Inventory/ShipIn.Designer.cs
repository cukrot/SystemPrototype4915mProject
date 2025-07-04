namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    partial class ShipIn
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
            txtID = new TextBox();
            txtQty = new TextBox();
            lblID = new Label();
            cbGoodType = new ComboBox();
            btnShipIn = new Button();
            cbWh = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 86);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 0;
            label1.Text = "Good Type";
            // 
            // txtID
            // 
            txtID.Location = new Point(145, 124);
            txtID.Name = "txtID";
            txtID.Size = new Size(121, 23);
            txtID.TabIndex = 1;
            txtID.TextChanged += txtID_TextChanged;
            // 
            // txtQty
            // 
            txtQty.Location = new Point(145, 200);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(121, 23);
            txtQty.TabIndex = 2;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(103, 124);
            lblID.Name = "lblID";
            lblID.Size = new Size(19, 15);
            lblID.TabIndex = 3;
            lblID.Text = "ID";
            // 
            // cbGoodType
            // 
            cbGoodType.FormattingEnabled = true;
            cbGoodType.Location = new Point(145, 86);
            cbGoodType.Name = "cbGoodType";
            cbGoodType.Size = new Size(121, 23);
            cbGoodType.TabIndex = 4;
            cbGoodType.SelectedIndexChanged += cbGoodType_SelectedIndexChanged;
            // 
            // btnShipIn
            // 
            btnShipIn.Location = new Point(191, 311);
            btnShipIn.Name = "btnShipIn";
            btnShipIn.Size = new Size(75, 23);
            btnShipIn.TabIndex = 5;
            btnShipIn.Text = "Confirm Ship In";
            btnShipIn.UseVisualStyleBackColor = true;
            btnShipIn.Click += btnShipIn_Click;
            // 
            // cbWh
            // 
            cbWh.FormattingEnabled = true;
            cbWh.Location = new Point(145, 238);
            cbWh.Name = "cbWh";
            cbWh.Size = new Size(121, 23);
            cbWh.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(67, 200);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 7;
            label3.Text = "Quantity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 238);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 8;
            label4.Text = "Warehouse";
            // 
            // txtName
            // 
            txtName.Location = new Point(145, 162);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(121, 23);
            txtName.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 162);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 10;
            label2.Text = "Good Name";
            // 
            // ShipIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cbWh);
            Controls.Add(btnShipIn);
            Controls.Add(cbGoodType);
            Controls.Add(lblID);
            Controls.Add(txtQty);
            Controls.Add(txtID);
            Controls.Add(label1);
            Name = "ShipIn";
            Text = "ShipIn";
            Load += ShipIn_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtID;
        private TextBox txtQty;
        private Label lblID;
        private ComboBox cbGoodType;
        private Button btnShipIn;
        private ComboBox cbWh;
        private Label label3;
        private Label label4;
        private TextBox txtName;
        private Label label2;
    }
}