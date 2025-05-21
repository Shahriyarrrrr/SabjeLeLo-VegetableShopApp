using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SabJeeLelo
{
    
    public partial class Products : Form
    {

        
        public Products()
        {
            InitializeComponent();

            
        }

        private void pictureBox2_Click(object sender, EventArgs e) // Back button
        {
            Menu mm=new Menu();
            mm.ShowDialog();
            //this.Close();
        }
        public static string gg = "";
        private void button1_Click(object sender, EventArgs e) // Add product
        {
            
            //kc += 1;
           if(textBox1.Text=="" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || gg=="")
           {
                MessageBox.Show("Data Missing Try Again !!!");
           }
            else
            {   
                try
                {   

                    using (DataClasses1DataContext A = new DataClasses1DataContext())
                    {
                        int kl = 0;
                        var q = from Demo in A.TypeTbls
                                where Demo.TypeName == gg
                                select new
                                {
                                    Demo.TypeCode
                                };
                        foreach(var it in q)
                        {
                            kl = Convert.ToInt32(it.TypeCode);
                        }
                        
                        ProductTbl Nigga = new ProductTbl
                        {
                            ProductName = textBox1.Text,
                            Description = textBox2.Text,
                            ProductTypeCode = kl,
                            ProductPrice=Convert.ToDecimal(textBox3.Text),
                            Stock=Convert.ToInt32(textBox4.Text)
                        };
                        A.ProductTbls.InsertOnSubmit(Nigga);
                        A.SubmitChanges();
                        MessageBox.Show("Action Confirmed {0}" , kl.ToString());
                    }
                }
                catch (Exception ex)
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gg = comboBox1.SelectedItem.ToString(); // Variable declaration

        }

        private void Products_Load(object sender, EventArgs e)
        {
            //G = "";
            DataClasses1DataContext XD=new DataClasses1DataContext();
            var Q = from Demo in XD.TypeTbls select Demo;
            
            foreach (var it in Q)
            {
                comboBox1.Items.Add(it.TypeName.ToString());
            }

            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button4_Click(object sender, EventArgs e) // show table
        {
            DataClasses1DataContext AA = new DataClasses1DataContext();
            var q = from Demo in AA.ProductTbls select new
            {
                Demo.ProductCode,Demo.ProductName,Demo.Description,Demo.ProductTypeCode,Demo.ProductPrice,Demo.Stock
            };
            dataGridView1.DataSource = q;
            dataGridView1.Show();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // Editing 
        {
            if (textBox5.Text=="")
            {
                MessageBox.Show("Please Enter the Product Code!!!");
            }
            else
            {
                try
                {

                    using (DataClasses1DataContext AA = new DataClasses1DataContext())
                    {
                        int kl = 0;
                        var q = from Demo in AA.TypeTbls
                                where Demo.TypeName == gg
                                select new
                                {
                                    Demo.TypeCode
                                };
                        foreach (var it in q)
                        {
                            kl = Convert.ToInt32(it.TypeCode);
                            break;
                        }

                        int ss = Convert.ToInt32(textBox5.Text);
                        ProductTbl Nigga = AA.ProductTbls.SingleOrDefault(x => x.ProductCode == ss);
                        if (textBox1.Text != "")
                        {
                            Nigga.ProductName = textBox1.Text;
                        }
                        if (textBox2.Text != "")
                        {
                            Nigga.Description = textBox2.Text;
                        }

                        if (kl != 0)
                        {
                            Nigga.ProductTypeCode = kl;
                        }

                        if (textBox3.Text != "")
                        {
                            Nigga.ProductPrice = Convert.ToDecimal(textBox3.Text);
                        }

                        if (textBox4.Text != "")
                        {
                            Nigga.Stock = Convert.ToInt32(textBox4.Text);
                        }
                        
                        
                        AA.SubmitChanges();
                        MessageBox.Show("Action Confirmed !!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e) // Deleting 
        {
            if(textBox5.Text == "")
            {
                MessageBox.Show("Please inter the data code");
            }
            try
            {   
                 
                using(DataClasses1DataContext AAA = new DataClasses1DataContext())
                {
                    int ct = Convert.ToInt32(textBox5.Text);
                    ProductTbl T = AAA.ProductTbls.SingleOrDefault(x=> x.ProductCode==ct);
                    AAA.ProductTbls.DeleteOnSubmit(T);
                    AAA.SubmitChanges();
                }
                MessageBox.Show("Action Confirmed !!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
