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
    public partial class addItems : Form
    {
        public addItems()
        {
            InitializeComponent();
        }
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addItems_Load(object sender, EventArgs e)
        {

        }

        private void itembtntxt_Click(object sender, EventArgs e)
        {
            
            SqlConnection sql = new SqlConnection(cs);
            sql.Open();
            string qry = "insert into itemstbl values(@name , @price , @discount)";
            SqlCommand cmd = new SqlCommand(qry,sql);
            cmd.Parameters.AddWithValue("@name",itmnametxt.Text);
            cmd.Parameters.AddWithValue("@price",itmprice.Text);
            cmd.Parameters.AddWithValue("@discount",distxt.Text);
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data inserted");
                itmnametxt.Text = "";
                itmprice.Text = "";
                distxt.Text = "";
                itmnametxt.Focus();



            }
            else
            {
                MessageBox.Show("Invalid");
            }


            sql.Close();
        }
    }
}
