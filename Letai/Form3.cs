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
    public partial class Form3 : Form
    {
        Form2 form2 = new Form2();
        Form1 form1 = new Form1();
        public string _idStaff = "";
        public string _history = "";
        public string _idClient = "";
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                using (Model1Container db = new Model1Container())
                {
                    foreach (Clients clients in db.ClientsSet)
                    {
                        if (textBox6.Text == clients.Id.ToString())
                        {
                            _idClient = clients.Id.ToString();
                            _history = "Удалён клиент " + clients.Surname + " " + clients.Name;
                            _idStaff = label7.Text;
                            db.ClientsSet.Remove(clients);
                        }
                    }
                    db.SaveChanges();
                    History history = new History()
                    {
                        IdStaff = _idStaff,
                        Happened = _history,
                        IdClient = _idClient
                    };
                    db.HistorySet.Add(history);
                    db.SaveChanges();
                    _idStaff = null;
                    _history = null;
                    _idClient = null;
                    MessageBox.Show("Удален!");
                }
            }
            else
            {
                MessageBox.Show("Неверно заданы значения!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                using (Model1Container db = new Model1Container())
                {
                    foreach(Clients clients in db.ClientsSet)
                    {
                        if(textBox6.Text == clients.Id.ToString())
                        {
                            clients.Surname = textBox1.Text;
                            clients.Name = textBox2.Text;
                            clients.Passport = textBox3.Text;
                            clients.Service = textBox4.Text;
                            clients.Price = textBox5.Text;
                            _idClient = clients.Id.ToString();
                            _idStaff = label7.Text;
                            _history = "Обновлены данные у клиента " + clients.Surname + " " + clients.Name;
                        }
                    }
                    db.SaveChanges();
                    History history = new History()
                    {
                        IdStaff = _idStaff,
                        Happened = _history,
                        IdClient = _idClient
                    };
                    db.HistorySet.Add(history);

                    db.SaveChanges();
                    _idStaff = null;
                    _history = null;
                    _idClient = null;
                    MessageBox.Show("Данные успешно изменены!");
                }
            }
            else
            {
                MessageBox.Show("Неверно заданы значения!");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            form2.Show();
        }
    }
}
