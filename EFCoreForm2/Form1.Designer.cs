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
            btnInclude = new Button();
            dataGridView2 = new DataGridView();
            btnCustomer = new Button();
            btnProductCustomer = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // btnEF
            // 
            btnEF.Location = new Point(12, 424);
            btnEF.Margin = new Padding(3, 2, 3, 2);
            btnEF.Name = "btnEF";
            btnEF.Size = new Size(134, 34);
            btnEF.TabIndex = 0;
            btnEF.Text = "EF";
            btnEF.UseVisualStyleBackColor = true;
            btnEF.Click += btnEF_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 17);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(806, 218);
            dataGridView1.TabIndex = 1;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // btnWhere
            // 
            btnWhere.Location = new Point(12, 462);
            btnWhere.Margin = new Padding(3, 2, 3, 2);
            btnWhere.Name = "btnWhere";
            btnWhere.Size = new Size(134, 33);
            btnWhere.TabIndex = 2;
            btnWhere.Text = "Where";
            btnWhere.UseVisualStyleBackColor = true;
            btnWhere.Click += btnWhere_Click;
            // 
            // btnOrder
            // 
            btnOrder.Location = new Point(12, 500);
            btnOrder.Margin = new Padding(3, 2, 3, 2);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(134, 33);
            btnOrder.TabIndex = 3;
            btnOrder.Text = "Order";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // btnFind
            // 
            btnFind.Location = new Point(152, 424);
            btnFind.Margin = new Padding(3, 2, 3, 2);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(134, 33);
            btnFind.TabIndex = 4;
            btnFind.Text = "Find";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // btnFirstOrDefaurlt
            // 
            btnFirstOrDefaurlt.Location = new Point(152, 462);
            btnFirstOrDefaurlt.Margin = new Padding(3, 2, 3, 2);
            btnFirstOrDefaurlt.Name = "btnFirstOrDefaurlt";
            btnFirstOrDefaurlt.Size = new Size(134, 33);
            btnFirstOrDefaurlt.TabIndex = 5;
            btnFirstOrDefaurlt.Text = "FirstOrDefault";
            btnFirstOrDefaurlt.UseVisualStyleBackColor = true;
            btnFirstOrDefaurlt.Click += btnFirstOrDefaurlt_Click;
            // 
            // btnLike
            // 
            btnLike.Location = new Point(152, 500);
            btnLike.Margin = new Padding(3, 2, 3, 2);
            btnLike.Name = "btnLike";
            btnLike.Size = new Size(134, 33);
            btnLike.TabIndex = 6;
            btnLike.Text = "Like";
            btnLike.UseVisualStyleBackColor = true;
            btnLike.Click += btnLike_Click;
            // 
            // btnTest
            // 
            btnTest.Location = new Point(12, 537);
            btnTest.Margin = new Padding(3, 2, 3, 2);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(134, 33);
            btnTest.TabIndex = 7;
            btnTest.Text = "Test";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // btnInJoin
            // 
            btnInJoin.Location = new Point(291, 424);
            btnInJoin.Margin = new Padding(3, 2, 3, 2);
            btnInJoin.Name = "btnInJoin";
            btnInJoin.Size = new Size(134, 33);
            btnInJoin.TabIndex = 8;
            btnInJoin.Text = "InJoin";
            btnInJoin.UseVisualStyleBackColor = true;
            btnInJoin.Click += btnInJoin_Click;
            // 
            // btnLeftJoin
            // 
            btnLeftJoin.Location = new Point(291, 462);
            btnLeftJoin.Margin = new Padding(3, 2, 3, 2);
            btnLeftJoin.Name = "btnLeftJoin";
            btnLeftJoin.Size = new Size(134, 33);
            btnLeftJoin.TabIndex = 9;
            btnLeftJoin.Text = "LeftJoin";
            btnLeftJoin.UseVisualStyleBackColor = true;
            btnLeftJoin.Click += btnLeftJoin_Click;
            // 
            // btnInclude
            // 
            btnInclude.Location = new Point(292, 500);
            btnInclude.Margin = new Padding(3, 2, 3, 2);
            btnInclude.Name = "btnInclude";
            btnInclude.Size = new Size(134, 33);
            btnInclude.TabIndex = 10;
            btnInclude.Text = "Include";
            btnInclude.UseVisualStyleBackColor = true;
            btnInclude.Click += btnInclude_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 239);
            dataGridView2.Margin = new Padding(3, 2, 3, 2);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(806, 172);
            dataGridView2.TabIndex = 11;
            // 
            // btnCustomer
            // 
            btnCustomer.Location = new Point(431, 425);
            btnCustomer.Margin = new Padding(3, 2, 3, 2);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(134, 33);
            btnCustomer.TabIndex = 12;
            btnCustomer.Text = "Customer";
            btnCustomer.UseVisualStyleBackColor = true;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // btnProductCustomer
            // 
            btnProductCustomer.Location = new Point(431, 462);
            btnProductCustomer.Margin = new Padding(3, 2, 3, 2);
            btnProductCustomer.Name = "btnProductCustomer";
            btnProductCustomer.Size = new Size(134, 71);
            btnProductCustomer.TabIndex = 13;
            btnProductCustomer.Text = "IncludeProductCustomer";
            btnProductCustomer.UseVisualStyleBackColor = true;
            btnProductCustomer.Click += btnProductCustomer_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 593);
            Controls.Add(btnProductCustomer);
            Controls.Add(btnCustomer);
            Controls.Add(dataGridView2);
            Controls.Add(btnInclude);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
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
        private Button btnInclude;
        private DataGridView dataGridView2;
        private Button btnCustomer;
        private Button btnProductCustomer;
    }
}
