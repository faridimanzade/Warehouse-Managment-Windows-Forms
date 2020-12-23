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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(maskedTextBox1.Text) || String.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Input Fields are empty. FILL THEM", "Empty Inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-CMJP8T1\\SQLEXPRESS;Database=WareHouse;Trusted_Connection=True;"))
                    {
                        sqlConnection.Open();

                        SqlCommand sqlCommand = new SqlCommand("insert into Customers(name, surname, email, phone, address) values(@name, @surname, @email, @phone, @address)", sqlConnection);
                        sqlCommand.Parameters.AddWithValue("name", textBox1.Text);
                        sqlCommand.Parameters.AddWithValue("surname", textBox2.Text);
                        sqlCommand.Parameters.AddWithValue("email", textBox3.Text);
                        sqlCommand.Parameters.AddWithValue("phone", maskedTextBox1.Text);
                        sqlCommand.Parameters.AddWithValue("address", richTextBox1.Text);

                        var result = sqlCommand.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Customer Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Failed Adding Customer", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception exec)
                {
                    MessageBox.Show($"{exec.Message}", "Cannot Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
