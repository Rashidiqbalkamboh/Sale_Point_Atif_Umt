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
    public partial class Entry_List_of_Today_Supply : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int c = 0, i = 0,bxs=0;
        string pnm = "", pn = "";
        Double tc1 = 0, bx1 = 0, to = 0, fb = 0, roamt = 0, am = 0, rt = 0, bvq1 = 0, ct = 0, sp = 0, tspp = 0, tssp = 0, tc = 0, bq = 0, bxsp = 0, bxpp = 0, pamt = 0, ret = 0, disc = 0, percent = 0, bxsp2 = 0, tbx = 0, pbdisc = 0, ttbx = 0, remain = 0, ttbx2 = 0, discount=0;
        double cb = 0, spa = 0, ctn = 0;
        bool cncl = false;
        public Entry_List_of_Today_Supply()
        {
            InitializeComponent();
        }
        private void Entry_List_of_Today_Supply_Load(object sender, EventArgs e)
        {
            
            string sn = "";
            enmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            enmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
            string sql2 = "select Distinct(Employ_Name) from EmployRec";
            da = new SqlDataAdapter(sql2, cn1);
            DataSet ds = new DataSet();
            da.Fill(ds, "EmployRec");
            c = ds.Tables["EmployRec"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                enmcombo.Items.Add(ds.Tables["EmployRec"].Rows[i]["Employ_Name"]);
                sn = ds.Tables["EmployRec"].Rows[i]["Employ_Name"].ToString();
                col1.Add(sn);
            }
            cn1.Close();
            enmcombo.AutoCompleteCustomSource = col1;
        }

        private void enmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string sql1 = "Select Bill_No,Bill_Date,SK_ID,SK_Name,SK_Address,Total_Amount From SK_Sale_Bill where E_Name='" + enmcombo.Text + "' and Bill_Date='" + dateTimePicker1.Value + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql1, cn1);
            ds = new DataSet();
            da.Fill(ds, "SK_Sale_Bill");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "SK_Sale_Bill";
            cn1.Close();
            enmcombo.Enabled = false;
        }

        private void bnotxt_Leave(object sender, EventArgs e)
        {            //YE If Wala Code Hamid Ny lgya hai........!!
            if (enmcombo.Text == "Select Employ")
            {
               // MessageBox.Show("Please select Employ Must");
               // enmcombo.Focus();
            }
            deptxt.Enabled = true;
            amttxt.Text = "0";
            deptxt.Text = "0";
            IDtxt.Clear();
            pnmcombo.Items.Clear();
            pnmcombo.Items.Add("Cancel");
            string sql1 = "Select * From SK_Sale_Bill where Bill_No='" + bnotxt.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql1, cn1);
           ds = new DataSet();
            da.Fill(ds, "SK_Sale_Bill");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "SK_Sale_Bill";
            cn1.Close();

            string sql2 = "select * from SK_Sale_Bill where Bill_No='" + bnotxt.Text + "'";
            da = new SqlDataAdapter(sql2, cn1);
            DataSet ds1 = new DataSet();
            da.Fill(ds1, "SK_Sale_Bill");
            c = ds1.Tables["SK_Sale_Bill"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                billtxt.Text = (ds1.Tables["SK_Sale_Bill"].Rows[i]["Bill_No"]).ToString();
                sidtxt.Text = (ds1.Tables["SK_Sale_Bill"].Rows[i]["SK_ID"]).ToString();
                snmtxt.Text = (ds1.Tables["SK_Sale_Bill"].Rows[i]["SK_Name"]).ToString();
                enmcombo.Text = (ds1.Tables["SK_Sale_Bill"].Rows[i]["E_Name"]).ToString();
                addtxt.Text = (ds1.Tables["SK_Sale_Bill"].Rows[i]["SK_Address"]).ToString();
                ct = Convert.ToDouble(ds1.Tables["SK_Sale_Bill"].Rows[i]["Total_Amount"]);
                amttxt.Text = Convert.ToString(Convert.ToDouble(amttxt.Text) + ct);
                roitxt.Text = (ds1.Tables["SK_Sale_Bill"].Rows[i]["Total_ROI"]).ToString();
                totxt.Text = (ds1.Tables["SK_Sale_Bill"].Rows[i]["Total_TO"]).ToString();
                disctxt.Text = (ds1.Tables["SK_Sale_Bill"].Rows[i]["Discount"]).ToString();
                pertxt.Text = (ds1.Tables["SK_Sale_Bill"].Rows[i]["prcnt"]).ToString();
            }
            cn1.Close();
            disc = Convert.ToDouble(disctxt.Text);
          //  MessageBox.Show("TOTAL DISCOUNT......." + disc + ".....Information");
            percent = Convert.ToDouble(pertxt.Text);
            //MessageBox.Show("TOTAL PERCENT......." + percent + ".......Information");
            cretxt.Text = amttxt.Text;
            string sql4 = "select * from Khata_Record where SK_ID='" +sidtxt.Text + "' and E_Name='"+enmcombo.Text+"'";
                da = new SqlDataAdapter(sql4, cn1);
                ds1 = new DataSet();
                da.Fill(ds1, "Khata_Record");
                c = ds1.Tables["Khata_Record"].Rows.Count;
                for (i = 0; i <= c - 1; i++)
                {
                    khatatxt.Text = (ds1.Tables["Khata_Record"].Rows[i]["T_Amount"]).ToString();
                    remaintxt.Text = (ds1.Tables["Khata_Record"].Rows[i]["R_Amount"]).ToString();
                }
                cn1.Close();
          /*  string sql4 = "select * from Khata_Record where Bill_No='" +bnotxt.Text + "'";
            da = new SqlDataAdapter(sql4, cn1);
            ds1 = new DataSet();
            da.Fill(ds1, "Khata_Record");
            c = ds1.Tables["Khata_Record"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                khatatxt.Text = (ds1.Tables["Khata_Record"].Rows[i]["T_Amount"]).ToString();
                remaintxt.Text = (ds1.Tables["Khata_Record"].Rows[i]["R_Amount"]).ToString();
            }
            cn1.Close();*/

            string sn1 = "";
           pnmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
           pnmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
            string sql3 = "select Distinct(P_Name) from Sale_Invoice where Bill_No='" + bnotxt.Text + "'";
            da = new SqlDataAdapter(sql3, cn1);
           DataSet ds2 = new DataSet();
            da.Fill(ds2, "Sale_Invoice");
            c = ds2.Tables["Sale_Invoice"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                pnmcombo.Items.Add(ds2.Tables["Sale_Invoice"].Rows[i]["P_Name"]).ToString();
                sn1 = ds2.Tables["Sale_Invoice"].Rows[i]["P_Name"].ToString();
                col1.Add(sn1);
            }
            cn1.Close();
            pnmcombo.AutoCompleteCustomSource = col1;
            Double x;
            Double.TryParse(khatatxt.Text, out x);
            khatatxt.Text = x.ToString(".00");
            Double.TryParse(remaintxt.Text, out x);
            remaintxt.Text = x.ToString(".00");
            Double.TryParse(cretxt.Text, out x);
            cretxt.Text = x.ToString(".00");
            Double.TryParse(rettxt.Text, out x);
            rettxt.Text = x.ToString(".00");
            Double.TryParse(amttxt.Text, out x);
            amttxt.Text = x.ToString(".00");
            Double.TryParse(textBox1.Text, out x);
            textBox1.Text = x.ToString(".00");
          //  to round ValueType of textbox
          //  khatatxt.Text=Math.Round(Convert.ToDouble(khatatxt.Text), 2,MidpointRounding.ToEven).ToString();
        }

        private void IDtxt_Leave(object sender, EventArgs e)
        {
            if (IDtxt.TextLength != 0)
            {
                amttxt.Text = "0";
                string sql1 = "Select * From SK_Sale_Bill where SK_ID='" + IDtxt.Text + "'";
                cn1.Open();
                da = new SqlDataAdapter(sql1, cn1);
                ds = new DataSet();
                da.Fill(ds, "SK_Sale_Bill");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "SK_Sale_Bill";
                cn1.Close();

                string sql2 = "select * from SK_Sale_Bill where SK_ID='" + IDtxt.Text + "' and E_Name='"+enmcombo.Text+"'";
                da = new SqlDataAdapter(sql2, cn1);
                DataSet ds1 = new DataSet();
                da.Fill(ds1, "SK_Sale_Bill");
                c = ds1.Tables["SK_Sale_Bill"].Rows.Count;
                for (i = 0; i <= c - 1; i++)
                {
                    snmtxt.Text = (ds1.Tables["SK_Sale_Bill"].Rows[i]["SK_Name"]).ToString();
                    addtxt.Text = (ds1.Tables["SK_Sale_Bill"].Rows[i]["SK_Address"]).ToString();
                    ct = Convert.ToDouble(ds1.Tables["SK_Sale_Bill"].Rows[i]["Total_Amount"]);
                    amttxt.Text = Convert.ToString(Convert.ToDouble(amttxt.Text) + ct);
                }
                cn1.Close();

                string sql4 = "select * from Khata_Record where SK_ID='" +IDtxt.Text + "' and E_Name='"+enmcombo.Text+"'";
                da = new SqlDataAdapter(sql4, cn1);
                ds1 = new DataSet();
                da.Fill(ds1, "Khata_Record");
                c = ds1.Tables["Khata_Record"].Rows.Count;
                for (i = 0; i <= c - 1; i++)
                {
                    khatatxt.Text = (ds1.Tables["Khata_Record"].Rows[i]["T_Amount"]).ToString();
                    remaintxt.Text = (ds1.Tables["Khata_Record"].Rows[i]["R_Amount"]).ToString();
                }
                cn1.Close();
            }

        }

        private void pnmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnmcombo.Text == "Cancel")
            {
                cncl = true;
                string sql2 = "select * from Sale_Invoice where Bill_No='" + bnotxt.Text + "'";
                da = new SqlDataAdapter(sql2, cn1);
                DataSet ds1 = new DataSet();
                da.Fill(ds1, "Sale_Invoice");
                c = ds1.Tables["Sale_Invoice"].Rows.Count;
                for (i = 0; i <= c - 1; i++)
                {
                    pn = ds1.Tables["Sale_Invoice"].Rows[i]["P_Name"].ToString();
                    cqtxt.Text = ds1.Tables["Sale_Invoice"].Rows[i]["CQ"].ToString();
                    bqtxt.Text = ds1.Tables["Sale_Invoice"].Rows[i]["BQ"].ToString();
                    string sql1 = "select * from Inventry_Stock where Product_Name='" + pn + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql1;
                    reader = cmd.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        tc = Convert.ToDouble(reader.GetValue(3));
                        bq = Convert.ToDouble(reader.GetValue(5));
                        tspp = Convert.ToDouble(reader.GetValue(10));
                        tssp = Convert.ToDouble(reader.GetValue(11));
                                                                //convert.todouble(reader.getvalue(3));
                        bvq1 = Convert.ToDouble((cqtxt.Text)) * Convert.ToDouble(reader.GetValue(4));
                        bvq1 = bvq1 + Convert.ToDouble(bqtxt.Text);
                        am = bvq1 * Convert.ToDouble(reader.GetValue(8));
                        sp = bvq1 * Convert.ToDouble(reader.GetValue(9));
                       // roitxt.Text = "0";
                   }
                    cn1.Close();
                    
                    string sql = "Update Inventry_Stock set Carton='" + (tc + Convert.ToDouble(cqtxt.Text)) + "',BVQ='" + (bq + bvq1) + "',Total_Stock_PP='" + (tspp + sp) + "',Total_Stock_SP='" + (tssp + am) + "' where Product_Name='" + pn + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                     cn1.Close();
                  //   MessageBox.Show("Value of amt=" + amttxt.Text);
                    /* khatatxt.Text = Convert.ToString(Convert.ToDouble(khatatxt.Text) - Convert.ToDouble(amttxt.Text));
                     remaintxt.Text = Convert.ToString(Convert.ToDouble(remaintxt.Text) - Convert.ToDouble(amttxt.Text));
                    cretxt.Text = Convert.ToString(Convert.ToDouble(amttxt.Text) - Convert.ToDouble(rettxt.Text)); */                   
                }
                khatatxt.Text = Convert.ToString(Convert.ToDouble(khatatxt.Text) - Convert.ToDouble(amttxt.Text));
                remaintxt.Text = Convert.ToString(Convert.ToDouble(remaintxt.Text) - Convert.ToDouble(amttxt.Text));
                cretxt.Text = Convert.ToString(Convert.ToDouble(amttxt.Text) - Convert.ToDouble(rettxt.Text)); 
                
                rettxt.Text = amttxt.Text;
                tc = 0; bq = 0; bvq1 = 0; tspp = 0; sp = 0; tssp = 0; am = 0;
                cretxt.Text = "0";
                cqtxt.Text = "0";
                bqtxt.Text = "0";
                amttxt.Text = "0";
                rettxt.Text = "0";
                roitxt.Text = "0";
                pnmcombo.Items.Clear();
                pnmcombo.Items.Add("Cancel");


            }
            else
            {
                cncl = false;
                cn1.Open();
                string sql2 = "select P_Name,CQ,BQ,Final_Bill from Sale_Invoice where P_Name='" + pnmcombo.Text + "' and E_Name='"+enmcombo.Text+"' and Bill_No='"+bnotxt.Text+"'";
                da = new SqlDataAdapter(sql2, cn1);
                DataSet ds1 = new DataSet();
                da.Fill(ds1, "Sale_Invoice");
                c = ds1.Tables["Sale_Invoice"].Rows.Count;
                for (i = 0; i <= c-1;i++)
                {
                    pnm = Convert.ToString(ds1.Tables["Sale_Invoice"].Rows[i]["P_Name"]);
                    cqtxt.Text=Convert.ToString(ds1.Tables["Sale_Invoice"].Rows[i]["CQ"]);
                   bqtxt.Text = Convert.ToString(ds1.Tables["Sale_Invoice"].Rows[i]["BQ"]);
                    rt = Convert.ToDouble(ds1.Tables["Sale_Invoice"].Rows[i]["Final_Bill"]);
                    cn1.Close();

                    string sql1 = "select * from Inventry_Stock where Product_Name='" +pnmcombo.Text+ "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql1;
                    reader = cmd.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        bvq1 =Convert.ToDouble((cqtxt.Text)) *Convert.ToDouble(reader.GetValue(4));
                        bvq1 = bvq1 +Convert.ToDouble(bqtxt.Text);
                        bvq1 = bvq1 *Convert.ToDouble(reader.GetValue(8));
                    }
                   
                }
                rettxt.Text = Convert.ToString(Convert.ToDouble(rettxt.Text) + rt);
                cn1.Close();
                pnmcombo.Enabled = false;
                
               // cretxt.Text = Convert.ToString(Convert.ToDouble(cretxt.Text) - Convert.ToDouble(rettxt.Text));
              //  pnmcombo.Items.Remove(pnmcombo.SelectedItem);
            }
        }

        private void deptxt_Leave(object sender, EventArgs e)
        {
         /* cretxt.Text=Convert.ToString(Convert.ToDouble(cretxt.Text) -Convert.ToDouble(deptxt.Text));
          remaintxt.Text = Convert.ToString(Convert.ToDouble(remaintxt.Text) - Convert.ToDouble(deptxt.Text));*/
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

        private void bqtxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(bqtxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void bnotxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(bnotxt, true, true, true, true);

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

        private void deptxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(deptxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void rettxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Digit Only", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please Verify All the Data Before Submit", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql7 = "select * from Sale_Invoice where P_Name='" + pnm + "' and Bill_No='" + billtxt.Text + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql7;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tc1 = Convert.ToDouble(reader.GetValue(6));
                    bx1 = Convert.ToDouble(reader.GetValue(7));
                    to = Convert.ToDouble(reader.GetValue(8));
                    fb = Convert.ToDouble(reader.GetValue(10));
                    roamt = Convert.ToDouble(reader.GetValue(11));

                }
                cn1.Close();

                string sql18 = "select * from Sale_Invoice where Bill_No='" + billtxt.Text + "' and P_Name='" + pnmcombo.Text+"'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql18;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Sale Price Of A product in A Bill 
                 
                    bxsp = Convert.ToDouble(reader.GetValue(12));

                    
                }

               
                cn1.Close();
                string sql19 = "select * from Sale_Invoice where Bill_No='" + billtxt.Text + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql19;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //Total No. of Boxes of all the products in a Bill 

                                        ttbx2 = ttbx2 + Convert.ToDouble(reader.GetValue(7));
                                        
                }
                
                discount = Convert.ToDouble(disctxt.Text);
            
                if (pbdisc == 0)
               
                { pbdisc = Convert.ToDouble(disctxt.Text) / ttbx2; }
               
                else if (discount==0)
             
                {
                    pbdisc = 0;
                }
               
                cn1.Close();
               
              

                string sql1 = "select * from Inventry_Stock where Product_Name='" + pnm + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql1;
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    tc = Convert.ToDouble(reader.GetValue(3));
                    bq = Convert.ToDouble(reader.GetValue(5));
                    tspp = Convert.ToDouble(reader.GetValue(10));
                    tssp = Convert.ToDouble(reader.GetValue(11));
                    bxs = Convert.ToInt32(reader.GetValue(4));

                    bvq1 = Convert.ToDouble((cqtxt.Text)) * bxs;
                    bvq1 = bvq1 + Convert.ToDouble(bqtxt.Text);
       // HAMID NY COMMENT KIAA NECHY WALY KO TA K HUMY ACTUAL SAFI RATE MILY JB HUM BSP.TEXT M KHUD SE DATA ENTER KRTY HAIN 
                     
                    
                    bxsp2 = (bxsp * Convert.ToDouble(pertxt.Text)) / 100;
                  
                    
                        bxsp2 = bxsp2 + pbdisc;
                        bxsp = bxsp - bxsp2;
                        textBox1.Text = Convert.ToString(bxsp + Convert.ToDouble(textBox1.Text));

                        bxpp = Convert.ToDouble(reader.GetValue(9));
                        am = bvq1 * bxsp;
                        sp = bvq1 * bxpp;
                        roitxt.Text = Convert.ToString(Convert.ToDouble(roitxt.Text) - (bvq1 * (bxsp - bxpp)));
                        rettxt.Text = Convert.ToString(am);
                    
                    // rettxt.Text =Convert.ToString(Convert.ToDouble(rettxt.Text) + Convert.ToDouble(am));
                }
                cn1.Close();
               
                    
                  
                   
                //Ye Code Hamid Ny Lagaya hai Discount Calcultae krny k lye ..........!!!!!
                
                
                    tc1 = tc1 - Convert.ToDouble(cqtxt.Text);
                    bx1 = bx1 - Convert.ToDouble(bqtxt.Text);
                    cb = tc1 * bxs;
                //replace bx1 with bqtxt vice versa
                    cb = cb + bx1;
                    
                    spa = cb * bxsp;
                    roamt = roamt - (cb * (bxsp - bxpp));
                      
                    string sql9 = "Update Sale_Invoice set CQ='" + tc1 + "',BQ='" + bx1 + "',Final_Bill='" + spa + "',ROI_Amount='" + cb * (bxsp - bxpp) + "' where Bill_No='" + billtxt.Text + "' and P_Name='" + pnm + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql9;
                    cmd.ExecuteNonQuery();
                    cn1.Close();

                    string sql = "Update Inventry_Stock set Carton='" + (tc + Convert.ToDouble(cqtxt.Text)) + "',BVQ='" + (bq + bvq1) + "',Total_Stock_PP='" + (tspp + sp) + "',Total_Stock_SP='" + (tssp + am) + "' where Product_Name='" + pnm + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Stock Returend Successfully....!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn1.Close();

                    cretxt.Text = Convert.ToString(Convert.ToDouble(cretxt.Text) - (Convert.ToDouble(rettxt.Text) + Convert.ToDouble(deptxt.Text)));

                    //YAHAN HAMID NY CODE LAgAYA HAi NECHY RETURN STOCK KA TOTAL KRNY K LYE .......!!!!
                    string sql2 = "select * from SK_Sale_Bill where Bill_No='" + billtxt.Text + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql2;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // ret  = Convert.ToDouble(ds1.Tables["SK_Sale_Bill"].Rows[i]["Return_Stock"]);
                        ret = Convert.ToDouble(reader.GetValue(14));
                      //  MessageBox.Show("Discount Done Successfully....!" + ret + "Information");
                    }
                    cn1.Close();
                    ret = Convert.ToDouble(ret + Convert.ToDouble(rettxt.Text));
                    //MessageBox.Show("Return in this Bill......" + ret + "Information");
                    string sql11 = "Update SK_Sale_Bill set Total_Amount='" + cretxt.Text + "',Total_ROI='" + roitxt.Text + "',Return_Stock='" + ret + "' where Bill_No='" + billtxt.Text + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql11;
                    cmd.ExecuteNonQuery();
                    cn1.Close();
                    khatatxt.Text = Convert.ToString(Convert.ToDouble(khatatxt.Text) - Convert.ToDouble(rettxt.Text));
                    remaintxt.Text = Convert.ToString(Convert.ToDouble(remaintxt.Text) - (Convert.ToDouble(rettxt.Text) + Convert.ToDouble(deptxt.Text)));
                    remain = Convert.ToDouble(remaintxt.Text);
                    if (remain == 0)
                    {
                        string sql4 = "Delete Khata_Record where SK_ID='" + sidtxt.Text + "' and E_Name= '" + enmcombo.Text + "'";
                        cn1.Open();
                        cmd.Connection = cn1;
                        cmd.CommandText = sql4;
                        cmd.ExecuteNonQuery();
                        cn1.Close();
                          MessageBox.Show("Remaining = 0 ..........      Record Deleted..!!! " );
                               }
                    else
                    {
                        string sql12 = "Update Khata_Record set T_Amount='" + khatatxt.Text + "',R_Amount='" + remaintxt.Text + "' where SK_ID='" + sidtxt.Text + "' and E_Name='" + enmcombo.Text + "'";
                        cn1.Open();
                        cmd.Connection = cn1;
                        cmd.CommandText = sql12;
                        cmd.ExecuteNonQuery();
                        cn1.Close();
                       deptxt.Text = "0";
                        deptxt.Enabled = false;
                    }

                    if (cncl == true)
                    {
                        tc1 = 0; bx1 = 0; spa = 0; roamt = 0;
                        string sql8 = "Update Sale_Invoice set CQ='" + tc1 + "',BQ='" + bx1 + "',Final_Bill='" + spa + "',ROI_Amount='" + roamt + "' where Bill_No='" + billtxt.Text + "'";
                        cn1.Open();
                        cmd.Connection = cn1;
                        cmd.CommandText = sql8;
                        cmd.ExecuteNonQuery();
                        cn1.Close();
                    }
                    string sql10 = "Select * From SK_Sale_Bill where Bill_No='" + bnotxt.Text + "'";
                    cn1.Open();
                    da = new SqlDataAdapter(sql10, cn1);
                    ds = new DataSet();
                    da.Fill(ds, "SK_Sale_Bill");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "SK_Sale_Bill";
                    cn1.Close();

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
                rettxt.Text = "0";
                enmcombo.Enabled = true;
                pnmcombo.Enabled = true;
                pnmcombo.Text = " Select Product ";
                textBox1.Text = "0";
                bqtxt.Text = "0"; cqtxt.Text = "0";
                         

    }

        private void Entry_List_of_Today_Supply_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void billtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void bnotxt_Enter(object sender, EventArgs e)
        {
          /*  if (IDtxt.TextLength == 0)
            {
                MessageBox.Show("Please Enter SK_ID First.....!");
                IDtxt.Focus();
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (enmcombo.Text != "Select Employ")
            {
                SKBillReport sb = new SKBillReport();
                sb.SetParameterValue("E_Name", enmcombo.Text);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Hamid_Bhutta_and_Brothers.Properties.Setting.DistributionSetup"].ToString();
                string sql1 = "select * from SK_Sale_Bill where E_Name='" + enmcombo.Text + "' and Bill_Date='" + dateTimePicker1.Value + "'";
                DataSet ds1 = new DataSet();
                SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                da1.Fill(ds1, "SK_Sale_Bill");
                DataTable dt = ds1.Tables["SK_Sale_Bill"];
                sb.SetDataSource(ds1.Tables["SK_Sale_Bill"]);
                crystalReportViewer1.ReportSource = sb;
                crystalReportViewer1.Refresh();
            }
            //Is ko m Hamid ny comment kia hai ....
            else
            {
                MessageBox.Show("Please Select Employ Name First");
                enmcombo.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            enmcombo.Enabled = true; pnmcombo.Enabled = true; deptxt.Enabled = true;
            enmcombo.Text = "Select Employ"; bnotxt.Clear(); IDtxt.Clear();
            cqtxt.Text = "0"; bqtxt.Text = "0"; billtxt.Clear();
            sidtxt.Clear(); snmtxt.Clear(); addtxt.Clear(); amttxt.Text = "0";
            deptxt.Text = "0"; rettxt.Text = "0"; cretxt.Clear();
            pnmcombo.Text = "Select Product"; roitxt.Text = "0"; totxt.Text = "0";
            khatatxt.Text = "0"; remaintxt.Text = "0";

        }

        private void enmcombo_Leave(object sender, EventArgs e)
        {
            //YE If Wala Code Hamid Ny lgya hai........!!
            if (enmcombo.Text == "Select Employ")
            {
                MessageBox.Show("Please select Employ Must");
                enmcombo.Focus();
            }
        }

        private void billtxt_Leave(object sender, EventArgs e)
        {

        }

        private void bnotxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
