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
    public partial class Summary_Of_Today_Supply : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true");

        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader, reader1;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        int c = 0, b = 0, i = 0 ;
        string pnm = "", ppnm = "" ;
        Double ct = 0, bx = 0, carton = 0, Tcarton = 0, sum_cq=0 , tct=0,tb=0;
        Bitmap bitmap;

        public Summary_Of_Today_Supply()
        {
            InitializeComponent();
        }
        private void Summary_Of_Today_Supply_Load(object sender, EventArgs e)
        {
            /*  string sql15 = "truncate table Sale_Invoice";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql15;
            cmd.ExecuteNonQuery();
            cn1.Close();*/

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
            enmcombo.Items.Add("ALL Employes");


            string sn1 = "";
            //  areacombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            // areacombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            string sql = "select Distinct(Area_Name) from ShopKeeperRecord";
            da = new SqlDataAdapter(sql, cn1);
            DataSet ds1 = new DataSet();
            da.Fill(ds1, "ShopKeeperRecord");
            c = ds1.Tables["ShopKeeperRecord"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                // areacombo.Items.Add(ds1.Tables["ShopKeeperRecord"].Rows[i]["Area_Name"]);
                sn = ds1.Tables["ShopKeeperRecord"].Rows[i]["Area_Name"].ToString();
                col.Add(sn);
            }
            cn1.Close();
            //areacombo.AutoCompleteCustomSource = col;

            string cn = "";
            cnmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cnmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col2 = new AutoCompleteStringCollection();
            string sql1 = "select Distinct(Company_Name) from Inventry_Stock";
            da = new SqlDataAdapter(sql1, cn1);
            ds = new DataSet();
            da.Fill(ds, "Inventry_Stock");
            c = ds.Tables["Inventry_Stock"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                cnmcombo.Items.Add(ds.Tables["Inventry_Stock"].Rows[i]["Company_Name"]);
                cn = ds.Tables["Inventry_Stock"].Rows[i]["Company_Name"].ToString();
                col2.Add(cn);
            }
            cn1.Close();
            cnmcombo.AutoCompleteCustomSource = col;




        }

        private void enmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            dataGridView1.Rows.Clear();
            int row = 0, bxsss = 0, ctnnn = 0;

            string Pname = "", ppnm = "", pnm = "";
            //  cn1.Open();
            string sql2 = "select * from Sale_Invoice where Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and E_Name='" + enmcombo.Text + "'";
            da = new SqlDataAdapter(sql2, cn1);
            DataSet ds1 = new DataSet();
            da.Fill(ds1, "Sale_Invoice");
            c = ds1.Tables["Sale_Invoice"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                pnm = Convert.ToString(ds1.Tables["Sale_Invoice"].Rows[i]["P_Name"]);
                cn1.Close();
                if (pnm == ppnm)
                {
                    continue;
                }

                string sql1 = "select Sum(CQ) from Sale_Invoice where Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and P_Name='" + pnm + "' and E_Name='" + enmcombo.Text + "'";// Group By P_Name having P_Name='" + pnm + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql1;
                ct = Convert.ToDouble(cmd.ExecuteScalar());
                cn1.Close();

                string sql = "select Sum(BQ) from Sale_Invoice where Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and P_Name='" + pnm + "' and E_Name='" + enmcombo.Text + "'";// Group By P_Name having P_Name='" + pnm + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                bx = Convert.ToDouble(cmd.ExecuteScalar());
                cn1.Close();

                dataGridView1.Rows.Add();
                row = dataGridView1.Rows.Count - 1;
                dataGridView1["Pname", row].Value = pnm.ToString();
                ppnm = pnm;
                dataGridView1["CQ", row].Value = Convert.ToString(ct);
                dataGridView1["BoxQ", row].Value = Convert.ToString(bx);
                  }
            cn1.Close();
            for (int j = 0; j <= dataGridView1.Rows.Count - 1; j++)
            {
                ppnm = dataGridView1["Pname", j].Value.ToString();
                for (int m = j + 1; m <= dataGridView1.Rows.Count - 1; m++)
                {
                    if (ppnm == dataGridView1["Pname", m].Value.ToString())
                        dataGridView1.Rows.RemoveAt(m);
                }
            }

            for (int k = 0; k <= dataGridView1.Rows.Count - 1; k++)
            {
               
                string sql11 = "select * from Inventry_Stock where Product_Name='" + dataGridView1["Pname", k].Value + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql11;
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                  
                    bxsss = Convert.ToInt32(reader.GetValue(4));
                  
                   
                    // MessageBox.Show("Product Name is = " + dataGridView1["Pname", k].Value + "\n Carton Quantity is=" + tct, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    ctnnn = Convert.ToInt32(dataGridView1["BoxQ", k].Value) / bxsss;
                   
               
                    //yahn tk add kia hy hamid ny


                    dataGridView1["CQ", k].Value = Convert.ToInt32(dataGridView1["CQ", k].Value) + ctnnn;
                  
                    dataGridView1["BoxQ", k].Value = Convert.ToInt32(dataGridView1["BoxQ", k].Value) % bxsss;
                    dataGridView1["CQ", k].Value = Convert.ToString(dataGridView1["CQ", k].Value);
                    dataGridView1["BoxQ", k].Value = Convert.ToString(dataGridView1["BoxQ", k].Value);
             
                }
                cn1.Close();
              
                
            }
            // dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count-1);

            for (int j = 0; j <= dataGridView1.Rows.Count - 1; j++)
            {
                ppnm = dataGridView1["Pname", j].Value.ToString();
                for (int m = j + 1; m <= dataGridView1.Rows.Count - 1; m++)
                {
                    if (ppnm == dataGridView1["Pname", m].Value.ToString())
                        dataGridView1.Rows.RemoveAt(m);
                }
            }
            //ctn sale total krny k lye
            /*string sql3 = "select * from Sale_Invoice where Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and E_Name='" + enmcombo.Text + "'and C_Name='"+cnmcombo.Text+"'";
            da = new SqlDataAdapter(sql3, cn1);
            DataSet ds2 = new DataSet();
            da.Fill(ds2, "Sale_Invoice");
            c = ds2.Tables["Sale_Invoice"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                pnm = Convert.ToString(ds2.Tables["Sale_Invoice"].Rows[i]["P_Name"]);
                cn1.Close();
                  if (pnm == ppnm)
                  {
                      continue;
                  

                string sql1 = "select CQ from Sale_Invoice where Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and P_Name='" + pnm + "' and E_Name='" + enmcombo.Text + "' and C_Name='" + cnmcombo.Text + "'";// Group By P_Name having P_Name='" + pnm + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql1;
                ct = Convert.ToDouble(cmd.ExecuteScalar());
                cn1.Close();

                string sql = "select BQ from Sale_Invoice where Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and P_Name='" + pnm + "' and E_Name='" + enmcombo.Text + "'and C_Name='" + cnmcombo.Text + "'";// Group By P_Name having P_Name='" + pnm + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                bx = Convert.ToDouble(cmd.ExecuteScalar());
                cn1.Close();

                string sql11 = "select * from Inventry_Stock where Product_Name='" +pnm + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql11;
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {

                    bxsss = Convert.ToInt32(reader.GetValue(4));
         // MessageBox.Show("Product Name is = " + dataGridView1["Pname", k].Value + "\n Carton Quantity is=" + tct, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
  
                }
                cn1.Close();
                cartontxt.Text = "0";
                tct = bx / bxsss;
                Tcarton = ct + tct;
                tb = tb + Tcarton;
                cartontxt.Text = Convert.ToString(tb);

           
            }
            */
            
            
            //final bracket below of enm combo box   
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Summary_Of_Today_Supply_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = (dataGridView1.Rows.Count + 2) * dataGridView1.RowTemplate.Height;
            bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);                      //PrintableArea
            RectangleF recPrint = e.PageSettings.PrintableArea;
            if (this.dataGridView1.Height - recPrint.Height > 0)
            {
                e.HasMorePages = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dataGridView1.Rows.Clear();
            int row = 0, bxsss = 0, ctnnn = 0;
            string Pname = "";
            string sql2 = "select * from Sale_Invoice where Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
            da = new SqlDataAdapter(sql2, cn1);
            DataSet ds1 = new DataSet();
            da.Fill(ds1, "Sale_Invoice");
            c = ds1.Tables["Sale_Invoice"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                pnm = Convert.ToString(ds1.Tables["Sale_Invoice"].Rows[i]["P_Name"]);
                cn1.Close();
                if (pnm == ppnm)
                    continue;

                string sql1 = "select Sum(CQ) from Sale_Invoice where Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and P_Name='" + pnm + "'";// Group By P_Name having P_Name='" + pnm + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql1;
                ct = Convert.ToDouble(cmd.ExecuteScalar());
                cn1.Close();

                string sql = "select Sum(BQ) from Sale_Invoice where Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and P_Name='" + pnm + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                bx = Convert.ToDouble(cmd.ExecuteScalar());
                cn1.Close();

                dataGridView1.Rows.Add();
                row = dataGridView1.Rows.Count - 1;
                dataGridView1["Pname", row].Value = pnm.ToString();
                ppnm = pnm;
                dataGridView1["CQ", row].Value = Convert.ToString(ct);
                dataGridView1["BoxQ", row].Value = Convert.ToString(bx);
            }
            cn1.Close();
            for (int j = 0; j <= dataGridView1.Rows.Count - 1; j++)
            {
                ppnm = dataGridView1["Pname", j].Value.ToString();
                for (int k = j + 1; k <= dataGridView1.Rows.Count - 1; k++)
                    if (ppnm == dataGridView1["Pname", k].Value.ToString())
                        dataGridView1.Rows.RemoveAt(k);
            }

            for (int k = 0; k <= dataGridView1.Rows.Count - 1; k++)
            {
                string sql11 = "select * from Inventry_Stock where Product_Name='" + dataGridView1["Pname", k].Value + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql11;
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    bxsss = Convert.ToInt32(reader.GetValue(4));
                    ctnnn = Convert.ToInt32(dataGridView1["BoxQ", k].Value) / bxsss;
                    dataGridView1["CQ", k].Value = Convert.ToInt32(dataGridView1["CQ", k].Value) + ctnnn;
                    dataGridView1["BoxQ", k].Value = Convert.ToInt32(dataGridView1["BoxQ", k].Value) % bxsss;
                    dataGridView1["CQ", k].Value = Convert.ToString(dataGridView1["CQ", k].Value);
                    dataGridView1["BoxQ", k].Value = Convert.ToString(dataGridView1["BoxQ", k].Value);
                }
                cn1.Close();
            }

            for (int j = 0; j <= dataGridView1.Rows.Count - 1; j++)
            {
                ppnm = dataGridView1["Pname", j].Value.ToString();
                for (int k = j + 1; k <= dataGridView1.Rows.Count - 1; k++)
                    if (ppnm == dataGridView1["Pname", k].Value.ToString())
                        dataGridView1.Rows.RemoveAt(k);
            }

            for (int j = 0; j <= dataGridView1.Rows.Count - 1; j++)
            {
                ppnm = dataGridView1["Pname", j].Value.ToString();
                for (int k = j + 1; k <= dataGridView1.Rows.Count - 1; k++)
                    if (ppnm == dataGridView1["Pname", k].Value.ToString())
                        dataGridView1.Rows.RemoveAt(k);
            }
       
        //final bracket of label ALL Employes below
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // nechy sir ka code comment kia hy apna test krny k lye
            int height = dataGridView1.Height;
            dataGridView1.Height = (dataGridView1.Rows.Count + 2) * dataGridView1.RowTemplate.Height;
            bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0,0, this.dataGridView1.Width, this.dataGridView1.Height));
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;
            
            /*
            //yahan se nechy mera code hy print k lye
            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
            }
             */
        }



        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {  
            e.Graphics.DrawImage(bitmap, 0,0);                      //PrintableArea
            RectangleF recPrint = e.PageSettings.PrintableArea;
            if (this.dataGridView1.Height - recPrint.Height > 0)
            {
                e.HasMorePages = true;
            }

            /*
                try
    {
        strFormat = new StringFormat();
        strFormat.Alignment = StringAlignment.Near;
        strFormat.LineAlignment = StringAlignment.Center;
        strFormat.Trimming = StringTrimming.EllipsisCharacter;

        arrColumnLefts.Clear();
        arrColumnWidths.Clear();
        iCellHeight = 0;
        iCount = 0;
        bFirstPage = true;
        bNewPage = true;

        // Calculating Total Widths
        iTotalWidth = 0;
        foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
        {
            iTotalWidth += dgvGridCol.Width;
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
*/

        }







        // Agar Crystal report tyar na hui to is ko dbara active krna hy

       

        private void printDocument1_QueryPageSettings(object sender, System.Drawing.Printing.QueryPageSettingsEventArgs e)
        {


        }

        private void printPreviewDialog1_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (enmcombo.Text != "ALL Employes")
            {
               /* CrystalReport2 cr = new CrystalReport2();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["Hamid_Bhutta_and_Brothers.Properties.Setting.DistributionSetup"].ToString();*/
                string sql = "SELECT * from Sale_Invoice where E_Name='" + enmcombo.Text + "' and Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                DataSet ds2 = new DataSet();
               // SqlDataAdapter da2 = new SqlDataAdapter(sql, conn);
                da.Fill(ds2, "Sale_Invoice");
                DataTable dt = ds2.Tables["Sale_Invoice"];
               // cr.SetDataSource(ds2.Tables["Sale_Invoice"]);


                //Carton aor boxes ka sum leny k lye copy kia hua code paste kr rha hn 
                c = ds2.Tables["Sale_Invoice"].Rows.Count;
                for (i = 0; i <= c-1 ; i++)
                {
                    pnm = Convert.ToString(ds2.Tables["Sale_Invoice"].Rows[i]["P_Name"]);
                    cn1.Close();
                    if (pnm == ppnm)
                    {
                        continue;
                    }

                    string sql1 = "select CQ from Sale_Invoice where Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and P_Name='" + pnm + "' and E_Name='" + enmcombo.Text + "'";// Group By P_Name having P_Name='" + pnm + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql1;
                    ct = Convert.ToDouble(cmd.ExecuteScalar());

                    
                    
                    cn1.Close();

                    string sql3 = "select BQ from Sale_Invoice where Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "' and P_Name='" + pnm + "' and E_Name='" + enmcombo.Text + "'";// Group By P_Name having P_Name='" + pnm + "'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql3;
                    bx = Convert.ToDouble(cmd.ExecuteScalar());
                   MessageBox.Show("Boxes Quantity is= " + bx + "\n Carton Quantity is=" + ct, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tct = tct + ct;
                    tb = tb + bx;
                    cartontxt.Text = Convert.ToString(tct);
                    Boxtxt.Text = Convert.ToString(tb);
                    ct = 0;
                    bx = 0;
                
                    cn1.Close();

                    
                   
                }
                cn1.Close();

                if (enmcombo.Text == "ALL Employes")
                {
    
                   /* DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["Hamid_Bhutta_and_Brothers.Properties.Setting.DistributionSetup"].ToString();
                    TextObject comnm, empnum, tctn, tbx ;
                    empnum = (TextObject)cr.ReportDefinition.ReportObjects["Text5"];
                    empnum.Text = enmcombo.Text;*/
                    string sql1 = "SELECT * from Sale_Invoice where E_Name='" + enmcombo.Text + "' and Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                    DataSet ds5 = new DataSet();
                   // SqlDataAdapter da5 = new SqlDataAdapter(sql1, );
                    da.Fill(ds, "Sale_Invoice");
                    DataTable dt5 = ds.Tables["Sale_Invoice"];
                    //cr.SetDataSource(ds.Tables["Sale_Invoice"]);
                    /*
                    tctn = (TextObject)cr.ReportDefinition.ReportObjects["ctntxt"];
                    tbx = (TextObject)cr.ReportDefinition.ReportObjects["bxtxt"];
                    crystalReportViewer1.ReportSource = cr;
                    cr.PrintOptions.PrinterName = printDocument1.PrinterSettings.PrinterName;
                    cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

                    crystalReportViewer1.Refresh();
                    */
                }

            }
            
            cn1.Close();
            CrystalReport2 cr = new CrystalReport2();
            SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = ConfigurationManager.ConnectionStrings["Hamid_Bhutta_and_Brothers.Properties.Setting.DistributionSetup"].ToString();
            DataSet ds1 = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["Hamid_Bhutta_and_Brothers.Properties.Setting.DistributionSetup"].ToString();
            TextObject comnm, empnum, tctn, tbx;

            empnum = (TextObject)cr.ReportDefinition.ReportObjects["Text5"];
            empnum.Text = enmcombo.Text;
           
            MessageBox.Show("Boxes Quantity is= " + Boxtxt.Text + "\n Carton Quantity is=" + cartontxt.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //tbx = (TextObject)cr.ReportDefinition.ReportObjects["Text7"];
            //tbx.Text = Boxtxt.Text;
            //tctn = (TextObject)cr.ReportDefinition.ReportObjects["Text6"];
            //tctn.Text = cartontxt.Text;

            crystalReportViewer1.ReportSource = cr;
            cr.PrintOptions.PrinterName = printDocument1.PrinterSettings.PrinterName;
            cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

            crystalReportViewer1.Refresh();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DefaultCellStyleChanged(object sender, EventArgs e)
        {

        }




        public StringFormat strFormat { get; set; }

        public int iCount { get; set; }

        public int iCellHeight { get; set; }

        public bool bNewPage { get; set; }

        public bool bFirstPage { get; set; }

        public int iTotalWidth { get; set; }

        private void printPreviewDialog1_Load_1(object sender, EventArgs e)
        {

        }

        private void cnmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }    
}


