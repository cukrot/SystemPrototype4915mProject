namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    partial class ViewMaterial
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
            dtMaterials = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtMaterials).BeginInit();
            SuspendLayout();
            // 
            // dtMaterials
            // 
            dtMaterials.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtMaterials.Location = new Point(69, 114);
            dtMaterials.Name = "dtMaterials";
            dtMaterials.Size = new Size(441, 266);
            dtMaterials.TabIndex = 0;
            // 
            // ViewMaterial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtMaterials);
            Name = "ViewMaterial";
            Text = "ViewMaterial";
            Load += ViewMaterial_Load;
            ((System.ComponentModel.ISupportInitialize)dtMaterials).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtMaterials;
    }
}