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
    public partial class Form5 : Form
    {
        List<Product> Products;
        public Form5(List<Product> products)
        {
            InitializeComponent();
            this.Products = products;
        }


        //========================================================= ADDS NEW PRODUCT TO THE LIST
        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(numericUpDown1.Text) || String.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Input Fields are empty. FILL THEM", "Empty Inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Products.Add(new Product(textBox1.Text, textBox2.Text, numericUpDown1.Value,richTextBox1.Text));
                this.Hide();
            }
        }
    }
}
