namespace CodeFirst_kindle
{
    partial class Form2
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
            CustomerDataGrid = new DataGridView();
            StaffDataGrid = new DataGridView();
            button1 = new Button();
            dg1 = new DataGridView();
            dg2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)CustomerDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StaffDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dg1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dg2).BeginInit();
            SuspendLayout();
            // 
            // CustomerDataGrid
            // 
            CustomerDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CustomerDataGrid.Location = new Point(12, 37);
            CustomerDataGrid.Name = "CustomerDataGrid";
            CustomerDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomerDataGrid.Size = new Size(472, 224);
            CustomerDataGrid.TabIndex = 0;
            CustomerDataGrid.SelectionChanged += CustomerDataGrid_SelectionChanged;
            // 
            // StaffDataGrid
            // 
            StaffDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            StaffDataGrid.Location = new Point(571, 37);
            StaffDataGrid.Name = "StaffDataGrid";
            StaffDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            StaffDataGrid.Size = new Size(472, 224);
            StaffDataGrid.TabIndex = 1;
            StaffDataGrid.SelectionChanged += StaffDataGrid_SelectionChanged;
            // 
            // button1
            // 
            button1.Location = new Point(490, 117);
            button1.Name = "button1";
            button1.Size = new Size(75, 50);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dg1
            // 
            dg1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg1.Location = new Point(12, 267);
            dg1.Name = "dg1";
            dg1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg1.Size = new Size(472, 224);
            dg1.TabIndex = 3;
            // 
            // dg2
            // 
            dg2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg2.Location = new Point(571, 267);
            dg2.Name = "dg2";
            dg2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg2.Size = new Size(472, 224);
            dg2.TabIndex = 4;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1073, 646);
            Controls.Add(dg2);
            Controls.Add(dg1);
            Controls.Add(button1);
            Controls.Add(StaffDataGrid);
            Controls.Add(CustomerDataGrid);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)CustomerDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)StaffDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)dg1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dg2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView CustomerDataGrid;
        private DataGridView StaffDataGrid;
        private Button button1;
        private DataGridView dg1;
        private DataGridView dg2;
    }
}