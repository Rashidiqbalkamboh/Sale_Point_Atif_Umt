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
    public partial class Form1 : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int cnt=0,c=0,chk=0,eff=0,b=0,i=0;
        string input = "",input2="",dat="";
        double camt=0,ramt=0;
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please Verify All the Data Before Submit", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cnmtxt.Enabled == true && cnmtxt.Text == "")
                    MessageBox.Show("FILL All THE TEXTBOXES");
                if (pnmtxt.Text == "" || qtxt.Text == "" || sptxt.Text == "" || pptxt.Text == "")
                    MessageBox.Show("FILL All THE TEXTBOXES");
                else
                {
                    string sql = "Insert Into Inventry_Stock(Date,Company_Name,Product_Name,Carton,Boxes,BVQ,Carton_Sale_Price,Carton_Purchase_Price,Sale_Price,Purchase_Price,total_Stock_PP,Total_Stock_SP)Values('" + dateTimePicker1.Value + "','" + cnmtxt.Text.Trim() + "','" + pnmtxt.Text.Trim() + "','" + qtxt.Text + "','" + boxtxt.Text + "','" + Bqtytxt.Text + "','" + Csptxt.Text + "','" + Cpptxt.Text + "','" + sptxt.Text + "','" + pptxt.Text + "','" + tpptxt.Text + "','" + tsptxt.Text + "')";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data stored", "ExpDetail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn1.Close();

                    string sql1 = "Insert Into Purchase_Detail(Purchase_Date,Company_Name,Product_Name,Carton_Quantity,Box_Quantity,Total_Box,CPP,TCPP)Values('" + dateTimePicker1.Value + "','" + cnmtxt.Text.Trim() + "','" + pnmtxt.Text.Trim() + "','" + qtxt.Text + "','" + boxtxt.Text + "','" + Bqtytxt.Text + "','" + Cpptxt.Text + "','" + tpptxt.Text + "')";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql1;
                    cmd.ExecuteNonQuery();
                    cn1.Close();

                    comboBox1.Items.Clear();
                    string sql4 = "select Distinct(Company_Name) from Inventry_Stock";
                    cn1.Open();
                    da = new SqlDataAdapter(sql4, cn1);
                    ds = new DataSet();
                    da.Fill(ds, "Inventry_Stock");
                    c = ds.Tables["Inventry_Stock"].Rows.Count;
                    for (i = 0; i <= c - 1; i++)
                    {
                        comboBox1.Items.Add(ds.Tables["Inventry_Stock"].Rows[i]["Company_Name"]);
                    }
                    cn1.Close();
                    comboBox1.Items.Add("New");

                    string sql11 = "select * from Inventry_Stock";
                    cn1.Open();
                    da = new SqlDataAdapter(sql11, cn1);
                    ds = new DataSet();
                    da.Fill(ds, "Inventry_Stock");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Inventry_Stock";
                    cn1.Close();

                    string sql2 = "select count(*) from Inventry_Stock";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql2;
                    c = Convert.ToInt32(cmd.ExecuteScalar());
                    label17.Text = Convert.ToString(c);
                    cn1.Close();

                    comboBox1.Text = ""; cnmtxt.Clear(); pnmtxt.Clear(); qtxt.Clear();
                    sptxt.Clear(); pptxt.Clear(); boxtxt.Clear();
                    Bqtytxt.Clear(); Csptxt.Clear(); Cpptxt.Clear();
                    tsptxt.Clear(); tpptxt.Clear();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chk = 0;
            button1.Enabled = true; button2.Enabled = true; button3.Enabled = true;
            comboBox1.Text = ""; cnmtxt.Clear(); pnmtxt.Clear(); qtxt.Clear();
            sptxt.Clear(); pptxt.Clear(); boxtxt.Clear();
            Bqtytxt.Clear(); Csptxt.Clear(); Cpptxt.Clear();
            tsptxt.Clear(); tpptxt.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            cnmtxt.Enabled =false;
            string cn = "";
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
            string sql2 = "select Distinct(Company_Name) from Inventry_Stock";
            cn1.Open();
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "Inventry_Stock");
            c = ds.Tables["Inventry_Stock"].Rows.Count;
            for (i = 0; i <= c - 1;i++)
            {
               comboBox1.Items.Add(ds.Tables["Inventry_Stock"].Rows[i]["Company_Name"]);
               cn = ds.Tables["Inventry_Stock"].Rows[i]["Company_Name"].ToString();
               col1.Add(cn);
            }
            cn1.Close();
            comboBox1.AutoCompleteCustomSource = col1;
            comboBox1.Items.Add("New");
            string sql1 = "select count(*) from Inventry_Stock";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql1;
            c=Convert.ToInt32( cmd.ExecuteScalar());
            label17.Text = Convert.ToString(c);
            cn1.Close();
            string sql = "select * from Inventry_Stock";
            cn1.Open();
            da = new SqlDataAdapter(sql, cn1);
            ds = new DataSet();
            da.Fill(ds, "Inventry_Stock");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Inventry_Stock";
            cn1.Close();
        }

        private void pptxt_Leave(object sender, EventArgs e)
        {
            if (qtxt.Text == "" || boxtxt.Text == "" || sptxt.Text == "" || pptxt.Text == "")
                qtxt.Focus();
            else
            {
                tsptxt.Text = Convert.ToString(Convert.ToDouble(sptxt.Text) * Convert.ToDouble(Bqtytxt.Text));
                tpptxt.Text = Convert.ToString(Convert.ToDouble(pptxt.Text) * Convert.ToDouble(Bqtytxt.Text));
                Csptxt.Text = Convert.ToString(Convert.ToDouble(sptxt.Text) * Convert.ToDouble(boxtxt.Text));
                Cpptxt.Text = Convert.ToString(Convert.ToDouble(pptxt.Text) * Convert.ToDouble(boxtxt.Text));
            }
        }

        private void boxtxt_Leave(object sender, EventArgs e)
        {
            Bqtytxt.Text = Convert.ToString(Convert.ToDouble(qtxt.Text) * Convert.ToDouble(boxtxt.Text));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cnt++;
            if (cnt == 60)
                cnt = 0;
            if (cnt % 2 == 0)
                label17.Text="";
            else
                label17.Text=Convert.ToString(c);
        }

        private void qtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Please Enter Digits Only", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Show();
            cnmtxt.Show();
            cnmtxt.Enabled = true;
            if (chk == 0)
            {
                button1.Enabled = false;
                button3.Enabled = false;
                input =Microsoft.VisualBasic.Interaction.InputBox("Enter Company Name Here", "Input Box", "", 500, 300);
                input2 = Microsoft.VisualBasic.Interaction.InputBox("Enter Product Name Here", "Input Box", "", 500, 300);
                string sql1 = "select * from Inventry_Stock where Company_Name='" + input + "' and Product_Name='"+input2+"'";
                cmd = new SqlCommand(sql1, cn1);
                cn1.Open();
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable table = new DataTable();
                eff = da.Fill(table);
                if (eff != 0)
                {
                   cnmtxt.Text =table.Rows[b]["Company_Name"].ToString().TrimStart();
                   pnmtxt.Text = table.Rows[b]["Product_Name"].ToString();
                   qtxt.Text = table.Rows[b]["Carton"].ToString();
                   boxtxt.Text = table.Rows[b]["Boxes"].ToString();
                   sptxt.Text = table.Rows[b]["Sale_Price"].ToString();
                   pptxt.Text = table.Rows[b]["Purchase_Price"].ToString();
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

                string sql = "Update Inventry_Stock set Company_Name='" +cnmtxt.Text + "',Product_Name='" + pnmtxt.Text + "',Carton='" + qtxt.Text + "',Boxes='" + boxtxt.Text + "',BVQ='"+Bqtytxt.Text+"',Carton_Sale_Price='" + Csptxt.Text + "',Carton_Purchase_Price='" +Cpptxt.Text + "',Total_Stock_PP='"+tpptxt.Text+"',Total_Stock_SP='"+tsptxt.Text+"',Sale_Price='" + sptxt.Text + "',Purchase_Price='" + pptxt.Text + "' where Company_Name='" + input + "' and Product_Name='" + input2 + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfully....!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Question);
                chk = 0;
                cn1.Close();

                comboBox1.Text = ""; cnmtxt.Clear(); pnmtxt.Clear(); qtxt.Clear();
                sptxt.Clear(); pptxt.Clear(); boxtxt.Clear();
                Bqtytxt.Clear(); Csptxt.Clear(); Cpptxt.Clear();
                tsptxt.Clear(); tpptxt.Clear();

                string sql2 = "Select * from Inventry_Stock";
                cn1.Open();
                da = new SqlDataAdapter(sql2, cn1);
                ds = new DataSet();
                da.Fill(ds, "Inventry_Stock");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Inventry_Stock";
                cn1.Close();
                button1.Enabled =true;
                button3.Enabled =true;
                chk = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chk == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                input = Microsoft.VisualBasic.Interaction.InputBox("Enter Company Name Here", "Input Box", "", 500, 300);
                input2 = Microsoft.VisualBasic.Interaction.InputBox("Enter Product Name Here", "Input Box", "", 500, 300);
                string sql1 = "select * from Inventry_Stock where Company_Name='" + input + "' and Product_Name='" + input2 + "'";
                cmd = new SqlCommand(sql1, cn1);
                cn1.Open();
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable table = new DataTable();
                eff = da.Fill(table);
                if (eff != 0)
                {
                    cnmtxt.Text = table.Rows[b]["Company_Name"].ToString();
                    pnmtxt.Text = table.Rows[b]["Product_Name"].ToString();
                    qtxt.Text = table.Rows[b]["Carton"].ToString();
                    boxtxt.Text = table.Rows[b]["Boxes"].ToString();
                    sptxt.Text = table.Rows[b]["Sale_Price"].ToString();
                    pptxt.Text = table.Rows[b]["Purchase_Price"].ToString();
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
                string sql = "Delete from Inventry_Stock where Company_Name='" +input + "' and Product_Name='"+input2+"'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully....!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                chk = 0;
                cn1.Close();

                comboBox1.Text = ""; cnmtxt.Clear(); pnmtxt.Clear(); qtxt.Clear();
                sptxt.Clear(); pptxt.Clear(); boxtxt.Clear();
                Bqtytxt.Clear(); Csptxt.Clear(); Cpptxt.Clear();
                tsptxt.Clear(); tpptxt.Clear(); chk = 0;

                string sql2 = "Select * from Inventry_Stock";
                cn1.Open();
                da = new SqlDataAdapter(sql2, cn1);
                ds = new DataSet();
                da.Fill(ds, "Inventry_Stock");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Inventry_Stock";
                cn1.Close();

                string sql3 = "select count(*) from Inventry_Stock";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql3;
                c = Convert.ToInt32(cmd.ExecuteScalar());
                label17.Text = Convert.ToString(c);
                cn1.Close();
                button1.Enabled =true;
                button2.Enabled =true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedItem == "New")
            {
                cnmtxt.Enabled = true;
                cnmtxt.Clear();
            }
            else
            {
                cnmtxt.Enabled = false;
                cnmtxt.Text=comboBox1.Text;
            }
            string sql = "select * from Inventry_Stock where Company_Name='"+comboBox1.Text+"'";
            cn1.Open();
            da = new SqlDataAdapter(sql, cn1);
            ds = new DataSet();
            da.Fill(ds, "Inventry_Stock");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Inventry_Stock";
            cn1.Close();

            string sql1 = "select count(*) from Inventry_Stock where Company_Name='"+comboBox1.Text+"'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql1;
            c = Convert.ToInt32(cmd.ExecuteScalar());
            label17.Text = Convert.ToString(c);
            cn1.Close();
        }

        private void pnmtxt_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            dv.RowFilter = string.Format("Product_Name Like '%{0}%'", pnmtxt.Text);
            dataGridView1.DataSource = dv;
        }

        private void pnmtxt_Leave(object sender, EventArgs e)
        {
            string nm = "";
            string sql2 = "select Product_Name from Inventry_Stock";
            cn1.Open();
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "Inventry_Stock");
            c = ds.Tables["Inventry_Stock"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
              nm=ds.Tables["Inventry_Stock"].Rows[i]["Product_Name"].ToString();
              if (pnmtxt.Text.ToLower() == nm.ToLower())
              { 
                  MessageBox.Show("Product Name Already Stored", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  pnmtxt.Clear();
                  pnmtxt.Focus();
              }
            }
            cn1.Close();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void qtxt_KeyPress_1(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(qtxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void boxtxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(boxtxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void sptxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(sptxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void pptxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(pptxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }
    }
}
