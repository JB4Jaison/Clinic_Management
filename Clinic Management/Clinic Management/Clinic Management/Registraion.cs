using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace Clinic_Management
{
    public partial class Registraion : Form
    {
        int ID = 001;
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        private void DB_Connect()
        {
            String oradb = "Data Source=XE;User ID=system;Password=student";
            conn = new OracleConnection(oradb);
            conn.Open();
        }
        public Registraion()
        {
            InitializeComponent();
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from patient ";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "TB1_bil");
            dt = ds.Tables["TB1_bil"];
            int t = dt.Rows.Count;
            ID = ID + t;
            conn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Registraion_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 frm1 = new Form6();
            frm1.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 frm5 = new Form1();
            frm5.Show();
            this.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked != true && radioButton2.Checked != true && radioButton3.Checked != true && radioButton4.Checked != true && radioButton5.Checked != true &&
                radioButton6.Checked != true && radioButton7.Checked != true || textBox1.Text == "" || textBox2.Text == "" ||
                textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox7.Text == "" || textBox8.Text == ""  )
            {
                MessageBox.Show("Please Fill In All The details");

            }
            else if (! textBox8.Text.Any(char.IsDigit))

            {
                MessageBox.Show("Please Enter a Valid File No");
            }
            else {
                String blood = "";
                if (radioButton1.Checked == true) blood = "A+";
                else if (radioButton2.Checked == true) blood = "AB+";

                else if (radioButton3.Checked == true) blood = "O+";
                else if (radioButton4.Checked == true) blood = "AB-";
                else if (radioButton5.Checked == true) blood = "B+";
                else if (radioButton6.Checked == true) blood = "B-";
                else if (radioButton7.Checked == true) blood = "A-";


                DB_Connect();
                int d_id = int.Parse(textBox5.Text);
                int p_id = ID;
                int fno = int.Parse(textBox8.Text);

                OracleCommand cm = new OracleCommand();
                cm.Connection = conn;
                cm.CommandText = "insert into patient  values(" + p_id + ",'" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox3.Text + "'," + d_id + ")";
                cm.CommandType = CommandType.Text;
                cm.ExecuteNonQuery();
                MessageBox.Show("Inserted");

                OracleCommand cm1 = new OracleCommand();
                cm1.Connection = conn;
                cm1.CommandText = "insert into medicalhistory  values(" + p_id + "," + fno + ", 'Alive' , 'None' ,'" + blood + "','" + textBox7.Text + "')";
                cm1.CommandType = CommandType.Text;
                cm1.ExecuteNonQuery();
                MessageBox.Show("Created New Medical History");

                conn.Close();

                DB_Connect();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.Show();
            this.Visible = false;
        }
    }
}
