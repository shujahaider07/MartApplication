using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace MartApplication
{
    public partial class Edititems : Form
    {
        
        public Edititems()
        {
            InitializeComponent();
            bindGridView();
        }

        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        

        private void Edititems_Load(object sender, EventArgs e)
        {
            
        }

       void bindGridView()
        {
            SqlConnection sql = new SqlConnection(cs);
            string qry = "select * from itemstbl";
            SqlDataAdapter da = new SqlDataAdapter(qry,sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            

               dataGridView1.CurrentRow.Selected = true;
                idtxt.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                ednametxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                edpricetxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                eddistxt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

  
            
           

        }
    }
}
