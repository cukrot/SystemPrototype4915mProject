namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Menu
{
    partial class FlowPanelDesign
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
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnViewCustomer = new Button();
            btnViewEmp = new Button();
            button10 = new Button();
            button11 = new Button();
            panel1 = new Panel();
            lblMasterData = new Label();
            flowLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnViewCustomer);
            flowLayoutPanel2.Controls.Add(btnViewEmp);
            flowLayoutPanel2.Controls.Add(button10);
            flowLayoutPanel2.Controls.Add(button11);
            flowLayoutPanel2.Location = new Point(5, 46);
            flowLayoutPanel2.Margin = new Padding(5);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(383, 350);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // btnViewCustomer
            // 
            btnViewCustomer.Location = new Point(20, 20);
            btnViewCustomer.Margin = new Padding(20);
            btnViewCustomer.Name = "btnViewCustomer";
            btnViewCustomer.Size = new Size(125, 75);
            btnViewCustomer.TabIndex = 3;
            btnViewCustomer.Text = "View Customer Data";
            btnViewCustomer.UseVisualStyleBackColor = true;
            btnViewCustomer.Click += btnViewCustomer_Click;
            // 
            // btnViewEmp
            // 
            btnViewEmp.Location = new Point(185, 20);
            btnViewEmp.Margin = new Padding(20);
            btnViewEmp.Name = "btnViewEmp";
            btnViewEmp.Size = new Size(125, 75);
            btnViewEmp.TabIndex = 0;
            btnViewEmp.Text = "View Employee Data";
            btnViewEmp.UseVisualStyleBackColor = true;
            btnViewEmp.Click += btnViewEmp_Click;
            // 
            // button10
            // 
            button10.Location = new Point(20, 135);
            button10.Margin = new Padding(20);
            button10.Name = "button10";
            button10.Size = new Size(125, 75);
            button10.TabIndex = 1;
            button10.Text = "button10";
            button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Location = new Point(185, 135);
            button11.Margin = new Padding(20);
            button11.Name = "button11";
            button11.Size = new Size(125, 75);
            button11.TabIndex = 2;
            button11.Text = "button11";
            button11.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblMasterData);
            panel1.Controls.Add(flowLayoutPanel2);
            panel1.Location = new Point(55, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(425, 429);
            panel1.TabIndex = 5;
            // 
            // lblMasterData
            // 
            lblMasterData.AutoSize = true;
            lblMasterData.Font = new Font("Microsoft JhengHei UI", 16F);
            lblMasterData.Location = new Point(25, 14);
            lblMasterData.Name = "lblMasterData";
            lblMasterData.Size = new Size(132, 28);
            lblMasterData.TabIndex = 5;
            lblMasterData.Text = "MasterData";
            // 
            // FlowPanelDesign
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1509, 689);
            Controls.Add(panel1);
            Name = "FlowPanelDesign";
            Text = "FlowPanelDesign";
            flowLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnViewCustomer;
        private Button btnViewEmp;
        private Button button10;
        private Button button11;
        private Panel panel1;
        private Label lblMasterData;
    }
}