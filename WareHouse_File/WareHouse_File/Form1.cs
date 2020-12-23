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
    public partial class Form1 : Form
    {

        List<Seller> Sellers = new List<Seller>();
        private void Form1_Load_1(object sender, EventArgs e)
        {
            //Sellers = new List<Seller>()
            //{
            //    new Seller("username1","password1","name1","surname1"),
            //    new Seller("username2","password2","name2","surname2"),
            //    new Seller("username3","password3","name3","surname3")
            //};

            DirectoryInfo directoryInfo = new DirectoryInfo(@".\DataStorage");
            string sellerDB = Path.Combine(directoryInfo.FullName, "sellerDB.json");

            using (StreamReader streamReader = new StreamReader(sellerDB))
            {
                string jsonText = streamReader.ReadToEnd();
                Sellers = JsonConvert.DeserializeObject<List<Seller>>(jsonText);
            }

            //textBox2.PasswordChar = '*';
        }


        public Form1()
        {
            InitializeComponent();
        }


        //========================================================= CHECKS WHETHER SUCH SELLER EXISTS OR NOT
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Input Fields are empty. FILL THEM", "Empty Inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Seller foundSeller = Sellers.Find(x => x.Username == textBox1.Text && x.Password == textBox2.Text);
                bool isFound = Sellers.Exists(x => x.Username == textBox1.Text && x.Password == textBox2.Text);

                if (isFound)
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


        //========================================================= REDIRECTS YOU TO SIGN UP
        private void button2_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(Sellers);
            form3.ShowDialog();
        }
    }



    public class Seller
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Seller(string username, string password, string name, string surname)
        {
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
        }
    }
}
