namespace System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting2
{
    partial class Test_Insert
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
            lbColumns = new ListView();
            SuspendLayout();
            // 
            // lbColumns
            // 
            lbColumns.Location = new Point(232, 77);
            lbColumns.Name = "lbColumns";
            lbColumns.Size = new Size(494, 214);
            lbColumns.TabIndex = 0;
            lbColumns.UseCompatibleStateImageBehavior = false;
            // 
            // Test_Insert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbColumns);
            Name = "Test_Insert";
            Text = "Test_Insert";
            Load += Test_Insert_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView lbColumns;
    }
}