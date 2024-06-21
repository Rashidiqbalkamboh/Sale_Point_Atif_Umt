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
    public partial class Expense_Sheet : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        AutoCompleteStringCollection col = new AutoCompleteStringCollection();
        int c = 0, i = 0, eff = 0, chk = 0, b = 0,chkk=0;
        double amt = 0;
        string input = "", input2 = "",input1="",input3="";
        public Expense_Sheet()
        {
            InitializeComponent();
        }
        private void Expense_Sheet_Load(object sender, EventArgs e)
        {
            /* string sql15 = "truncate table Expance_Record";
             cn1.Open();
             cmd.Connection = cn1;
             cmd.CommandText = sql15;
             cmd.ExecuteNonQuery();
             cn1.Close();*/
            string sql3 = "select * from Expance_Record";
            cn1.Open();
            da = new SqlDataAdapter(sql3, cn1);
            ds = new DataSet();
            da.Fill(ds, "Expance_Record");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Expance_Record";
            cn1.Close();
            cattxt.Enabled = false;
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

           string cl = "";
          catcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
         catcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           AutoCompleteStringCollection col = new AutoCompleteStringCollection();
           string sql = "select Distinct(Expance_Type) from Expance_Record";
           cn1.Open();
           da = new SqlDataAdapter(sql, cn1);
           ds = new DataSet();
           da.Fill(ds, "Expance_Record");
           c = ds.Tables["Expance_Record"].Rows.Count;
           for (i = 0; i <= c - 1; i++)
           {
              catcombo.Items.Add(ds.Tables["Expance_Record"].Rows[i]["Expance_Type"]);
               cl = ds.Tables["Expance_Record"].Rows[i]["Expance_Type"].ToString();
               col.Add(cl);
           }
           cn1.Close();
          catcombo.AutoCompleteCustomSource = col;
        }

        private void Expense_Sheet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
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
              cattxt.Text =catcombo.Text;
              string sql = "select * from Expance_Record where Expance_Type='" + cattxt.Text + "'";
              cn1.Open();
              cmd.Connection = cn1;
              cmd.CommandText=sql;
              reader=cmd.ExecuteReader();
              while (reader.Read())
              {
                  IDtxt.Text = reader.GetValue(1).ToString();
                  chkk = 1;
              }
              cn1.Close();
              
              string sql3 = "select * from Expance_Record where Expance_Type='"+cattxt.Text+"'";
              cn1.Open();
              da = new SqlDataAdapter(sql3, cn1);
              ds = new DataSet();
              da.Fill(ds, "Expance_Record");
              dataGridView1.DataSource = ds;
              dataGridView1.DataMember = "Expance_Record";
              cn1.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please Verify All the Data Before Submit", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cattxt.Text == "" || cnmcombo.Text == "" || amttxt.Text == "")
                    MessageBox.Show("Fill All The Textboxes");
                else
                {
                    string sql2 = "Insert Into Expance_Record(Expance_Date,Expance_ID,Expance_Type,Company_Name,Expance_Amount,Expance_Detail)Values('" + dateTimePicker2.Value + "','" + IDtxt.Text.Trim() + "','" + cattxt.Text.Trim() + "','" + cnmtxt.Text.Trim() + "','" + amttxt.Text.Trim() + "','" + dettxt.Text.Trim() + "')";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql2;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Stored Successfully...!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn1.Close();
                    IDtxt.Clear(); cnmtxt.Clear(); pamttxt.Clear();
                    cattxt.Clear(); catcombo.Text = ""; cnmcombo.Text = ""; amttxt.Clear(); dettxt.Clear();

                    catcombo.Items.Clear();

                    string cl = "";
                    catcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    catcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                    string sql = "select Distinct(Expance_Type) from Expance_Record";
                    cn1.Open();
                    da = new SqlDataAdapter(sql, cn1);
                    ds = new DataSet();
                    da.Fill(ds, "Expance_Record");
                    c = ds.Tables["Expance_Record"].Rows.Count;
                    for (i = 0; i <= c - 1; i++)
                    {
                        catcombo.Items.Add(ds.Tables["Expance_Record"].Rows[i]["Expance_Type"]);
                        cl = ds.Tables["Expance_Record"].Rows[i]["Expance_Type"].ToString();
                        col.Add(cl);
                    }
                    cn1.Close();
                    catcombo.AutoCompleteCustomSource = col;
                    catcombo.Items.Add("New");

                    string sql3 = "select * from Expance_Record";
                    cn1.Open();
                    da = new SqlDataAdapter(sql3, cn1);
                    ds = new DataSet();
                    da.Fill(ds, "Expance_Record");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Expance_Record";
                    cn1.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chk = 0; button1.Enabled = true;
            cattxt.Clear(); catcombo.Text = ""; cnmcombo.Text = ""; amttxt.Clear(); dettxt.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Bitmap bitmap;
        private void button6_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
                MessageBox.Show("From Date Always Less Then To Date", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (cnmcombo.Text != "")
            {    //Expance_ID='" + IDtxt.Text + "' and
                string sql3 = "select * from Expance_Record where  Company_Name='" + cnmcombo.Text + "' and Expance_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";//";
                cn1.Open();
                da = new SqlDataAdapter(sql3, cn1);
                ds = new DataSet();
                da.Fill(ds, "Expance_Record");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Expance_Record";
                cn1.Close();

                int height = dataGridView1.Height;
                dataGridView1.Height = (dataGridView1.Rows.Count + 1) * dataGridView1.RowTemplate.Height;
                bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                dataGridView1.Height = height;
            }
            else 
            {
                MessageBox.Show("Please Select Compnay_Name Firast");
            }

        }

        private void IDtxt_Leave(object sender, EventArgs e)
        {
            string sql1 = "select * from Expance_Record where Expance_ID='" + IDtxt.Text + "'";
            da = new SqlDataAdapter(sql1, cn1);
            ds = new DataSet();
            da.Fill(ds, "Expance_Record");
            c = ds.Tables["Expance_Record"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                cattxt.Text = ds.Tables["Expance_Record"].Rows[i]["Expance_Type"].ToString();
                catcombo.Text = ds.Tables["Expance_Record"].Rows[i]["Expance_Type"].ToString();
            }
            cn1.Close();

            string sql3 = "select * from Expance_Record where Expance_ID='" + IDtxt.Text + "' and Company_Name='" + cnmcombo.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql3, cn1);
            ds = new DataSet();
            da.Fill(ds, "Expance_Record");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Expance_Record";
            cn1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chk == 0)
            {
                button1.Enabled = false;
                input = Microsoft.VisualBasic.Interaction.InputBox("Enter Date Here LIKE MM/DD/YYYY", "Input Box", "", 500, 300);
                input2 = Microsoft.VisualBasic.Interaction.InputBox("Enter Expance_ID Here", "Input Box", "", 500, 300);
                input1 = Microsoft.VisualBasic.Interaction.InputBox("Enter Company_Name Here", "Input Box", "", 500, 300);
                input3 = Microsoft.VisualBasic.Interaction.InputBox("Enter Description Here", "Input Box", "", 500, 300);
                string sql1 = "select * from Expance_Record where Expance_Date='" + input + "' and Company_Name='"+input1+"'  and Expance_ID='" + input2 + "' and Expance_Detail='"+input3+"'";
                cn1.Open();
                cmd = new SqlCommand(sql1, cn1);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable table = new DataTable();
                eff = da.Fill(table);
                if (eff != 0)
                {
                   IDtxt.Text = table.Rows[b]["Expance_ID"].ToString();
                  cattxt.Text = table.Rows[b]["Expance_Type"].ToString();
                 cnmtxt.Text = table.Rows[b]["Company_Name"].ToString();
                  amttxt.Text = table.Rows[b]["Expance_Amount"].ToString();
                    dettxt.Text = table.Rows[b]["Expance_Detail"].ToString();
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

                string sql = "Update Expance_Record set Expance_ID='" +IDtxt.Text + "',Expance_Type='" +cattxt.Text + "',Company_Name='" +cnmtxt.Text + "',Expance_Amount='" +amttxt.Text + "',Expance_Detail='" +dettxt.Text + "' where Expance_Date='" + input + "' and Company_Name='"+input1+"' and Expance_ID='" + input2 + "' and Expance_Detail='"+input3+"'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfully....!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Question);
                chk = 0;
                cn1.Close();

                string sql2 = "Select * from Expance_Record where Expance_Date='" + input + "' and Company_Name='"+input1+"' and Expance_ID='" + input2 + "'";
                cn1.Open();
                da = new SqlDataAdapter(sql2, cn1);
                ds = new DataSet();
                da.Fill(ds, "Expance_Record");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Expance_Record";
                cn1.Close();

                cattxt.Clear(); catcombo.Text = ""; cnmcombo.Text = ""; amttxt.Clear(); dettxt.Clear();
                button1.Enabled = true;
            }

        }

        private void cnmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            pamttxt.Text = "0";
            cnmtxt.Text = cnmcombo.Text;
             string sql1 = "select * from Expance_Record where Company_Name='" + cnmcombo.Text + "' and Expance_ID='"+IDtxt.Text+"'";
                da = new SqlDataAdapter(sql1, cn1);
                ds = new DataSet();
                eff = da.Fill(ds, "Expance_Record");
                c = ds.Tables["Expance_Record"].Rows.Count;
                for (i = 0; i <= c - 1; i++)
                    {
                    pamttxt.Text=Convert.ToString(Convert.ToDouble(pamttxt.Text)+Convert.ToDouble(ds.Tables["Expance_Record"].Rows[i]["Expance_Amount"]));
                    }
                   cn1.Close();

                   string sql3 = "select * from Expance_Record where Company_Name='" +cnmcombo.Text + "'";// and Expance_ID='"+IDtxt.Text+"'";
                   cn1.Open();
                   da = new SqlDataAdapter(sql3, cn1);
                   ds = new DataSet();
                   da.Fill(ds, "Expance_Record");
                   dataGridView1.DataSource = ds;
                   dataGridView1.DataMember = "Expance_Record";
                   cn1.Close();
          
        }

        private void cnmcombo_Enter(object sender, EventArgs e)
        {
            if (IDtxt.TextLength == 0)
            {
                MessageBox.Show("Please Select ID First");
               // IDtxt.Focus();
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

        private void IDtxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(IDtxt, true, true, true, true);

                }
                e.Handled = true;
            }
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
    }
}
