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
    public partial class Form3 : Form
    {
        List<Seller> Sellers;
        public Form3(List<Seller> Sellers)
        {
            InitializeComponent();
            this.Sellers = Sellers;
        }


        //========================================================= ALL REGISTRATION PART FOR SELLER
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) || String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Input Fields are empty. FILL THEM", "Empty Inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox2.Text == textBox3.Text)
                {
                    Sellers.Add(new Seller(textBox1.Text, textBox2.Text, textBox4.Text, textBox5.Text));

                    DirectoryInfo directoryInfo = new DirectoryInfo(@".\DataStorage");
                    string sellerDB = Path.Combine(directoryInfo.FullName, "sellerDB.json");

                    string customerList = JsonConvert.SerializeObject(Sellers);
                    using (StreamWriter streamWriter = new StreamWriter(sellerDB))
                    {
                        streamWriter.WriteLine(customerList);
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Passwords Don't match. Check Again", "Passwords Unmatching", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
