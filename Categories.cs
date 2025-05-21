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
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Add
        {
            if (textBox1.Text == "" || textBox2.Text=="")
            {
                MessageBox.Show("Data Missing Try Again !!!");
            }
            else
            {
                using (DataClasses1DataContext A = new DataClasses1DataContext())
                {
                    try
                    {
                        string Name = textBox1.Text;
                        string Description = textBox2.Text;
                        TypeTbl obj = new TypeTbl
                        {
                            TypeName = Name,
                            Description = Description
                        };
                        A.TypeTbls.InsertOnSubmit(obj);
                        A.SubmitChanges();
                        MessageBox.Show("Action Confrimed");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) // show
        {
            using (DataClasses1DataContext AA = new DataClasses1DataContext())
            {
                var querry = from Demo in AA.TypeTbls select Demo;
                dataGridView1.DataSource = querry;
                dataGridView1.Show();
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e) //Edit
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("You need to type code of product !!!");
            }
            else
            {
                using(DataClasses1DataContext AAA = new DataClasses1DataContext())
                {
                    try
                    {
                        int code = Convert.ToInt32(textBox3.Text);
                        if (textBox1.Text == "" || textBox2.Text == "")
                        {
                            MessageBox.Show("Data Missing Try Again !!!");
                        }
                        else
                        {
                            TypeTbl N = AAA.TypeTbls.SingleOrDefault(x => x.TypeCode == code);
                            N.TypeName = textBox1.Text;
                            N.Description = textBox2.Text;
                            AAA.SubmitChanges();
                            MessageBox.Show("Action Confrimed");
                        }

                    }
                    catch (Exception ex )
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) // delete
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("You need to type code of product !!!");
            }
            else
            {
                try
                {
                    int code = Convert.ToInt32(textBox3.Text);
                    using (DataClasses1DataContext AAAA = new DataClasses1DataContext())
                    {
                        TypeTbl C = AAAA.TypeTbls.SingleOrDefault(x => x.TypeCode == code);
                        AAAA.TypeTbls.DeleteOnSubmit(C);
                        AAAA.SubmitChanges();
                    }

                    MessageBox.Show("Action Confrimed");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) // back button
        {
            Menu cc = new Menu();
            cc.ShowDialog();
        }

        private void Categories_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
