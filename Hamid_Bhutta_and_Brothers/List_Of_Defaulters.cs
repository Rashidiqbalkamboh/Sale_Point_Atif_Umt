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
    public partial class List_Of_Defaulters : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int i = 0, c = 0, b = 0, eff = 0;
       DateTime dt;
       Double tamt = 0, ramt = 0;
       Bitmap bitmap;
        public List_Of_Defaulters()
        {
            InitializeComponent();
        }
        private void List_Of_Defaulters_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void enmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnmcombo.Text = "";
            cnmcombo.Items.Clear();
            
            string sql3 = "select Distinct(Company_Name) from EmployRec where Employ_Name='" +enmcombo.Text + "'";
             da = new SqlDataAdapter(sql3, cn1);
             ds = new DataSet();
             da.Fill(ds, "EmployRec");
             c = ds.Tables["EmployRec"].Rows.Count;
             for (i = 0; i <= c - 1; i++)
             {
                cnmcombo.Text=ds.Tables["EmployRec"].Rows[i]["Company_Name"].ToString();
             }
             cn1.Close();
            

            if (dateTimePicker1.Value > dateTimePicker2.Value)
                MessageBox.Show("From Date Always be lesss");
            else
            {
                DateTime sd = dateTimePicker2.Value.Date;
                DateTime ed = dateTimePicker1.Value.Date;
                TimeSpan ts = sd - ed;
                int day = ts.Days;
                label1.Text = Convert.ToString(day) + " Days";
            }

            string sql = "select * from Khata_Record where E_Name='"+enmcombo.Text+"'";
            da = new SqlDataAdapter(sql, cn1);
            ds = new DataSet();
            da.Fill(ds, "Khata_Record");
            c = ds.Tables["Khata_Record"].Rows.Count;
           for (i = 0; i <= c - 1; i++)
            {
                dt = Convert.ToDateTime(ds.Tables["Khata_Record"].Rows[i]["Date"]);               
              tamt=Convert.ToDouble(ds.Tables["Khata_Record"].Rows[i]["T_Amount"]);
               ramt =Convert.ToDouble(ds.Tables["Khata_Record"].Rows[i]["R_Amount"]);
              // && dt.Date.Day <= dateTimePicker2.Value.Date.Day && dt.Date.Month <= dateTimePicker2.Value.Date.Month && dt.Date.Year <= dateTimePicker2.Value.Date.Year && dt.Date.Day >= dateTimePicker1.Value.Date.Day && dt.Date.Month >= dateTimePicker1.Value.Date.Month && dt.Date.Year >= dateTimePicker1.Value.Date.Year)
              if (tamt==ramt)
               {
                 //  MessageBox.Show("tamt" + tamt + " \nramt" + ramt);
                  string sql2 = "select Date,SK_ID,SK_Name,SK_Address,T_Amount,R_Amount,Bill_No from Khata_Record where E_Name='"+enmcombo.Text+"' and Date between '"+dateTimePicker1.Value+"' and '"+dateTimePicker2.Value+"'";
                   da = new SqlDataAdapter(sql2,cn1);
                   ds = new DataSet();
                   da.Fill(ds, "Khata_Record");
                   dataGridView1.DataSource = ds;
                   dataGridView1.DataMember = "Khata_Record";
               }
            }
            cn1.Close();

            for (int j = 0; j <= dataGridView1.Rows.Count - 1; j++)
            {
                tamt =Convert.ToDouble(dataGridView1["T_Amount", j].Value);
                ramt = Convert.ToDouble(dataGridView1["R_Amount", j].Value);
                if(tamt!=ramt)
                    dataGridView1.Rows.RemoveAt(j);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string en = "";
            enmcombo.Items.Clear();
            enmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            enmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
            string sql = "select Distinct(E_Name) from Khata_Record where Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
            da = new SqlDataAdapter(sql, cn1);
            ds = new DataSet();
            da.Fill(ds, "Khata_Record");
            c = ds.Tables["Khata_Record"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                enmcombo.Items.Add(ds.Tables["Khata_Record"].Rows[i]["E_Name"]);
                en = ds.Tables["Khata_Record"].Rows[i]["E_Name"].ToString();
                col1.Add(en);
            }
            cn1.Close();
            enmcombo.AutoCompleteCustomSource = col1;
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

        private void List_Of_Defaulters_Load(object sender, EventArgs e)
        {

        }
    }
}
