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
    public partial class Form1 : Form
    {
        int tax = 0;
        int SrNo = 0;
        int FinalCost = 0;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Form1()
        {

            InitializeComponent();

            getItem();

            comboBox1.Focus();
            getInvoice();
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
            username1txt.Text = login.username;
            button2.KeyUp += Button2_KeyUp;


        }

        private void Button2_KeyUp(object sender, KeyEventArgs e)
        {


        }

        private void Button1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void Quantitytxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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


        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Focus();
            styleGridView2();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void getItem()
        {
            comboBox1.Items.Clear();
            SqlConnection sql = new SqlConnection(cs);
            sql.Open();
            string qry = "select * from itemstbl";
            SqlCommand cmd = new SqlCommand(qry, sql);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string items = dr.GetString(1);
                comboBox1.Items.Add(items);

            }

            comboBox1.Sorted = true;


            sql.Close();

        }

        public void getPrice()
        {
            if (comboBox1.SelectedItem == null)
            {

            }
            else
            {
                SqlConnection sql = new SqlConnection(cs);
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
           // getPrice1();
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
                SqlConnection sql = new SqlConnection(cs);
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

                try
                {


                    int price = Convert.ToInt32(unitpricetxt.Text);
                    int discount = Convert.ToInt32(discounttxt.Text);
                    int quantity = Convert.ToInt32(quantitytxt.Text);

                    int subtotal = price * quantity;
                    subtotal = subtotal - discount * quantity;
                    subtxt.Text = subtotal.ToString();
                }
                catch (Exception)
                {

                }

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
                    tax = (int)(subtotal * 0.12);
                    taxtxt.Text = tax.ToString();
                }
                else if (subtotal >= 6000)
                {
                    tax = (int)(subtotal * 0.12);
                    taxtxt.Text = tax.ToString();
                }
                else if (subtotal >= 3000)
                {
                    tax = (int)(subtotal * 0.12);
                    taxtxt.Text = tax.ToString();
                }
                else if (subtotal >= 1000)
                {
                    tax = (int)(subtotal * 0.12);
                    taxtxt.Text = tax.ToString();
                }
                else
                {
                    tax = (int)(subtotal * 0.12);
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
            string[] row = { sr_no, item_name, unit_price, discount, quantity, subTotal, tax, subtotal };
            dataGridView1.Rows.Add(row);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;

            if (comboBox1.SelectedItem == null)
            {

            }
            else
            {

                addToGridView((++SrNo).ToString(), comboBox1.SelectedItem.ToString(), unitpricetxt.Text, discounttxt.Text, quantitytxt.Text, subtxt.Text, taxtxt.Text, totalcosttxt.Text);
                clearData();
                quantitytxt.Enabled = false;
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

        private void unitpricetxt_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Amountpaidtxt.Text) == true)
            {

            }
            else
            {
                int fCost = Convert.ToInt32(finalCosttxt.Text);
                int amtpaid = Convert.ToInt32(Amountpaidtxt.Text);
                int change = amtpaid - fCost;
                changetxt.Text = change.ToString();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??", "Confirm Delete!!", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                finalCosttxt.Text = "";
                Amountpaidtxt.Text = "";
                changetxt.Text = "";
                quantitytxt.Enabled = false;
                dataGridView1.Rows.Clear();
                SrNo = 0;

            }
            else
            {


            }

        }

        private void quantitytxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }
        public void getInvoice()
        {
            SqlConnection sql = new SqlConnection(cs);

            string qry = "select invoiceId from order_master";
            SqlDataAdapter da = new SqlDataAdapter(qry, sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
            {

                invoicetxt.Text = "1";

            }
            else
            {


                string qry1 = "select max(invoiceid) from order_master";
                SqlCommand cmd = new SqlCommand(qry1, sql);
                sql.Open();
                int a = Convert.ToInt32(cmd.ExecuteScalar());

                a = a + 1;

                invoicetxt.Text = a.ToString();
                sql.Close();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(cs);
            string qry = "insert into order_master values(@id,@user,@datatime,@finalcost)";
            SqlCommand cmd = new SqlCommand(qry, sql);
            cmd.Parameters.AddWithValue("@id", invoicetxt.Text);
            cmd.Parameters.AddWithValue("@user", username1txt.Text);
            cmd.Parameters.AddWithValue("@datatime", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@finalcost", finalCosttxt.Text);
            sql.Open();

            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Inserted");
                getInvoice();
                clearData();

            }
            else
            {
                MessageBox.Show("Failed");
            }

            sql.Close();



        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        public void styleGridView2()
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Goldenrod;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.BackgroundColor = Color.Azure;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.EnableHeadersVisualStyles = true;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("calibri", 9);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void pptxt_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = Properties.Resources.syrmart;
            Image img = bmp;
            e.Graphics.DrawImage(img, 30, 5, 800, 150);

            e.Graphics.DrawString("Invoice id :" + invoicetxt.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 340));
            e.Graphics.DrawString("Username :" + username1txt.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 370));
            e.Graphics.DrawString("DATE :" + DateTime.Now, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 400));
            e.Graphics.DrawString("TIME :" + DateTime.Now, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 430));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------", new Font
            ("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 480));






            e.Graphics.DrawString("Item", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 520));

            e.Graphics.DrawString("Price", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(250, 520));

            e.Graphics.DrawString("Quantity", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(450, 520));

            e.Graphics.DrawString("Discount", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(650, 520));









            if (dataGridView1.Rows.Count > 0)
            {

                try
                {

                    int gap = 610;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {

                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, gap));
                        gap = gap + 30;
                    }
                }
                catch
                {

                }

            }







            if (dataGridView1.Rows.Count > 0)
            {

                try
                {

                    int gap1 = 610;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {

                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(250, gap1));
                        gap1 = gap1 + 30;
                    }
                }
                catch
                {

                }

            }




            if (dataGridView1.Rows.Count > 0)
            {

                try
                {

                    int gap2 = 610;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {

                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(450, gap2));
                        gap2 = gap2 + 30;
                    }
                }
                catch
                {

                }

            }


            if (dataGridView1.Rows.Count > 0)
            {

                try
                {

                    int gap3 = 610;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {

                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(650, gap3));
                        gap3 = gap3 + 30;
                    }
                }
                catch
                {

                }

            }

            int subtotalPrint = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                subtotalPrint = subtotalPrint + Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);


            }

            e.Graphics.DrawString("Subtotal: " + subtotalPrint.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 800));



            int taxPrint = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                taxPrint = taxPrint + Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);


            }

            e.Graphics.DrawString("Tax: " + taxPrint.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 830));






            int finalamountAdd = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                finalamountAdd = finalamountAdd + Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);


            }

            e.Graphics.DrawString("Final Amount: " + finalamountAdd.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 860));











        }

        private void button4_Click(object sender, EventArgs e)
        {
            login l1 = new login();
            var confirmResult = MessageBox.Show("Are you sure to LOGOUT ? ", " LOGOUT ! ", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {

                this.Hide();
                l1.ShowDialog();



            }
            else
            {

            }


        }

        private void pbtxt_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addItems a1 = new addItems();
            a1.Show();
        }

        private void addItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addItems ad = new addItems();
            ad.ShowDialog();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            getItem();
        }

        private void editItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Edititems et = new Edititems();
            et.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
    }
}




 
