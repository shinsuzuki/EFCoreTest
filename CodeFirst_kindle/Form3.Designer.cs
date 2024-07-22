namespace CodeFirst_kindle
{
    partial class Form3
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
            dg1 = new DataGridView();
            dg2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dg1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dg2).BeginInit();
            SuspendLayout();
            // 
            // dg1
            // 
            dg1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg1.Location = new Point(12, 12);
            dg1.Name = "dg1";
            dg1.Size = new Size(674, 165);
            dg1.TabIndex = 0;
            // 
            // dg2
            // 
            dg2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg2.Location = new Point(12, 183);
            dg2.Name = "dg2";
            dg2.Size = new Size(674, 165);
            dg2.TabIndex = 2;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 450);
            Controls.Add(dg2);
            Controls.Add(dg1);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)dg1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dg2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dg1;
        private DataGridView dg2;
    }
}