namespace EFCoreForm2
{
    partial class FormUpdate
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
            txtProductId = new TextBox();
            txtProductName = new TextBox();
            txtPrice = new TextBox();
            btnSave = new Button();
            label1 = new Label();
            btnFind = new Button();
            btnInsertUpdate = new Button();
            dataGridView1 = new DataGridView();
            btnSearch = new Button();
            btnDelete = new Button();
            btnRemoveMatome = new Button();
            btnInsertOrder = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(12, 31);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(136, 26);
            txtProductId.TabIndex = 0;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(154, 31);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(136, 26);
            txtProductName.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(296, 31);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(136, 26);
            txtPrice.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(519, 32);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 25);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(149, 19);
            label1.TabIndex = 5;
            label1.Text = "●別コンテキストから更新";
            // 
            // btnFind
            // 
            btnFind.Location = new Point(438, 31);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(75, 26);
            btnFind.TabIndex = 3;
            btnFind.Text = "Find";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // btnInsertUpdate
            // 
            btnInsertUpdate.Location = new Point(438, 74);
            btnInsertUpdate.Name = "btnInsertUpdate";
            btnInsertUpdate.Size = new Size(156, 25);
            btnInsertUpdate.TabIndex = 6;
            btnInsertUpdate.Text = "InsertUpdate";
            btnInsertUpdate.UseVisualStyleBackColor = true;
            btnInsertUpdate.Click += btnInsertUpdate_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 155);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(420, 318);
            dataGridView1.TabIndex = 7;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(12, 123);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 26);
            btnSearch.TabIndex = 8;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(438, 155);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 26);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRemoveMatome
            // 
            btnRemoveMatome.Location = new Point(438, 187);
            btnRemoveMatome.Name = "btnRemoveMatome";
            btnRemoveMatome.Size = new Size(133, 26);
            btnRemoveMatome.TabIndex = 10;
            btnRemoveMatome.Text = "Delete Matome";
            btnRemoveMatome.UseVisualStyleBackColor = true;
            btnRemoveMatome.Click += btnRemoveMatome_Click;
            // 
            // btnInsertOrder
            // 
            btnInsertOrder.Location = new Point(597, 156);
            btnInsertOrder.Name = "btnInsertOrder";
            btnInsertOrder.Size = new Size(156, 25);
            btnInsertOrder.TabIndex = 11;
            btnInsertOrder.Text = "Insert Order";
            btnInsertOrder.UseVisualStyleBackColor = true;
            btnInsertOrder.Click += btnInsertOrder_Click;
            // 
            // FormUpdate
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 485);
            Controls.Add(btnInsertOrder);
            Controls.Add(btnRemoveMatome);
            Controls.Add(btnDelete);
            Controls.Add(btnSearch);
            Controls.Add(dataGridView1);
            Controls.Add(btnInsertUpdate);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(btnFind);
            Controls.Add(txtPrice);
            Controls.Add(txtProductName);
            Controls.Add(txtProductId);
            Name = "FormUpdate";
            Text = "FormUpdate";
            Load += FormUpdate_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtProductId;
        private TextBox txtProductName;
        private TextBox txtPrice;
        private Button btnSave;
        private Label label1;
        private Button btnFind;
        private Button btnInsertUpdate;
        private DataGridView dataGridView1;
        private Button btnSearch;
        private Button btnDelete;
        private Button btnRemoveMatome;
        private Button btnInsertOrder;
    }
}