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

namespace Hamid_Bhutta_and_Brothers
{
    public partial class EmployRecord : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true"); 
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int cnt = 0, c = 0, chk = 0, eff = 0, b = 0, i = 0;
        string input = "", input2 = "", dat = "";
        public EmployRecord()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please Verify All the Data Before Submit", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cnmcombo.Text == "" || enmtxt.Text == "")
                    MessageBox.Show("Please Fill All the Boxes", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    string sql3 = "Insert Into EmployRec(Company_Name,Employ_Name,Employ_Cell)Values('" + cnmcombo.Text.Trim() + "','" + enmtxt.Text.Trim() + "','" + esltxt.Text.Trim() + "')";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql3;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data stored", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn1.Close();

                    string sql1 = "select * from EmployRec";
                    cn1.Open();
                    da = new SqlDataAdapter(sql1, cn1);
                    ds = new DataSet();
                    da.Fill(ds, "EmployRec");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "EmployRec";
                    cn1.Close();

                    cnmcombo.Text = ""; enmcombo.Text = ""; enmtxt.Clear(); esltxt.Clear();
                }
            }
        }

        private void EmployRecord_Load(object sender, EventArgs e)
        {
          cnmcombo.Items.Clear();
          string cn = "";
         cnmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
         cnmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
          AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
           string sql2 = "select Distinct(Company_Name) from Inventry_Stock";
            da = new SqlDataAdapter(sql2, cn1);
            DataSet ds = new DataSet();
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
          
           string sql1 = "select * from EmployRec";
           cn1.Open();
           da = new SqlDataAdapter(sql1, cn1);
           ds = new DataSet();
           da.Fill(ds, "EmployRec");
           dataGridView1.DataSource = ds;
           dataGridView1.DataMember = "EmployRec";
           cn1.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            chk = 0;
            button1.Enabled = true; button2.Enabled = true; button3.Enabled = true;
            cnmcombo.Text = ""; enmcombo.Text = ""; enmtxt.Clear(); esltxt.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cnmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            enmcombo.Items.Clear();
            string enm = "";
          enmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
          enmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            string sql2 = "select Distinct(Employ_Name) from EmployRec where Company_Name='"+cnmcombo.Text+"'";
            da = new SqlDataAdapter(sql2, cn1);
            DataSet ds = new DataSet();
            da.Fill(ds, "EmployRec");
            c = ds.Tables["EmployRec"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
              enmcombo.Items.Add(ds.Tables["EmployRec"].Rows[i]["Employ_Name"]);
              enm = ds.Tables["EmployRec"].Rows[i]["Employ_Name"].ToString();
              col.Add(enm);

            }
            cn1.Close();
            enmcombo.AutoCompleteCustomSource = col;
           enmcombo.Items.Add("New");

           string sql1 = "select * from EmployRec where Company_Name='"+cnmcombo.Text+"'";
           cn1.Open();
           da = new SqlDataAdapter(sql1, cn1);
           ds = new DataSet();
           da.Fill(ds, "EmployRec");
           dataGridView1.DataSource = ds;
           dataGridView1.DataMember = "EmployRec";
           cn1.Close();
        }

        private void enmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (enmcombo.SelectedItem == "New")
            {
              enmtxt.Enabled = true;
             enmtxt.Clear();
            }
            else
            {
              enmtxt.Enabled = false;
             enmtxt.Text =enmcombo.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chk == 0)
            {
                button1.Enabled = false;
                button3.Enabled = false;
                input = Microsoft.VisualBasic.Interaction.InputBox("Enter Company_Name Here", "Input Box", "", 500, 300);
                input2 = Microsoft.VisualBasic.Interaction.InputBox("Enter Employ_Name Here", "Input Box", "", 500, 300);
                string sql1 = "select * from EmployRec where Company_Name='" + input + "' and Employ_Name='"+input2+"'";
                cmd = new SqlCommand(sql1, cn1);
                cn1.Open();
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable table = new DataTable();
                eff = da.Fill(table);
                if (eff != 0)
                {
                    cnmcombo.Text = table.Rows[b]["Company_Name"].ToString().TrimStart();
                    enmtxt.Text = table.Rows[b]["Employ_Name"].ToString().TrimStart();
                    chk = 1;
                    cn1.Close();
                }
                else
                {
                    MessageBox.Show("Rrecord Not In Table");
                    cn1.Close();
                }

            }

            else if (chk == 1)
            {

                string sql = "Update EmployRec set Company_Name='" +cnmcombo.Text + "',Employ_Name='" +enmtxt.Text + "' where Company_Name='" + input + "' and Employ_Name='"+input2+"'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfully....!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Question);
                chk = 0;
                cn1.Close();

                string sql2 = "Select * from EmployRec where Company_Name='"+cnmcombo.Text+"' and Employ_Name='"+enmtxt.Text+"'";
                cn1.Open();
                da = new SqlDataAdapter(sql2, cn1);
                ds = new DataSet();
                da.Fill(ds, "ShopKeeperRecord");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "ShopKeeperRecord";
                cn1.Close();

                cnmcombo.Text = ""; enmcombo.Text = ""; enmtxt.Clear(); esltxt.Clear();
                button1.Enabled =true;
                button3.Enabled = true; chk = 0;                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chk == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                input = Microsoft.VisualBasic.Interaction.InputBox("Enter Company_Name Here", "Input Box", "", 500, 300);
                input2 = Microsoft.VisualBasic.Interaction.InputBox("Enter Employ_Name Here", "Input Box", "", 500, 300);
                string sql1 = "select * from EmployRec where Company_Name='" + input + "' and Employ_Name='" + input2 + "'";
                cmd = new SqlCommand(sql1, cn1);
                cn1.Open();
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable table = new DataTable();
                eff = da.Fill(table);
                if (eff != 0)
                {
                    cnmcombo.Text = table.Rows[b]["Company_Name"].ToString().TrimStart();
                    enmtxt.Text = table.Rows[b]["Employ_Name"].ToString().TrimStart();
                    chk = 1;
                    cn1.Close();
                }
                else
                {
                    MessageBox.Show("Rrecord Not In Table");
                    cn1.Close();
                }

            }

            else if (chk == 1)
            {
                string sql = "Delete EmployRec where Company_Name='" + input + "' and Employ_Name='" + input2 + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully....!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Question);
                chk = 0;
                cn1.Close();

                string sql2 = "Select * from EmployRec where Company_Name='" + cnmcombo.Text + "' and Employ_Name='" + enmtxt.Text + "'";
                cn1.Open();
                da = new SqlDataAdapter(sql2, cn1);
                ds = new DataSet();
                da.Fill(ds, "ShopKeeperRecord");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "ShopKeeperRecord";
                cn1.Close();

                cnmcombo.Text = ""; enmcombo.Text = ""; enmtxt.Clear(); esltxt.Clear();
                button1.Enabled =true;
                button2.Enabled = true; chk = 0;
            }
        }

        private void enmtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                e.Handled = false;
            else if (Char.IsDigit(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Characters Only", "Error");
            }
            if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(enmtxt, true, true, true, true);

                }
                e.Handled = true;
            }

        }

        private void esltxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Digit Only", "Error");
            }
            if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(esltxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void EmployRecord_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
