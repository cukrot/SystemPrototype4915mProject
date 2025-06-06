namespace System_prototype_for_S_S_toy_Co__4915m_Project_.ProductRequirement
{
    partial class ViewRequirements
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
            dtRequirement = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtRequirement).BeginInit();
            SuspendLayout();
            // 
            // dtRequirement
            // 
            dtRequirement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtRequirement.Location = new Point(48, 87);
            dtRequirement.Name = "dtRequirement";
            dtRequirement.Size = new Size(525, 287);
            dtRequirement.TabIndex = 0;
            // 
            // ViewRequirements
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtRequirement);
            Name = "ViewRequirements";
            Text = "ViewRequirements";
            Load += ViewRequirements_Load;
            ((System.ComponentModel.ISupportInitialize)dtRequirement).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtRequirement;
    }
}