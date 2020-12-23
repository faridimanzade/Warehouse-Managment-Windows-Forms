using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouse_MsSql
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //=============================== ADD NEW CUSTOMER
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        //=============================== ADD NEW PRODUCT
        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        //=============================== VIEW LIST OF CUSTOMERS
        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.SendData(1);
            form7.ShowDialog();
        }

        //=============================== VIEW LIST OF PRODUCTS
        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.SendData(2);
            form7.ShowDialog();
        }

        //=============================== ADD NEW ORDER
        private void acceptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.ShowDialog();
        }

        //=============================== VIEW LIST OF ORDERS
        private void listToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.SendData(3);
            form7.ShowDialog();
        }

    }
}
