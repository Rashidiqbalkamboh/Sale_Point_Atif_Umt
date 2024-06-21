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
using CrystalDecisions.CrystalReports.Engine;


namespace Hamid_Bhutta_and_Brothers
{
    public partial class Sale_Form : Form
    {   
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int cnt = 0, c = 0, chk = 0, cq1 = 0, eff = 0, efff = 0, b = 0, i = 0, bq = 0, bsp = 0, bpp = 0, skkid = 0, tessst = 0, employ=0;
        string input = "", input2 = "", input1 = "", cnm = "", pnm = "", empname = "";
       double cqt=0, bqt=0, fb=0,spp=0,bvq1=0,ct=0,PA=-1,reamt=0,bxs=0,ttt=0,rrr=0,roi=0,final=0,percentage=0,after=0,Company=0;
       
        int submit = 0; double pramt = 0;
        double ctn = 0;
        public Sale_Form()
        {
            InitializeComponent();
        }

        private void Sale_Form_Load(object sender, EventArgs e)
        {
          //  crystalReportViewer1.Zoom(89);
           /* string sql15 = "truncate table Sale_Invoice";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql15;
            cmd.ExecuteNonQuery();
            cn1.Close();

            string sql16 = "truncate table SK_Sale_Bill";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql16;
            cmd.ExecuteNonQuery();
            cn1.Close();*/

           string en = "";
           enmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
           enmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col11 = new AutoCompleteStringCollection();
            string sql1 = "select Distinct(Employ_Name) from EmployRec";
            da = new SqlDataAdapter(sql1, cn1);
           DataSet ds = new DataSet();
            da.Fill(ds, "EmployRec");
            c = ds.Tables["EmployRec"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                enmcombo.Items.Add(ds.Tables["EmployRec"].Rows[i]["Employ_Name"]);
                en = ds.Tables["EmployRec"].Rows[i]["Employ_Name"].ToString();
                col11.Add(en);
            }
            cn1.Close();
            enmcombo.AutoCompleteCustomSource = col11;
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

            string sql3 = "select count(Bill_No) from SK_Sale_Bill";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql3;
            cnt =Convert.ToInt32(cmd.ExecuteScalar());
            bnotxt.Text = Convert.ToString(cnt + 1);
            cn1.Close();

        }

        private void snmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDtxt.Enabled = false;
           string sql2 = "select * from ShopKeeperRecord where ShopKeeper_Name='" +snmcombo.Text + "'";
            da = new SqlDataAdapter(sql2, cn1);
            DataSet ds = new DataSet();
            da.Fill(ds, "ShopKeeperRecord");
            c = ds.Tables["ShopKeeperRecord"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
               snmtxt.Text = (ds.Tables["ShopKeeperRecord"].Rows[i]["ShopKeeper_Name"]).ToString();
                IDtxt.Text = (ds.Tables["ShopKeeperRecord"].Rows[i]["ID"]).ToString();
                Addtxt.Text =(ds.Tables["ShopKeeperRecord"].Rows[i]["Address"]).ToString();
                cnttxt.Text = (ds.Tables["ShopKeeperRecord"].Rows[i]["Contact_No"]).ToString();
                textBox2.Text = (ds.Tables["ShopKeeperRecord"].Rows[i]["Area_Name"]).ToString();

            }
            cn1.Close();
            patxt.Text = "0";
            string sql1 = "select Sum(R_Amount) from Khata_Record where SK_ID='" + IDtxt.Text + "'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql1;
            patxt.Text = Convert.ToString(cmd.ExecuteScalar());
            cn1.Close();
            snmcombo.Enabled = false;
        }

