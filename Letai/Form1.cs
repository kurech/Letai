using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Letai
{
    public partial class Form1 : Form
    {
        public string _idSt = "";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Model1Container db = new Model1Container())
            {
                foreach(Staff staff in db.StaffSet)
                {
                    if((textBox1.Text == staff.Login) && (this.GetHashString(textBox2.Text) == staff.Password))
                    {
                        MessageBox.Show("Вход в аккаунт " + staff.Login);
                        Form2 form2 = new Form2();
                        form2.Show();
                        form2.label2.Text = staff.Id.ToString();
                        this.Hide();
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }
    }
}
