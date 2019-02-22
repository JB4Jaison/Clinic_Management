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
    public partial class Form11 : Form
    {
        int Prescp_ID = 1;
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
        public Form11()
        {
            InitializeComponent();
            DB_Connect();
            comm = new OracleCommand();
           
            comm.CommandText = "select * from appointment where doctor_id = " + Form8.D_id + "and appdate = date'" + DateTime.Today.ToString("yyyy-MM-dd")+"'" ;
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "TB1_pat");
            dt = ds.Tables["TB1_pat"];
            int t = dt.Rows.Count;
            if (t > 0)
            {
                dr = dt.Rows[i];
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "TB1_pat";
                

            }
            else
            {
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "TB1_pat";
            }

            comm = new OracleCommand();
           
            comm.CommandText = "select * from prescription";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "TB1_pat");
            dt = ds.Tables["TB1_pat"];
            t = dt.Rows.Count;
            if (t > 0)
            {

                Prescp_ID+=t;

            }
            else
            {

            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form10 frm4 = new Form10();
            frm4.Show();
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void update()
        {
            InitializeComponent();
            DB_Connect();
            comm = new OracleCommand();
     
            comm.CommandText = "select * from appointment where doctor_id = " + Form8.D_id + "and appdate = date'" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "TB1_pat");
            dt = ds.Tables["TB1_pat"];
            int t = dt.Rows.Count;
            if (t > 0)
            {
                dr = dt.Rows[i];
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "TB1_pat";
                

            }
            else
            {
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "TB1_pat";
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB_Connect();
            try
            {

                String temp = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                int pid = int.Parse(temp);
                OracleCommand cm = new OracleCommand();
                cm.Connection = conn;
                cm.CommandText = "update medicalhistory set disease ='" + textBox1.Text + "' where p_id=" + pid;
                cm.CommandType = CommandType.Text;

                cm.ExecuteNonQuery();
                MessageBox.Show("Patient Has been Diagnosed With" + textBox1.Text + "!!!");



                OracleCommand cm1 = new OracleCommand();
                cm1.Connection = conn;
                cm1.CommandText = "insert into prescription values(" + pid + "," + Form8.D_id + "," + Prescp_ID + ")";
                cm1.CommandType = CommandType.Text;

                cm1.ExecuteNonQuery();


                OracleCommand cm2 = new OracleCommand();
                cm2.Connection = conn;

                if (comboBox1.Text != "None")
                {
                    cm2.CommandText = "insert into Presc_medicine values(" + Prescp_ID + "," + int.Parse(comboBox1.Text) + ")";
                    cm2.CommandType = CommandType.Text;

                    cm2.ExecuteNonQuery();
                }
                if (comboBox3.Text != "None")
                {
                    cm2.CommandText = "insert into Presc_medicine values(" + Prescp_ID + "," + int.Parse(comboBox3.Text) + ")";
                    cm2.CommandType = CommandType.Text;

                    cm2.ExecuteNonQuery();
                }
                if (comboBox4.Text != "None")
                {
                    cm2.CommandText = "insert into Presc_medicine values(" + Prescp_ID + "," + int.Parse(comboBox4.Text) + ")";
                    cm2.CommandType = CommandType.Text;

                    cm2.ExecuteNonQuery();

                }
                if (comboBox5.Text != "None")
                {
                    cm2.CommandText = "insert into Presc_medicine values(" + Prescp_ID + "," + int.Parse(comboBox5.Text) + ")";
                    cm2.CommandType = CommandType.Text;

                    cm2.ExecuteNonQuery();
                }
                MessageBox.Show("Prescription Created");
                Prescp_ID++;
                OracleCommand cm3 = new OracleCommand();
                cm3.Connection = conn;
                cm3.CommandText = "delete from appointment where p_id =" + pid;
                cm3.CommandType = CommandType.Text;

                cm3.ExecuteNonQuery();
                update();
            }
            catch(Exception)
            {
                MessageBox.Show("Please select a Patient");
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 frm4 = new Form8();
            frm4.Show();
            this.Visible = false;
        }
    }
}
