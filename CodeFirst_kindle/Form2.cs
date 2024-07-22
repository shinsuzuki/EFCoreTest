using CodeFirst_kindle.MyEFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst_kindle
{
    public partial class Form2 : Form
    {
        AndersonDbContext _context = new AndersonDbContext();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CustomerDataGrid.DataSource = _context.Customers.Include(x => x.Staffs).ToList();
            StaffDataGrid.DataSource = _context.Staffs.Include(x => x.Customers).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c = CustomerDataGrid.CurrentRow.DataBoundItem as Customer;
            foreach (DataGridViewRow row in StaffDataGrid.SelectedRows)
            {
                var s = row.DataBoundItem as Staff;
                if (s != null)
                {
                    if (c != null)
                    {
                        c.Staffs.Add(s);
                    }
                }
            }

            _context.SaveChanges();
        }

        private void CustomerDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            var c = CustomerDataGrid.CurrentRow.DataBoundItem as Customer;
            if (c != null)
            {
                dg1.DataSource = c.Staffs;
            }
        }

        private void StaffDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            var s = StaffDataGrid.CurrentRow.DataBoundItem as Staff;
            if (s != null) 
            {
                dg2.DataSource = s.Customers;
            }

        }
    }
}
