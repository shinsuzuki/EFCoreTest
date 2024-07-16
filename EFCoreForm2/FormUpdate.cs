using EFCoreForm2.MyEFCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCoreForm2
{
    public partial class FormUpdate : Form
    {
        private ProductEntity _product = new();

        public FormUpdate()
        {
            InitializeComponent();
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                // 検索
                using (var ctx = new AndersonDbContext())
                {
                    var id = Convert.ToInt32(txtProductId.Text);
                    this._product = ctx.Products.FirstOrDefault(x => x.ProductId == id);

                    if (_product == null)
                    {
                        MessageBox.Show("nothing!");
                        return;
                    }

                    txtProductName.Text = _product.ProductName;
                    txtPrice.Text = _product.Price.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 別のコンテキストで更新
            try
            {
                using (var ctx = new AndersonDbContext())
                {
                    this._product.ProductName = this.txtProductName.Text;
                    this._product.Price = Convert.ToInt32(this.txtPrice.Text);
                    ctx.Update(this._product);
                    //ctx.Entry(this._product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnInsertUpdate_Click(object sender, EventArgs e)
        {
            // 新規、更新
            try
            {
                var product = new ProductEntity()
                {
                    ProductId = Convert.ToInt32(this.txtProductId.Text),
                    ProductName = this.txtProductName.Text,
                    Price = Convert.ToInt32(this.txtPrice.Text),
                };

                using (var ctx = new AndersonDbContext())
                {
                    if (ctx.Products.Any(x => x.ProductId == product.ProductId))
                    {
                        ctx.Update(product);
                    }
                    else
                    {
                        ctx.Products.Add(product);
                    }

                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (var ctx = new AndersonDbContext())
            {
                dataGridView1.DataSource = ctx.Products.ToList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var ctx = new AndersonDbContext())
            {
                var target = ctx.Products
                    .FirstOrDefault(x => x.ProductId == Convert.ToInt32(this.txtProductId.Text));

                if (target == null)
                {
                    MessageBox.Show("nothing!");
                    return;
                }


                // ProductEntityを作って、ProductIdだけを入れて、Removeしても削除されますし、
                // 別のContextでRemoveしても削除されます。
                // Removeの場合は、キーさえ指定すれば、別のContextで実施しても削除することができる
                ctx.Products.Remove(target);
                ctx.SaveChanges();
            }
        }
    }
}
