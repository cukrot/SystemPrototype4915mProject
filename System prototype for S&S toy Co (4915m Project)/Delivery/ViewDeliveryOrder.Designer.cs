namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Delivery
{
    partial class ViewDeliveryOrder
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
            dtDOrders = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtDOrders).BeginInit();
            SuspendLayout();
            // 
            // dtDOrders
            // 
            dtDOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtDOrders.Location = new Point(79, 88);
            dtDOrders.Name = "dtDOrders";
            dtDOrders.Size = new Size(412, 240);
            dtDOrders.TabIndex = 0;
            // 
            // ViewDeliveryOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtDOrders);
            Name = "ViewDeliveryOrder";
            Text = "ViewDeliveryOrder";
            Load += ViewDeliveryOrder_Load;
            ((System.ComponentModel.ISupportInitialize)dtDOrders).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtDOrders;
    }
}