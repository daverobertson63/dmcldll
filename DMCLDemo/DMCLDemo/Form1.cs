
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using dmcldll;

namespace DMCLDemo
{
    public partial class Form1 : Form

    {
        String DQLSearch = Properties.Settings.Default["DQLSearch"].ToString();
        String customerAttributeName = ""; // name of the customer record
        String customerTypeName = "";
        String localFileCache="c:\\temp\\";


        public Form1()
        {
            InitializeComponent();
            int resint = DMCL.dmAPIInit();

            //Properties.Settings.Default.Save(); 
        }

        // Created with the toolbox
        //ListBox listBox1 = new ListBox();

        private void SearchDocbase_Click(object sender, EventArgs e)
        {

            //listBox1.Location = new System.Drawing.Point(12, 12);
            listBox1.Name = "ListBox1";
            //listBox1.Size = new System.Drawing.Size(245, 200);
            //listBox1.BackColor = System.Drawing.Color.Orange;
            //listBox1.ForeColor = System.Drawing.Color.Black;

            listBox1.Font = new Font("Georgia", 16);
            listBox1.BorderStyle = BorderStyle.FixedSingle;

            listBox1.Items.Add("Mahesh Chand");
            listBox1.Items.Add("Mike Gold");
            listBox1.Items.Add("Praveen Kumar");
            listBox1.Items.Add("Raj Beniwal");

            //listBox1.SelectionMode = SelectionMode.MultiSimple;
            //listBox1.SetSelected(1, true);
            //listBox1.SetSelected(2, true);

            listBox1.Sorted = true;

            listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);

            Controls.Add(listBox1);
        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            MessageBox.Show(listBox1.SelectedItem.ToString());
        }


        private void GetItemsButton_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (object item in listBox1.Items)
            {
                sb.Append(item.ToString());
                sb.Append(" ");
            }
            MessageBox.Show(sb.ToString());
        }

        private void SelectedItemButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(listBox1.Text);
            string selectedItem = null;
            if (listBox1.SelectedIndex > -1)
            {
                selectedItem = listBox1.Items[listBox1.SelectedIndex].ToString();
            }
        }

        private void FindItemButton_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();

            int index = listBox1.FindString(textBox1.Text);

            if (index < 0)
            {
                MessageBox.Show("Item not found.");
                textBox1.Text = String.Empty;
            }
            else
            {
                listBox1.SelectedIndex = index;
            }
        }

        private void DataBindingButton_Click(object sender, EventArgs e)
        {
            ArrayList authors = new ArrayList();
            authors.Add("Mahesh Chand");
            authors.Add("Mike Gold");
            authors.Add("Raj Kumar");
            authors.Add("Praveen Kumar");

            listBox1.Items.Clear();
            listBox1.DataSource = authors;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin _login = new frmLogin();
            _login.ShowDialog();
            if (_login.Authenticated)
            {
                MessageBox.Show("You have logged in successfully " + _login.Username);
            }

            // dispose
            _login = null;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = DQLSearch;
        }

        // Save the DQL to the app config
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DQLSearch=textBox1.Text;

            Properties.Settings.Default["DQLSearch"] = DQLSearch;

            Properties.Settings.Default.Save();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
