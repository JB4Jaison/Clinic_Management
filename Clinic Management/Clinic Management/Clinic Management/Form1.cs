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
    public partial class Form1 : Form
    {
        String Rname = "";
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
        public Form1()
        {
            InitializeComponent();

            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from patient";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "TB1_pat");
            dt = ds.Tables["TB1_pat"];
            int t = dt.Rows.Count;
            label5.Text = t.ToString();

            comm.CommandText = "select * from department";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "TB1_dept");
            dt = ds.Tables["TB1_dept"];
            t = dt.Rows.Count;
            label8.Text = t.ToString();
           

            comm.CommandText = "select * from appointment";
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "TB1_app");
            dt = ds.Tables["TB1_app"];
            t = dt.Rows.Count;
            label10.Text = t.ToString();

            comm.CommandText = "select * from receptionist where recep_id =" +Form8.R_id;
            comm.CommandType = CommandType.Text;
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "TB1_app");
            dt = ds.Tables["TB1_app"];
            t = dt.Rows.Count;
            dr = dt.Rows[i];
            Rname = dr["r_name"].ToString();
       
            label6.Text = "Welcome " + Rname ;

            conn.Close();

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registraion frm3 = new Registraion();
            frm3.Show();
            this.Visible = false ;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
        //    DB_Connect();
        //    comm = new OracleCommand();
        //    comm.CommandText = "select * from person";
        //    comm.CommandType = CommandType.Text;
        //    ds = new DataSet();
        //    da = new OracleDataAdapter(comm.CommandText, conn);
        //    da.Fill(ds, "TB1_car");
        //    dt = ds.Tables["TB1_car"];
        //    int t = dt.Rows.Count;
        //    MessageBox.Show(t.ToString());
        //    dr = dt.Rows[i];
        //    dataGridView1.DataSource = ds;
        //    dataGridView1.DataMember = "TB1_car";
        //    conn.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //label5.Text =dataGridView1.SelectedRows[1].Cells[1].Value.ToString();
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.Show();
            this.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    MessageBox.Show(label5.Text = dataGridView1.SelectedRows[0].ToString());
        //    label5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

        //}

        //private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    MessageBox.Show(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
        //    label5.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        //}
}

