using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_management_system
{
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 l = new Form1();
            l.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
           
            login k = new login();
           
            k.Show();
        }
    }
}
