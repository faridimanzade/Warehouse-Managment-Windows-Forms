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
    public partial class Form7 : Form
    {
        List<Customer> Customers;
        List<Product> Products;
        List<Order> Orders;


        //========================================================= ADDS TO THE DATAGRIDVIEW
        public Form7(List<Customer> customers)
        {
            InitializeComponent();
            this.Customers = customers;

            listView1.Visible = false;
            dataGridView1.Visible = true;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = customers;
        }


        //========================================================= ADDS TO THE DATAGRIDVIEW
        public Form7(List<Product> products)
        {
            InitializeComponent();
            this.Products = products;

            listView1.Visible = false;
            dataGridView1.Visible = true;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = products;
        }


        //========================================================= ADDS TO THE LISTVIEW
        public Form7(List<Order> orders)
        {
            InitializeComponent();

            listView1.Visible = true;
            dataGridView1.Visible = false;

            listView1.Columns.Add("Customer Name");
            listView1.Columns.Add("Product Name");
            listView1.Columns.Add("Arrival Time");
            listView1.Columns.Add("Quantity of Product");
            this.Orders = orders;


            for (int i = 0; i < orders.Count; i++)
            {
                string[] data = new string[] { orders[i].Customer.Name, orders[i].Product.Name, orders[i].ArriveTime.ToString(), orders[i].OrderAmount.ToString() };
                ListViewItem newRow = new ListViewItem(data);
                listView1.Items.Add(newRow);
            }

            //dataGridView1.DataSource = null;
            //dataGridView1.DataSource = orders;

        }


    }
}
