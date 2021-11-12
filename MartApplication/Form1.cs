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

namespace MartApplication
{
    public partial class Form1 : Form
    {
        int tax = 0;
        int SrNo = 0;
        int FinalCost = 0;
        public Form1()
        {
          
            InitializeComponent();
            getItem();
            quantitytxt.KeyUp += Quantitytxt_KeyUp;
            comboBox1.KeyUp += ComboBox1_KeyUp;
            button1.KeyUp += Button1_KeyUp;
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "SR NO";
            dataGridView1.Columns[1].Name = "ITEM NAME";
            dataGridView1.Columns[2].Name = "UNIT PRICE";
            dataGridView1.Columns[3].Name = "DISCOUNT PER ITEM";
            dataGridView1.Columns[4].Name = "QUANTITY";
            dataGridView1.Columns[5].Name = "SUB TOTAL";
            dataGridView1.Columns[6].Name = "TAX";
            dataGridView1.Columns[7].Name = "TOTAL COST";
            comboBox1.Focus();
            
        }

        private void Button1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void Quantitytxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void ComboBox1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                quantitytxt.Focus();
            }
        }

        SqlConnection sql = new SqlConnection(@"Data Source=DESKTOP-C13GBHB\SQLEXPRESS01;Initial Catalog=Mart;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void getItem()
        {
            sql.Open();
            string qry = "select * from itemstbl";
            SqlCommand cmd = new SqlCommand(qry,sql);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                string items = dr.GetString(1);
                comboBox1.Items.Add(items);

            }



            sql.Close();

        }

        public void getPrice()
        {
            if (comboBox1.SelectedItem == null)
            {

            }
            else
            {
                sql.Open();
                int price = 0;
                string qry = "select item_price from itemstbl where item_name = @name";
                SqlDataAdapter da = new SqlDataAdapter(qry, sql);
                da.SelectCommand.Parameters.AddWithValue("@name", comboBox1.SelectedItem.ToString());
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    price = Convert.ToInt32(dt.Rows[0]["item_price"]);
                }

                unitpricetxt.Text = price.ToString();



                sql.Close();
            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPrice();
            Discount();
            quantitytxt.Enabled = true;

        }
    
        public void Discount()
        {
            if (comboBox1.SelectedItem == null)
            {

            }
            else
            {
                int discount = 0;
                sql.Open();
                string qry = "select item_discount from itemstbl where item_name = @name";
                SqlDataAdapter da = new SqlDataAdapter(qry, sql);
                da.SelectCommand.Parameters.AddWithValue("@name", comboBox1.SelectedItem.ToString());
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    discount = Convert.ToInt32(dt.Rows[0]["item_discount"].ToString());

                }
                discounttxt.Text = discount.ToString();

                sql.Close();
            }
        }

        private void quantitytxt_TextChanged(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(quantitytxt.Text) == true)
            {

            }
            else
            {


                
                    int price = Convert.ToInt32(unitpricetxt.Text);
                    int discount = Convert.ToInt32(discounttxt.Text);
                    int quantity = Convert.ToInt32(quantitytxt.Text);

                    int subtotal = price * quantity;
                    subtotal = subtotal - discount * quantity;
                    subtxt.Text = subtotal.ToString();
                

            }

         }

       

        private void subtxt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(subtxt.Text) == true)
            {

            }
            else
            {


                int subtotal = Convert.ToInt32(subtxt.Text);
                if (subtotal >= 10000)
                {
                    tax = (int)(subtotal * 0.07);
                    taxtxt.Text = tax.ToString();
                }
                else if (subtotal >= 6000)
                {
                    tax = (int)(subtotal * 0.05);
                    taxtxt.Text = tax.ToString();
                }
                else if (subtotal >= 3000)
                {
                    tax = (int)(subtotal * 0.04);
                    taxtxt.Text = tax.ToString();
                }
                else if (subtotal >= 1000)
                {
                    tax = (int)(subtotal * 0.02);
                    taxtxt.Text = tax.ToString();
                }
                else
                {
                    tax = (int)(subtotal * 0.02);
                    taxtxt.Text = tax.ToString();
                }
            }

        }

        private void taxtxt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(taxtxt.Text) == true)
            {

            }
            else
            {


                int subtotal = Convert.ToInt32(subtxt.Text);
                int tax = Convert.ToInt32(taxtxt.Text);
                int totalcost = subtotal + tax;

                totalcosttxt.Text = totalcost.ToString();

            }
      }

        public void addToGridView(string sr_no, string item_name, string unit_price, string discount, string quantity, string subTotal, string tax, string subtotal)
        {
            string [] row = { sr_no, item_name, unit_price, discount , quantity, subTotal , tax , subtotal };
            dataGridView1.Rows.Add(row);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {

            }
            else
            {

          

            addToGridView((++SrNo).ToString(), comboBox1.SelectedItem.ToString(), unitpricetxt.Text, discounttxt.Text, quantitytxt.Text, subtxt.Text, taxtxt.Text, totalcosttxt.Text);
            clearData();
            comboBox1.Focus();
            finalCost();
        }
         
        }
    public void clearData()
        {
            comboBox1.SelectedItem = null;
            unitpricetxt.Text = "";
            discounttxt.Text = "";
            quantitytxt.Text = "";
            subtxt.Text = "";
            taxtxt.Text = "";
            totalcosttxt.Text = "";
        }
        public void finalCost()
        {
            FinalCost = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                FinalCost = FinalCost + Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
               

            }
            finalCosttxt.Text = FinalCost.ToString();

        }
    }

    
  
}
 
