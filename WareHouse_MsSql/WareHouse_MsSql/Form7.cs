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
    public partial class Form7 : Form
    {
        public int ListID = 0;
        public SqlConnection sqlConnection;
        public Form7()
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

        public void SendData(int listid)
        {
            ListID = listid;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();


            //============================= SHOWS LIST OF CUSTOMERS
            if (ListID == 1)
            {
                using (SqlDataAdapter sqlData = new SqlDataAdapter("select * from Customers", sqlConnection))
                {
                    DataTable dataTable = new DataTable();

                    sqlData.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                    label2.Text = "Customers";
                }
            }
            //============================= SHOWS LIST OF PRODUCTS
            else if (ListID == 2)
            {
                using (SqlDataAdapter sqlData = new SqlDataAdapter("select * from Products", sqlConnection))
                {
                    DataTable dataTable = new DataTable();

                    sqlData.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                    label2.Text = "Products";
                }
            }
            //============================= SHOWS LIST OF ORDERS
            else if (ListID == 3)
            {
                using (SqlDataAdapter sqlData = new SqlDataAdapter("select o.order_id, c.name + ' ' + c.surname as Fullname, p.name, o.orderAmount, p.price, p.price*o.orderAmount as TotalPrice, o.arrive_time " +
                    "from Orders o " +
                    "join Customers c on o.customer_id = c.customer_id " +
                    "join Products p on o.product_id = p.product_id " +
                    "order by order_id desc", sqlConnection))
                {
                    DataTable dataTable = new DataTable();

                    sqlData.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                    label2.Text = "Orders";
                }
            }


            sqlConnection.Close();
        }
    }
}
