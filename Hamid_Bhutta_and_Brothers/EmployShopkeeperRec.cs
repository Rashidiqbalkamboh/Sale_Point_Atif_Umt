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
    public partial class EmployShopkeeperRec : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int cnt = 0, c = 0, chk = 0, eff = 0, b = 0, i = 0;
        string input = "", input2 = "", dat = "", SuggestString = "";
        Bitmap bitmap;

        public EmployShopkeeperRec()
        {
            InitializeComponent();
        }

        private void EmployShopkeeperRec_Load(object sender, EventArgs e)
        {


            areatxt.Enabled = false;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            string cn = "";
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col3 = new AutoCompleteStringCollection();
            string sql3 = "select Distinct(Area_Name) from ShopKeeperRecord";
            da = new SqlDataAdapter(sql3, cn1);
            DataSet ds = new DataSet();
            da.Fill(ds, "ShopKeeperRecord");
            c = ds.Tables["ShopKeeperRecord"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                comboBox1.Items.Add(ds.Tables["ShopKeeperRecord"].Rows[i]["Area_Name"]);
                cn = ds.Tables["ShopKeeperRecord"].Rows[i]["Area_Name"].ToString();
                col3.Add(cn);
            }
            cn1.Close();
            comboBox1.AutoCompleteCustomSource = col3;
            comboBox1.Items.Add("New");

            string sn = "";
            snmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            snmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
            string sql2 = "select ShopKeeper_Name from ShopKeeperRecord";
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "ShopKeeperRecord");
            c = ds.Tables["ShopKeeperRecord"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                snmcombo.Items.Add(ds.Tables["ShopKeeperRecord"].Rows[i]["ShopKeeper_Name"]);
                sn = ds.Tables["ShopKeeperRecord"].Rows[i]["ShopKeeper_Name"].ToString();
                col1.Add(sn);
            }
            cn1.Close();
            snmcombo.AutoCompleteCustomSource = col1;


            //Yahan Hamid ny snmtxt ko autocomplete kia h ta k naya add krty hue overlapping na ho




            /*  string sm;
              snmtxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
              snmtxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
              AutoCompleteStringCollection coll = new AutoCompleteStringCollection(); 
              string sql6 = "select ShopKeeper_Name from ShopKeeperRecord";
              da = new SqlDataAdapter(sql6, cn1);
              ds = new DataSet();
              da.Fill(ds, "ShopKeeperRecord");
              c = ds.Tables["ShopKeeperRecord"].Rows.Count;
              for (i = 0; i <= c - 1; i++)
              {
                  //snmtxt.Items.Add(ds.Tables["ShopKeeperRecord"].Rows[i]["ShopKeeper_Name"]);
                  coll.Add(ds.Tables["ShopkeeperRecord"].Rows[i]["Shopkeeper_Name"].ToString());
                  sm = ds.Tables["ShopKeeperRecord"].Rows[i]["ShopKeeper_Name"].ToString();
                  coll.Add(sm);
              }
              cn1.Close();
              snmtxt.AutoCompleteCustomSource = coll;*/





            string sql4 = "select count(ID) from ShopKeeperRecord";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql4;
            cnt = Convert.ToInt32(cmd.ExecuteScalar());
            IDtxt.Text = Convert.ToString(cnt + 1);
            cn1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please Verify All the Data Before Submit", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (areatxt.Text == "" || blktxt.Text == "" || snmtxt.Text == "" || saddtxt.Text == "" || phtxt.Text == "")
                    MessageBox.Show("FILL All THE TEXTBOXES");
                else
                {
                    string sql = "Insert Into ShopKeeperRecord(Area_Name,Area_Blocks,ShopKeeper_Name,ID,Address,Contact_No)Values('" + areatxt.Text.Trim() + "','" + blktxt.Text.Trim() + "','" + snmtxt.Text.Trim() + "','" + IDtxt.Text + "','" + saddtxt.Text.Trim() + "','" + phtxt.Text.Trim() + "')";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data stored", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn1.Close();

                    /* string sql2 = "Insert Into Khata_Record(SK_ID,SK_Name,SK_Address)Values('" + IDtxt.Text.Trim() + "','" + snmtxt.Text.Trim() + "','" + saddtxt.Text.Trim() + "')";
                     cn1.Open();
                     cmd.Connection = cn1;
                     cmd.CommandText = sql2;
                     cmd.ExecuteNonQuery();
                     cn1.Close();*/

                    comboBox1.Items.Clear();

                    string sql4 = "select Distinct(Area_Name) from ShopKeeperRecord";
                    cn1.Open();
                    da = new SqlDataAdapter(sql4, cn1);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "ShopKeeperRecord");
                    c = ds.Tables["ShopKeeperRecord"].Rows.Count;
                    for (i = 0; i <= c - 1; i++)
                    {
                        comboBox1.Items.Add(ds.Tables["ShopKeeperRecord"].Rows[i]["Area_Name"]);
                    }
                    cn1.Close();
                    comboBox1.Items.Add("New");

                    comboBox2.Items.Clear();

                    string sql5 = "select Distinct(Area_Blocks) from ShopKeeperRecord";
                    cn1.Open();
                    da = new SqlDataAdapter(sql5, cn1);
                    ds = new DataSet();
                    da.Fill(ds, "ShopKeeperRecord");
                    c = ds.Tables["ShopKeeperRecord"].Rows.Count;
                    for (i = 0; i <= c - 1; i++)
                    {
                        comboBox2.Items.Add(ds.Tables["ShopKeeperRecord"].Rows[i]["Area_Blocks"]);
                    }
                    cn1.Close();
                    comboBox2.Items.Add("New");

                    string sql1 = "select * from ShopKeeperRecord";
                    cn1.Open();
                    da = new SqlDataAdapter(sql1, cn1);
                    ds = new DataSet();
                    da.Fill(ds, "ShopKeeperRecord");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "ShopKeeperRecord";
                    cn1.Close();


                    string sql3 = "select count(ID) from ShopKeeperRecord";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql3;
                    cnt = Convert.ToInt32(cmd.ExecuteScalar());
                    IDtxt.Text = Convert.ToString(cnt + 1);
                    cn1.Close();

                    comboBox1.Text = ""; comboBox2.Text = ""; areatxt.Clear();
                    blktxt.Clear(); snmtxt.Clear(); saddtxt.Clear();
                    phtxt.Clear(); snmcombo.Text = "";
                }
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {  //YAHAN HAMID NY CODE ADD KIA HAI TA K HAMY AREA SELECT KRNY K BAD OS AREA M MOJOD SHOPKEEPERS KI LIST DATA GRID M MIL SKY
            /* string sql2 = "Select * from ShopKeeperRecord where Area_Name '" + areatxt.Text + "''";
             cn1.Open();
             da = new SqlDataAdapter(sql2, cn1);
             ds = new DataSet();
             da.Fill(ds, "ShopKeeperRecord") ;
             dataGridView1.DataSource = ds;
             dataGridView1.DataMember = "ShopKeeperRecord";
             cn1.Close();

             int height = dataGridView1.Height;
             dataGridView1.Height = (dataGridView1.Rows.Count + 1) * dataGridView1.RowTemplate.Height;
             bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
             dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
             printPreviewDialog1.Document = printDocument1;
             printPreviewDialog1.PrintPreviewControl.Zoom = 1;
             printPreviewDialog1.ShowDialog();
             dataGridView1.Height = height;*/

            string sql3 = "select count(ID) from ShopKeeperRecord";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql3;
            cnt = Convert.ToInt32(cmd.ExecuteScalar());
            IDtxt.Text = Convert.ToString(cnt + 1);
            cn1.Close();

            if (comboBox1.SelectedItem == "New")
            {
                snmcombo.Text = ""; snmtxt.Text = ""; saddtxt.Text = ""; phtxt.Text = "";
                areatxt.Enabled = true;
                areatxt.Clear();
                blktxt.Enabled = true;
                comboBox2.Items.Clear();
                comboBox2.Items.Add("New");
            }
            else
            {
                snmcombo.Text = ""; snmtxt.Text = ""; saddtxt.Text = ""; phtxt.Text = "";
                comboBox2.Items.Clear();
                areatxt.Enabled = false;
                areatxt.Text = comboBox1.Text;
                string ab = "";
                comboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
                comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                string sql = "select Distinct(Area_Blocks) from ShopKeeperRecord where Area_Name='" + areatxt.Text + "'";
                // cn1.Open();
                da = new SqlDataAdapter(sql, cn1);
                ds = new DataSet();
                da.Fill(ds, "ShopKeeperRecord");
                c = ds.Tables["ShopKeeperRecord"].Rows.Count;
                for (i = 0; i <= c - 1; i++)
                {
                    comboBox2.Items.Add(ds.Tables["ShopKeeperRecord"].Rows[i]["Area_Blocks"]);
                    ab = ds.Tables["ShopKeeperRecord"].Rows[i]["Area_Blocks"].ToString();
                    col.Add(ab);
                }
                cn1.Close();
                comboBox2.AutoCompleteCustomSource = col;
                comboBox2.Items.Add("New");
            }

            //YAHAN HAMID NY CODE ADD KIA HAI TA K HAMY AREA SELECT KRNY K BAD OS AREA M MOJOD SHOPKEEPERS KI LIST DATA GRID M MIL SKY
            string sql2 = "Select * from ShopKeeperRecord where Area_Name= '" + areatxt.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "ShopKeeperRecord");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "ShopKeeperRecord";
            cn1.Close();

            int height = dataGridView1.Height;
            dataGridView1.Height = (dataGridView1.Rows.Count + 1) * dataGridView1.RowTemplate.Height;
            bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

            dataGridView1.Height = height;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "New")
            {
                blktxt.Enabled = true;
                blktxt.Clear();
            }
            else
            {
                blktxt.Enabled = false;
                blktxt.Text = comboBox2.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chk = 0;
            button1.Enabled = true; button2.Enabled = true; button3.Enabled = true;
            comboBox1.Text = ""; comboBox2.Text = ""; areatxt.Clear();
            blktxt.Clear(); snmtxt.Clear(); saddtxt.Clear();
            phtxt.Clear();
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
                button3.Enabled = false;
                input = Microsoft.VisualBasic.Interaction.InputBox("Enter ShopKeeperID Here", "Input Box", "", 500, 300);
                string sql1 = "select * from ShopKeeperRecord where ID='" + input + "'";
                cmd = new SqlCommand(sql1, cn1);
                cn1.Open();
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable table = new DataTable();
                eff = da.Fill(table);
                if (eff != 0)
                {
                    areatxt.Text = table.Rows[b]["Area_Name"].ToString().TrimStart();
                    blktxt.Text = table.Rows[b]["Area_Blocks"].ToString().TrimStart();
                    snmtxt.Text = table.Rows[b]["ShopKeeper_Name"].ToString().TrimStart();
                    saddtxt.Text = table.Rows[b]["Address"].ToString().TrimStart();
                    phtxt.Text = table.Rows[b]["Contact_No"].ToString().TrimStart();
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

                string sql = "Update ShopkeeperRecord set Area_Name='" + areatxt.Text + "',Area_Blocks='" + blktxt.Text + "',ShopKeeper_Name='" + snmtxt.Text + "',Address='" + saddtxt.Text + "',Contact_No='" + phtxt.Text + "' where ID='" + input + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Successfully....!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Question);
                chk = 0;
                cn1.Close();

                comboBox1.Text = ""; comboBox2.Text = ""; areatxt.Clear();
                blktxt.Clear(); snmtxt.Clear(); saddtxt.Clear();
                phtxt.Clear();

                string sql2 = "Select * from ShopKeeperRecord";
                cn1.Open();
                da = new SqlDataAdapter(sql2, cn1);
                ds = new DataSet();
                da.Fill(ds, "ShopKeeperRecord");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "ShopKeeperRecord";
                cn1.Close();

                button1.Enabled = true;
                button3.Enabled = true; chk = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chk == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                input = Microsoft.VisualBasic.Interaction.InputBox("Enter ShopKeeperID Here", "Input Box", "", 500, 300);
                string sql1 = "select * from ShopKeeperRecord where ID='" + input + "'";
                cmd = new SqlCommand(sql1, cn1);
                cn1.Open();
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable table = new DataTable();
                eff = da.Fill(table);
                if (eff != 0)
                {
                    areatxt.Text = table.Rows[b]["Area_Name"].ToString().TrimStart();
                    blktxt.Text = table.Rows[b]["Area_Blocks"].ToString().TrimStart();
                    snmtxt.Text = table.Rows[b]["ShopKeeper_Name"].ToString().TrimStart();
                    saddtxt.Text = table.Rows[b]["Address"].ToString().TrimStart();
                    phtxt.Text = table.Rows[b]["Contact_No"].ToString().TrimStart();
                    chk = 1;
                    cn1.Close();
                    if (areatxt.Text == "")
                        MessageBox.Show("Rrecord Not In Table");
                }
                else
                {

                    MessageBox.Show("Rrecord Not In Table");
                    cn1.Close();
                }

            }

            else if (chk == 1)
            {
                comboBox1.Text = ""; comboBox2.Text = ""; areatxt.Clear();
                blktxt.Clear(); snmtxt.Clear(); saddtxt.Clear();
                phtxt.Clear();
                string sql = "Update ShopkeeperRecord set Area_Name='" + areatxt.Text + "',Area_Blocks='" + blktxt.Text + "',ShopKeeper_Name='" + snmtxt.Text + "',Address='" + saddtxt.Text + "',Contact_No='" + phtxt.Text + "' where ID='" + input + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully....!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Question);
                chk = 0;
                cn1.Close();

                string sql2 = "Select * from ShopKeeperRecord";
                cn1.Open();
                da = new SqlDataAdapter(sql2, cn1);
                ds = new DataSet();
                da.Fill(ds, "ShopKeeperRecord");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "ShopKeeperRecord";
                cn1.Close();
                button1.Enabled = true;
                button2.Enabled = true; chk = 0;
            }
        }

        private void areatxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(areatxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void blktxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(blktxt, true, true, true, true);

                }
                e.Handled = true;
            }

        }

        private void snmtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* if (Char.IsDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar))
             {
                 e.Handled = true;
                 MessageBox.Show("Please Enter Digit Only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             else if (Char.IsLetter(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
                 e.Handled = false;*/
            if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(snmtxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void saddtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(saddtxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void phtxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(phtxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void EmployShopkeeperRec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please Select Area First");
                comboBox1.Focus();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sql2 = "Select * from ShopKeeperRecord where ID between '" + textBox1.Text + "' and '" + textBox2.Text + "'";// where C_Name='" + cnmcombo.Text + "' and P_Name='" + pnmcombo.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "ShopKeeperRecord");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "ShopKeeperRecord";
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

        private void IDtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void snmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql2 = "select * from ShopKeeperRecord where Shopkeeper_Name='" + snmcombo.Text + "'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql2;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                snmtxt.Text = reader.GetValue(2).ToString();
                IDtxt.Text = reader.GetValue(3).ToString();
                saddtxt.Text = reader.GetValue(4).ToString();
                phtxt.Text = reader.GetValue(5).ToString();
                areatxt.Text = reader.GetValue(0).ToString();

            }
            cn1.Close();


        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {

        }

        void Autocomplete()
        {

        }

        private void snmtxt_TextChanged(object sender, EventArgs e)
        {


            /*   snmtxt.AutoCompleteMode = AutoCompleteMode.Suggest;
               snmtxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
               AutoCompleteStringCollection col = new AutoCompleteStringCollection();
               TextBox t = sender as TextBox;
               if (t != null)
               {
                   //say you want to do a search when user types 3 or more chars
                   if (t.Text.Length >= 1)
                   {
                       //SuggestStrings will have the logic to return array of strings either from cache/db
                       string[] arr = SuggestStrings(t.Text);

                       AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                       collection.AddRange(arr);

                       this.snmtxt.AutoCompleteCustomSource = collection;
                   }

               }
           }

           private string[] SuggestStrings(string p)
           {
               throw new NotImplementedException();
           }
   */
        }
        public string sql8 { get; set; }
    }
}