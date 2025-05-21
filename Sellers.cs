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
    public partial class Sellers : Form
    {
        public Sellers()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e) // back button
        {
            Menu mm= new Menu();
            mm.ShowDialog();
        }

        public static string Gen = "";
        private void button1_Click(object sender, EventArgs e) // Adding
        {
            if(textBox1.Text=="" || textBox2.Text == "" )
            {
                MessageBox.Show("Missing Data Try Agin");
            }
            else
            {
                try
                {
                    using(DataClasses1DataContext C=new DataClasses1DataContext() )
                    {
                        SellerTbl TC=new SellerTbl();
                        TC.SellerName= textBox1.Text;
                        TC.SellerPassword= textBox2.Text;
                        TC.SellerPhone= textBox3.Text;
                        if (Gen == "Male") TC.SellerGender = 'M';
                        if(Gen =="Female") TC.SellerGender = 'F';

                        C.SellerTbls.InsertOnSubmit(TC);
                        C.SubmitChanges();
                        MessageBox.Show("Action Confirmed");
                    }
                }
                catch( Exception ex )
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Gen=comboBox1.SelectedItem.ToString();
        }

        private void Sellers_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Male");
            comboBox1.Items.Add("Female");

            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) // showing 
        {
            DataClasses1DataContext C = new DataClasses1DataContext();
            var q = from Demo in C.SellerTbls
                    select new
                    {
                        Demo.SellerCode,
                        Demo.SellerName,
                        Demo.SellerPhone,
                        Demo.SellerPassword,
                        Demo.SellerGender
                    };

            dataGridView1.DataSource = q;
            dataGridView1.Show();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            Gen = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // Edit 
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Plese enter the seller code !!!");
            }
            else
            {
                try
                {
                    using (DataClasses1DataContext CX = new DataClasses1DataContext())
                    {
                        int key = Convert.ToInt32(textBox4.Text);
                        SellerTbl Nigga = CX.SellerTbls.SingleOrDefault(x => x.SellerCode == key);

                        if (textBox1.Text != "")
                        {
                            Nigga.SellerName = textBox1.Text;
                        }
                        if (textBox2.Text != "")
                        {
                            Nigga.SellerPassword = textBox2.Text;
                        }

                        if (textBox3.Text != "")
                        {
                            Nigga.SellerPhone = textBox3.Text;
                        }

                        if (Gen == "Male") Nigga.SellerGender = 'M';
                        if (Gen == "Female") Nigga.SellerGender = 'F';

                        CX.SubmitChanges();
                    }
                    MessageBox.Show("Action Confirmed");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
