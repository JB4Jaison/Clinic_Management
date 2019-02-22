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
    public partial class Form5 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        int b_no = 1000;
        private void DB_Connect()
        {
            String oradb = "Data Source=XE;User ID=system;Password=student";
            conn = new OracleConnection(oradb);
            conn.Open();
        }
        public Form5()
        {
            InitializeComponent();
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from bill ";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "TB1_bil");
            dt = ds.Tables["TB1_bil"];
            int t = dt.Rows.Count;
            if (t > 0)
            {
                b_no += t;
                dr = dt.Rows[i];
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "TB1_bil";
                
            }
            else
            {

            }
            conn.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void Form5_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                here:
                try
                {

                    label6.Text = ((int.Parse(textBox2.Text) + int.Parse(textBox1.Text)) * 2).ToString();
                }
                catch (Exception)
                {
                    textBox1.Text = "0";

                    goto here;


                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                here:
                try
                {

                    label6.Text = ((int.Parse(textBox2.Text) + int.Parse(textBox1.Text)) * 2).ToString();
                }
                catch (Exception)
                {
                    textBox2.Text = "0";

                    goto here;


                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Visible = false ;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            int p_id = int.Parse(textBox8.Text);
            int tot = int.Parse(label6.Text);

            try
            {
                DB_Connect();

                OracleCommand cm = new OracleCommand();
                cm.Connection = conn;

                cm.CommandText = "insert into bill values('" + p_id + "','" + b_no + "','" + tot + "','" + Form8.R_id + "')";
                cm.CommandType = CommandType.Text;
                cm.ExecuteNonQuery();
                MessageBox.Show("A BIll Has Been Created");
                update();
                b_no++;

                conn.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Patient Already Ha a bill!!");
            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 frm1 = new Form6();
            frm1.Show();
            this.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void update()
        {
            DB_Connect();
            comm = new OracleCommand();
            comm.CommandText = "select * from bill ";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "TB1_bil");
            dt = ds.Tables["TB1_bil"];
            int t = dt.Rows.Count;
            if (t > 0)
            {
                dr = dt.Rows[i];
                

            }
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TB1_bil";
            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {


                DB_Connect();
                String b_id = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                DB_Connect();

                OracleCommand cm = new OracleCommand();
                cm.Connection = conn;
                cm.CommandText = "delete from bill where billno =:ye";
                cm.CommandType = CommandType.Text;
                OracleParameter pa1 = new OracleParameter();
                pa1.ParameterName = "ye";
                pa1.DbType = DbType.String;
                pa1.Value = b_id;
                cm.Parameters.Add(pa1);
                cm.ExecuteNonQuery();
                MessageBox.Show("Paid");
                update();
                conn.Close();

            }
            else
            {
                MessageBox.Show("Please Ensure thst you select a row !!!");
            }
        }
    }
}
