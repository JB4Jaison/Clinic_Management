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
    public partial class Form10 : Form
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
        public Form10()
        {
            InitializeComponent();
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from appointment where doctor_id = " + Form8.D_id;
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
                label10.Text = t.ToString();

            }
            else
            {

            }

            comm = new OracleCommand();
            //comm.CommandText = "select count(*) from appointment a1 where not in (select * from appointment where a1.doctor_id ="+ Form8.D_id + "and date= date'"  +DateTime.Today.ToString("yyyy-MM-dd") + "')";
            //comm.CommandText = "select count(*) AS COU from appointment a1 where a1.doctor_id = 2003 and a1.P_id not in (select b.p_id from appointment b where a1.doctor_id = 2003  and b.appdate ='" + DateTime.Today.ToString("dd - MMM - yyyy") + "')";
            comm.CommandText = "select count(*) as cou from appointment a1 where a1.doctor_id=" +Form8.D_id +"and a1.P_id not in (select b.p_id from appointment b where a1.doctor_id =" + Form8.D_id + " and b.appdate = date'" + DateTime.Today.ToString("yyyy-MM-dd") + "')";
            //comm.CommandText = "select count(*) as cou from appointment a1 where a1.doctor_id= 2003 and a1.P_id not in (select b.p_id from appointment b where a1.doctor_id = 2003  and b.appdate = '28-MAR-2018')";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "TB1_pat");
            dt = ds.Tables["TB1_pat"];
             t = dt.Rows.Count;
            dr = dt.Rows[i];
            label7.Text =dr["cou"].ToString();
            conn.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form11 frm4 = new Form11();
            frm4.Show();
            this.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 frm4 = new Form8();
            frm4.Show();
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //DB_Connect();
            //////String adate = DateTime.Today.ToString("dd-MMM-yyyy");
            //////String cmdString = "EXECUTE tot(" + Form8.D_id + ",'" + adate +"')";
            //////String cmdString = "Execute tot(2003,'28-MAR-2018'))";
            //OracleCommand c = new OracleCommand();
            //c.Connection = conn;
            //OracleCommand c1 = new OracleCommand();
            //c1.Connection = conn;
            ////c.CommandText = "tot";
            ////c.CommandType = CommandType.StoredProcedure;
            ////OracleParameter pa1  = new OracleParameter();
            ////pa1.ParameterName = "d_id";
            ////pa1.DbType = DbType.Int32;
            ////pa1.Value = 2003;
            ////OracleParameter pa2 = new OracleParameter();
            ////pa2.ParameterName = "adate";
            ////pa2.DbType = DbType.Date;
            ////pa2.Value = "28-MAR-2018";
            ////c.Parameters.Add(pa1);
            ////c.Parameters.Add(pa2);
            ////String x  = c.ExecuteScalar().ToString();
            ////label2.Text = x.ToString();
            ////conn.Close();
            //////c.Connection = conn;
            //////c.CommandType = CommandType.StoredProcedure;
            //////c.ExecuteNonQuery();
            //////conn.Close();
            //c.CommandText = " CREATE or replace VIEW TODAY  AS (select * from appointment a1 where a1.doctor_id= 2003 and a1.P_id in (select b.p_id from appointment b where a1.doctor_id = 2003  and b.appdate = '28-MAR-2018'))";
            ////comm.CommandText = "select count(*) as cou from appointment a1 where a1.doctor_id= 2003 and a1.P_id not in (select b.p_id from appointment b where a1.doctor_id = 2003  and b.appdate = '28-MAR-2018')";
            //c.CommandType = CommandType.Text;
            //c.ExecuteNonQuery();
            //c1.CommandText = " SELECT COUNT(*) as coun FROM TODAY";
            //c1.CommandType = CommandType.Text;
            //ds = new DataSet();
            //da = new OracleDataAdapter(c1.CommandText, conn);
            //da.Fill(ds, "TB1_pat");
            //dt = ds.Tables["TB1_pat"];
            //int t = dt.Rows.Count;
            //dr = dt.Rows[i];
            //label2.Text = dr["coun"].ToString();
            //int D = int.Parse()
            //conn.Close();

        }
    }
}
