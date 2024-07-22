namespace CodeFirst_kindle
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnEntry = new Button();
            dg1 = new DataGridView();
            dg2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dg1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dg2).BeginInit();
            SuspendLayout();
            // 
            // btnEntry
            // 
            btnEntry.Location = new Point(12, 12);
            btnEntry.Name = "btnEntry";
            btnEntry.Size = new Size(112, 36);
            btnEntry.TabIndex = 0;
            btnEntry.Text = "登録（1:n）";
            btnEntry.UseVisualStyleBackColor = true;
            btnEntry.Click += btnEntry_Click;
            // 
            // dg1
            // 
            dg1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg1.Location = new Point(12, 54);
            dg1.Name = "dg1";
            dg1.Size = new Size(830, 230);
            dg1.TabIndex = 1;
            // 
            // dg2
            // 
            dg2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg2.Location = new Point(12, 301);
            dg2.Name = "dg2";
            dg2.Size = new Size(830, 230);
            dg2.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(854, 638);
            Controls.Add(dg2);
            Controls.Add(dg1);
            Controls.Add(btnEntry);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dg1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dg2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnEntry;
        private DataGridView dg1;
        private DataGridView dg2;
    }
}
