using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace MartApplication
{
    public partial class login : Form
    {
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public static string username = ""; 
        public login()
        {
            InitializeComponent();

            usertxt.KeyUp += Usertxt_KeyUp;
            passwordtxt.KeyUp += Passwordtxt_KeyUp;
        }

        private void Passwordtxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void Usertxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                passwordtxt.Focus();
            }
        }

   
        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection sql = new SqlConnection(cs);
            sql.Open();
            string qry = "select * from signup where name = @name and password = @pass";
            SqlCommand cmd = new SqlCommand(qry,sql);
            cmd.Parameters.AddWithValue("@name",usertxt.Text);
            cmd.Parameters.AddWithValue("@pass",passwordtxt.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                MessageBox.Show("Login successfull");
                username = usertxt.Text;
                this.Hide();
                Form1 frm = new Form1();
                frm.ShowDialog();
              
            }
            else
            {
                MessageBox.Show("failed to login");
            }



            sql.Close();


        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;
            switch (check)
            {
                case true:
                    passwordtxt.UseSystemPasswordChar = false;
                    break;
                default:
                    passwordtxt.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup si = new signup();
            this.Hide();
            si.ShowDialog();
           
        }
    }
}
