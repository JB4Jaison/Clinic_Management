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
    public partial class Form8 : Form
    {
        static public String D_id = "";
        static public String R_id = "";

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
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String pword = textBox2.Text;

            int uname = int.Parse(textBox1.Text);
            if (radioButton2.Checked == true)
            {
                DB_Connect();


                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from doctor where doctor_id = " + uname + " and password = '" + pword+ "'";


                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "TB1_doc");
                dt = ds.Tables["TB1_doc"];
                int t = dt.Rows.Count;
                if (t > 0)
                {
                    
                    dr = dt.Rows[i];
                    D_id = dr["doctor_id"].ToString();
                    this.Visible = false;
                    Form10 frm1 = new Form10();
                    frm1.Show();
                }
                else
                {
                    MessageBox.Show("INVALID CREDENTIALS!!!");
                }
                conn.Close();
            }
            else if( radioButton1.Checked == true)
            {
                DB_Connect();


                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from receptionist where recep_id = " + uname + " and password = '" + pword + "'";


                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "TB1_rep");
                dt = ds.Tables["TB1_rep"];
                int t = dt.Rows.Count;
                if (t > 0)
                {
                  
                    dr = dt.Rows[i];
                    R_id = dr["recep_id"].ToString();
                    this.Visible = false;
                    Form1 frm1 = new Form1();
                    frm1.Show();
                }
                else
                {
                    MessageBox.Show("INVALID CREDENTIALS!!!");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please Ensure you select the type of user !!!");
            }
        }
    }
}
