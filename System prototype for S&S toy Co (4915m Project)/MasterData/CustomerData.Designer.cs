namespace System_prototype_for_S_S_toy_Co__4915m_Project_.MasterData
{
    partial class CustomerData
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
            dgCustomer = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgCustomer).BeginInit();
            SuspendLayout();
            // 
            // dgCustomer
            // 
            dgCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgCustomer.Location = new Point(105, 93);
            dgCustomer.Name = "dgCustomer";
            dgCustomer.Size = new Size(456, 245);
            dgCustomer.TabIndex = 0;
            // 
            // CustomerData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgCustomer);
            Name = "CustomerData";
            Text = "CustomerData";
            Load += CustomerData_Load;
            ((System.ComponentModel.ISupportInitialize)dgCustomer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgCustomer;
    }
}