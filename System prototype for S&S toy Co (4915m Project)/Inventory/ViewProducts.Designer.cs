namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    partial class ViewProducts
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
            dtProduct = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtProduct).BeginInit();
            SuspendLayout();
            // 
            // dtProduct
            // 
            dtProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtProduct.Location = new Point(108, 120);
            dtProduct.Name = "dtProduct";
            dtProduct.Size = new Size(450, 252);
            dtProduct.TabIndex = 0;
            // 
            // ViewProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtProduct);
            Name = "ViewProducts";
            Text = "ViewProducts";
            Load += ViewProducts_Load;
            ((System.ComponentModel.ISupportInitialize)dtProduct).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtProduct;
    }
}