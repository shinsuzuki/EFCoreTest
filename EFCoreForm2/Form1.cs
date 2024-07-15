using Microsoft.EntityFrameworkCore;
using EFCoreForm2.MyEFCore;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreForm2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnEF_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                dataGridView1.DataSource = context.Products.ToList();
            }
        }

        private void btnWhere_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                //dataGridView1.DataSource = context.Products.ToList();
                dataGridView1.DataSource = context.Products
                    .Where(x => x.ProductName.Contains("A"))
                    .ToList();

            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                //dataGridView1.DataSource = context.Products.ToList();
                dataGridView1.DataSource = context.Products
                    .OrderBy(x => x.Price)
                    .ThenBy(x => x.ProductName)
                    .ToList();

            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                var product = context.Products.Find(4);
                MessageBox.Show(product.ToString());
            }
        }

        private void btnFirstOrDefaurlt_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                var product = context.Products
                    .OrderBy(x => x.Price)
                    .FirstOrDefault(x => x.ProductName.Contains("p"));

                MessageBox.Show(product.ToString());
            }
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            using (var context = new AndersonDbContext())
            {
                // 前方一致、後方一致を指定。含まれていることを確認したいだけならContainsでOK
                var product = context.Products
                    .Where(x => EF.Functions.Like(x.ProductName, "%A%"));

                dataGridView1.DataSource = product.ToList();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            using (var ctx = new AndersonDbContext())
            {
                //this.dataGridView1.DataSource = ctx.OrderItems.ToList();
                this.dataGridView1.DataSource = ctx.Orders.ToList();
            }


        }

        private void btnInJoin_Click(object sender, EventArgs e)
        {
            using (var ctx = new AndersonDbContext())
            {
                var q = ctx.Orders.Join(ctx.OrderItems,
                    orders => orders.OrderId, orderItems => orderItems.OrderId,
                    (order, orderItem) => new
                    {
                        order.OrderId,
                        order.CustomerId,
                        order.OrderDate,
                        orderItem.ProductId,
                        orderItem.Quantity,
                        orderItem.Price,
                    });

                this.dataGridView1.DataSource = q.ToList();
            }
        }

        private void btnLeftJoin_Click(object sender, EventArgs e)
        {
            using (var ctx = new AndersonDbContext())
            {
                var q = ctx.Orders
                    .GroupJoin(ctx.OrderItems,
                        a => a.OrderId,
                        b => b.OrderId,
                        (order, orderItems) => new
                        {
                            o = order,
                            oi = orderItems
                        })
                    .SelectMany(item => item.oi.DefaultIfEmpty(),
                    (item, orderItem) => new
                    {
                        OrderId = item.o.OrderId,
                        CustomerId = item.o.CustomerId,
                        OrderDate = item.o.OrderDate,
                        ProductId = orderItem == null ? (int?)null : orderItem.ProductId,
                        Quantity = orderItem == null ? (int?)null : orderItem.Quantity,
                        Price = (orderItem == null) ? (int?)null : orderItem.Price
                    });

                this.dataGridView1.DataSource = q.ToList();
            }
        }

        private void btnInclude_Click(object sender, EventArgs e)
        {
            using (var ctx = new AndersonDbContext())
            {
                var oreders = ctx.Orders
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                    .ToList();

                dataGridView1.DataSource = oreders;
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var order = dataGridView1.CurrentRow.DataBoundItem as Order;
            if (order == null)
            {
                return;
            }
            dataGridView2.DataSource = order.OrderItems;
        }
    }
}
