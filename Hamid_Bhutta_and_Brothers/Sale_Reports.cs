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
    public partial class Sale_Reports : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int c = 0, i = 0, chkk = 0, chk = 0, b = 0, eff = 0;
        double amt = 0, ct = 0;
        string input = "", input2 = "", input1 = "", input3 = "";
        Bitmap bitmap;
        public Sale_Reports()
        {
            InitializeComponent();
        }

        private void deptxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Sale_Reports_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void Sale_Reports_Load(object sender, EventArgs e)
        {

            //Yahan Hamid Ny Area Wise Sale lny k lye AREA Combo box m Area load kiye hyn
            string an = "";
            areacombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            areacombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            string sql12 = "select Distinct(Area_Name) from ShopKeeperRecord";
            da = new SqlDataAdapter(sql12, cn1);
            ds = new DataSet();
            da.Fill(ds, "ShopKeeperRecord");
            c = ds.Tables["ShopKeeperRecord"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                areacombo.Items.Add(ds.Tables["ShopKeeperRecord"].Rows[i]["Area_Name"]);
                an = ds.Tables["ShopKeeperRecord"].Rows[i]["Area_Name"].ToString();
                coll.Add(an);
            }
            cn1.Close();
            areacombo.AutoCompleteCustomSource = coll;
            string cnn = "";
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
            string sql1 = "select Distinct(Company_Name) from Inventry_Stock";
            da = new SqlDataAdapter(sql1, cn1);
            ds = new DataSet();
            da.Fill(ds, "Inventry_Stock");
            c = ds.Tables["Inventry_Stock"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                comboBox1.Items.Add(ds.Tables["Inventry_Stock"].Rows[i]["Company_Name"]);
                cnn = ds.Tables["Inventry_Stock"].Rows[i]["Company_Name"].ToString();
                col1.Add(cnn);
            }
            cn1.Close();
            comboBox1.AutoCompleteCustomSource = col1;
            string cn = "";
            enmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            enmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            string sql = "select Distinct(Employ_Name) from EmployRec";
            da = new SqlDataAdapter(sql, cn1);
            ds = new DataSet();
            da.Fill(ds, "EmployRec");
            c = ds.Tables["EmployRec"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                enmcombo.Items.Add(ds.Tables["EmployRec"].Rows[i]["Employ_Name"]);
                cn = ds.Tables["EmployRec"].Rows[i]["Employ_Name"].ToString();
                col.Add(cn);
            }
            cn1.Close();
            enmcombo.AutoCompleteCustomSource = col;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void enmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnmtxt.Text = "";
            deptxt.Text = "0";
            string sql = "select Distinct(Company_Name) from EmployRec where Employ_Name='" + enmcombo.Text + "'";
            da = new SqlDataAdapter(sql, cn1);
            ds = new DataSet();
            da.Fill(ds, "EmployRec");
            c = ds.Tables["EmployRec"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                cnmtxt.Text = ds.Tables["EmployRec"].Rows[i]["Company_Name"].ToString();
            }
            cn1.Close();
            if (areacombo.Text == "Area Wise Sale")
            {

            }
            else
            {
                deptxt.Text = "0";
                cnmtxt.Text = comboBox1.Text;
                string sql1 = "select * from Sale_Invoice where E_Name='" + comboBox1.Text + "' and Area='" + areacombo.Text + "' and C_Name='" + comboBox1.Text + "' and Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql1;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ct = Convert.ToDouble(reader.GetValue(10));
                    deptxt.Text = Convert.ToString(Convert.ToDouble(deptxt.Text) + ct);
                }
                cn1.Close();


            }





            /*   string sql1 = "select * from SK_Sale_Bill where E_Name='" + enmcombo.Text + "' and Bill_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";// ";//Group By P_Name having P_Name='" + pnm + "'";
               cn1.Open();
               cmd.Connection = cn1;
               cmd.CommandText = sql1;
               reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                   ct=Convert.ToDouble(reader.GetValue(6));
                   deptxt.Text = Convert.ToString(Convert.ToDouble(deptxt.Text) +ct);
               }           
               cn1.Close();

               string sql2 = "select E_Name,Total_Amount,Total_ROI from SK_Sale_Bill where E_Name='" + enmcombo.Text + "' and Bill_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
               da = new SqlDataAdapter(sql2, cn1);
               ds = new DataSet();
               da.Fill(ds, "SK_Sale_Bill");
               dataGridView1.DataSource = ds;
               dataGridView1.DataMember = "SK_Sale_Bill";
               cn1.Close();*/

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {    //YAHAN HAMID NY Sale Reports M SE DISCOUNT AOR PERCENTAGE KI VALUE MINUS KRNY K LYE CODING KI HY
            distxt.Text = "0";
            string sql13 = "select * from SK_Sale_Bill where E_Name='" + enmcombo.Text + "' and Bill_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";// ";//Group By P_Name having P_Name='" + pnm + "'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql13;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {   //Value Of Discount of All the Bills of an Employ between the selected dates
                ct = Convert.ToDouble(reader.GetValue(9));
                distxt.Text = Convert.ToString(Convert.ToDouble(distxt.Text) + ct);

            }
            cn1.Close();
            if (areacombo.Text == "Area Wise Sale")
            {


                deptxt.Text = "0";
                cnmtxt.Text = comboBox1.Text;
                string sql1 = "select * from Sale_Invoice where C_Name='" + comboBox1.Text + "' and E_Name='" + enmcombo.Text + "' and Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql1;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ct = Convert.ToDouble(reader.GetValue(10));
                    deptxt.Text = Convert.ToString(Convert.ToDouble(deptxt.Text) + ct);
                }
                cn1.Close();
                
                 if    (enmcombo.Text == "ALL EMPLOYS")
                {
                    deptxt.Text = "0";
                    cnmtxt.Text = comboBox1.Text;
                    string sql6 = "select * from Sale_Invoice where C_Name='" + comboBox1.Text + "'  and Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql6;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ct = Convert.ToDouble(reader.GetValue(10));
                        deptxt.Text = Convert.ToString(Convert.ToDouble(deptxt.Text) + ct);
                    }

                    cn1.Close();
                    //YAHAN HAMID NY Sale Reports M SE DISCOUNT AOR PERCENTAGE KI VALUE MINUS KRNY K LYE CODING KI HY
                    distxt.Text = "0";
                    string sql17 = "select * from SK_Sale_Bill where Bill_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";// ";//Group By P_Name having P_Name='" + pnm + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql17;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {   //Value Of Discount of All the Bills of an Employ between the selected dates
                        ct = Convert.ToDouble(reader.GetValue(9));
                        distxt.Text = Convert.ToString(Convert.ToDouble(distxt.Text) + ct);

                    }
                    cn1.Close();




                }

                string sql3 = "select E_Name,Final_Bill,ROI_Amount from Sale_Invoice where C_Name='" + comboBox1.Text + "' and E_Name='" + enmcombo.Text + "' and Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                da = new SqlDataAdapter(sql3, cn1);
                ds = new DataSet();
                da.Fill(ds, "Sale_Invoice");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Sale_Invoice";
                cn1.Close();

                //YAHAN NECHY HAMID NY CODE LAGAYA HAI CRETXT MAI OS EMPLOY KA TOTAL CREDIT HASIL KRNY K LYE ......!!!!
                Cretxt.Text = "0";
                string sql2 = "select * from SK_Sale_Bill where E_Name='" + enmcombo.Text + "' and Bill_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql2;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ct = Convert.ToDouble(reader.GetValue(14));
                    Cretxt.Text = Convert.ToString(Convert.ToDouble(Cretxt.Text) + ct);
                }
                cn1.Close();
            }

            else
            {
                deptxt.Text = "0";
                cnmtxt.Text = comboBox1.Text;
                string sql1 = "select * from Sale_Invoice where E_Name='" + comboBox1.Text + "' and Area='" + areacombo.Text + "' and C_Name='" + comboBox1.Text + "' and Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql1;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ct = Convert.ToDouble(reader.GetValue(10));
                    deptxt.Text = Convert.ToString(Convert.ToDouble(deptxt.Text) + ct);
                }
                cn1.Close();


            }



        }
        private void Cretxt_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void distxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void areacombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                 }
    }
}