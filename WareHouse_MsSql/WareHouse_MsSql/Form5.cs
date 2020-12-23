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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(numericUpDown1.Text) || String.IsNullOrEmpty(richTextBox1.Text))
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

                        SqlCommand sqlCommand = new SqlCommand("insert into Products(name, price, quantity, description) values(@name, @price, @quantity, @description)", sqlConnection);
                        sqlCommand.Parameters.Add(new SqlParameter("name", textBox1.Text));
                        sqlCommand.Parameters.Add(new SqlParameter("price", textBox2.Text));
                        sqlCommand.Parameters.Add(new SqlParameter("quantity", numericUpDown1.Value));
                        sqlCommand.Parameters.Add(new SqlParameter("description", richTextBox1.Text));

                        var result = sqlCommand.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Product Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Failed Adding Product", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
