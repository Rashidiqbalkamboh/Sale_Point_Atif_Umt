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
    public partial class Add_Stock : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true"); 
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        AutoCompleteStringCollection col = new AutoCompleteStringCollection();
        int p=0, c = 0, chk = 0, eff = 0, eff1 = 0, b = 0, i = 0;
        Double tb = 0, tspp, cvsp, tssp, tcsp = 0,bvqty=0,sssp=0,spp=0,cqty=0,carton=0 , onlybox=0;
        string input = "", input1 = "", input2 = "";
        string pnm = "", pn = "";
        double spa = 0, cb = 0, ctn = 0, crtn = 0, bvq = 0, cq1 = 0, cq2 = 0, ssp = 0, bxq = 0,csp = 0, cpp = 0;
        public Add_Stock()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chk = 0;
            button1.Enabled = true; button2.Enabled = true; button3.Enabled = true;
            comboBox1.Text = ""; pnmtxt.Clear(); cnmtxt.Clear();
            comboBox2.Text = ""; cqtxt.Clear(); boxtxt.Clear();
            pptxt.Clear(); Bqtytxt.Clear(); tpptxt.Clear();
        }

        private void Add_Stock_Load(object sender, EventArgs e)
        {
            string sql13 = "select * from Inventry_Stock";
            da = new SqlDataAdapter(sql13, cn1);
            DataSet ds1 = new DataSet();
            da.Fill(ds1, "Inventry_Stock");
            c = ds1.Tables["Inventry_Stock"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                pnm = ds1.Tables["Inventry_Stock"].Rows[i]["Product_Name"].ToString();
                ctn = Convert.ToDouble(ds1.Tables["Inventry_Stock"].Rows[i]["BVQ"]) / Convert.ToDouble(ds1.Tables["Inventry_Stock"].Rows[i]["Boxes"]);
                cn1.Close();
                string sql14 = "Update Inventry_Stock set Carton='" + ctn + "' where Product_Name='" + pnm + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql14;
                cmd.ExecuteNonQuery();
            }
            cn1.Close();
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
            for (i = 0; i <= c - 1; i++)
            {
                comboBox1.Items.Add(ds.Tables["Inventry_Stock"].Rows[i]["Company_Name"]);
                cn = ds.Tables["Inventry_Stock"].Rows[i]["Company_Name"].ToString();
                col1.Add(cn);
            }
            cn1.Close();
            comboBox1.AutoCompleteCustomSource = col1;

            string sql1 = "select count(Order_Number) from Purchase_Detail";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql1;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ordtxt.Text = reader.GetValue(0).ToString();
            }
            cn1.Close();
            ordtxt.Text = Convert.ToString(Convert.ToDouble(ordtxt.Text) + 1);

            string sql = "select * from Purchase_Detail";
            cn1.Open();
            da = new SqlDataAdapter(sql, cn1);
            ds = new DataSet();
            da.Fill(ds, "Purchase_Detail");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Purchase_Detail";
            cn1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string pn = "";
            comboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            cnmtxt.Text = comboBox1.Text;            
            string sql2 = "select Product_Name from Inventry_Stock where Company_Name='" +cnmtxt.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "Inventry_Stock");
            c = ds.Tables["Inventry_Stock"].Rows.Count;
           for (i = 0; i <= c - 1; i++)
            {
              comboBox2.Items.Add(ds.Tables["Inventry_Stock"].Rows[i]["Product_Name"]);
              pn = ds.Tables["Inventry_Stock"].Rows[i]["Product_Name"].ToString();
              col.Add(pn);
            }
            cn1.Close();
            comboBox2.AutoCompleteCustomSource = col;

        }

         private void cqtxt_Leave(object sender, EventArgs e)
        {
            if (cqtxt.TextLength == 0)
            {
               cqtxt.Text="0";
            }
            else
            {
                Bqtytxt.Text = Convert.ToString(Convert.ToDouble(boxtxt.Text) * Convert.ToDouble(cqtxt.Text));
                tpptxt.Text = Convert.ToString(Convert.ToDouble(pptxt.Text) * Convert.ToDouble(cqtxt.Text));
            }

        }
               
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please Verify All the Data Before Submit", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                onlybox = Convert.ToDouble(obxtxt.Text);
                carton =Convert.ToDouble( cqtxt.Text);
                c = 0; i = 0;
                if (comboBox1.Text == "" || comboBox2.Text == "" || cqtxt.Text == "" || dp1.Value >= dp2.Value)
                    MessageBox.Show("All the Textboxes Must Be Filled OR Fix Order_Date", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if(carton > 0 )
                {
                    cn1.Open();
                    string sql3 = "select * from Inventry_Stock where Product_Name='" + pnmtxt.Text + "'";
                    da = new SqlDataAdapter(sql3, cn1);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Inventry_Stock");
                    c = ds.Tables["Inventry_Stock"].Rows.Count;
                    for (i = 0; i <= c - 1; i++)
                    {
                        crtn = Convert.ToDouble(ds.Tables["Inventry_Stock"].Rows[i]["Carton"]);
                        bvq = Convert.ToDouble(ds.Tables["Inventry_Stock"].Rows[i]["BVQ"]);
                        cvsp = Convert.ToDouble(ds.Tables["Inventry_Stock"].Rows[i]["Carton_Sale_Price"]);
                        tspp = Convert.ToDouble(ds.Tables["Inventry_Stock"].Rows[i]["Total_Stock_PP"]);
                        tssp = Convert.ToDouble(ds.Tables["Inventry_Stock"].Rows[i]["Total_Stock_SP"]);

                        crtn = crtn + Convert.ToDouble(cqtxt.Text);
                        MessageBox.Show("crtn value is=" + crtn);
                        bvq = bvq + Convert.ToDouble(Bqtytxt.Text);
                        tspp = tspp + Convert.ToDouble(tpptxt.Text);
                        cvsp = cvsp * Convert.ToDouble(cqtxt.Text);
                        tssp = tssp + cvsp;
                        string sql14 = "update Inventry_Stock set Date='" + dp2.Value + "',Carton ='" + crtn + "',BVQ='" + bvq + "',Total_Stock_PP='" + tspp + "',Total_Stock_SP='" + tssp + "' where Product_Name='" + pnmtxt.Text + "'";
                        cmd.Connection = cn1;
                        cmd.CommandText = sql14;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Stock Added Successfully.....!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cn1.Close();
                        tspurtxt.Text = Convert.ToString(Convert.ToDouble(tspurtxt.Text) + Convert.ToDouble(tpptxt.Text));

                        string sql = "select * from Inventry_Stock where Product_Name='" + pnmtxt.Text + "'";
                        cn1.Open();
                        da = new SqlDataAdapter(sql, cn1);
                        ds = new DataSet();
                        da.Fill(ds, "Inventry_Stock");
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "Inventry_Stock";
                        cn1.Close();

                        string sql2 = "Insert Into Purchase_Detail(Order_Number,Order_Date,Purchase_Date,Company_Name,Product_Name,Carton_Quantity,Box_Quantity,Total_Box,CPP,TCPP)Values('" + ordtxt.Text.Trim() + "','" + dp1.Value + "','" + dp2.Value + "','" + comboBox1.Text.Trim() + "','" + pnmtxt.Text.Trim() + "','" + cqtxt.Text + "','" + boxtxt.Text + "','" + Bqtytxt.Text + "','" + pptxt.Text + "','" + tpptxt.Text + "')";
                        cn1.Open();
                        cmd.Connection = cn1;
                        cmd.CommandText = sql2;
                        cmd.ExecuteNonQuery();
                        cn1.Close();

                        string sql11 = "select Order_Number from Purchase_Detail";
                        cn1.Open();
                        cmd.Connection = cn1;
                        cmd.CommandText = sql11;
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                            ordtxt.Text = reader.GetValue(0).ToString();
                        cn1.Close();

                        pnmtxt.Clear();
                        comboBox2.Text = ""; cqtxt.Clear(); boxtxt.Clear();
                        pptxt.Clear(); Bqtytxt.Clear();
                        break;
                    }
                    
                }
                else if (onlybox > 0)
                {
                    //Ye Code Hamid Ny LAGAYA HAI TA K JB SIRF BOXES ADD KRNA HON TO WO POSSIBLE HO SKY PEHLY JUST CTN HTY THY
                    string sql1 = "select * from Inventry_Stock where Company_Name='" + cnmtxt.Text + "' and Product_Name='" + comboBox2.Text + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql1;
                    reader = cmd.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        bvqty = Convert.ToDouble(obxtxt.Text) + Convert.ToDouble(reader.GetValue(5));
                        cqty = bvqty / Convert.ToDouble(reader.GetValue(4));
                        spp = bvqty * Convert.ToDouble(reader.GetValue(9));

                        sssp = Convert.ToDouble(reader.GetValue(8)) * bvqty;
                        cn1.Close();
                        string sql2 = "Update Inventry_Stock set Carton='" + cqty + "',BVQ='" + bvqty + "',Total_Stock_PP='" + spp + "',Total_Stock_SP='" + sssp + "' where Company_Name='" + cnmtxt.Text + "' and Product_Name='" + comboBox2.Text + "'";
                        cn1.Open();
                        cmd.Connection = cn1;
                        cmd.CommandText = sql2;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Only Boxes Added Successfully.....!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cn1.Close();
                        obxtxt.Text = "0"; comboBox2.Text = ""; 
                       string sql = "select * from Inventry_Stock where Product_Name='" + pnmtxt.Text + "'";
                        cn1.Open();
                        da = new SqlDataAdapter(sql, cn1);
                        ds = new DataSet();
                        da.Fill(ds, "Inventry_Stock");
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "Inventry_Stock";
                        
                       

                    }
                    cn1.Close();
                }
            }

            string sql13 = "select * from Inventry_Stock";
            da = new SqlDataAdapter(sql13, cn1);
            DataSet ds1 = new DataSet();
            da.Fill(ds1, "Inventry_Stock");
            c = ds1.Tables["Inventry_Stock"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                pnm = ds1.Tables["Inventry_Stock"].Rows[i]["Product_Name"].ToString();
                ctn = Convert.ToDouble(ds1.Tables["Inventry_Stock"].Rows[i]["BVQ"]) / Convert.ToDouble(ds1.Tables["Inventry_Stock"].Rows[i]["Boxes"]);
                cn1.Close();
                string sql14 = "Update Inventry_Stock set Carton='" + ctn + "' where Product_Name='" + pnm + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql14;
                cmd.ExecuteNonQuery();
            }
            cn1.Close();
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("First Select Company Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Focus();
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
                button3.Enabled = false;
                input = Microsoft.VisualBasic.Interaction.InputBox("Enter Purchase_Date Here", "Input Box", "", 500, 300);
                input1 = Microsoft.VisualBasic.Interaction.InputBox("Enter Company Name Here", "Input Box", "", 500, 300);
                input2 = Microsoft.VisualBasic.Interaction.InputBox("Enter Product Name Here", "Input Box", "", 500, 300);
                string sql1 = "select * from Purchase_Detail where Purchase_Date='" + input + "' and Company_Name='" + input1 + "' and Product_Name='" + input2 + "'";
                cn1.Open();
                cmd = new SqlCommand(sql1, cn1);                
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable table = new DataTable();
                eff = da.Fill(table);
                if (eff != 0)
                {
                  cnmtxt.Text = table.Rows[b]["Company_Name"].ToString().TrimStart();
                  pnmtxt.Text = table.Rows[b]["Product_Name"].ToString();
                    cq1 = Convert.ToDouble(table.Rows[b]["Carton_Quantity"]);
                    cqtxt.Text =Convert.ToString(cq1);
                    tb = Convert.ToDouble(table.Rows[b]["Total_Box"]);
                    Bqtytxt.Text =Convert.ToString(tb);
                    boxtxt.Text = table.Rows[b]["Box_Quantity"].ToString();
                   pptxt.Text = table.Rows[b]["CPP"].ToString();
                    chk = 1;
                    cn1.Close();
                    
                }
                else
                {
                    MessageBox.Show("Rrecord Not In Table");
                    cn1.Close();
                }

            }////////

            else if (chk == 1)
            {
                string sql2 = "select * from Inventry_Stock where Company_Name='" + input1 + "' and Product_Name='" + input2 + "'";
                cn1.Open();
                cmd = new SqlCommand(sql2, cn1);                
                da = new SqlDataAdapter(cmd);
              DataSet  ds = new DataSet();
                DataTable table1 = new DataTable();
                eff1 = da.Fill(table1);
                if (eff1 != 0)
                {
                    cq2 = Convert.ToDouble(table1.Rows[b]["Carton"]);
                    boxtxt.Text = table1.Rows[b]["Boxes"].ToString();
                    pptxt.Text = table1.Rows[b]["Carton_Purchase_Price"].ToString();
                    bxq = Convert.ToDouble(table1.Rows[b]["BVQ"]);
                    tcsp = Convert.ToDouble(table1.Rows[b]["Total_Stock_PP"]);
                    ssp = Convert.ToDouble(table1.Rows[b]["Total_Stock_SP"]);
                    bxq = bxq - Convert.ToInt32(tb);
                    cq2 = cq2 - cq1;
                    csp = cq2 * Convert.ToDouble(table1.Rows[b]["Carton_Sale_Price"]);
                    cpp = cq2 * Convert.ToDouble(table1.Rows[b]["Carton_Purchase_Price"]);

                    string sql14 = "update Inventry_Stock set Carton ='" + cq2 + "',BVQ='" + bxq + "',Total_Stock_PP='" + cpp + "',Total_Stock_SP='" + csp + "' where Company_Name='" + input1 + "' and Product_Name='" + input2 + "'";
                    cmd.Connection = cn1;
                    cmd.CommandText = sql14;
                    cmd.ExecuteNonQuery();
                    cn1.Close();

                }

                cn1.Open();
                string sql3 = "select * from Inventry_Stock where Company_Name='" + input1 + "' and Product_Name='" + input2 + "'";
                da = new SqlDataAdapter(sql3, cn1);
                 ds = new DataSet();
                da.Fill(ds, "Inventry_Stock");
                c = ds.Tables["Inventry_Stock"].Rows.Count;
                for (b = 0; b <= c - 1; b++)
                {
                    crtn = Convert.ToDouble(ds.Tables["Inventry_Stock"].Rows[b]["Carton"]);
                    bvq = Convert.ToDouble(ds.Tables["Inventry_Stock"].Rows[b]["BVQ"]);
                    cvsp = Convert.ToDouble(ds.Tables["Inventry_Stock"].Rows[b]["Carton_Sale_Price"]);
                    tspp = Convert.ToDouble(ds.Tables["Inventry_Stock"].Rows[b]["Total_Stock_PP"]);
                    tssp = Convert.ToDouble(ds.Tables["Inventry_Stock"].Rows[b]["Total_Stock_SP"]);


                    crtn = crtn + Convert.ToInt32(cqtxt.Text);
                    bvq = bvq + Convert.ToInt32(Bqtytxt.Text);
                    tspp = tspp + Convert.ToDouble(tpptxt.Text);
                    cvsp = cvsp * Convert.ToDouble(cqtxt.Text);
                    tssp = tssp + cvsp;
                    string sql14 = "update Inventry_Stock set Carton ='" + crtn + "',BVQ='" + bvq + "',Total_Stock_PP='" + tspp + "',Total_Stock_SP='" + tssp + "' where Product_Name='" +pnmtxt.Text + "'";
                    cmd.Connection = cn1;
                    cmd.CommandText = sql14;
                    cmd.ExecuteNonQuery();
                    cn1.Close();
                                                                                    //replace crtn          //replce bvq                //replace (cpp/crtn)  //replace cpp
                    string sql44 = "update Purchase_Detail set Carton_Quantity ='" +cqtxt.Text + "',Total_Box='" +Bqtytxt.Text + "',CPP='" +pptxt.Text + "',TCPP='" +tpptxt.Text + "' where Product_Name='" +pnmtxt.Text + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql44;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Stock Updated Successfully.....!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn1.Close();

                    string sql5 = "Select * from Inventry_Stock";
                    cn1.Open();
                    da = new SqlDataAdapter(sql5, cn1);
                    ds = new DataSet();
                    da.Fill(ds, "Inventry_Stock");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Inventry_Stock";
                    cn1.Close();
                    comboBox1.Text = ""; pnmtxt.Clear(); cnmtxt.Clear();
                    comboBox2.Text = ""; cqtxt.Clear(); boxtxt.Clear();
                    pptxt.Clear(); Bqtytxt.Clear(); tpptxt.Clear(); chk = 0;
                }
                button1.Enabled =true;
                button3.Enabled =true;
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            pnmtxt.Text = comboBox2.Text;
            string sql2 = "select Product_Name,Boxes,Carton_Purchase_Price from Inventry_Stock where Product_Name='" +pnmtxt.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "Inventry_Stock");
            c = ds.Tables["Inventry_Stock"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                boxtxt.Text = ds.Tables["Inventry_Stock"].Rows[i]["Boxes"].ToString();
                pptxt.Text = ds.Tables["Inventry_Stock"].Rows[i]["Carton_Purchase_Price"].ToString();
                pnmtxt.Text = ds.Tables["Inventry_Stock"].Rows[i]["Product_Name"].ToString();
            }
            cn1.Close();
            string sql = "select * from Inventry_Stock where Product_Name='" +pnmtxt.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql, cn1);
            ds = new DataSet();
            da.Fill(ds, "Inventry_Stock");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Inventry_Stock";
            cn1.Close();

            string sql1 = "select count(*) from Inventry_Stock where Product_Name='" +pnmtxt.Text + "'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql1;
            c = Convert.ToInt32(cmd.ExecuteScalar());
            label17.Text = Convert.ToString(c);
            cn1.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chk == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                input1 = Microsoft.VisualBasic.Interaction.InputBox("Enter Company Name Here", "Input Box", "", 500, 300);
                input2 = Microsoft.VisualBasic.Interaction.InputBox("Enter Product Name Here", "Input Box", "", 500, 300);
                string sql1 = "select * from Purchase_Detail where Company_Name='" + input1 + "' and Product_Name='" + input2 + "'";
                cn1.Open();
                cmd = new SqlCommand(sql1, cn1);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable table = new DataTable();
                eff = da.Fill(table);
                if (eff != 0)
                {   
                    
                    cnmtxt.Text = table.Rows[b]["Company_Name"].ToString().TrimStart();
                 pnmtxt.Text = table.Rows[b]["Product_Name"].ToString();
                    cq1 = Convert.ToInt32(table.Rows[b]["Carton_Quantity"]);
                    cqtxt.Text = Convert.ToString(cq1);
                    tb = Convert.ToDouble(table.Rows[b]["Total_Box"]);
                    Bqtytxt.Text = Convert.ToString(tb);
                    boxtxt.Text = table.Rows[b]["Box_Quantity"].ToString();
                    pptxt.Text = table.Rows[b]["CPP"].ToString();
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
                string sql = "Delete from Inventry_Stock where Company_Name='" + input1 + "' and Product_Name='" + input2 + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                chk = 0;
                cn1.Close();
                ///
                string sql1 = "Delete from Purchase_Detail where Company_Name='" + input1 + "' and Product_Name='" + input2 + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql1;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully....!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                chk = 0;
                cn1.Close();

                string sql2 = "select * from Purchase_Detail";
                cn1.Open();
                da = new SqlDataAdapter(sql2, cn1);
                ds = new DataSet();
                da.Fill(ds, "Purchase_Detail");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Purchase_Detail";
                cn1.Close();
                comboBox1.Text = ""; pnmtxt.Clear(); cnmtxt.Clear();
                comboBox2.Text = ""; cqtxt.Clear(); boxtxt.Clear();
                pptxt.Clear(); Bqtytxt.Clear(); tpptxt.Clear(); chk = 0;

                button1.Enabled =true;
                button2.Enabled =true;
             }
        }

        private void cqtxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(cqtxt, true, true, true, true);

                }
                e.Handled = true;
            }
          
        }
        private void comboBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
           
          

        }

        private void Add_Stock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        Bitmap bitmap;
        private void button6_Click(object sender, EventArgs e)
        {
            string sql = "select Purchase_Date as PDate,Company_Name as C_Name,Product_Name as P_Name,Carton_Quantity as CQ,Box_Quantity as BQ,CPP,TCPP from Purchase_Detail where Purchase_Date='" + dp2.Value + "' and Company_Name='"+cnmtxt.Text+"'";
            cn1.Open();
            da = new SqlDataAdapter(sql, cn1);
            ds = new DataSet();
            da.Fill(ds, "Purchase_Detail");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Purchase_Detail";
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

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void ordtxt_TabStopChanged(object sender, EventArgs e)
        {

        }

        private void obxtxt_TextChanged(object sender, EventArgs e)
        {   
            
        }

        private void cqtxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
