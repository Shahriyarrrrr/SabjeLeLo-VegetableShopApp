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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e) // product
        {
            Products p= new Products();
            p.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e) // catagory
        {
            Categories p= new Categories();
            p.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e) // seller
        {
            Sellers p= new Sellers();
            p.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e) // billing
        {
            Billings p= new Billings();
            p.ShowDialog();
        }
    }
}
