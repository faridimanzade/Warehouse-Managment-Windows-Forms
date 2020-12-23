using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouse_File
{
    public partial class Form4 : Form
    {
        List<Customer> Customers;
        public Form4(List<Customer> customers)
        {
            InitializeComponent();
            this.Customers = customers;
        }


        //========================================================= ADDS NEW CUSTOMER TO THE LIST
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(maskedTextBox1.Text) || String.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Input Fields are empty. FILL THEM", "Empty Inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Customers.Add(new Customer(textBox1.Text, textBox2.Text, textBox3.Text, maskedTextBox1.Text, richTextBox1.Text));
                this.Hide();
            }
        }
    }
}
