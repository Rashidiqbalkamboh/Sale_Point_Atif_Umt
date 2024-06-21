using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Drawing.Drawing2D;
using System.IO;

namespace Hamid_Bhutta_and_Brothers
{
    public partial class Log_In : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        AutoCompleteStringCollection col = new AutoCompleteStringCollection();
        int check;
        string cc;
        public Log_In()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Log_In_Load(object sender, EventArgs e)
        {
            /* string sql15 = "truncate table ROI_Record";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql15;
            cmd.ExecuteNonQuery();
            cn1.Close();*/
            label3.Hide();
            string nm = "";
            nmtxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            nmtxt.AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
            string sql = "select * from Log_In";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
           while(reader.Read())
            {
                nm = reader.GetValue(0).ToString();
                col1.Add(nm);
            }
            cn1.Close();
         nmtxt.AutoCompleteCustomSource = col1;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from Log_In where User_Name='" + nmtxt.Text + "' and Password='" +pstxt.Text + "'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
               Main_Form MF = new Main_Form(nmtxt.Text,pstxt.Text);
                MF.Show();
                cn1.Close();
                nmtxt.Clear();
               pstxt.Clear();

            }
            else
            {
                label3.Show();
                cn1.Close();
                nmtxt.Clear();
               pstxt.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Hide();
            nmtxt.Clear();
            pstxt.Clear();
        }

        private void nmtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(nmtxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void pstxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(pstxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void nmtxt_TextChanged(object sender, EventArgs e)
        {
           /* SqlConnection cn1 = new SqlConnection();
            cn1.ConnectionString = "data source=localhost\\sqlexpress;initial catalog=DistributionSetup;integrated security=true";
            SqlDataAdapter da = new SqlDataAdapter();
            cn1.Open();
            SqlDataReader reader;
         SqlCommand cmd=new SqlCommand("select User_Name from Log_In where User_Name LIKE  @name",cn1);
           cmd.Parameters.Add(new SqlParameter("@name","%" + nmtxt.Text + "%"));
           reader = cmd.ExecuteReader();
           AutoCompleteStringCollection col = new AutoCompleteStringCollection();
          while(reader.Read())
           {
               col.Add(reader.GetString(0));  
           }
          nmtxt.AutoCompleteCustomSource = col;
           cn1.Close();*/

        }

        private void Log_In_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
