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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

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
                    try
                    {
                        using (SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-CMJP8T1\\SQLEXPRESS;Database=WareHouse;Trusted_Connection=True;"))
                        {
                            sqlConnection.Open();

                            SqlCommand sqlCommand = new SqlCommand("insert into Sellers(username, password, name, surname) values(@username, @password, @name, @surname)", sqlConnection);
                            sqlCommand.Parameters.Add(new SqlParameter("username", textBox1.Text));
                            sqlCommand.Parameters.Add(new SqlParameter("password", textBox2.Text));
                            sqlCommand.Parameters.Add(new SqlParameter("name", textBox4.Text));
                            sqlCommand.Parameters.Add(new SqlParameter("surname", textBox5.Text));

                            var result = sqlCommand.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Signed Up successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Signed Up Failed", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception exec)
                    {

                        MessageBox.Show($"{exec.Message}", "Cannot Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Passwords Don't match. Check Again", "Passwords Unmatching", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
