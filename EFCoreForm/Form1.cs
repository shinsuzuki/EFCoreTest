using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace EFCoreForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"SSTPX13G4";
            builder.InitialCatalog = "AndersonA";
            builder.IntegratedSecurity = true;
            builder.Encrypt = false;    // 信頼されていない機関によって証明書チェーンが発行されました_のエラー対応

            var sql = "select * from Product";
            var dt = new DataTable();
            using (var cnn = new SqlConnection(builder.ConnectionString))
            {
                using (var adpt = new SqlDataAdapter(sql, cnn))
                {
                    cnn.Open();
                    adpt.Fill(dt);
                }
            }

            dataGridView1.DataSource = dt;
        }
    }
}
