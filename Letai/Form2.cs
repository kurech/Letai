using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Letai
{
    public partial class Form2 : Form
    {
        public int _id = 0;
        public string _name = "";
        public string _surname = "";
        public string _passport = "";
        public string _service = "";
        public string _price = "";

        public bool flag = false;

        public Form2()
        {
            InitializeComponent();
            UpdateList();
            label1.Visible = false;
            comboBox1.Visible = false;
            textBox1.Visible = false;
        }

        public void UpdateList()
        {
            using (Model1Container db = new Model1Container())
            {
                listBox1.Items.Clear();
                foreach (var item in db.ClientsSet)
                {
                    listBox1.Items.Add(item.Surname + "   " + item.Name);
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show(); //912
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            using (Model1Container db = new Model1Container())
            {
                foreach (var item in db.ClientsSet)
                {
                    if ((item.Surname + "   " + item.Name) == (string)listBox1.SelectedItem)
                    {
                        clients = db.ClientsSet.Find(item.Id);
                        _id = clients.Id;
                        _surname = clients.Surname;
                        _name = clients.Name;
                        _passport = clients.Passport;
                        _service = clients.Service;
                        _price = clients.Price;
                    }
                }
                Form3 form3 = new Form3();
                form3.Show();
                form3.label7.Text = label2.Text;
                this.Hide();
                form3.textBox6.Text = _id.ToString();
                form3.textBox1.Text = _surname;
                form3.textBox2.Text = _name;
                form3.textBox3.Text = _passport;
                form3.textBox4.Text = _service;
                form3.textBox5.Text = _price;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            form4.label6.Text = label2.Text;
            this.Hide();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                listBox1.Size = (Size)new Point(497, 381);
                label1.Visible = true;
                comboBox1.Visible = true;
                textBox1.Visible = true;
                flag = true;
            }
            else if (flag == true)
            {
                listBox1.Size = (Size)new Point(497, 439);
                label1.Visible = false;
                comboBox1.Visible = false;
                textBox1.Visible = false;
                flag = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 
            using (Model1Container db = new Model1Container())
            {
                if(textBox1.Text != "")
                {
                    foreach (Clients clients in db.ClientsSet)
                    {
                        if(comboBox1.Text == "фамилии")
                        {
                            if (clients.Surname == textBox1.Text)
                            {
                                listBox1.Items.Clear();
                                listBox1.Items.Add(clients.Surname + "   " + clients.Name);
                            }
                        }
                        if (comboBox1.Text == "имени")
                        {
                            if (clients.Name == textBox1.Text)
                            {
                                listBox1.Items.Clear();
                                listBox1.Items.Add(clients.Surname + "   " + clients.Name);
                            }
                        }
                    }
                }
                else
                {
                    UpdateList();
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
    }
}
