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
    public partial class Form6 : Form
    {
        List<Customer> Customers;
        List<Product> Products;
        List<Order> Orders;
        public Form6(List<Customer> customers, List<Product> products, List<Order> orders)
        {
            InitializeComponent();
            this.Customers = customers;
            this.Products = products;
            this.Orders = orders;

            foreach (var item in Customers)
            {
                comboBox1.Items.Add(item.Name);
            }

            foreach (var item in Products)
            {
                comboBox2.Items.Add(item.Name);
            }
        }


        //========================================================= CREATES NEW ORDER AND ADDS IT TO THE ORDERS LIST
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || numericUpDown1.Text == "" || dateTimePicker1.Value == null)
            {
                MessageBox.Show("Input Fields are empty. FILL THEM", "Empty Inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Customer foundCustomer = Customers.Find(x=>x.Name == comboBox1.Text);
                Product foundProduct = Products.Find(x => x.Name == comboBox2.Text);
                bool isProductLeft = Products.Exists(x=>x.Quantity > numericUpDown1.Value);

                if (isProductLeft)
                {
                    Orders.Add(new Order()
                    {
                        Customer = foundCustomer,
                        Product = foundProduct,
                        ArriveTime = dateTimePicker1.Value,
                        OrderAmount = numericUpDown1.Value
                    });
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Not Enough Amount of Product in warehouse. Please select correct Number of it.", "Inappropriate inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
