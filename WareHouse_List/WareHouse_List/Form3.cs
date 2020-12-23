using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouse_List
{
    public partial class Form3 : Form
    {
        List<Seller> Sellers;
        public Form3(List<Seller> Sellers)
        {
            InitializeComponent();
            this.Sellers = Sellers;
        }


        //========================================================= ALL REGISTRATION PART FOR SELLER
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Input Fields are empty. FILL THEM", "Empty Inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox2.Text == textBox3.Text)
                {
                    Sellers.Add(new Seller(textBox1.Text, textBox2.Text, textBox4.Text, textBox5.Text));
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Passwords Don't match. Check Again", "Passwords Unmatching", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
