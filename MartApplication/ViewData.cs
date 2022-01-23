using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace MartApplication
{
    public partial class ViewData : Form
    {
        public ViewData()
        {
            InitializeComponent();
        }
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        private void ViewData_Load(object sender, EventArgs e)
        {
                label2.Text = dataGridView1.RowCount.ToString();
      

            



            SqlConnection sql = new SqlConnection(cs);
            sql.Open();
            string qry = "select * from itemstbl";
            SqlDataAdapter da = new SqlDataAdapter(qry,sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;



            sql.Close();

        }
    }
}
