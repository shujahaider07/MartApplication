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
    public partial class signup : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public signup()
        {
            InitializeComponent();
            nametxt.KeyUp += Nametxt_KeyUp;
            surnametxt.KeyUp += Surnametxt_KeyUp;
            gendertxt.KeyUp += Gendertxt_KeyUp;
            agetxt.KeyUp += Agetxt_KeyUp;
            addtxt.KeyUp += Addtxt_KeyUp;
            passtxt.KeyUp += Passtxt_KeyUp;
            contxt.KeyUp += Contxt_KeyUp;
        }

        private void Contxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                signbtn.Focus();
            }
        }

        private void Passtxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                contxt.Focus();
            }
        }

        private void Addtxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                passtxt.Focus();
            }
        }

        private void Agetxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                addtxt.Focus();
            }
        }

        private void Gendertxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                agetxt.Focus();
            }
        }

        private void Surnametxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                gendertxt.Focus();
            }
        }

        private void Nametxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                surnametxt.Focus();
            }
        }

        private void signbtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(nametxt.Text)==true)
            {
                MessageBox.Show("Fill proper information");
            }else if (string.IsNullOrEmpty(addtxt.Text)==true)
            {
                MessageBox.Show("Fill proper information");

            }
            else if (string.IsNullOrEmpty(passtxt.Text) == true)
            {
                MessageBox.Show("Fill proper information");
            }
            else
            {

                SqlConnection sql = new SqlConnection(cs);
                sql.Open();
                string qry = "insert into signup values('" + nametxt.Text + "','" + surnametxt.Text + "','" + gendertxt.Text + "','" + agetxt.Text + "','" + addtxt.Text + "','" + passtxt.Text + "')";
                SqlCommand cmd = new SqlCommand(qry, sql);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Signup Sucessfull");
                this.Hide();
                login l1 = new login();
                l1.ShowDialog();



                sql.Close();

            }

        }

        private void nametxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch)==true)
            {
                e.Handled = false;
            }else if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void restbtn_Click(object sender, EventArgs e)
        {
            nametxt.Text = "";
            surnametxt.Text = "";
            gendertxt.Text = "";
            agetxt.Text = "";
            addtxt.Text = "";
            passtxt.Text = "";
            contxt.Text = "";

        }

        private void signup_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
