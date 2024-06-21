using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Hamid_Bhutta_and_Brothers
{
    public partial class Incoming_Sheet : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int c = 0, i = 0, chkk = 0, chk = 0, b = 0, eff = 0,test=0;
        double amt = 0,ina=0,tcsh=0,ch=0;
        string input = "", input2 = "", input1 = "",input3="";
        Bitmap bitmap; int updt = 0;
        public Incoming_Sheet()
        {
            InitializeComponent();
        }

        private void Incoming_Sheet_Load(object sender, EventArgs e)
        {
            /* string sql15 = "truncate table Incoming";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql15;
            cmd.ExecuteNonQuery();
            cn1.Close();*/
            cattxt.Enabled = false;
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

            string cl = "";
            catcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            catcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
            string sql2 = "select Distinct(Income_Type) from Incoming";
            cn1.Open();
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "Incoming");
            c = ds.Tables["Incoming"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                catcombo.Items.Add(ds.Tables["Incoming"].Rows[i]["Income_Type"]);
                cl = ds.Tables["Incoming"].Rows[i]["Income_Type"].ToString();
                col1.Add(cl);
            }
            cn1.Close();
            catcombo.AutoCompleteCustomSource = col1;
        }

        private void cnmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql5 = "select * from Incoming where Income_ID='" + IDtxt.Text + "' and C_Name='" + cnmcombo.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql5, cn1);
            ds = new DataSet();
            da.Fill(ds, "Incoming");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Incoming";
            cn1.Close();

           pchtxt.Text = "0";
           tcontxt.Text = "0";
           string sql4 = "select * from Incoming where C_Name='" + cnmcombo.Text + "'";// and Income_Date between '"+dateTimePicker1.Value+"' and '"+dateTimePicker2.Value+"'";
            cn1.Open();
            da = new SqlDataAdapter(sql4, cn1);
            ds = new DataSet();
            da.Fill(ds, "Incoming");
            c = ds.Tables["Incoming"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
               pchtxt.Text = Convert.ToString(Convert.ToDouble(pchtxt.Text) + Convert.ToDouble(ds.Tables["Incoming"].Rows[i]["Cash_In_Hand"]));
               tcontxt.Text = Convert.ToString(Convert.ToDouble(tcontxt.Text) + Convert.ToDouble(ds.Tables["Incoming"].Rows[i]["Coins"]));
            }
            cn1.Close();

            tintxt.Text = "0";
            string sql2 = "select Income_Amount,Coins from Incoming where C_Name='"+cnmcombo.Text+"' and Income_Date='"+dateTimePicker2.Value+"'";
            cn1.Open();
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "Incoming");
            c = ds.Tables["Incoming"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                ina = Convert.ToDouble(ds.Tables["Incoming"].Rows[i]["Income_Amount"]);
                tintxt.Text = Convert.ToString(Convert.ToDouble(tintxt.Text) + ina);
            }
            cn1.Close();

           textxt.Text = "0";
            string sql3 = "select Expance_Amount from Expance_Record where Company_Name='" + cnmcombo.Text + "' and Expance_Date='" + dateTimePicker2.Value + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql3, cn1);
            ds = new DataSet();
            da.Fill(ds, "Expance_Record");
            c = ds.Tables["Expance_Record"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                ina = Convert.ToDouble(ds.Tables["Expance_Record"].Rows[i]["Expance_Amount"]);
               textxt.Text = Convert.ToString(Convert.ToDouble(textxt.Text) + ina);
            }
            cn1.Close();
            enmcombo.Items.Clear();
            enmcombo.Text = "";
            string en = "";
            enmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            enmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
            string sql = "select Distinct(Employ_Name) from EmployRec";
            da = new SqlDataAdapter(sql, cn1);
            ds = new DataSet();
            da.Fill(ds, "EmployRec");
            c = ds.Tables["EmployRec"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                enmcombo.Items.Add(ds.Tables["EmployRec"].Rows[i]["Employ_Name"]);
                en = ds.Tables["EmployRec"].Rows[i]["Employ_Name"].ToString();
                col1.Add(en);
            }
            cn1.Close();
            enmcombo.AutoCompleteCustomSource = col1;

            cnmtxt.Text = cnmcombo.Text;
            if (catcombo.Text != "New")
            {
                string sql1 = "select * from Incoming where C_Name='" + cnmcombo.Text + "' and Income_ID='" + IDtxt.Text + "'";
                da = new SqlDataAdapter(sql1, cn1);
                ds = new DataSet();
                eff = da.Fill(ds, "Incoming");
                c = ds.Tables["Incoming"].Rows.Count;
                if (eff == 0)
                {
                    catcombo.Text = "";
                }
                else if (eff != 0)
                {
                    for (i = 0; i <= c - 1; i++)
                    {
                        catcombo.Text = ds.Tables["Incoming"].Rows[i]["Income_Type"].ToString();

                    }
                }
                cn1.Close();
            }
      }

        private void button1_Click(object sender, EventArgs e)
        {
            updt = 0;
            if (MessageBox.Show("Please Verify All the Data Before Submit", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cattxt.Text == "" || amttxt.Text == "" || cnmcombo.Text == "" || enmcombo.Text == "")
                    MessageBox.Show("Fill All The Textboxes");
                else
                {
                    string sql2 = "Insert Into Incoming(Income_Date,Income_ID,Income_Type,C_Name,E_Name,Income_Amount,Income_Detail,Cash_In_Hand,Coins)Values('" + dateTimePicker2.Value + "','" + IDtxt.Text.Trim() + "','" + cattxt.Text.Trim() + "','" + cnmcombo.Text.Trim() + "','" + enmcombo.Text.Trim() + "','" + amttxt.Text + "','" + dettxt.Text.Trim() + "','" + cshtxt.Text + "','" + contxt.Text + "')";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql2;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Stored Successfully...!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn1.Close();

                    pchtxt.Text = "0";
                    tcontxt.Text = "0";
                    string sql4 = "select * from Incoming where C_Name='" + cnmcombo.Text + "' and Income_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                    cn1.Open();
                    da = new SqlDataAdapter(sql4, cn1);
                    ds = new DataSet();
                    da.Fill(ds, "Incoming");
                    c = ds.Tables["Incoming"].Rows.Count;
                    for (i = 0; i <= c - 1; i++)
                    {
                        pchtxt.Text = Convert.ToString(Convert.ToDouble(pchtxt.Text) + Convert.ToDouble(ds.Tables["Incoming"].Rows[i]["Cash_In_Hand"]));
                        tcontxt.Text = Convert.ToString(Convert.ToDouble(tcontxt.Text) + Convert.ToDouble(ds.Tables["Incoming"].Rows[i]["Coins"]));
                    }
                    cn1.Close();

                    cattxt.Clear(); catcombo.Text = ""; cnmcombo.Text = ""; amttxt.Clear(); dettxt.Clear();
                    catcombo.Items.Clear(); tintxt.Text = "0"; textxt.Text = "0"; cshtxt.Text = "0"; contxt.Text = "0";

                    string cl = "";
                    catcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    catcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                    string sql = "select Distinct(Income_Type) from Incoming";
                    cn1.Open();
                    da = new SqlDataAdapter(sql, cn1);
                    ds = new DataSet();
                    da.Fill(ds, "Incoming");
                    c = ds.Tables["Incoming"].Rows.Count;
                    for (i = 0; i <= c - 1; i++)
                    {
                        catcombo.Items.Add(ds.Tables["Incoming"].Rows[i]["Income_Type"]);
                        cl = ds.Tables["Incoming"].Rows[i]["Income_Type"].ToString();
                        col.Add(cl);
                    }
                    cn1.Close();
                    catcombo.AutoCompleteCustomSource = col;
                    catcombo.Items.Add("New");

                    string sql3 = "select * from Incoming";
                    cn1.Open();
                    da = new SqlDataAdapter(sql3, cn1);
                    ds = new DataSet();
                    da.Fill(ds, "Incoming");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Incoming";
                    cn1.Close();
                }
            }            
        }

        private void catcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (catcombo.SelectedItem == "New")
            {
                cattxt.Enabled = true;
                cnmcombo.Text = "";
                cattxt.Clear();
                IDtxt.Clear();
            }
            else
            {
                cattxt.Enabled = false;
                cattxt.Text = catcombo.Text;
                string sql = "select * from Incoming where Income_Type='" + cattxt.Text + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    IDtxt.Text = reader.GetValue(1).ToString();
                    chkk = 1;
                }
                cn1.Close();

                string sql3 = "select * from Incoming where Income_Type='" + cattxt.Text + "'";
                cn1.Open();
                da = new SqlDataAdapter(sql3, cn1);
                ds = new DataSet();
                da.Fill(ds, "Incoming");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Incoming";
                cn1.Close();

            }
        }

        private void IDtxt_Leave(object sender, EventArgs e)
        {
            string sql1 = "select * from Incoming where Income_ID='" + IDtxt.Text + "'";
            da = new SqlDataAdapter(sql1, cn1);
            ds = new DataSet();
            da.Fill(ds, "Incoming");
            c = ds.Tables["Incoming"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                cattxt.Text = ds.Tables["Incoming"].Rows[i]["Income_Type"].ToString();
                catcombo.Text = ds.Tables["Incoming"].Rows[i]["Income_Type"].ToString();
            }
            cn1.Close();

            string sql3 = "select * from Incoming where Income_ID='" + IDtxt.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql3, cn1);
            ds = new DataSet();
            da.Fill(ds, "Incoming");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Incoming";
            cn1.Close();
        }

        private void cnmcombo_Enter(object sender, EventArgs e)
        {
            if (IDtxt.TextLength == 0)
            {
                MessageBox.Show("Please Select ID First");
                IDtxt.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
                MessageBox.Show("From Date Always Less Then To Date", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                string sql3 = "select * from Incoming where Income_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                cn1.Open();
                da = new SqlDataAdapter(sql3, cn1);
                ds = new DataSet();
                da.Fill(ds, "Incoming");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Incoming";
                cn1.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chk = 0; button1.Enabled = true; IDtxt.Clear(); updt = 0; enmcombo.Text = "Select Employ";
            cattxt.Clear(); cnmtxt.Clear(); catcombo.Text = ""; cnmcombo.Text = ""; amttxt.Clear(); dettxt.Clear();
            tintxt.Text = "0"; textxt.Text = "0"; cshtxt.Text = "0";pchtxt.Text="0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            test = 1; updt = 1;
            if (chk == 0)
            {
                button1.Enabled = false;
                input = Microsoft.VisualBasic.Interaction.InputBox("Enter Date Here LIKE MM/DD/YYYY", "Input Box", "", 500, 300);
                input2 = Microsoft.VisualBasic.Interaction.InputBox("Enter Expance_ID Here", "Input Box", "", 500, 300);
                input1 = Microsoft.VisualBasic.Interaction.InputBox("Enter Company_Name Here", "Input Box", "", 500, 300);
                input3 = Microsoft.VisualBasic.Interaction.InputBox("Enter Employ_Name Here", "Input Box", "", 500, 300);
                string sql1 = "select * from Incoming where Income_Date='" + input + "' and C_Name='" + input1 + "'  and Income_ID='" + input2 + "' and E_Name='"+input3+"'";
                cn1.Open();
                cmd = new SqlCommand(sql1, cn1);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable table = new DataTable();
                eff = da.Fill(table);
                if (eff != 0)
                {
                    IDtxt.Text = table.Rows[b]["Income_ID"].ToString();
                    cattxt.Text = table.Rows[b]["Income_Type"].ToString();
                    cnmtxt.Text = table.Rows[b]["C_Name"].ToString();
                    enmcombo.Text = table.Rows[b]["E_Name"].ToString();
                    amttxt.Text = table.Rows[b]["Income_Amount"].ToString();
                    tintxt.Text = table.Rows[b]["Income_Amount"].ToString();
                    dettxt.Text = table.Rows[b]["Income_Detail"].ToString();
                    cshtxt.Text = table.Rows[b]["Cash_In_Hand"].ToString();
                    chk = 1;
                    cn1.Close();

                    string sql4 = "select * from Incoming where C_Name='" +input1 + "'";// and Income_Date between '"+dateTimePicker1.Value+"' and '"+dateTimePicker2.Value+"'";
                    cn1.Open();
                    da = new SqlDataAdapter(sql4, cn1);
                    ds = new DataSet();
                    da.Fill(ds, "Incoming");
                    c = ds.Tables["Incoming"].Rows.Count;
                    for (i = 0; i <= c - 1; i++)
                    {
                        pchtxt.Text = Convert.ToString(Convert.ToDouble(pchtxt.Text) + Convert.ToDouble(ds.Tables["Incoming"].Rows[i]["Cash_In_Hand"]));
                        tcontxt.Text = Convert.ToString(Convert.ToDouble(tcontxt.Text) + Convert.ToDouble(ds.Tables["Incoming"].Rows[i]["Coins"]));
                    }
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
                tintxt.Text = Convert.ToString(Convert.ToDouble(amttxt.Text) + Convert.ToDouble(tintxt.Text));
                pchtxt.Text = Convert.ToString(Convert.ToDouble(pchtxt.Text) + Convert.ToDouble(amttxt.Text));//changed textbox name put tintxt instead amttxt
                cshtxt.Text = Convert.ToString(Convert.ToDouble(cshtxt.Text) + Convert.ToDouble(amttxt.Text));
                string sql = "Update Incoming set Income_ID='" + IDtxt.Text + "',Income_Type='" + cattxt.Text + "',C_Name='" + cnmtxt.Text + "',E_Name='"+enmcombo.Text+"',Income_Amount='" +tintxt.Text + "',Income_Detail='" + dettxt.Text + "',Cash_In_Hand='"+cshtxt.Text+"' where Income_Date='" + input + "' and C_Name='" + input1 + "' and Income_ID='" + input2 + "' and E_Name='"+input3+"'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfully....!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Question);
                chk = 0;
                cn1.Close();

                string sql2 = "Select * from Incoming where Income_Date='" + input + "' and C_Name='" + input1 + "' and Income_ID='" + input2 + "' and E_Name='"+input3+"'";
                cn1.Open();
                da = new SqlDataAdapter(sql2, cn1);
                ds = new DataSet();
                da.Fill(ds, "Incoming");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Incoming";
                cn1.Close();

                cattxt.Clear(); catcombo.Text = ""; cnmcombo.Text = ""; amttxt.Clear(); dettxt.Clear();
                tintxt.Text = "0"; textxt.Text = "0"; cshtxt.Text = "0";
                button1.Enabled = true;
            }
        }

        private void amttxt_Leave(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do U Want To Clear Expance Text", "Expance Text", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                textxt.Text = "0";
            }
            if(updt==0)
            tintxt.Text = "0";
            if (test != 1)
            {
                tintxt.Text = Convert.ToString(Convert.ToDouble(tintxt.Text) + Convert.ToDouble(amttxt.Text));
                cshtxt.Text = Convert.ToString(Convert.ToDouble(cshtxt.Text) + Convert.ToDouble(tintxt.Text));
                cshtxt.Text = Convert.ToString(Convert.ToDouble(cshtxt.Text) - Convert.ToDouble(textxt.Text));
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = (dataGridView1.Rows.Count + 1) * dataGridView1.RowTemplate.Height;
            bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
            RectangleF recPrint = e.PageSettings.PrintableArea;
            if (this.dataGridView1.Height - recPrint.Height > 0)
            {
                e.HasMorePages = true;
            }
        }

        private void amttxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(amttxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void enmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
