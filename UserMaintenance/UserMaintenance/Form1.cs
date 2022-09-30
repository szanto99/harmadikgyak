using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();
            FullName.Text = Resource1.FullName;
            button1.Text = Resource1.Add;
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "Fullname";
            WritetoFile.Text = Resource1.WritetoFile;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text,
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*";
            saveFileDialog1.Filter = filter;
            saveFileDialog1.AddExtension = true;
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF8);
                
                foreach (User user in users)
                {
                    sw.WriteLine($"{user.ID};{user.FullName}");
                }
                sw.Close();
            }
        }
    }
}
