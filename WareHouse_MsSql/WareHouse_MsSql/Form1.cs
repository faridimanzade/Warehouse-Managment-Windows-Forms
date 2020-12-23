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
    public partial class Form1 : Form
    {
        List<Seller> sellers = new List<Seller>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
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

                        SqlCommand sqlCommand = new SqlCommand("Select username, password from Sellers", sqlConnection);
                        var reader = sqlCommand.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string username = reader.GetString(0);
                                string password = reader.GetString(1);

                                sellers.Add(new Seller(username, password));
                            }
                        }

                        if (sellers.Exists(x=>x.username == textBox1.Text && x.password == textBox2.Text))
                        {
                                Form2 form2 = new Form2();
                                form2.Show();
                                this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("You don't have account. Maybe Sign up?", "Invalid Inputs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            button2.Visible = true;
                        }
                    }
                }
                catch (Exception exec)
                {
                    MessageBox.Show($"{exec.Message}", "Cannot Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }

    class Seller
    {
        public string username { get; set; }
        public string password { get; set; }

        public Seller(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
