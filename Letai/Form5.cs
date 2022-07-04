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
    public partial class Form5 : Form
    {
        ListViewItem lvi;
        public Form5()
        {
            InitializeComponent();
            UpdateList();

        }

        public void UpdateList()
        {
            using (Model1Container db = new Model1Container())
            {
                listView1.Items.Clear();
                foreach (var item in db.HistorySet)
                {
                    lvi = new ListViewItem(item.IdStaff);
                    lvi.SubItems.Add(item.Happened);
                    lvi.SubItems.Add(item.IdClient);
                    listView1.Items.Add(lvi); 
                }
            }
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
