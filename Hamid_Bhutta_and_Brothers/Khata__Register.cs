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
    public partial class Khata__Register : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int i = 0, c = 0, eff = 0, b = 0;
        double tam=0,ramt=0,wkamt=0,ct=0;
           double mamt = 0,tamt=0,wamt=0,thamt=0,samt=0,suamt=0;
           DateTime date;
           string ara = "";
        public Khata__Register()
        {
            InitializeComponent();
        }

        private void Khata__Register_Load(object sender, EventArgs e)
        {
           label3.Text=Convert.ToString(DateTime.Now.Date.DayOfWeek);
            string cn = "";
           enmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
           enmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
            string sql2 = "select Distinct(E_Name) from Khata_Record";
            cn1.Open();
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "Khata_Record");
            c = ds.Tables["Khata_Record"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                enmcombo.Items.Add(ds.Tables["Khata_Record"].Rows[i]["E_Name"]);
                cn = ds.Tables["Khata_Record"].Rows[i]["E_Name"].ToString();
                col1.Add(cn);
            }
            cn1.Close();
           enmcombo.AutoCompleteCustomSource = col1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void enmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Ye Nechy Wala Code Hamid Ny Lgya Hai ...........!!!!!
            cretxt.Text = "0";
            string sql2 = "select * from Khata_Record where E_Name='" + enmcombo.Text + "'"; // and E_Name='" + enmcombo.Text + "' and Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql2;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ct = Convert.ToDouble(reader.GetValue(12));
                cretxt.Text = Convert.ToString(Convert.ToDouble(cretxt.Text) + ct);
            }
            cn1.Close();
            string sql12 = "select SK_ID,SK_Name,SK_Address,T_Amount,Sat,Sun,Mon,Tue,Wed,Thu,R_Amount from Khata_Record where E_Name='" + enmcombo.Text + "'";
            cn1.Open(); 
            da = new SqlDataAdapter(sql12, cn1);
            ds = new DataSet();
            da.Fill(ds, "Khata_Record");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Khata_Record";
            cn1.Close();
           

           snmcombo.Items.Clear();
           snmcombo.Text = "";
            string pn = "";
           snmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
          snmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            string sql = "select SK_Name from Khata_Record where E_Name='" +enmcombo.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql, cn1);
            ds = new DataSet();
            da.Fill(ds, "Khata_Record");
            c = ds.Tables["Khata_Record"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
              snmcombo.Items.Add(ds.Tables["Khata_Record"].Rows[i]["SK_Name"]);
                pn = ds.Tables["Khata_Record"].Rows[i]["SK_Name"].ToString();
                col.Add(pn);
            }
            cn1.Close();
           snmcombo.AutoCompleteCustomSource = col;
        }

        private void snmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IDtxt_Leave(object sender, EventArgs e)
        {
            
                       DateTime sd = dateTimePicker1.Value.Date;
                       DateTime ed = dateTimePicker2.Value.Date ;
                TimeSpan ts = sd - ed;
                int day = ts.Days;
                Durtxt.Text = Convert.ToString(day) ;

            string sql = "select Date,SK_ID,SK_Name,SK_Address,R_Amount,Area from Khata_Record where E_Name='" + enmcombo.Text + "' and SK_ID='"+IDtxt.Text+"'";
            cn1.Open();
            cmd = new SqlCommand(sql, cn1);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            DataTable table = new DataTable();
            eff = da.Fill(table);
            if (eff != 0)
            {
                dateTimePicker2.Text = table.Rows[b]["Date"].ToString();
                IDtxt.Text = table.Rows[b]["SK_ID"].ToString(); 
                snmcombo.Text =table.Rows[b]["SK_Name"].ToString();
                //addtxt.Text =table.Rows[b]["SK_Address"].ToString();
                amttxt.Text =table.Rows[b]["R_Amount"].ToString();
                textBox2.Text = table.Rows[b]["Area"].ToString();
                cn1.Close();
            }
            else 
            {
                MessageBox.Show("Data Not In Table OR Employ_Name Have Not Customer Detail","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                cn1.Close();
                IDtxt.Clear();
            }



            string sql2 = "select SK_ID,SK_Name,SK_Address,T_Amount,Sat,Sun,Mon,Tue,Wed,Thu,R_Amount from Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name='" + enmcombo.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "Khata_Record");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Khata_Record";
            cn1.Close();

            

        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please Verify All the Data Before Submit", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (label3.Text == "Monday")
                {   
                    string sql = "select Sat,Sun,Mon,Tue,Wed,Thu,T_Amount,R_Amount from Khata_Record where E_Name='" + enmcombo.Text + "' and SK_ID='" + IDtxt.Text + "'";
                    cn1.Open();
                    cmd = new SqlCommand(sql, cn1);
                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    DataTable table = new DataTable();
                    eff = da.Fill(table);
                    if (eff != 0)
                    {
                        samt = Convert.ToDouble(table.Rows[b]["Sat"]);
                        suamt = Convert.ToDouble(table.Rows[b]["Sun"]);
                        mamt = Convert.ToDouble(table.Rows[b]["Mon"]);
                        tamt = Convert.ToDouble(table.Rows[b]["Tue"]);
                        wamt = Convert.ToDouble(table.Rows[b]["Wed"]);
                        thamt = Convert.ToDouble(table.Rows[b]["Thu"]);
                        tam = Convert.ToDouble(table.Rows[b]["T_Amount"]);
                        ramt = Convert.ToDouble(table.Rows[b]["R_Amount"]);
                    }
                    cn1.Close();
                    if (ramt != 0)
                    {
                        mamt = 0;
                        mamt = mamt + Convert.ToDouble(destxt.Text);
                      //  wkamt = samt + suamt + mamt + tamt + wamt + thamt;
                        ramt = ramt - Convert.ToDouble(destxt.Text); 
                        if (ramt == 0)
                        {
                            string sql4 = "Delete Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name= '" + enmcombo.Text + "'";
                            cn1.Open();
                            cmd.Connection = cn1;
                            cmd.CommandText = sql4;
                            cmd.ExecuteNonQuery();
                            cn1.Close();
                            Totaltxt.Text = Convert.ToString(Convert.ToDouble(Totaltxt.Text) + Convert.ToDouble(destxt.Text));
                            destxt.Clear();
                           

                            MessageBox.Show("Remaining Amount = 0... And Record Deleted....!!! ", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string sql2 = "Update Khata_Record set Mon='" + mamt + "',R_Amount='" + ramt + "' where SK_ID='" + IDtxt.Text + "' and E_Name='" + enmcombo.Text + "'";
                            cn1.Open();
                            cmd.Connection = cn1;
                            cmd.CommandText = sql2;
                            cmd.ExecuteNonQuery();
                            cn1.Close();

                            string sql1 = "select SK_ID,SK_Name,SK_Address,T_Amount,Sat,Sun,Mon,Tue,Wed,Thu,R_Amount from Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name='" + enmcombo.Text + "'";
                            cn1.Open();
                            da = new SqlDataAdapter(sql1, cn1);
                            ds = new DataSet();
                            da.Fill(ds, "Khata_Record");
                            dataGridView1.DataSource = ds;
                            dataGridView1.DataMember = "Khata_Record";
                            cn1.Close();
                            Totaltxt.Text = Convert.ToString(Convert.ToDouble(Totaltxt.Text) + Convert.ToDouble(destxt.Text));
                            destxt.Clear();
                            MessageBox.Show("Data Added Successfully....!!! ", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                                    }
                else if (label3.Text == "Tuesday")
                {
                    string sql = "select Sat,Sun,Mon,Tue,Wed,Thu,T_Amount,R_Amount from Khata_Record where E_Name='" + enmcombo.Text + "' and SK_ID='" + IDtxt.Text + "'";
                    cn1.Open();
                    cmd = new SqlCommand(sql, cn1);
                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    DataTable table = new DataTable();
                    eff = da.Fill(table);
                    if (eff != 0)
                    {
                        samt = Convert.ToDouble(table.Rows[b]["Sat"]);
                        suamt = Convert.ToDouble(table.Rows[b]["Sun"]);
                        mamt = Convert.ToDouble(table.Rows[b]["Mon"]);
                        tamt = Convert.ToDouble(table.Rows[b]["Tue"]);
                        wamt = Convert.ToDouble(table.Rows[b]["Wed"]);
                        thamt = Convert.ToDouble(table.Rows[b]["Thu"]);
                        tam = Convert.ToDouble(table.Rows[b]["T_Amount"]);
                        ramt = Convert.ToDouble(table.Rows[b]["R_Amount"]);
                    }
                    cn1.Close();
                    if (ramt != 0)
                    {
                        tamt = 0;
                        tamt = tamt + Convert.ToDouble(destxt.Text);
                       // wkamt = samt + suamt + mamt + tamt + wamt + thamt;
                       // MessageBox.Show("Week amount= " + wkamt);
                        ramt = ramt - Convert.ToDouble(destxt.Text); 
                        if (ramt == 0)
                        {
                            string sql4 = "Delete Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name= '" + enmcombo.Text + "'";
                            cn1.Open();
                            cmd.Connection = cn1;
                            cmd.CommandText = sql4;
                            cmd.ExecuteNonQuery();
                            cn1.Close();
                            Totaltxt.Text = Convert.ToString(Convert.ToDouble(Totaltxt.Text) + Convert.ToDouble(destxt.Text));
                            destxt.Clear();

                            MessageBox.Show("Remaining Amount = 0... And Record Deleted....!!! ", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string sql2 = "Update Khata_Record set Tue='" + tamt + "',R_Amount='" + ramt + "' where SK_ID='" + IDtxt.Text + "' and E_Name='" + enmcombo.Text + "'";
                            cn1.Open();
                            cmd.Connection = cn1;
                            cmd.CommandText = sql2;
                            cmd.ExecuteNonQuery();
                            cn1.Close();


                            string sql1 = "select SK_ID,SK_Name,SK_Address,T_Amount,Sat,Sun,Mon,Tue,Wed,Thu,R_Amount from Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name='" + enmcombo.Text + "'";
                            cn1.Open();
                            da = new SqlDataAdapter(sql1, cn1);
                            ds = new DataSet();
                            da.Fill(ds, "Khata_Record");
                            dataGridView1.DataSource = ds;
                            dataGridView1.DataMember = "Khata_Record";
                            cn1.Close();
                            Totaltxt.Text = Convert.ToString(Convert.ToDouble(Totaltxt.Text) + Convert.ToDouble(destxt.Text));
                            destxt.Clear();
                            MessageBox.Show("Data Added Successfully....!!! ", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    
                }
                else if (label3.Text == "Wednesday")
                {
                    string sql = "select Sat,Sun,Mon,Tue,Wed,Thu,T_Amount,R_Amount from Khata_Record where E_Name='" + enmcombo.Text + "' and SK_ID='" + IDtxt.Text + "'";
                    cn1.Open();
                    cmd = new SqlCommand(sql, cn1);
                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    DataTable table = new DataTable();
                    eff = da.Fill(table);
                    if (eff != 0)
                    {
                        samt = Convert.ToDouble(table.Rows[b]["Sat"]);
                        suamt = Convert.ToDouble(table.Rows[b]["Sun"]);
                        mamt = Convert.ToDouble(table.Rows[b]["Mon"]);
                        tamt = Convert.ToDouble(table.Rows[b]["Tue"]);
                        wamt = Convert.ToDouble(table.Rows[b]["Wed"]);
                        thamt = Convert.ToDouble(table.Rows[b]["Thu"]);
                        tam = Convert.ToDouble(table.Rows[b]["T_Amount"]);
                        ramt = Convert.ToDouble(table.Rows[b]["R_Amount"]);
                    }
                    cn1.Close();
                    if (ramt != 0)
                    {
                        wamt = 0;
                        wamt = wamt + Convert.ToDouble(destxt.Text);
                        //wkamt = samt + suamt + mamt + tamt + wamt + thamt;
                        ramt = ramt - Convert.ToDouble(destxt.Text); 
                        if (ramt == 0)
                        {
                            string sql4 = "Delete Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name= '" + enmcombo.Text + "'";
                            cn1.Open();
                            cmd.Connection = cn1;
                            cmd.CommandText = sql4;
                            cmd.ExecuteNonQuery();
                            cn1.Close();
                            Totaltxt.Text = Convert.ToString(Convert.ToDouble(Totaltxt.Text) + Convert.ToDouble(destxt.Text));
                            destxt.Clear();

                            MessageBox.Show("Remaining Amount = 0... And Record Deleted....!!! ", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string sql2 = "Update Khata_Record set Wed='" + wamt + "',R_Amount='" + ramt + "' where SK_ID='" + IDtxt.Text + "' and E_Name='" + enmcombo.Text + "'";
                            cn1.Open();
                            cmd.Connection = cn1;
                            cmd.CommandText = sql2;
                            cmd.ExecuteNonQuery();
                            cn1.Close();


                            string sql1 = "select SK_ID,SK_Name,SK_Address,T_Amount,Sat,Sun,Mon,Tue,Wed,Thu,R_Amount from Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name='" + enmcombo.Text + "'";
                            cn1.Open();
                            da = new SqlDataAdapter(sql1, cn1);
                            ds = new DataSet();
                            da.Fill(ds, "Khata_Record");
                            dataGridView1.DataSource = ds;
                            dataGridView1.DataMember = "Khata_Record";
                            cn1.Close();
                            Totaltxt.Text = Convert.ToString(Convert.ToDouble(Totaltxt.Text) + Convert.ToDouble(destxt.Text));
                            destxt.Clear();
                            MessageBox.Show("Data Added Successfully....!!! ", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    

                }
                else if (label3.Text == "Thursday")
                {
                    string sql = "select Sat,Sun,Mon,Tue,Wed,Thu,T_Amount,R_Amount from Khata_Record where E_Name='" + enmcombo.Text + "' and SK_ID='" + IDtxt.Text + "'";
                    cn1.Open();
                    cmd = new SqlCommand(sql, cn1);
                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    DataTable table = new DataTable();
                    eff = da.Fill(table);
                    if (eff != 0)
                    {

                        samt = Convert.ToDouble(table.Rows[b]["Sat"]);
                        suamt = Convert.ToDouble(table.Rows[b]["Sun"]);
                        mamt = Convert.ToDouble(table.Rows[b]["Mon"]);
                        tamt = Convert.ToDouble(table.Rows[b]["Tue"]);
                        wamt = Convert.ToDouble(table.Rows[b]["Wed"]);
                        thamt = Convert.ToDouble(table.Rows[b]["Thu"]);
                        tam = Convert.ToDouble(table.Rows[b]["T_Amount"]);
                        ramt = Convert.ToDouble(table.Rows[b]["R_Amount"]);
                    }
                    cn1.Close();
                    if (ramt != 0)
                    {
                        thamt = 0;
                        thamt = thamt + Convert.ToDouble(destxt.Text);
                        //wkamt = samt + suamt + mamt + tamt + wamt + thamt;
                        ramt = ramt - Convert.ToDouble(destxt.Text); 
                        if (ramt == 0)
                        {
                            string sql4 = "Delete Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name= '" + enmcombo.Text + "'";
                            cn1.Open();
                            cmd.Connection = cn1;
                            cmd.CommandText = sql4;
                            cmd.ExecuteNonQuery();
                            cn1.Close();
                            Totaltxt.Text = Convert.ToString(Convert.ToDouble(Totaltxt.Text) + Convert.ToDouble(destxt.Text));
                            destxt.Clear();

                            MessageBox.Show("Remaining Amount = 0... And Record Deleted....!!! ", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string sql2 = "Update Khata_Record set Thu='" + thamt + "',R_Amount='" + ramt + "' where SK_ID='" + IDtxt.Text + "' and E_Name='" + enmcombo.Text + "'";
                            cn1.Open();
                            cmd.Connection = cn1;
                            cmd.CommandText = sql2;
                            cmd.ExecuteNonQuery();
                            cn1.Close();


                            string sql1 = "select SK_ID,SK_Name,SK_Address,T_Amount,Sat,Sun,Mon,Tue,Wed,Thu,R_Amount from Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name='" + enmcombo.Text + "'";
                            cn1.Open();
                            da = new SqlDataAdapter(sql1, cn1);
                            ds = new DataSet();
                            da.Fill(ds, "Khata_Record");
                            dataGridView1.DataSource = ds;
                            dataGridView1.DataMember = "Khata_Record";
                            cn1.Close();
                            Totaltxt.Text = Convert.ToString(Convert.ToDouble(Totaltxt.Text) + Convert.ToDouble(destxt.Text));
                            destxt.Clear();
                            MessageBox.Show("Data Added Successfully....!!! ", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                                    }
                else if (label3.Text == "Saturday")
                {
                    string sql = "select Sat,Sun,Mon,Tue,Wed,Thu,T_Amount,R_Amount from Khata_Record where E_Name='" + enmcombo.Text + "' and SK_ID='" + IDtxt.Text + "'";
                    cn1.Open();
                    cmd = new SqlCommand(sql, cn1);
                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    DataTable table = new DataTable();
                    eff = da.Fill(table);
                    if (eff != 0)
                    {

                        samt = Convert.ToDouble(table.Rows[b]["Sat"]);
                        suamt = Convert.ToDouble(table.Rows[b]["Sun"]);
                        mamt = Convert.ToDouble(table.Rows[b]["Mon"]);
                        tamt = Convert.ToDouble(table.Rows[b]["Tue"]);
                        wamt = Convert.ToDouble(table.Rows[b]["Wed"]);
                        thamt = Convert.ToDouble(table.Rows[b]["Thu"]);
                        tam = Convert.ToDouble(table.Rows[b]["T_Amount"]);
                        ramt = Convert.ToDouble(table.Rows[b]["R_Amount"]);
                    }
                    cn1.Close();
                    if (ramt != 0)
                    {
                        samt = 0;
                        samt = samt + Convert.ToDouble(destxt.Text);
                        //wkamt = samt + suamt + mamt + tamt + wamt + thamt;
                        ramt = ramt - Convert.ToDouble(destxt.Text); 
                        if (ramt == 0)
                        {
                            string sql4 = "Delete Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name= '" + enmcombo.Text + "'";
                            cn1.Open();
                            cmd.Connection = cn1;
                            cmd.CommandText = sql4;
                            cmd.ExecuteNonQuery();
                            cn1.Close();
                            Totaltxt.Text = Convert.ToString(Convert.ToDouble(Totaltxt.Text) + Convert.ToDouble(destxt.Text));
                            destxt.Clear();

                            MessageBox.Show("Remaining Amount = 0... And Record Deleted....!!! ", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string sql2 = "Update Khata_Record set Sat='" + samt + "',R_Amount='" + ramt + "' where SK_ID='" + IDtxt.Text + "' and E_Name='" + enmcombo.Text + "'";
                            cn1.Open();
                            cmd.Connection = cn1;
                            cmd.CommandText = sql2;
                            cmd.ExecuteNonQuery();
                            cn1.Close();

                            string sql1 = "select SK_ID,SK_Name,SK_Address,T_Amount,Sat,Sun,Mon,Tue,Wed,Thu,R_Amount from Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name='" + enmcombo.Text + "'";
                            cn1.Open();
                            da = new SqlDataAdapter(sql1, cn1);
                            ds = new DataSet();
                            da.Fill(ds, "Khata_Record");
                            dataGridView1.DataSource = ds;
                            dataGridView1.DataMember = "Khata_Record";
                            cn1.Close();
                            Totaltxt.Text = Convert.ToString(Convert.ToDouble(Totaltxt.Text) + Convert.ToDouble(destxt.Text));
                            destxt.Clear();
                            MessageBox.Show("Data Added Successfully....!!! ", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    
                }
                else if (label3.Text == "Sunday")
                {
                    string sql = "select Sat,Sun,Mon,Tue,Wed,Thu,T_Amount,R_Amount from Khata_Record where E_Name='" + enmcombo.Text + "' and SK_ID='" + IDtxt.Text + "'";
                    cn1.Open();
                    cmd = new SqlCommand(sql, cn1);
                    da = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    DataTable table = new DataTable();
                    eff = da.Fill(table);
                    if (eff != 0)
                    {
                        samt = Convert.ToDouble(table.Rows[b]["Sat"]);
                        suamt = Convert.ToDouble(table.Rows[b]["Sun"]);
                        mamt = Convert.ToDouble(table.Rows[b]["Mon"]);
                        tamt = Convert.ToDouble(table.Rows[b]["Tue"]);
                        wamt = Convert.ToDouble(table.Rows[b]["Wed"]);
                        thamt = Convert.ToDouble(table.Rows[b]["Thu"]);
                        tam = Convert.ToDouble(table.Rows[b]["T_Amount"]);
                        ramt = Convert.ToDouble(table.Rows[b]["R_Amount"]);
                        
                    }
                    cn1.Close();
                    if (ramt != 0)
                    {
                        suamt = 0;
                        suamt = suamt + Convert.ToDouble(destxt.Text);
                       // wkamt = samt + suamt + mamt + tamt + wamt + thamt;
                        ramt = ramt - Convert.ToDouble(destxt.Text);
                      
                        MessageBox.Show( "ramt value=" + ramt);

                        if (ramt == 0)
                        {
                            string sql4 = "Delete Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name= '" + enmcombo.Text + "'";
                            cn1.Open();
                            cmd.Connection = cn1;
                            cmd.CommandText = sql4;
                            cmd.ExecuteNonQuery();
                            cn1.Close();
                            Totaltxt.Text = Convert.ToString(Convert.ToDouble(Totaltxt.Text) + Convert.ToDouble(destxt.Text));
                            destxt.Clear();

                            MessageBox.Show("Remaining Amount = 0... And Record Deleted....!!! ", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string sql2 = "Update Khata_Record set Sun='" + suamt + "',R_Amount='" + ramt + "' where SK_ID='" + IDtxt.Text + "' and E_Name='" + enmcombo.Text + "'";
                            cn1.Open();
                            cmd.Connection = cn1;
                            cmd.CommandText = sql2;
                            cmd.ExecuteNonQuery();
                            cn1.Close();

                            string sql1 = "select SK_ID,SK_Name,SK_Address,T_Amount,Sat,Sun,Mon,Tue,Wed,Thu,R_Amount from Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name='" + enmcombo.Text + "'";
                            cn1.Open();
                            da = new SqlDataAdapter(sql1, cn1);
                            ds = new DataSet();
                            da.Fill(ds, "Khata_Record");
                            dataGridView1.DataSource = ds;
                            dataGridView1.DataMember = "Khata_Record";
                            cn1.Close();
                            Totaltxt.Text = Convert.ToString(Convert.ToDouble(Totaltxt.Text) + Convert.ToDouble(destxt.Text));
                            destxt.Clear();
                            MessageBox.Show("Data Added Successfully....!!! ", "Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    
                }
                snmcombo.Text = ""; IDtxt.Clear(); amttxt.Clear(); textBox2.Clear();
                //addtxt.Clear();

            }
        }
        private void Khata__Register_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            snmcombo.Text = ""; IDtxt.Clear(); amttxt.Clear(); textBox2.Clear();
            //addtxt.Clear();
          //  button2.Enabled = true; button3.Enabled = true;
           
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

        private void destxt_KeyPress(object sender, KeyPressEventArgs e)
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
                    this.SelectNextControl(destxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           /* KhataReport kr = new KhataReport();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Hamid_Bhutta_and_Brothers.Properties.Setting.DistributionSetup"].ToString();
            DataSet ds1 = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter();*/

            if (enmcombo.Text == "" || enmcombo.Text == "Employ Name")
                MessageBox.Show("Please Select Employ Name First");
            else 
            {
                KhataReport kr = new KhataReport();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Hamid_Bhutta_and_Brothers.Properties.Setting.DistributionSetup"].ToString();
                string sql1 = "select * from Khata_Record where E_Name='" + enmcombo.Text + "'";
               DataSet ds1 = new DataSet();
               SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
                da1.Fill(ds1, "Khata_Record");
                DataTable dt = ds1.Tables["Khata_Record"];
                kr.SetDataSource(ds1.Tables["Khata_Record"]);
                crystalReportViewer1.ReportSource = kr;
                //  crystalReportViewer1.PrintReport();
                crystalReportViewer1.Refresh();
            }
           /* else
            {
                string sql2 = "select * from Khata_Record where E_Name='" + enmcombo.Text + "'";
                da = new SqlDataAdapter(sql2, cn1);
                ds = new DataSet();
                da.Fill(ds, "Khata_Record");
                c = ds.Tables["Khata_Record"].Rows.Count;
                MessageBox.Show("value c is=" + c);
               for (i = 0; i <= c- 1; i++)
                {
                    ara = (ds.Tables["Khata_Record"].Rows[i]["Area"]).ToString();
                    MessageBox.Show("area is=" + ara);
                    string sql1 = "select * from Khata_Record where E_Name='"+enmcombo.Text+"' and Area='"+ara+"'";
                    ds1 = new DataSet();
                    da1 = new SqlDataAdapter(sql1, con);
                    da1.Fill(ds1, "Khata_Record");
                    DataTable dt = ds1.Tables["Khata_Record"];
                    kr.SetDataSource(ds1.Tables["Khata_Record"]);
                    crystalReportViewer1.ReportSource = kr;
                  //  crystalReportViewer1.PrintReport();
                    crystalReportViewer1.Refresh();
                }
               cn1.Close();
            }*/
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void destxt_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Leave(object sender, EventArgs e)
        {
            IDtxt.Focus();
        }

        //YE CODE HAMID NY COPY PASTE KIA HAI TA K Snmcombo SE BHI DATA MIL SKY
 
        private void snmcombo_Leave(object sender, EventArgs e)
        {
            string sql = "select SK_ID,SK_Address,R_Amount,Area from Khata_Record where E_Name='" + enmcombo.Text + "' and SK_Name='" + snmcombo.Text + "'";
            cn1.Open();
            cmd = new SqlCommand(sql, cn1);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            DataTable table = new DataTable();
            eff = da.Fill(table);
            if (eff != 0)
            {

                IDtxt.Text = table.Rows[b]["SK_ID"].ToString();
                //snmcombo.Text = table.Rows[b]["SK_Name"].ToString();
                //addtxt.Text = table.Rows[b]["SK_Address"].ToString();
                amttxt.Text = table.Rows[b]["R_Amount"].ToString();
                textBox2.Text = table.Rows[b]["Area"].ToString();
                cn1.Close();
            }
            else
            {
                MessageBox.Show("Data Not In Table OR Employ_Name Have Not Customer Detail", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn1.Close();
                IDtxt.Clear();
            }

            string sql2 = "select SK_ID,SK_Name,SK_Address,T_Amount,Sat,Sun,Mon,Tue,Wed,Thu,R_Amount from Khata_Record where SK_ID='" + IDtxt.Text + "' and E_Name='" + enmcombo.Text + "'";
            cn1.Open();
            da = new SqlDataAdapter(sql2, cn1);
            ds = new DataSet();
            da.Fill(ds, "Khata_Record");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Khata_Record";
            cn1.Close();
        }
    }
}
