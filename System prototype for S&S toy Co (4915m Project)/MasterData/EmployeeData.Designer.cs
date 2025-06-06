namespace System_prototype_for_S_S_toy_Co__4915m_Project_.MasterData
{
    partial class EmployeeData
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
            dtEmployee = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtEmployee).BeginInit();
            SuspendLayout();
            // 
            // dtEmployee
            // 
            dtEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtEmployee.Location = new Point(67, 83);
            dtEmployee.Name = "dtEmployee";
            dtEmployee.Size = new Size(449, 244);
            dtEmployee.TabIndex = 0;
            // 
            // EmployeeData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtEmployee);
            Name = "EmployeeData";
            Text = "EmployeeData";
            Load += EmployeeData_Load;
            ((System.ComponentModel.ISupportInitialize)dtEmployee).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtEmployee;
    }
}