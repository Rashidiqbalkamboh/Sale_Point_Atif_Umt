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
using System.Configuration;

namespace Hamid_Bhutta_and_Brothers
{
    public partial class View_Stock : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int c = 0, i = 0;
        public View_Stock()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (cnmcombo.Text != "")
            {
                string sql1 = "Select * From Inventry_Stock where Company_Name='" + cnmcombo.Text + "'";
                cn1.Open();
                da = new SqlDataAdapter(sql1, cn1);

                ds = new DataSet();
                da.Fill(ds, "Inventry_Stock");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Inventry_Stock";
                cn1.Close();

                string sql2 = "Select SUM(Total_Stock_PP) From Inventry_Stock where Company_Name='" + cnmcombo.Text + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql2;
               TPVtxt.Text=Convert.ToString(cmd.ExecuteScalar());
               cn1.Close();

               string sql3 = "Select SUM(Total_Stock_SP) From Inventry_Stock where Company_Name='" + cnmcombo.Text + "'";
               cn1.Open();
               cmd.Connection = cn1;
               cmd.CommandText = sql3;
              TSVtxt.Text = Convert.ToString(cmd.ExecuteScalar());
               cn1.Close();
            }
            else
            {
                MessageBox.Show("Please Select Company Name First");
                cnmcombo.Focus(); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cnmcombo.Text != "")
            {
                CrystalReport1 cr = new CrystalReport1();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Hamid_Bhutta_and_Brothers.Properties.Setting.DistributionSetup"].ToString();
                string sql1 = "Select * From Inventry_Stock where Company_Name='" + cnmcombo.Text + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sql1, con);
                da.Fill(ds, "Inventry_Stock");
                DataTable dt = ds.Tables["Inventry_Stock"];
                cr.SetDataSource(ds.Tables["Inventry_Stock"]);
                crystalReportViewer1.ReportSource = cr;
                crystalReportViewer1.Refresh();
            }
            else 
            {
                MessageBox.Show("Please Select Company Name First");
                cnmcombo.Focus();
            }
        }

        private void View_Stock_Load(object sender, EventArgs e)
        {
            string cn = "";
            cnmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cnmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            string sql = "select Distinct(Company_Name) from Inventry_Stock";
            da = new SqlDataAdapter(sql, cn1);
            ds = new DataSet();
            da.Fill(ds, "Inventry_Stock");
            c = ds.Tables["Inventry_Stock"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                cnmcombo.Items.Add(ds.Tables["Inventry_Stock"].Rows[i]["Company_Name"]);
                cn = ds.Tables["Inventry_Stock"].Rows[i]["Company_Name"].ToString();
                col.Add(cn);
            }
            cn1.Close();
            cnmcombo.AutoCompleteCustomSource = col;
        }

        private void View_Stock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
