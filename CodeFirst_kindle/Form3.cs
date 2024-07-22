using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeFirst_kindle.MyEFCore;

namespace CodeFirst_kindle
{
    public partial class Form3 : Form
    {
        AndersonDbContext _context = new AndersonDbContext();


        public Form3()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            dg1.SelectionChanged += Dg1_SelectionChanged;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dg1.DataSource = _context.Products.ToList();
        }
        private void Dg1_SelectionChanged(object? sender, EventArgs e)
        {
            var p = dg1.CurrentRow.DataBoundItem as Product;

            if (p != null) 
            {
                // Enrty に Entiry をいれて、紐づくデータを取得
                _context.Entry(p).Collection(x => x.ProductItems).Load();
                dg2.DataSource = p.ProductItems;
            }
        }

    }
}
