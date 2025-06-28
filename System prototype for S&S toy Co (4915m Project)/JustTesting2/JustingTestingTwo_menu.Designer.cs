namespace System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting2
{
    partial class JustingTestingTwo_menu
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
            sbForm = new ComboBox();
            btnOpenForm = new Button();
            SuspendLayout();
            // 
            // sbForm
            // 
            sbForm.FormattingEnabled = true;
            sbForm.Location = new Point(63, 87);
            sbForm.Name = "sbForm";
            sbForm.Size = new Size(121, 23);
            sbForm.TabIndex = 0;
            // 
            // btnOpenForm
            // 
            btnOpenForm.Location = new Point(71, 184);
            btnOpenForm.Name = "btnOpenForm";
            btnOpenForm.Size = new Size(113, 23);
            btnOpenForm.TabIndex = 1;
            btnOpenForm.Text = "Open Form";
            btnOpenForm.UseVisualStyleBackColor = true;
            btnOpenForm.Click += btnOpenForm_Click;
            // 
            // JustingTestingTwo_menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 340);
            Controls.Add(btnOpenForm);
            Controls.Add(sbForm);
            Name = "JustingTestingTwo_menu";
            Text = "JustingTestingTwo_menu";
            Load += JustingTestingTwo_menu_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox sbForm;
        private Button btnOpenForm;
    }
}