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
    public partial class Expire_Stock_Detail : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true"); 
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int i = 0, c = 0, eff = 0, ct = 0,b=0,chk=0,cc=0,bb=0;
        double pv = 0, bxv = 0, tbx = 0, tctn = 0, tv = 0, tbxs = 0, tc = 0, ttv = 0, prs = 0, bq = 0;
        string input = "", input1 = "";
        Bitmap bitmap;
        public Expire_Stock_Detail()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Expire_Stock_Detail_Load(object sender, EventArgs e)
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

        private void cnmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnmcombo.Items.Clear();
            pnmcombo.Text = "";
            string pn = "";
            pnmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            pnmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            string sql1 = "select Distinct(Product_Name) from Inventry_Stock where Company_Name='" + cnmcombo.Text + "'";
            da = new SqlDataAdapter(sql1, cn1);
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

            string sql2 = "select SUM(Value) from Expired_Stock where C_Name='" + cnmcombo.Text + "'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql2;
            totxt.Text =Convert.ToString(cmd.ExecuteScalar());
            cn1.Close();

            string sql3 = "Select * from Expired_Stock where C_Name='" +cnmcombo.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql3, cn1);
            ds = new DataSet();
            da.Fill(ds, "Expired_Stock");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Expired_Stock";
            cn1.Close();
        }

        private void pnmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql1 = "select * from Inventry_Stock where Product_Name='" +pnmcombo.Text + "'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql1;
           reader=cmd.ExecuteReader();
           while (reader.Read())
           {
               bxv =Convert.ToDouble(reader.GetValue(4));
               pv =Convert.ToDouble(reader.GetValue(9));
           }
            cn1.Close();
            string sql3 = "Select * from Expired_Stock where C_Name='" + cnmcombo.Text + "' and P_Name='"+pnmcombo.Text+"'";
            cn1.Open();
            da = new SqlDataAdapter(sql3, cn1);
            ds = new DataSet();
            da.Fill(ds, "Expired_Stock");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Expired_Stock";
            cn1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please Verify All the Data Before Submit", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql1 = "select * from Expired_Stock where P_Name='" +pnmcombo.Text + "'";
                da = new SqlDataAdapter(sql1, cn1);
                ds = new DataSet();
                eff = da.Fill(ds, "Expired_Stock");
                c = ds.Tables["Expired_Stock"].Rows.Count;
                if (eff == 0)
                {
                    tbx = (Convert.ToDouble(ctntxt.Text) * bxv) + Convert.ToDouble(bxtxt.Text);
                    tatxt.Text = Convert.ToString(tbx * pv);
                    string sql3 = "Insert Into Expired_Stock(C_Name,P_Name,Carton,Boxes,Value)Values('" + cnmcombo.Text.Trim() + "','" + pnmcombo.Text.Trim() + "','" + ctntxt.Text.Trim() + "','" + bxtxt.Text.Trim() + "','" + tatxt.Text.Trim() + "')";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql3;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Stock Added To Expire Stock.....!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn1.Close();
                    pnmcombo.Text = ""; ctntxt.Text = "0"; bxtxt.Text = "0"; tatxt.Text = "0";
                }
                else if (eff != 0)
                {
                    string sql5 = "Select * from Expired_Stock where P_Name='" + pnmcombo.Text + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql5;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tctn = Convert.ToDouble(ctntxt.Text) + Convert.ToDouble(reader.GetValue(2));
                        tc =Convert.ToDouble(ctntxt.Text) * bxv;
                        tbxs = Convert.ToDouble(bxtxt.Text) + Convert.ToDouble(reader.GetValue(3));
                        ttv = (Convert.ToDouble(bxtxt.Text)+tc) * pv;
                        tatxt.Text =Convert.ToString(ttv);
                        tv = Convert.ToDouble(tatxt.Text) + Convert.ToDouble(reader.GetValue(4));
                    }
                    cn1.Close();
                    
                    string sql14 = "update Expired_Stock set Carton='" +tctn + "',Boxes ='" +tbxs + "',Value='" +tv + "' where P_Name='" +pnmcombo.Text + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql14;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Stock Added To Expire Stock.....!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn1.Close();
                }               
            }
         }

        private void button4_Click(object sender, EventArgs e)
        {
            chk = 0;
            button1.Enabled = true;
            cnmcombo.Text = ""; pnmcombo.Text = ""; ctntxt.Text = "0"; bxtxt.Text = "0"; tatxt.Text = "0";
            totxt.Text = "0";
        }

        private void bxtxt_Leave(object sender, EventArgs e)
        {
            ct=Convert.ToInt32(bxtxt.Text) / Convert.ToInt32(bxv);
            bxtxt.Text = Convert.ToString(Convert.ToInt32(bxtxt.Text) % bxv);
            ctntxt.Text = Convert.ToString(Convert.ToInt32(ctntxt.Text) + ct);       
            

        }

        private void ctntxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(ctntxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void bxtxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(bxtxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void Expire_Stock_Detail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chk == 0)
            {
                button1.Enabled = false;
                input = Microsoft.VisualBasic.Interaction.InputBox("Enter Company Name", "Input Box", "", 500, 300);
                input1 = Microsoft.VisualBasic.Interaction.InputBox("Enter Product_Name Here", "Input Box", "", 500, 300);
                string sql1 = "select * from Expired_Stock where C_Name='" + input + "' and P_Name='" + input1 + "'";
                cn1.Open();
                cmd = new SqlCommand(sql1, cn1);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable table = new DataTable();
                eff = da.Fill(table);
                if (eff != 0)
                {
                   ctntxt.Text = table.Rows[b]["Carton"].ToString();
                  bxtxt.Text = table.Rows[b]["Boxes"].ToString();
                  tatxt.Text = table.Rows[b]["Value"].ToString();
                    chk = 1;
                    cn1.Close();

                    string sql2 = "Select * from Inventry_Stock where Company_Name='" + input + "' and Product_Name='" + input1 + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql2;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        bq = Convert.ToDouble(reader.GetValue(4));
                        prs = Convert.ToDouble(reader.GetValue(9));
                    }
                    cn1.Close();

                }
                else
                {
                    MessageBox.Show("Rrecord Not In Table");
                    cn1.Close();
                }
                cc = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Enter Carton Quantity You Want To Remove", "Input Box", "", 500, 300));
                bb = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Enter Box Quantity You Want To Remove", "Input Box", "", 500, 300));
       
            }
           else if (chk == 1)
            {
             ctntxt.Text=Convert.ToString(Convert.ToInt32(ctntxt.Text) - cc);
              bxtxt.Text =Convert.ToString(Convert.ToInt32(bxtxt.Text) - bb);
              bq=Convert.ToDouble(ctntxt.Text)* bq;
              bq = bq +Convert.ToDouble(bxtxt.Text);
              bq= bq*prs;
              if (bq == 0)
              { tatxt.Text = "0"; }
              else if(bq!=Convert.ToDouble(tatxt.Text))
              {
              tatxt.Text =Convert.ToString(Convert.ToDouble(tatxt.Text) -Convert.ToDouble(bq));
              }
              
                string sql = "Update Expired_Stock set Carton='" +ctntxt.Text + "',Boxes='" +bxtxt.Text + "',Value='" +tatxt.Text + "' where C_Name='" + input + "' and P_Name='" + input1 + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfully....!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Question);
                chk = 0;
                cn1.Close();

                string sql2 = "Select * from Expired_Stock where C_Name='" + input + "' and P_Name='" + input1 + "'";
                cn1.Open();
                da = new SqlDataAdapter(sql2, cn1);
                ds = new DataSet();
                da.Fill(ds, "Expired_Stock");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Expired_Stock";
                cn1.Close();
                cnmcombo.Text = ""; pnmcombo.Text = ""; ctntxt.Text = "0"; bxtxt.Text = "0"; tatxt.Text = "0";
                totxt.Text = "0";
                button1.Enabled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sql2 = "Select * from Expired_Stock where C_Name='" +cnmcombo.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "Expired_Stock");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Expired_Stock";
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
