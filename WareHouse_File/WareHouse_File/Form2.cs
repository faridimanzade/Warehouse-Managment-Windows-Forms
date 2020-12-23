using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace WareHouse_File
{
    public partial class Form2 : Form
    {
        List<Customer> Customers = new List<Customer>();
        List<Product> Products = new List<Product>();
        List<Order> Orders = new List<Order>();


        static DirectoryInfo directoryInfo = new DirectoryInfo(@".\DataStorage");
        static string customerDB = Path.Combine(directoryInfo.FullName, "customerDB.json");
        static string productDB = Path.Combine(directoryInfo.FullName, "productDB.json");
        static string orderDB = Path.Combine(directoryInfo.FullName, "orderDB.json");

        private void Form2_Load_1(object sender, EventArgs e)
        {
            //Customers = new List<Customer>()
            //{
            //    new Customer("name1", "surname1", "mail1.com", "phone1", "address1"),
            //    new Customer("name2", "surname2", "mail2.com", "phone2", "address2"),
            //    new Customer("name3", "surname3", "mail3.com", "phone3", "address4")
            //};

            //Products = new List<Product>()
            //{
            //    new Product("name1", "100", 10, "Good1"),
            //    new Product("name2", "200", 20, "Good2"),
            //    new Product("name3", "300", 30, "Good3")
            //};

            //Orders = new List<Order>()
            //{
            //    new Order()
            //    {
            //        Customer = new Customer("name1", "surname1", "mail1.com", "phone1", "address1"),
            //        Product = new Product("name2", "200", 20, "Good1"),
            //        ArriveTime = DateTime.Now,
            //        OrderAmount = 5
            //    }
            //};


            using (StreamReader streamReader = new StreamReader(customerDB))
            {
                string jsonText = streamReader.ReadToEnd();
                Customers = JsonConvert.DeserializeObject<List<Customer>>(jsonText);
            }

            using (StreamReader streamReader = new StreamReader(productDB))
            {
                string jsonText = streamReader.ReadToEnd();
                Products = JsonConvert.DeserializeObject<List<Product>>(jsonText);
            }

            using (StreamReader streamReader = new StreamReader(orderDB))
            {
                string jsonText = streamReader.ReadToEnd();
                Orders = JsonConvert.DeserializeObject<List<Order>>(jsonText);
            }
        }

        public Form2()
        {
            InitializeComponent();
        }


        //===================================================================== CUSTOMER
        //================================================= ADD NEW CUSTOMER
        private void addToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(Customers);
            form4.ShowDialog();
        }

        //================================================= VIEW CUSTOMERS LIST
        private void listToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(Customers);
            form7.ShowDialog();
        }


        //===================================================================== PRODUCT
        //================================================= ADD NEW PRODUCT
        private void addToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(Products);
            form5.ShowDialog();
        }

        //================================================= VIEW PRODUCTS LIST
        private void listToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(Products);
            form7.ShowDialog();
        }

        //===================================================================== PRODUCT
        //================================================= ADD NEW ORDER
        private void acceptToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(Customers, Products, Orders);
            form6.ShowDialog();
        }

        //================================================= VIEW ORDERS LIST
        private void listToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(Orders);
            form7.ShowDialog();
        }


        //=================================================== WRITE TO THE FILE
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            string customerList = JsonConvert.SerializeObject(Customers);
            using (StreamWriter streamWriter = new StreamWriter(customerDB))
            {
                streamWriter.WriteLine(customerList);
            }

            string productList = JsonConvert.SerializeObject(Products);
            using (StreamWriter streamWriter = new StreamWriter(productDB))
            {
                streamWriter.WriteLine(productList);
            }

            string orderList = JsonConvert.SerializeObject(Orders);
            using (StreamWriter streamWriter = new StreamWriter(orderDB))
            {
                streamWriter.WriteLine(orderList);
            }
        }
    }

    public class Customer
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Customer(string name, string surname, string email, string phone, string address)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            Address = address;
        }
    }


    public class Product
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public decimal Quantity { get; set; }
        public string Description { get; set; }

        public Product(string name, string price, decimal quantity, string description)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Description = description;
        }
    }


    public class Order
    {
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public DateTime ArriveTime { get; set; }

        public decimal OrderAmount { get; set; }
    }
}
