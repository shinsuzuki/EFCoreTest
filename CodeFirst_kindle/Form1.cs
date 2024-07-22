using Microsoft.EntityFrameworkCore;
using CodeFirst_kindle.MyEFCore;

namespace CodeFirst_kindle
{
    public partial class Form1 : Form
    {
        AndersonDbContext _context = new AndersonDbContext();

        public Form1()
        {
            InitializeComponent();
            dg1.SelectionChanged += Dg1_SelectionChanged;
        }

        private void Dg1_SelectionChanged(object? sender, EventArgs e)
        {
            var p = dg1.CurrentRow.DataBoundItem as Product;
            if (p != null) {
                dg2.DataSource = p.ProductItems;
            }
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            var product = new Product()
            {
                ProductName = "BBB",
                Price = 100,
            };

            var item1 = new ProductItem();
            item1.ProductName = "取説";
            product.ProductItems.Add(item1);

            var item2 = new ProductItem();
            item2.ProductName = "ACアダプタ";
            product.ProductItems.Add(item2);

            var item3 = new ProductItem();
            item3.ProductName = "充電池";
            product.ProductItems.Add(item3);

            //using (var ctx = new AndersonDbContext())
            //{
                _context.Products.Add(product);
                _context.SaveChanges();
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dg1.DataSource = _context.Products.Include(x => x.ProductItems).ToList();
        }
    }
}
