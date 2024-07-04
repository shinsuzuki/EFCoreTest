namespace EFCoreForm2
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
            btnEF = new Button();
            dataGridView1 = new DataGridView();
            btnWhere = new Button();
            btnOrder = new Button();
            btnFind = new Button();
            btnFirstOrDefaurlt = new Button();
            btnLike = new Button();
            btnTest = new Button();
            btnInJoin = new Button();
            btnLeftJoin = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnEF
            // 
            btnEF.Location = new Point(34, 365);
            btnEF.Name = "btnEF";
            btnEF.Size = new Size(151, 41);
            btnEF.TabIndex = 0;
            btnEF.Text = "EF";
            btnEF.UseVisualStyleBackColor = true;
            btnEF.Click += btnEF_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(34, 21);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(685, 306);
            dataGridView1.TabIndex = 1;
            // 
            // btnWhere
            // 
            btnWhere.Location = new Point(34, 412);
            btnWhere.Name = "btnWhere";
            btnWhere.Size = new Size(151, 40);
            btnWhere.TabIndex = 2;
            btnWhere.Text = "Where";
            btnWhere.UseVisualStyleBackColor = true;
            btnWhere.Click += btnWhere_Click;
            // 
            // btnOrder
            // 
            btnOrder.Location = new Point(34, 458);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(151, 40);
            btnOrder.TabIndex = 3;
            btnOrder.Text = "Order";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // btnFind
            // 
            btnFind.Location = new Point(191, 365);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(151, 40);
            btnFind.TabIndex = 4;
            btnFind.Text = "Find";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // btnFirstOrDefaurlt
            // 
            btnFirstOrDefaurlt.Location = new Point(191, 411);
            btnFirstOrDefaurlt.Name = "btnFirstOrDefaurlt";
            btnFirstOrDefaurlt.Size = new Size(151, 40);
            btnFirstOrDefaurlt.TabIndex = 5;
            btnFirstOrDefaurlt.Text = "FirstOrDefault";
            btnFirstOrDefaurlt.UseVisualStyleBackColor = true;
            btnFirstOrDefaurlt.Click += btnFirstOrDefaurlt_Click;
            // 
            // btnLike
            // 
            btnLike.Location = new Point(191, 457);
            btnLike.Name = "btnLike";
            btnLike.Size = new Size(151, 40);
            btnLike.TabIndex = 6;
            btnLike.Text = "Like";
            btnLike.UseVisualStyleBackColor = true;
            btnLike.Click += btnLike_Click;
            // 
            // btnTest
            // 
            btnTest.Location = new Point(741, 21);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(151, 40);
            btnTest.TabIndex = 7;
            btnTest.Text = "Test";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // btnInJoin
            // 
            btnInJoin.Location = new Point(348, 366);
            btnInJoin.Name = "btnInJoin";
            btnInJoin.Size = new Size(151, 40);
            btnInJoin.TabIndex = 8;
            btnInJoin.Text = "InJoin";
            btnInJoin.UseVisualStyleBackColor = true;
            btnInJoin.Click += btnInJoin_Click;
            // 
            // btnLeftJoin
            // 
            btnLeftJoin.Location = new Point(348, 411);
            btnLeftJoin.Name = "btnLeftJoin";
            btnLeftJoin.Size = new Size(151, 40);
            btnLeftJoin.TabIndex = 9;
            btnLeftJoin.Text = "LeftJoin";
            btnLeftJoin.UseVisualStyleBackColor = true;
            btnLeftJoin.Click += btnLeftJoin_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 536);
            Controls.Add(btnLeftJoin);
            Controls.Add(btnInJoin);
            Controls.Add(btnTest);
            Controls.Add(btnLike);
            Controls.Add(btnFirstOrDefaurlt);
            Controls.Add(btnFind);
            Controls.Add(btnOrder);
            Controls.Add(btnWhere);
            Controls.Add(dataGridView1);
            Controls.Add(btnEF);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnEF;
        private DataGridView dataGridView1;
        private Button btnWhere;
        private Button btnOrder;
        private Button btnFind;
        private Button btnFirstOrDefaurlt;
        private Button btnLike;
        private Button btnTest;
        private Button btnInJoin;
        private Button btnLeftJoin;
    }
}
