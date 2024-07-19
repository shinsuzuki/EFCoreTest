using Microsoft.EntityFrameworkCore;
using EFCoreForm2.MyEFCore;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

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
                // �O����v�A�����v���w��B�܂܂�Ă��邱�Ƃ��m�F�����������Ȃ�Contains��OK
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

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            using (var ctx = new AndersonDbContext())
            {
                dataGridView1.DataSource = ctx.Customers.ToList();
            }
        }

        private void btnProductCustomer_Click(object sender, EventArgs e)
        {
            using (var ctx = new AndersonDbContext())
            {
                var orders = ctx.Orders
                    .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.Product)
                    .Include(o => o.Customer);

                dataGridView1.DataSource = orders.ToList();

            }
        }

        private void btnInsertProduct_Click(object sender, EventArgs e)
        {
            // �V�K�ǉ�
            var p = new ProductEntity()
            {
                ProductId = 11,
                ProductName = "Test11",
                Price = 10
            };

            using (var ctx = new AndersonDbContext())
            {
                ctx.Products.Add(p);
                ctx.SaveChanges();
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            // �X�V
            using (var ctx = new AndersonDbContext())
            {
                var p = ctx.Products.FirstOrDefault(x => x.ProductId == 11);
                if (p != null)
                {
                    p.ProductName = "xxxx" + DateTime.Now.ToString("yyyyMMdd_hhmmss");
                    ctx.SaveChanges();
                }
            }

        }

        private void btnUpdateForm_Click(object sender, EventArgs e)
        {
            using (var f = new FormUpdate())
            {
                f.ShowDialog();
            }
        }

        private void btnCustomerSQL_Click(object sender, EventArgs e)
        {
            // ��SQL
            using (var ctx = new AndersonDbContext())
            {
                // ������⊮��(SqlParameter�ɒu���������܂��B)
                var customerId = "1001";
                dataGridView1.DataSource = ctx.Customers.FromSql<Customer>($"select * from Customer where CustomerId = {customerId}").ToList();


                // �����񂩂�FormattableString�𐶐��A�p�����[�^��n����SQL�����s
                //var customerId = "1001";
                //var q = FormattableStringFactory.Create("select * from Customer where CustomerId = {0}", customerId);
                //dataGridView1.DataSource = ctx.Customers.FromSqlInterpolated(q).ToList();
            }
        }

        private void btnOrderJoin_Click(object sender, EventArgs e)
        {
            // ��SQL-JOIN
            using (var ctx = new AndersonDbContext())
            {
                // �匳��select�ɂ��ׂċL�q����K�v���肩?
                dataGridView1.DataSource =
                    ctx.Orders.FromSql(
                        @$"select 
                            o.OrderId, 
                            o.CustomerId, 
                            o.OrderDate, 
                            oi.Quantity, 
                            oi.Price 
                        from [Order] as o 
                            left outer join OrderItem as oi 
                            on o.OrderId = oi.OrderId").ToList();


                //var joukenOrderId = 4;
                //var sb = new StringBuilder();
                //sb.Append("select");
                //sb.Append("    o.OrderId, ");
                //sb.Append("    o.CustomerId, ");
                //sb.Append("    o.OrderDate, ");
                //sb.Append("    oi.Quantity, ");
                //sb.Append("    oi.Price ");
                //sb.Append(" from ");
                //sb.Append("    [Order] as o ");
                //sb.Append("    left outer join OrderItem as oi ");
                //sb.Append("    on o.OrderId = oi.OrderId");
                //sb.Append(" where o.OrderId > {0}");

                //dataGridView1.DataSource =
                //    ctx.Orders.FromSql(FormattableStringFactory.Create(sb.ToString(), joukenOrderId)).ToList();

            }

        }
    }
}

