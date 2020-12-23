using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouse_MsSql
{
    public partial class Form6 : Form
    {
        public SqlConnection sqlConnection;
        public int productId = 0;
        public decimal productQuantity = 0;
        public string customerId = null;

        public Form6()
        {
            InitializeComponent();
            try
            {
                sqlConnection = new SqlConnection("Server=DESKTOP-CMJP8T1\\SQLEXPRESS;Database=WareHouse;Trusted_Connection=True;");
            }
            catch (Exception exec)
            {
                MessageBox.Show($"{exec.Message}", "Cannot Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            //=================== FILL THE comboBox1
            sqlConnection.Open();
            SqlCommand sqlCommandCustomer = new SqlCommand("select name, surname from Customers", sqlConnection);
            var readerCustomer = sqlCommandCustomer.ExecuteReader();

            if (readerCustomer.HasRows)
            {
                while (readerCustomer.Read())
                {
                    comboBox1.Items.Add(readerCustomer.GetString(0) + " " + readerCustomer.GetString(1));
                }
            }
            sqlConnection.Close();

            //=================== FILL THE comboBox2
            sqlConnection.Open();
            SqlCommand sqlCommandProducts = new SqlCommand("select name from Products", sqlConnection);
            var readerProduct = sqlCommandProducts.ExecuteReader();

            if (readerProduct.HasRows)
            {
                while (readerProduct.Read())
                {
                    comboBox2.Items.Add(readerProduct.GetString(0));
                }
            }
            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || numericUpDown1.Text == "" || dateTimePicker1.Value == null)
            {
                MessageBox.Show("Input Fields are empty. FILL THEM", "Empty Inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //================================ GET THE SELECTED PRODUCT_ID AND PRODUCT QUANTITY 
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("select product_id, quantity from products where name like @name", sqlConnection);
                sqlCommand.Parameters.AddWithValue("name", comboBox2.Text);
                var reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productId = reader.GetInt32(0);
                        productQuantity = reader.GetDecimal(1);
                    }
                }
                sqlConnection.Close();


                //================================ CHECKS WHETHER THERE IS ENOUGH AMOUNT OF PRODUCT
                if (productQuantity <= numericUpDown1.Value)
                {
                    MessageBox.Show("Not Enougn Product in the WareHouse", "Inappropriate Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //================================ GETS THE CUSTOMER ID
                    sqlConnection.Open();
                    SqlCommand sqlCommandCustomerId = new SqlCommand("select customer_id from Customers where name like @name", sqlConnection);
                    var s = comboBox1.Text;
                    var firstSpaceIndex = s.IndexOf(" ");
                    var firstString = s.Substring(0, firstSpaceIndex);
                    sqlCommandCustomerId.Parameters.AddWithValue("name", firstString);
                    customerId = sqlCommandCustomerId.ExecuteScalar().ToString();
                    sqlConnection.Close();


                    //================================ CREATES NEW ORDER
                    sqlConnection.Open();
                    SqlCommand insertOrder = new SqlCommand("insert into Orders(arrive_time, orderAmount, customer_id, product_id) values(@arrive_time, @orderAmount, @customer_id, @product_id)", sqlConnection);
                    insertOrder.Parameters.AddWithValue("arrive_time", dateTimePicker1.Value);
                    insertOrder.Parameters.AddWithValue("orderAmount", numericUpDown1.Value);
                    insertOrder.Parameters.AddWithValue("customer_id", Int32.Parse(customerId));
                    insertOrder.Parameters.AddWithValue("product_id", productId);

                    var result = insertOrder.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Order is Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed creating Order", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    sqlConnection.Close();


                    //================================== UPDATES PRODUCTS TABLE AND SUBSTRACTS FROM THE  QUANTITY
                    sqlConnection.Open();
                    var leftQuantity = productQuantity - numericUpDown1.Value;
                    SqlCommand updateProductCommand = new SqlCommand("UPDATE Products SET quantity = @leftQuantity WHERE product_id = @product_id", sqlConnection);
                    updateProductCommand.Parameters.AddWithValue("leftQuantity", leftQuantity);
                    updateProductCommand.Parameters.AddWithValue("product_id",productId);
                    var updateResult = updateProductCommand.ExecuteNonQuery();

                    if (updateResult < 0)
                    {
                        MessageBox.Show("Failed creating Order", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    sqlConnection.Close();
                    this.Hide();
                }
            }
        }
    }
}
