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
    public partial class Closing_Report : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        AutoCompleteStringCollection col = new AutoCompleteStringCollection();
        int i = 0, c = 0;
        Double ctn = 0, cpp = 0, csp = 0, tcpp=0;
        DateTime dt;
        public Closing_Report()
        {
            InitializeComponent();
        }
        private void Closing_Report_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            { SendKeys.Send("{TAB}"); }
        }

        private void cnmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           pnmcombo.Items.Clear();
           pnmcombo.Text = "";
            string pn = "";
           pnmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
           pnmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            string sql2 = "select Product_Name from Inventry_Stock where Company_Name='" +cnmcombo.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "Inventry_Stock");
            c = ds.Tables["Inventry_Stock"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
               pnmcombo.Items.Add(ds.Tables["Inventry_Stock"].Rows[i]["Product_Name"]);
                pn = ds.Tables["Inventry_Stock"].Rows[i]["Product_Name"].ToString();
                col.Add(pn);
            }
            cn1.Close();
          pnmcombo.AutoCompleteCustomSource = col;
        }

        private void pnmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            rcvtxt.Text = "0";
            string sql3 = "select Purchase_Date,Carton_Quantity from Purchase_Detail where Product_Name='" + pnmcombo.Text + "' and Company_Name='" + cnmcombo.Text + "'";
            da = new SqlDataAdapter(sql3, cn1);
            ds = new DataSet();
            da.Fill(ds, "Purchase_Detail");
            c = ds.Tables["Purchase_Detail"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                dt=Convert.ToDateTime(ds.Tables["Purchase_Detail"].Rows[i]["Purchase_Date"]);
               if (dt.Date.DayOfYear <= dateTimePicker2.Value.Date.DayOfYear && dt.Date.Month <= dateTimePicker2.Value.Date.Month && dt.Date.Year <= dateTimePicker2.Value.Date.Year && dt.Date.DayOfYear>=dateTimePicker1.Value.Date.DayOfYear && dt.Date.Month>=dateTimePicker1.Value.Date.Month && dt.Date.Year>=dateTimePicker1.Value.Date.Year)
                    rcvtxt.Text = Convert.ToString(Convert.ToDouble(rcvtxt.Text) +Convert.ToDouble(ds.Tables["Purchase_Detail"].Rows[i]["Carton_Quantity"]));
            }
            cn1.Close();
          
            string sql = "select * from Inventry_Stock where Company_Name='" + cnmcombo.Text + "'and Product_Name='" + pnmcombo.Text + "'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql;
            reader=cmd.ExecuteReader();
            while (reader.Read())
            {
                cltxt.Text = reader.GetValue(3).ToString();
                cpp =Convert.ToDouble(reader.GetValue(7));
            }
            cn1.Close();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value <= dateTimePicker2.Value)
            {
                string en = "";
                cnmcombo.Items.Clear();
                cnmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cnmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
                string sql = "select Distinct(Company_Name) from Purchase_Detail where Purchase_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                da = new SqlDataAdapter(sql, cn1);
                ds = new DataSet();
                da.Fill(ds, "Purchase_Detail");
                c = ds.Tables["Purchase_Detail"].Rows.Count;
                for (i = 0; i <= c - 1; i++)
                {
                    cnmcombo.Items.Add(ds.Tables["Purchase_Detail"].Rows[i]["Company_Name"]);
                    en = ds.Tables["Purchase_Detail"].Rows[i]["Company_Name"].ToString();
                    col1.Add(en);
                }
                cn1.Close();
                cnmcombo.AutoCompleteCustomSource = col1;
            }
            else
            {
                MessageBox.Show("From Date Always Less or Equal to ToDate", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void optxt_Leave(object sender, EventArgs e)
        {
            if(optxt.TextLength!= 0)
            {
                totxt.Text = Convert.ToString(Convert.ToDouble(optxt.Text) + Convert.ToDouble(rcvtxt.Text));
                sotxt.Text = Convert.ToString(Convert.ToDouble(totxt.Text) - Convert.ToDouble(cltxt.Text));
                svtxt.Text = Convert.ToString(cpp * Convert.ToDouble(sotxt.Text));
                cvtxt.Text = Convert.ToString(cpp * Convert.ToDouble(cltxt.Text));

                string sql = "select Sum(Total_Stock_PP) from Inventry_Stock where Company_Name='" + cnmcombo.Text + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                tcpp = Convert.ToDouble(cmd.ExecuteScalar());
                cn1.Close();
                cptxt.Text = Convert.ToString((Convert.ToDouble(cvtxt.Text) / tcpp) * 100);
                sptxt.Text = Convert.ToString((Convert.ToDouble(svtxt.Text) / tcpp) * 100);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            cnmcombo.Text = "Select Company"; pnmcombo.Text = "Select Product";
            optxt.Clear(); rcvtxt.Text = "0"; totxt.Text = "0"; svtxt.Text = "0";
            sotxt.Text = "0"; cltxt.Text = "0"; cvtxt.Text = "0";
            cptxt.Text = "0"; sptxt.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please Verify All the Data Before Submit", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cnmcombo.Text == "" || pnmcombo.Text == "" || optxt.Text == "")
                {
                    MessageBox.Show("Please Fill The Requirements", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string sql3 = "Insert Into Closing_Record(From_Date,To_Date,C_Name,P_Name,Opening,Rcv_Stock,T_Stock,Sold_Stock,Closing_Stock,Closing_Value,Sold_Value,Closing_Per,Sold_Per)Values('" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "','" + cnmcombo.Text.Trim() + "','" + pnmcombo.Text.Trim() + "','" + optxt.Text + "','" + rcvtxt.Text + "','" + totxt.Text + "','" + sotxt.Text + "','" + cltxt.Text + "','" + cvtxt.Text + "','" + svtxt.Text + "','" + cptxt.Text + "','" + sptxt.Text + "')";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql3;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data stored", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn1.Close();

                    string sql1 = "select * from Closing_Record";
                    cn1.Open();
                    da = new SqlDataAdapter(sql1, cn1);
                    ds = new DataSet();
                    da.Fill(ds, "Closing_Record");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Closing_Record";
                    cn1.Close();

                    pnmcombo.Text = "";
                    optxt.Clear(); rcvtxt.Text = "0"; totxt.Text = "0"; svtxt.Text = "0";
                    sotxt.Text = "0"; cltxt.Text = "0"; cvtxt.Text = "0";
                    cptxt.Text = "0"; sptxt.Text = "0";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void optxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsLetter(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Digit Only", "Error");
            }
            if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(optxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql2 = "select * from Closing_Record where C_Name='"+cnmcombo.Text+"' and From_Date between '"+dateTimePicker1.Value+"' and '"+DateTime.Now.Date+"'";
            cn1.Open();
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "Closing_Record");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Closing_Record";
            cn1.Close();
             if (cnmcombo.Text != "")
             {               
                 CloseRPT cr = new CloseRPT();
                cr.SetParameterValue("C_Name", cnmcombo.Text);
                 SqlConnection con = new SqlConnection();
                 con.ConnectionString = ConfigurationManager.ConnectionStrings["Hamid_Bhutta_and_Brothers.Properties.Setting.DistributionSetup"].ToString();
                 string sql1 = "select * from Closing_Record where C_Name='"+cnmcombo.Text+"' and From_Date between '"+dateTimePicker1.Value+"' and '"+DateTime.Now.Date+"'";
                 DataSet ds1 = new DataSet();
                 SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                 da1.Fill(ds1, "Closing_Record");
                 DataTable dt = ds1.Tables["Closing_Record"];
                 cr.SetDataSource(ds1.Tables["Closing_Record"]);
                 crystalReportViewer1.ReportSource = cr;
                 crystalReportViewer1.Refresh();
             }
             else
             {
                 MessageBox.Show("Please Select Company Name First");
                 cnmcombo.Focus();
             }
        }

        private void Closing_Report_Load(object sender, EventArgs e)
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

        private void rcvtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void optxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
