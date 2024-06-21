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
    public partial class Company_Lager : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true"); 
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int cnt = 0, c = 0, chk = 0, eff = 0, b = 0, i = 0;
        string input = "", input2 = "", dat = "";
        public Company_Lager()
        {
            InitializeComponent();
        }

        private void Company_Lager_Load(object sender, EventArgs e)
        {
            /* string sql15 = "truncate table Company_Lager";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql15;
            cmd.ExecuteNonQuery();
            cn1.Close();*/
            string cn = "";
           cnmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
           cnmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
            string sql2 = "select Distinct(Company_Name) from Inventry_Stock";
            cn1.Open();
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "Inventry_Stock");
            c = ds.Tables["Inventry_Stock"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
               cnmcombo.Items.Add(ds.Tables["Inventry_Stock"].Rows[i]["Company_Name"]);
                cn = ds.Tables["Inventry_Stock"].Rows[i]["Company_Name"].ToString();
                col1.Add(cn);
            }
            cn1.Close();
          cnmcombo.AutoCompleteCustomSource = col1;
        }
        private void Company_Lager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void cnmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            rettxt.Text = "0";
            deptxt.Text = "0";
           ncrtxt.Text = "0";
           cnmtxt.Text = cnmcombo.Text;
           
            string sql1 = "select * from Company_Lager where C_Name='" + cnmcombo.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql1, cn1);
            ds = new DataSet();
            da.Fill(ds, "Company_Lager");
            c = ds.Tables["Company_Lager"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                cnmcombo.Text = ds.Tables["Company_Lager"].Rows[i]["C_Name"].ToString();
                rettxt.Text =ds.Tables["Company_Lager"].Rows[i]["Credit"].ToString();
            }
            cn1.Close();
        }

        private void deptxt_Leave(object sender, EventArgs e)
        {
            if(deptxt.TextLength!=0)
            rettxt.Text = Convert.ToString(Convert.ToDouble(rettxt.Text) -Convert.ToDouble(deptxt.Text));            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please Verify All the Data Before Submit", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cnmcombo.Text == "" || dettxt.Text == "")
                    MessageBox.Show("Fill Complete Data");
                else
                {
                    rettxt.Text = Convert.ToString(Convert.ToDouble(rettxt.Text) + Convert.ToDouble(ncrtxt.Text));
                    string sql3 = "Insert Into Company_Lager(Date,C_Name,New_Credit,Deposit,Credit,Descrip)Values('" + dateTimePicker3.Value + "','" + cnmcombo.Text.Trim() + "','" + ncrtxt.Text.Trim() + "','" + deptxt.Text.Trim() + "','" + rettxt.Text.Trim() + "','" + dettxt.Text.Trim() + "')";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql3;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data stored", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn1.Close();

                    cnmcombo.Text = ""; dettxt.Clear();
                    deptxt.Text = "0"; rettxt.Text = "0"; ncrtxt.Text = "0";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chk = 0; button1.Enabled = true;
            cnmcombo.Text = ""; dettxt.Clear(); 
            deptxt.Text = "0"; rettxt.Text = "0";ncrtxt.Text = "0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
                MessageBox.Show("From Date Always Less Then To Date", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                string sql1 = "Select * From Company_Lager where Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                cn1.Open();
                da = new SqlDataAdapter(sql1, cn1);
                ds = new DataSet();
                da.Fill(ds, "Company_Lager");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Company_Lager";
                cn1.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chk == 0)
            {
                button1.Enabled = false;
                input = Microsoft.VisualBasic.Interaction.InputBox("Enter Date Here LIKE MM/DD/YYYY", "Input Box", "", 500, 300);
                input2 = Microsoft.VisualBasic.Interaction.InputBox("Enter Company_Name Here", "Input Box", "", 500, 300);
                string sql1 = "select * from Company_Lager where Date='" + input + "' and C_Name='" + input2 + "'";
                cn1.Open();
                cmd = new SqlCommand(sql1, cn1);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable table = new DataTable();
                eff = da.Fill(table);
                if (eff != 0)
                {
                 cnmtxt.Text = table.Rows[b]["C_Name"].ToString().TrimStart();
                  ncrtxt.Text = table.Rows[b]["New_Credit"].ToString();
                  deptxt.Text = table.Rows[b]["Deposit"].ToString();
                   rettxt.Text =table.Rows[b]["Credit"].ToString();
                   dettxt.Text = table.Rows[b]["Descrip"].ToString();
                   chk = 1;
                    cn1.Close();

                    rettxt.Text = Convert.ToString(Convert.ToDouble(rettxt.Text) +Convert.ToDouble(deptxt.Text));
                    rettxt.Text = Convert.ToString(Convert.ToDouble(rettxt.Text) - Convert.ToDouble(ncrtxt.Text));
                    deptxt.Enabled = false; ncrtxt.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Rrecord Not In Table");
                    cn1.Close();
                    deptxt.Enabled =true; ncrtxt.Enabled =true;
                }

            }
            else if (chk == 1)
            {
                rettxt.Text = Convert.ToString(Convert.ToDouble(rettxt.Text) - Convert.ToDouble(deptxt.Text));
                rettxt.Text = Convert.ToString(Convert.ToDouble(rettxt.Text) + Convert.ToDouble(ncrtxt.Text));

                string sql = "Update Company_Lager set C_Name='" + cnmtxt.Text + "',Descrip='" + dettxt.Text + "' where Date='" + input + "' and C_Name='" + input2 + "'";//,New_Credit='" +ncrtxt.Text + "',Deposit='"+deptxt.Text+"',Credit='"+rettxt.Text+"'
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfully....!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Question);
                chk = 0;
                cn1.Close();

                string sql2 = "Select * from Company_Lager where Date='" + input + "' and C_Name='" + input2 + "'";
                cn1.Open();
                da = new SqlDataAdapter(sql2, cn1);
                ds = new DataSet();
                da.Fill(ds, "Company_Lager");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Company_Lager";
                cn1.Close();

                cnmcombo.Text = ""; dettxt.Clear(); deptxt.Text = "0";
                rettxt.Text = "0"; ncrtxt.Text = "0"; button1.Enabled = true;
                deptxt.Enabled = true; ncrtxt.Enabled = true;
           }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void deptxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(deptxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void rettxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(rettxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void ncrtxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(ncrtxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void dettxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar)||Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Digit Only", "Error");
            }
            if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(dettxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cnmcombo.Text != "")
            {
             Company_LagerReport cl = new Company_LagerReport();
                cl.SetParameterValue("C_Name", cnmcombo.Text);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Hamid_Bhutta_and_Brothers.Properties.Setting.DistributionSetup"].ToString();
                string sql1 = "select * from Company_Lager where C_Name='" + cnmcombo.Text + "' and Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                DataSet ds1 = new DataSet();
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                da1.Fill(ds1, "Company_Lager");
                DataTable dt = ds1.Tables["Company_Lager"];
                cl.SetDataSource(ds1.Tables["Company_Lager"]);
                crystalReportViewer1.ReportSource = cl;
                crystalReportViewer1.Refresh();
            }
            else
            {
                MessageBox.Show("Please Select Company Name First");
                cnmcombo.Focus();
            }
        }

        private void rettxt_Leave(object sender, EventArgs e)
        {
            if (rettxt.TextLength == 0)
                rettxt.Text = "0";
        }

        private void ncrtxt_Leave(object sender, EventArgs e)
        {
            if (ncrtxt.TextLength == 0)
               ncrtxt.Text = "0";
        }

        private void deptxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