        private void IDtxt_Leave(object sender, EventArgs e)
        {
            IDtxt.Enabled = false;    
            snmcombo.Enabled = false;
            string sql2 = "select * from ShopKeeperRecord where ID='" +IDtxt.Text + "'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql2;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
              snmtxt.Text = reader.GetValue(2).ToString();
                IDtxt.Text = reader.GetValue(3).ToString();
                Addtxt.Text = reader.GetValue(4).ToString();
                cnttxt.Text = reader.GetValue(5).ToString();
                textBox2.Text = reader.GetValue(0).ToString();

            }
            cn1.Close(); 
        //Ye Hamid Ny Code Lagaya h nechy ta k previous Amount sirf osi employ ki ae jc ki ho pari
            string sql15 = "Select * from Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name='" + textBox1.Text + "'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql15;
            reader = cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                tessst = 1;
            }
            cn1.Close();
            if (tessst == 0)
            {
                patxt.Text = "";
            }
            else if (tessst == 1)
            {


                string sql1 = "select R_Amount from Khata_Record where SK_ID='" + IDtxt.Text + "'and E_Name='"+textBox1.Text+"'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql1;
                patxt.Text = Convert.ToString(cmd.ExecuteScalar());
                cn1.Close();
                /* cmd = new SqlCommand(sql1, cn1);
                 da = new SqlDataAdapter(cmd);
                 ds = new DataSet();
                 DataTable table = new DataTable();
                 eff = da.Fill(table);
                 if (eff != 0)
                 {
                     patxt.Text = table.Rows[b]["R_Amount"].ToString();
                    // reamt = Convert.ToDouble(table.Rows[b]["R_Amount"]);
                   //  PA = Convert.ToDouble(table.Rows[b]["T_Amount"]);
                 }*/

            }
         }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Did You Submit the Bill Before Exit...???", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (submit == 0)
                {
                    string sql = "Delete Sale_Invoice where Bill_No='" + bnotxt.Text + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    // MessageBox.Show("Deleted Successfully....!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    // chk = 0;
                    cn1.Close();
                    this.Close();
                }
                else
                { this.Close(); }
            }
        }

        private void pnmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //enmcombo.Text = "";          
            string sql1 = "select * from Inventry_Stock where Product_Name='" +pnmcombo.Text + "'";
            da = new SqlDataAdapter(sql1, cn1);
            ds = new DataSet();
            da.Fill(ds, "Inventry_Stock");
            c = ds.Tables["Inventry_Stock"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
               pnmtxt.Text=ds.Tables["Inventry_Stock"].Rows[i]["Product_Name"].ToString();
             bsptxt.Text = ds.Tables["Inventry_Stock"].Rows[i]["Sale_Price"].ToString();
             bq = Convert.ToInt32(ds.Tables["Inventry_Stock"].Rows[i]["Boxes"]);
             bsp = Convert.ToInt32(ds.Tables["Inventry_Stock"].Rows[i]["Sale_Price"]);
             bpp = Convert.ToInt32(ds.Tables["Inventry_Stock"].Rows[i]["Purchase_Price"]);
             bvq1 = Convert.ToDouble(ds.Tables["Inventry_Stock"].Rows[i]["BVQ"]);
             ct = Convert.ToDouble(bvq1 / bq);
             if (ct != 0 || bvq1 != 0)
              MessageBox.Show("Boxes Quantity is= " + bvq1 + "\n Carton Quantity is=" + ct, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
             if (ct ==0 && bvq1==0)
             {
                 MessageBox.Show("Boxes Quantity is= " + bvq1 + "\n Carton Quantity is=" + ct, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 bsptxt.Text = "0";
             }
          }
            cn1.Close();
            enmcombo.Focus();
        }

        private void bxtxt_Leave(object sender, EventArgs e)
        {
            if (bxtxt.TextLength == 0)
                bxtxt.Text = "0";
           
        }

        private void ctntxt_Leave(object sender, EventArgs e)
        {
         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double rooi = 0,aammtt=0; 
            if (MessageBox.Show("Please Verify All the Data Before Submit", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql15 = "Select * from EmployRec where Employ_Name='" + enmcombo.Text +  "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql15;
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    employ = 1;
                }
                cn1.Close();
                if (employ == 0)
                {
                    MessageBox.Show("EMPLOY NAME IS WRONG", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    enmcombo.Focus();
                }
                else if (employ == 1)
                {
                   

                }

                
                if (bxtxt.Text == "0" && ctntxt.Text == "0")
                    MessageBox.Show("Please Select Product Name First", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (bq != 0)
                {
                    if (employ == 1)
                    {
                        if (Convert.ToInt32(bxtxt.Text) > bq)
                        {
                            ctntxt.Text = Convert.ToString(Convert.ToInt32(bxtxt.Text) / bq);
                            bxtxt.Text = Convert.ToString(Convert.ToInt32(bxtxt.Text) % bq);
                        }
                        bq = Convert.ToInt32(Convert.ToDouble(ctntxt.Text) * bq);
                        bq = Convert.ToInt32(bq + Convert.ToDouble(bxtxt.Text));
                        amttxt.Text = Convert.ToString(bq * Convert.ToInt32(bsptxt.Text));
                        aammtt = Convert.ToDouble(amttxt.Text);
                        bsp = bq * Convert.ToInt32(bsptxt.Text);
                        bsp = bsp - (bq * bpp);
                        if (ct <= 0)
                            bsp = 0;
                        // double rooi = 0;                    
                        roitxt.Text = Convert.ToString(Convert.ToInt32(roitxt.Text) + bsp);
                        rooi = Convert.ToDouble(roitxt.Text);
                        if (Convert.ToInt32(totxt.Text) != 0)
                        {
                            double ttt = 0;
                            totxt.Text = Convert.ToString(bq * Convert.ToInt32(totxt.Text));
                            ttotxt.Text = Convert.ToString(Convert.ToInt32(ttotxt.Text) + Convert.ToInt32(totxt.Text));
                            ttt = Convert.ToDouble(ttotxt.Text);
                        }


                        if (amttxt.Text != "")
                        {
                            double ttaa = 0, fatt = 0;
                            tatxt.Text = Convert.ToString(Convert.ToInt32(tatxt.Text) + Convert.ToInt32(amttxt.Text));
                            ttaa = Convert.ToDouble(tatxt.Text);
                            fatxt.Text = Convert.ToString(Convert.ToInt32(tatxt.Text) - Convert.ToInt32(ttotxt.Text));
                            fatt = Convert.ToDouble(fatxt.Text);
                        }

                        if (amttxt.Text == "" || snmtxt.Text == "" || IDtxt.Text == "" || cnmcombo.Text == "" || pnmcombo.Text == "" || enmcombo.Text == "" || fatxt.Text == "")
                        {
                            MessageBox.Show("Please Fill All The Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            troitxt.Text = Convert.ToString(Convert.ToDouble(roitxt.Text) + Convert.ToDouble(troitxt.Text));
                            if (bq <= bvq1)
                            {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               // "')";
                                
                                    string sql = "Insert Into Sale_Invoice(Sale_Date,Bill_No,SK_Name,C_Name,P_Name,E_Name,CQ,BQ,Total_To,Percentage,Final_Bill,ROI_Amount,Rate,Area)Values('" + dateTimePicker1.Value + "','" + bnotxt.Text.Trim() + "','" + snmtxt.Text.Trim() + "','" + cnmcombo.Text.Trim() + "','" + pnmcombo.Text.Trim() + "','" + enmcombo.Text.Trim() + "','" + ctntxt.Text + "','" + bxtxt.Text + "','" + ttotxt.Text + "','" + pertxt.Text + "','" + amttxt.Text + "','" + roitxt.Text + "','" + bsptxt.Text +"','"+textBox2.Text+ "')";
                                    cn1.Open();
                                    cmd.Connection = cn1;
                                    cmd.CommandText = sql;
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Data stored", "Sale_Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cn1.Close();
                                    submit = 0;
                                

                                    string sql1 = "Select * From Sale_Invoice where Bill_No='" + bnotxt.Text + "'";
                                    cn1.Open();
                                    da = new SqlDataAdapter(sql1, cn1);
                                    ds = new DataSet();
                                    da.Fill(ds, "Sale_Invoice");
                                    dataGridView1.DataSource = ds;
                                    dataGridView1.DataMember = "Sale_Invoice";
                                    cn1.Close();

                                    amttxt.Clear(); bsptxt.Clear(); bxtxt.Text = "0"; ctntxt.Text = "0";
                                    pnmtxt.Clear(); pnmcombo.Text = ""; pnmcombo.Text = ""; totxt.Text = "0"; roitxt.Text = "0";
                                    
                                    
                                // Table m se record delete krny k lye 
                                   
                              /*  string sql4 = "Delete Purchase_Detail where Purchase_Date between '"+dateTimePicker1.Value+"' and '"+DateTime.Now.Date+"'"  ;
                                    cn1.Open();
                                    cmd.Connection = cn1;
                                    cmd.CommandText = sql4;
                                    cmd.ExecuteNonQuery();
                                    cn1.Close();
                                    


                                    MessageBox.Show("Deleted Everything....!!! ", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                */
                                /////  
                                
                            }
                            else
                            {
                                MessageBox.Show("Quantity Oveloaded From Stock Please Check", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                troitxt.Text = Convert.ToString(Convert.ToDouble(troitxt.Text) - rooi);
                                fatxt.Text = Convert.ToString(Convert.ToInt32(fatxt.Text) - Convert.ToInt32(aammtt));
                                fatxt.Text = Convert.ToString(Convert.ToInt32(fatxt.Text) + Convert.ToInt32(totxt.Text));
                                tatxt.Text = Convert.ToString(Convert.ToInt32(tatxt.Text) - Convert.ToInt32(aammtt));
                                ttotxt.Text = Convert.ToString(Convert.ToInt32(ttotxt.Text) - Convert.ToInt32(totxt.Text));
                                amttxt.Clear(); bsptxt.Clear(); bxtxt.Text = "0"; ctntxt.Text = "0";
                                pnmtxt.Clear(); pnmcombo.Text = ""; totxt.Text = "0"; roitxt.Text = "0";
                            }
                        }
                    }
                }
            }
            pnmcombo.Items.Remove(pnmcombo.SelectedItem);

        }

        private void button1_Click(object sender, EventArgs e)

        {    
            
            if (MessageBox.Show("Please Verify All the Data Before Submit", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                 
                if (snmtxt.Text == "" || IDtxt.Text == "" || textBox1.Text == "" || fatxt.Text == "")
                    MessageBox.Show("Please Enter Complete Detail Some Data Missing", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {    
                    cn1.Open();
                    string sql3 = "select * from Sale_Invoice where Bill_No='" + bnotxt.Text + "' and SK_Name='" + snmtxt.Text + "'";
                    da = new SqlDataAdapter(sql3, cn1);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Sale_Invoice");
                    c = ds.Tables["Sale_Invoice"].Rows.Count;
                    for (i = 0; i <= c - 1; i++)
                    {
                        cnm = (ds.Tables["Sale_Invoice"].Rows[i]["C_Name"]).ToString();
                        pnm = (ds.Tables["Sale_Invoice"].Rows[i]["P_Name"]).ToString();
                        cqt = Convert.ToDouble(ds.Tables["Sale_Invoice"].Rows[i]["CQ"]);
                        bxs = Convert.ToDouble(ds.Tables["Sale_Invoice"].Rows[i]["BQ"]);
                        fb = Convert.ToDouble(ds.Tables["Sale_Invoice"].Rows[i]["Final_Bill"]);
                        cn1.Close();
                        string sql1 = "select * from Inventry_Stock where Company_Name='" + cnm + "' and Product_Name='" + pnm + "'";
                        cn1.Open();
                        cmd.Connection = cn1;
                        cmd.CommandText = sql1;
                        reader = cmd.ExecuteReader();
                        if (reader.Read() == true)
                        {
                            bqt = cqt * Convert.ToDouble(reader.GetValue(4));
                            bqt = bqt + bxs;
                            spp = bqt * Convert.ToDouble(reader.GetValue(9));
                            cqt = bqt / Convert.ToDouble(reader.GetValue(4));
                            fb = Convert.ToDouble(reader.GetValue(11)) - fb;
                            cqt = Convert.ToDouble(reader.GetValue(3)) - cqt;
                            bqt = Convert.ToDouble(reader.GetValue(5)) - bqt;
                            spp = Convert.ToDouble(reader.GetValue(10)) - spp;
                         
                        }
                        cn1.Close();
               //YE IF WALA CODE HAMID NY LAGAYA HAI TA K CQT KI VALUE BHI EXACT ZERO HO JAE JB BVQ KI VALUE ZERO HO WARNA CQT MINUS M CHALA JATA THA 
                        if (bqt == 0)
                        { cqt = 0; }
                        else { }
                        string sql2 = "Update Inventry_Stock set Carton='" + cqt + "',BVQ='" + bqt + "',Total_Stock_PP='" + spp + "',Total_Stock_SP='" + fb + "' where Company_Name='" + cnm + "' and Product_Name='" + pnm + "'";
                        cn1.Open();
                        cmd.Connection = cn1;
                        cmd.CommandText = sql2;
                        cmd.ExecuteNonQuery();
                    }
                    cn1.Close();


                    string sql = "Insert Into SK_Sale_Bill(Bill_No,Bill_Date,SK_ID,SK_Name,SK_Address,Area,Total_Amount,Total_ROI,Total_TO,Discount,Contact,P_Amount,C_Name,Prcnt,Return_Stock,E_Name)Values('" + bnotxt.Text.Trim() + "','" + dateTimePicker1.Value + "','" + IDtxt.Text.Trim() + "','" + snmtxt.Text.Trim() + "','" + Addtxt.Text + "','" + textBox2.Text + "','" + fatxt.Text.Trim() + "','" + troitxt.Text + "','" + ttotxt.Text.Trim() + "','" + distxt.Text + "','" + cnttxt.Text + "','" + patxt.Text + "','" + cnmcombo.Text.Trim() + "','" + pertxt.Text + "' , '" + '0' + "','" + enmcombo.Text.Trim() + "')";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Stock Deducted Successfully.....!", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn1.Close();

                    string sql15 = "Select * from Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name='"+textBox1.Text+"'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql15;
                    reader = cmd.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        tessst = 1;
                    }
                    cn1.Close();
                  if (tessst==0)
                    {
                        string sql11 = "Insert into Khata_Record(Date,SK_ID,SK_Name,SK_Address,E_Name,T_Amount,Sat,Sun,Mon,Tue,Wed,Thu,R_Amount,Bill_No,Area)Values('" + dateTimePicker1.Value + "','" + IDtxt.Text.Trim() + "','" + snmtxt.Text.Trim() + "','" + Addtxt.Text.Trim() + "','" + enmcombo.Text.Trim() + "','" + fatxt.Text.Trim() + "',0,0,0,0,0,0,'" + fatxt.Text.Trim() + "','" + bnotxt.Text + "','" + textBox2.Text.Trim() + "')";
                        cn1.Open();
                        cmd.Connection = cn1;
                        cmd.CommandText = sql11;
                        cmd.ExecuteNonQuery();
                      //  MessageBox.Show("Date Stored In Khata Record");
                        cn1.Close();
                    }
                    else if(tessst==1)
                    {
                        ttt = (Convert.ToDouble(patxt.Text) + Convert.ToDouble(fatxt.Text));
                        rrr = (Convert.ToDouble(patxt.Text) + Convert.ToDouble(fatxt.Text));
                        string sql2 = "Update Khata_Record set T_Amount='" + ttt + "',R_Amount='" + rrr + "' where SK_ID='" +IDtxt.Text + "' and E_Name='"+textBox1.Text+"'";
                        cn1.Open();
                        cmd.Connection = cn1;
                        cmd.CommandText = sql2;
                        cmd.ExecuteNonQuery();
                      //  MessageBox.Show("Date Updated In Khata Record");
                        cn1.Close();
                    }

                      string sql18 = "select count(Bill_No) from SK_Sale_Bill";
                      cn1.Open();
                      cmd.Connection = cn1;
                      cmd.CommandText = sql18;
                      cnt = Convert.ToInt32(cmd.ExecuteScalar());
                      bnotxt.Text = Convert.ToString(cnt + 1);
                      cn1.Close();
                      submit = 1;

                    cnmcombo.Text = ""; pnmcombo.Text = ""; pnmtxt.Clear(); snmtxt.Clear(); snmcombo.Text = "";
                    amttxt.Clear(); bsptxt.Clear(); textBox1.Clear();
                    bxtxt.Text = "0"; ctntxt.Text = "0"; totxt.Text = "0"; bq = 0;
                    roitxt.Text = "0"; tatxt.Text = "0"; ttotxt.Text = "0"; pertxt.Text = "0";
                    patxt.Text = "0"; fatxt.Text = "0"; troitxt.Text = "0"; distxt.Text = "0";
                    IDtxt.Clear(); IDtxt.Enabled = true;tessst=0;
                    snmcombo.Enabled = true; enmcombo.Enabled = true; enmcombo.Text = "";
                    pertxt.Enabled = true; distxt.Enabled = true;
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

        private void button4_Click(object sender, EventArgs e)
        {
            chk = 0; submit = 0;
            button1.Enabled = true; button2.Enabled = true; button3.Enabled = true;
            pnmtxt.Clear(); snmtxt.Clear(); snmcombo.Text = ""; cnmcombo.Text = "";
            pnmcombo.Text = ""; enmcombo.Text = "";amttxt.Clear(); bsptxt.Clear();
            bxtxt.Text = "0"; ctntxt.Text="0";totxt.Text = "0"; bq = 0; IDtxt.Clear();
            roitxt.Text = "0";tatxt.Text = "0"; ttotxt.Text = "0"; pertxt.Text = "0";
            patxt.Text = "0"; fatxt.Text = "0"; distxt.Text = "0"; troitxt.Text = "0"; snmcombo.Enabled = true;
            enmcombo.Enabled = true; enmcombo.Text = ""; pertxt.Enabled = true; distxt.Enabled = true; IDtxt.Enabled = true;  
        }

        private void pertxt_Leave(object sender, EventArgs e)
        {
            if (pertxt.TextLength == 0)
                pertxt.Text = "0";
            else
            {
                pramt = (Convert.ToDouble(fatxt.Text) * Convert.ToDouble(pertxt.Text)) / 100;
                fatxt.Text = Convert.ToString(Convert.ToDouble(fatxt.Text) - pramt);
                //YAHAN PAR HAMID NE FORMULA LAGAYA HAI NECHY WALA ........!!!!! 
                pramt = (Convert.ToDouble(tatxt.Text) * Convert.ToDouble(pertxt.Text)) / 100;
                tatxt.Text = Convert.ToString(Convert.ToDouble(tatxt.Text) - pramt);
                if (cnmcombo.Text == "JOJO (B)")
                { pramt = 8.3 * Convert.ToDouble(pertxt.Text); }
                else if (cnmcombo.Text=="Cutees")
                
                {   pramt = 8.3 * Convert.ToDouble(pertxt.Text);}
                else if (cnmcombo.Text == "Percy")
                { pramt = 8.3 * Convert.ToDouble(pertxt.Text); }
                
                pramt = (Convert.ToDouble(troitxt.Text) * pramt / 100) ;
                troitxt.Text = Convert.ToString(Convert.ToDouble(troitxt.Text) - pramt);
                MessageBox.Show("Percentage Done Successfully....!" + pertxt.Text + "Information");
                // pertxt.Text = "0";
                pertxt.Enabled = false;
                //YAHAN HAMID NY CODE LAGAYA HAI TAA K SALE INVOICE TABLE KO UPDATE KIA JAA SKY PERCENTAGE K BAAD
              /*  string sql3 = "select * from Sale_Invoice where Bill_No='" + bnotxt.Text + "' and SK_Name='" + snmtxt.Text + "'";
                da = new SqlDataAdapter(sql3, cn1);
                DataSet ds = new DataSet();
                da.Fill(ds, "Sale_Invoice");
                c = ds.Tables["Sale_Invoice"].Rows.Count;
                for (i = 0; i <= c - 1; i++)
                {
                    cnm = (ds.Tables["Sale_Invoice"].Rows[i]["C_Name"]).ToString();
                    pnm = (ds.Tables["Sale_Invoice"].Rows[i]["P_Name"]).ToString();
                    roi = Convert.ToDouble(ds.Tables["Sale_Invoice"].Rows[i]["ROI_Amount"]);
                    percentage = Convert.ToDouble(ds.Tables["Sale_Invoice"].Rows[i]["Percentage"]);
                    final = Convert.ToDouble(ds.Tables["Sale_Invoice"].Rows[i]["Final_Bill"]);
                    cn1.Close();
                }
                percentage = Convert.ToDouble(pertxt.Text);
                after = final * Convert.ToDouble(pertxt.Text) / 100;
                final = final - after;
          //Ab Roi ko Update kr ry hyn nechy 
             if (cnm == "JOJO (B)")
             {
                 percentage = 8.3 * percentage;
                 after = roi * percentage / 100;
                 roi = roi - after;

             }
            else if (cnm == "Cutees")
             {
                 percentage = 8.3 * percentage;
                 after = roi * percentage / 100;
                 roi = roi - after;
             }
             else if (cnm == "Percy")
             {
                 percentage = 8.3 * percentage;
                 after = roi * percentage / 100;
                 roi = roi - after;
             }
             else
             {   //New Company K lye os Company ki Percentage policy k according 8.3 ko change kr k os company ka name bhi add kia jae ga idhar 
                 percentage = 8.3 * percentage;
                 after = roi * percentage / 100;
                 roi = roi - after;
             }

                string sql = "Update Sale_Invoice set Final_Bill='" + final + "',ROI_Amount='" + roi + "',Percentage='" + percentage + "' where Bill_No='" + bnotxt.Text + "' and C_Name='" + cnm + "' and P_Name='" + pnm + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                cn1.Close();
                */
            }
        }

private double Converttodouble(ComboBox cnmcombo)
{
 	throw new NotImplementedException();
}

        private void snmcombo_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(snmcombo, true, true, true, true);

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

        private void cnmcombo_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(cnmcombo, true, true, true, true);

                }
                e.Handled = true;
            }

        }

        private void pnmcombo_KeyPress(object sender, KeyPressEventArgs e)
        {
          if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(pnmcombo, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void enmcombo_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(enmcombo, true, true, true, true);

                }
                e.Handled = true;
            }
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

        private void bsptxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;                                               
            else if (Char.IsLetter(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar)  || Char.IsPunctuation(e.KeyChar) || Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Digit Only", "Error");
            }
           
        }

        private void totxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(totxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void pertxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(pertxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void bsptxt_Leave(object sender, EventArgs e)
        {
          //  bsptxt.Text =Convert.ToString(bsp);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (chk == 0)
            {
                button1.Enabled = false;
                button3.Enabled = false;
                button6.Enabled = false;
                button2.FlatAppearance.BorderColor = Color.Black;
                input = Microsoft.VisualBasic.Interaction.InputBox("Enter Bill_No Here", "Input Box", "", 500, 300);
                input1 = Microsoft.VisualBasic.Interaction.InputBox("Enter Company Name Here", "Input Box", "", 500, 300);
                input2 = Microsoft.VisualBasic.Interaction.InputBox("Enter Product Name Here", "Input Box", "", 500, 300);
                string sql1 = "select * from Sale_Invoice where Bill_No='" + input + "' and C_Name='" + input1 + "' and P_Name='" + input2 + "'";
                cmd = new SqlCommand(sql1, cn1);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable table = new DataTable();
                eff = da.Fill(table);
                if (eff != 0)
                {
                    cnmcombo.Text = table.Rows[b]["C_Name"].ToString().TrimStart();
                    pnmcombo.Text = table.Rows[b]["P_Name"].ToString();
                    pnmtxt.Text = table.Rows[b]["P_Name"].ToString();
                    enmcombo.Text = table.Rows[b]["E_Name"].ToString();
                    cq1 = Convert.ToInt32(table.Rows[b]["CQ"]);
                    ctntxt.Text = Convert.ToString(cq1);
                    bxtxt.Text = table.Rows[b]["BQ"].ToString();
                    totxt.Text = (table.Rows[b]["Total_To"]).ToString();
                    pertxt.Text = table.Rows[b]["Percentage"].ToString();
                    amttxt.Text = table.Rows[b]["Final_Bill"].ToString();
                    chk = 1;
                    string sql = "Select * From SK_Sale_Bill where Bill_No='" + input + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                        fatxt.Text = reader.GetValue(6).ToString();
                    cn1.Close();
                    fatxt.Text = Convert.ToString(Convert.ToDouble(fatxt.Text) - Convert.ToDouble(amttxt.Text));
                   tatxt.Text = Convert.ToString(Convert.ToDouble(tatxt.Text) - Convert.ToDouble(amttxt.Text));
                   cnmcombo.Text = ""; pnmcombo.Text = ""; pnmtxt.Clear(); enmcombo.Text = "";

                }
                else
                {
                    MessageBox.Show("Rrecord Not In Table");
                    cn1.Close();
                }
            }
            else if (chk == 1 && pnmtxt.Text != "" && bsptxt.Text != "" && cnmcombo.Text != ""&& pnmcombo.Text != "")
            {
                bsp = Convert.ToInt32(bsptxt.Text);
                if (Convert.ToInt32(bxtxt.Text) > bq)
                {
                    ctntxt.Text = Convert.ToString(Convert.ToInt32(bxtxt.Text) / bq);
                    bxtxt.Text = Convert.ToString(Convert.ToInt32(bxtxt.Text) % bq);
                }
                bq = Convert.ToInt32(Convert.ToDouble(ctntxt.Text) * bq);
                bq = Convert.ToInt32(bq + Convert.ToDouble(bxtxt.Text));
                amttxt.Text = Convert.ToString(bq * Convert.ToInt32(bsp));
                bsp = bq * bsp;
                bsp = bsp - (bq * bpp);
                roitxt.Text = Convert.ToString(Convert.ToInt32(roitxt.Text) + bsp);
                if (Convert.ToInt32(totxt.Text) != 0)
                {
                    totxt.Text = Convert.ToString(bq * Convert.ToInt32(totxt.Text));
                    ttotxt.Text = Convert.ToString(Convert.ToInt32(ttotxt.Text) + Convert.ToInt32(totxt.Text));
                }
                fatxt.Text = Convert.ToString(Convert.ToDouble(fatxt.Text) + Convert.ToDouble(amttxt.Text));
                tatxt.Text = Convert.ToString(Convert.ToDouble(tatxt.Text) + Convert.ToDouble(amttxt.Text));

                string sql = "Update Sale_Invoice set SK_Name='" + snmtxt.Text + "',C_Name='" + cnmcombo.Text + "',P_Name='" + pnmcombo.Text + "',E_Name='" +textBox1.Text + "',CQ='" + ctntxt.Text + "',BQ='" + bxtxt.Text + "',Total_To='" + totxt.Text + "',Percentage='" + pertxt.Text + "',Final_Bill='" + amttxt.Text + "' where Bill_No='" + input + "' and C_Name='" + input1 + "' and P_Name='" + input2 + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                chk = 0;
                cn1.Close();

                string sql2 = "select * from Sale_Invoice  where Bill_No='" + input + "'";
                cn1.Open();
                da = new SqlDataAdapter(sql2, cn1);
                ds = new DataSet();
                da.Fill(ds, "Sale_Invoice");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Sale_Invoice";
                cn1.Close();

                button1.Enabled = true;
                button3.Enabled = true;
                button6.Enabled = true;
                button2.FlatAppearance.BorderColor = Color.Red;
                chk = 0;
            }
            else { MessageBox.Show("Some Data is Missing Please Check"); }

        }

        private void enmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text=enmcombo.Text;
            string sql1 = "select Sum(R_Amount) from Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name='"+textBox1.Text+"'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql1;
            patxt.Text = Convert.ToString(cmd.ExecuteScalar());
            cn1.Close();
            enmcombo.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chk == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button6.Enabled = false;
                button3.FlatAppearance.BorderColor = Color.Black;
                input = Microsoft.VisualBasic.Interaction.InputBox("Enter Bill_No Here", "Input Box", "", 500, 300);
                input1 = Microsoft.VisualBasic.Interaction.InputBox("Enter Company Name Here", "Input Box", "", 500, 300);
                input2 = Microsoft.VisualBasic.Interaction.InputBox("Enter Product Name Here", "Input Box", "", 500, 300);
                string sql1 = "select * from Sale_Invoice where Bill_No='" + input + "' and C_Name='" + input1 + "' and P_Name='" + input2 + "'";
                cmd = new SqlCommand(sql1, cn1);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                DataTable table = new DataTable();
                eff = da.Fill(table);
                if (eff != 0)
                {
                    cnmcombo.Text = table.Rows[b]["C_Name"].ToString().TrimStart();
                    pnmtxt.Text = table.Rows[b]["P_Name"].ToString();
                    cq1 = Convert.ToInt32(table.Rows[b]["CQ"]);
                    ctntxt.Text = Convert.ToString(cq1);
                    bq = Convert.ToInt32(table.Rows[b]["BQ"]);
                    bxtxt.Text = table.Rows[b]["BQ"].ToString();
                    totxt.Text = (table.Rows[b]["Total_To"]).ToString();
                    pertxt.Text = table.Rows[b]["Percentage"].ToString();
                    amttxt.Text = table.Rows[b]["Final_Bill"].ToString();
                    
                    string sql = "Select * From SK_Sale_Bill where Bill_No='" + input + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql;
                   reader=cmd.ExecuteReader();
                   while (reader.Read())
                       fatxt.Text = reader.GetValue(6).ToString();
                    cn1.Close();
                    chk = 1;

                }
                else
                {
                    MessageBox.Show("Rrecord Not In Table");
                    cn1.Close();
                }
            }
            else if (chk == 1)
            {
                pnmtxt.Clear(); snmtxt.Clear(); snmcombo.Text = ""; cnmcombo.Text = "";
                pnmcombo.Text = ""; enmcombo.Text = ""; amttxt.Clear(); bsptxt.Clear();
                bxtxt.Text = "0"; ctntxt.Text = "0"; totxt.Text = "0"; bq = 0; IDtxt.Clear();
                roitxt.Text = "0"; tatxt.Text = "0"; ttotxt.Text = "0"; pertxt.Text = "0";
                patxt.Text = "0"; fatxt.Text = "0";

                string sql = "Update Sale_Invoice set SK_Name='"+snmtxt.Text+"',C_Name='"+cnmcombo.Text+"',P_Name='"+pnmcombo.Text+"',E_Name='"+enmcombo.Text+"',CQ='"+ctntxt.Text+"',BQ='"+bxtxt.Text+"',Total_To='"+totxt.Text+"',Percentage='"+pertxt.Text+"',Final_Bill='"+amttxt.Text+"' where Bill_No='" + input + "' and C_Name='" + input1 + "' and P_Name='"+input2+"'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                chk = 0;
                cn1.Close();
                
                string sql1 = "Update SK_Sale_Bill set SK_ID='"+IDtxt.Text+"',SK_Name='"+snmtxt.Text+"',E_Name='"+enmcombo.Text+"',Total_Amount='"+fatxt.Text+"' where Bill_No='"+input+"'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql1;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully....!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                chk = 0;
                cn1.Close();

                string sql2 = "select * from Sale_Invoice";
                cn1.Open();
                da = new SqlDataAdapter(sql2, cn1);
                ds = new DataSet();
                da.Fill(ds, "Sale_Invoice");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Sale_Invoice";
                cn1.Close();

                button1.Enabled =true;
                button2.Enabled =true;
                button6.Enabled =true;
                button3.FlatAppearance.BorderColor = Color.Red;
                chk = 0;

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string skid = "", sadd = "",tamt="",tto="",dis="",cno="",pam="",sknm="",bn="",pcnt="",billno="",ec="";
            int cnting = 0;// j = 0;
            TodaySaleDetail todaysd = new TodaySaleDetail();
            SqlConnection con = new SqlConnection();
            DataSet ds1 = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Hamid_Bhutta_and_Brothers.Properties.Setting.DistributionSetup"].ToString();

            string sql1 = "Select * From Sale_Invoice where E_Name='" + textBox1.Text + "' and Sale_Date='" + dateTimePicker1.Value + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql1, cn1);
            ds = new DataSet();
            da.Fill(ds, "Sale_Invoice");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Sale_Invoice";
            cn1.Close();

            cnting = 0;
            string sql5 = "Select Count(Bill_No) From SK_Sale_Bill where E_Name='" + textBox1.Text + "' and Bill_Date='" + dateTimePicker1.Value + "'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql5;
            cnting=Convert.ToInt32(cmd.ExecuteScalar());
            cn1.Close();

            for (int j = 0; j <= cnting - 1; j++)
            {   //Yahan Hamid Ny Employ Ka Cell No bill print p ly jany k lye Coding ki h
                string sql9 = "Select * From EmployRec where Employ_Name='" + textBox1.Text + "'";
                da = new SqlDataAdapter(sql9, cn1);
                ds = new DataSet();
                da.Fill(ds, "EmployRec");
                c = ds.Tables["EmployRec"].Rows.Count;
                for (i = 0; i <= c - 1; i++)
                {
                    TextObject txt9;
                    ec = (ds.Tables["EmployRec"].Rows[i]["Employ_Cell"]).ToString();
                    txt9 = (TextObject)todaysd.ReportDefinition.ReportObjects["Text21"];
                    txt9.Text = ec;
 
                }


                string sql3 = "Select * From SK_Sale_Bill where E_Name='" + textBox1.Text + "' and Bill_Date='" + dateTimePicker1.Value + "'";
                da = new SqlDataAdapter(sql3, cn1);
                ds = new DataSet();
                da.Fill(ds, "SK_Sale_Bill");
                c = ds.Tables["SK_Sale_Bill"].Rows.Count;
                for (i = 0; i <= c - 1; i++)
                {
                    billno = (ds.Tables["SK_Sale_Bill"].Rows[i]["Bill_No"]).ToString();
                    bn = (ds.Tables["SK_Sale_Bill"].Rows[i]["SK_ID"]).ToString();
                    sknm = (ds.Tables["SK_Sale_Bill"].Rows[i]["SK_Name"]).ToString();
                    sadd = (ds.Tables["SK_Sale_Bill"].Rows[i]["SK_Address"]).ToString();
                    tamt = (ds.Tables["SK_Sale_Bill"].Rows[i]["Total_Amount"]).ToString();
                    tto = (ds.Tables["SK_Sale_Bill"].Rows[i]["Total_TO"]).ToString();
                    dis = (ds.Tables["SK_Sale_Bill"].Rows[i]["Discount"]).ToString();
                    cno = (ds.Tables["SK_Sale_Bill"].Rows[i]["Contact"]).ToString();
                    pam = (ds.Tables["SK_Sale_Bill"].Rows[i]["P_Amount"]).ToString();
                    pcnt = (ds.Tables["SK_Sale_Bill"].Rows[i]["Prcnt"]).ToString();
                     
                    TextObject txt, txt2, txt3, txt4, txt5, txt6, txt7, txt8;
                    txt = (TextObject)todaysd.ReportDefinition.ReportObjects["Text22"];
                    txt2 = (TextObject)todaysd.ReportDefinition.ReportObjects["Text28"];
                    txt3 = (TextObject)todaysd.ReportDefinition.ReportObjects["Text30"];

   //FILHAAL PREVIOUS AMOUNT KO COMMENT KIAA HAI JB KHATA RECORD KO SET KR LEN GY TO IS KA COMMENT HATA DEN GY
                  //  txt4 = (TextObject)todaysd.ReportDefinition.ReportObjects["Text9"];
                    txt5 = (TextObject)todaysd.ReportDefinition.ReportObjects["Text12"];
                    txt6 = (TextObject)todaysd.ReportDefinition.ReportObjects["Text15"];
                    txt7 = (TextObject)todaysd.ReportDefinition.ReportObjects["Text24"];
                    txt8 = (TextObject)todaysd.ReportDefinition.ReportObjects["Text17"];
                   
                    txt.Text = bn;
                    txt2.Text = cno;
                    txt3.Text = sadd;
                  //  txt4.Text = pam;
                    txt5.Text = tto;
                    txt6.Text = dis;
                    txt7.Text = tamt;
                    txt8.Text = pcnt;
                                    
                   
                    
                     


                        

                                              
                    


                        string sql2 = "select * from Sale_Invoice where E_Name='" + textBox1.Text + "' and Sale_Date='" + dateTimePicker1.Value + "' and SK_Name='" + sknm + "' and Bill_No='" + billno + "'";
                        ds1 = new DataSet();
                        da1 = new SqlDataAdapter(sql2, con);
                        da1.Fill(ds1, "Sale_Invoice");
                        DataTable dt = ds1.Tables["Sale_Invoice"];
                        todaysd.SetDataSource(ds1.Tables["Sale_Invoice"]);
                        //code remove from here                                    
                        crystalReportViewer1.ReportSource = todaysd;
                        crystalReportViewer1.Zoom(1);
                        //todaysd.PrintOptions.PrinterName = @"Control Panel\Hardware and Sound\Devices and Printers\HP LaserJet P2050 Series PCL6";
                        todaysd.PrintOptions.PrinterName = printDocument1.PrinterSettings.PrinterName;
                        // todaysd.PrintOptions.PaperSize =
                        todaysd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                        crystalReportViewer1.PrintReport();
                        /* PrintDialog pd = new PrintDialog();
                          if (pd.ShowDialog() == DialogResult.OK)
                          {
                              CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                              rd.Load(Application.StartupPath + "\\ShopkeeperBillDetailReport.rpt");
                              rd.PrintOptions.PrinterName = pd.PrinterSettings.PrinterName;
                              rd.PrintToPrinter(pd.PrinterSettings.Copies, pd.PrinterSettings.Collate, pd.PrinterSettings.FromPage, pd.PrinterSettings.ToPage);
                          }*/
                    }
                    cn1.Close();
                    break;
                }
            
            string sql4 = "select count(Bill_No) from SK_Sale_Bill";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql4;
            cnt = Convert.ToInt32(cmd.ExecuteScalar());
            bnotxt.Text = Convert.ToString(cnt + 1);
            cn1.Close();
        }

        private void Sale_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void IDtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void enmcombo_Leave(object sender, EventArgs e)
        {
            if (enmcombo.Text == "")
            {
                MessageBox.Show("Please select Employ Must");
                enmcombo.Focus();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            
        }

        private void troitxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void pertxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Leave(object sender, EventArgs e)
        {
            snmcombo.Focus();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            snmcombo.Focus();
        }

        private void distxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void distxt_Leave(object sender, EventArgs e)
        {
            fatxt.Text = Convert.ToString(Convert.ToDouble(fatxt.Text) - Convert.ToDouble(distxt.Text));
            //YAHAN PAR HAMID NY FORMULA LAGAYA HAI NECHY WALA ........!!!!!!!!!
            tatxt.Text = Convert.ToString(Convert.ToDouble(tatxt.Text) - Convert.ToDouble(distxt.Text));
            troitxt.Text = Convert.ToString(Convert.ToDouble(troitxt.Text) - Convert.ToDouble(distxt.Text));
            MessageBox.Show("Discount Done Successfully....!" + distxt.Text + "Information");
            //  distxt.Text = "0";
            distxt.Enabled = false;
        }
            //  distxt.Text = "0";
            //YAHAN PAR HAMID NY CODE LAGAYA HAI TAA K DISCOUNT K BAD SALE INVOICE TABLE UPDATE HO JAE


            
           /* string sql3 = "select * from Sale_Invoice where Bill_No='" + bnotxt.Text + "' and SK_Name='" + snmtxt.Text + "'";
            da = new SqlDataAdapter(sql3, cn1);
            DataSet ds = new DataSet();
            da.Fill(ds, "Sale_Invoice");
            c = ds.Tables["Sale_Invoice"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                cnm = (ds.Tables["Sale_Invoice"].Rows[i]["C_Name"]).ToString();
                pnm = (ds.Tables["Sale_Invoice"].Rows[i]["P_Name"]).ToString();
                roi = Convert.ToDouble(ds.Tables["Sale_Invoice"].Rows[i]["ROI_Amount"]);
                percentage = Convert.ToDouble(ds.Tables["Sale_Invoice"].Rows[i]["Percentage"]);
                final = Convert.ToDouble(ds.Tables["Sale_Invoice"].Rows[i]["Final_Bill"]);
                cn1.Close();
            }



            final = final - Convert.ToDouble(distxt.Text);
            roi = roi - Convert.ToDouble(distxt.Text);

            string sql = "Update Sale_Invoice set Final_Bill='" + final + "',ROI_Amount='" + roi + "',Percentage='" + percentage + "' where Bill_No='" + bnotxt.Text + "' and C_Name='" + cnm + "' and P_Name='" + pnm + "'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            cn1.Close();
           
        }*/

        private void bsptxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
    }       
}
