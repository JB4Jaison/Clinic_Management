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
    public partial class Form6 : Form
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
        public Form6()
        {
            InitializeComponent();
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from patient ";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "TB1_pat");
            dt = ds.Tables["TB1_pat"];
            int t = dt.Rows.Count;
            dr = dt.Rows[i];
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TB1_pat";
            conn.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 frm1 = new Form6();
            frm1.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 frm5 = new Form1();
            frm5.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registraion frm3 = new Registraion();
            frm3.Show();
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {


                DB_Connect();
                String p_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "select fileno , dept_name , disease , bloodgroup , allergy from patient natural join medicalhistory natural join department where p_id = " + p_id;


                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "TB1_pat");
                dt = ds.Tables["TB1_pat"];
                int t = dt.Rows.Count;
                dr = dt.Rows[i];
                label4.Text = dr["fileno"].ToString();
                label6.Text = dr["dept_name"].ToString();
                label7.Text = dr["disease"].ToString();
                label9.Text = dr["bloodgroup"].ToString();
                label11.Text = dr["allergy"].ToString();
                conn.Close();

            }
            else
            {
                MessageBox.Show("Please Ensure thst you select a row !!!");
            }

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
