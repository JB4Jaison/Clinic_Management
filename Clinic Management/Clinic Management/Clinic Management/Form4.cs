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
   
    public partial class Form4 : Form
    {
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
        public Form4()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            this.Visible = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm1 = new Form4();
            frm1.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registraion frm1 = new Registraion();
            frm1.Show();
            this.Visible = false;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Form1 frm5 = new Form1();
            frm5.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 frm1 = new Form6();
            frm1.Show();
            this.Visible = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Registraion frm3 = new Registraion();
            frm3.Show();
            this.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Connect();
                int d_id = int.Parse(textBox8.Text);
                int p_id = int.Parse(textBox1.Text);
                int fno = int.Parse(textBox2.Text);
                String date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                OracleCommand cm = new OracleCommand();
                cm.Connection = conn;
                cm.CommandText = "insert into appointment values(" + p_id + "," + fno + "," + d_id + ",date'" + date + "')";
                cm.CommandType = CommandType.Text;
                cm.ExecuteNonQuery();
                MessageBox.Show("Inserted");
                conn.Close();

                DB_Connect();
            }
            catch(Exception)
            {
                MessageBox.Show("Sorry!! Too many Appointments With Doctor Already");
            }

           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select p_id as Patient_Id ,Fileno as File_Number, P_Name as Patient_Name from Patient natural join medicalhistory;";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "TB1_pat");
            dt = ds.Tables["TB1_pat"];
            int t = dt.Rows.Count;
            if (t > 0)
            {
                dr = dt.Rows[i];


            }
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TB1_pat";
            conn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from appointment ";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "TB1_app");
            dt = ds.Tables["TB1_app"];
            int t = dt.Rows.Count;
            
            if (t > 0)
            {
                dr = dt.Rows[i];


            }
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TB1_app";
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.Show();
            this.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");

        }
    }
}
