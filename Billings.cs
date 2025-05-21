using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SabJeeLelo
{
    public partial class Billings : Form
    {
        public Billings()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e) // back button
        {
            Menu mm= new Menu();
            mm.ShowDialog();
        }

        private void textBox6_TextChanged(object sender, EventArgs e) // CustName 
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Phone
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) // item name
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e) // quantity 
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) //price
        {

        }

        private void button1_Click(object sender, EventArgs e) // Add Items 
        {
            if(textBox6.Text == "" || textBox1.Text == "" || textBox3.Text == "" || textBox5.Text == ""|| textBox4.Text == "")
            {
                MessageBox.Show("Missing Data try Again !!!");
            }
            else
            {
                try
                {
                    using (DataClasses1DataContext GG = new DataClasses1DataContext())
                    {
                        BillTbl ob = new BillTbl();
                        ob.CustomerName = textBox6.Text;
                        ob.CustomerPhone = textBox1.Text;
                        Double L = Convert.ToDouble(textBox4.Text);
                        Double Z = Convert.ToDouble(textBox5.Text);
                        Double res = (L * Z);
                        ob.Amount = Convert.ToDecimal(res);
                        ob.BuyingDate = DateTime.Now;

                        GG.BillTbls.InsertOnSubmit(ob);
                        GG.SubmitChanges();
                    }

                    MessageBox.Show("Action Confirmed !!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // Reset 
        {
            textBox6.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox4.Text ="";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext GTR = new DataClasses1DataContext();
            var Q = from Demo in GTR.BillTbls
                    select new
                    {
                        Demo.CustomerName,
                        Demo.CustomerPhone,
                        Demo.Amount,
                        Demo.BuyingDate
                    };

            dataGridView1.DataSource = Q;
            dataGridView1.Show();


            textBox6.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Billings_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
