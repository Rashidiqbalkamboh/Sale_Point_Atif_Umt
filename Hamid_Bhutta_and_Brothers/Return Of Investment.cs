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
    public partial class Return_Of_Investment : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlDataAdapter da,da1 = new SqlDataAdapter();
        DataSet ds,ds1 = new DataSet();
        int c = 0,c1=0, i = 0, chkk = 0, chk = 0, b = 0, eff = 0;
        double amt = 0, ct = 0 , discount=0,overall=0 ;
        string enm="";
        public Return_Of_Investment()
        {
            InitializeComponent();
        }

        private void Return_Of_Investment_Load(object sender, EventArgs e)
        {
           /* string sql15 = "truncate table ROI_Record";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql15;
            cmd.ExecuteNonQuery();
            cn1.Close();*/
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Return_Of_Investment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void cnmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            enmcombo.Items.Clear();
            enmcombo.Text = "";
            string en = "";
            enmcombo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            enmcombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection col1 = new AutoCompleteStringCollection();
            string sql = "select Distinct(Employ_Name) from EmployRec"; //where Company_Name='" + cnmcombo.Text + "'";
            da = new SqlDataAdapter(sql, cn1);
            ds = new DataSet();
            da.Fill(ds, "EmployRec");
            c = ds.Tables["EmployRec"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                enmcombo.Items.Add(ds.Tables["EmployRec"].Rows[i]["Employ_Name"]);
                en = ds.Tables["EmployRec"].Rows[i]["Employ_Name"].ToString();
                col1.Add(en);
            }
            cn1.Close();
            enmcombo.AutoCompleteCustomSource = col1;
            enmcombo.Items.Add("ALL Employes");

            pptxt.Text = "0";
            string sql4 = "select * from Inventry_Stock where Company_Name='" + cnmcombo.Text + "'";// and Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value +"'";
            cn1.Open();
            cmd.Connection = cn1;
            cmd.CommandText = sql4;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                pptxt.Text = Convert.ToString(Convert.ToDouble(pptxt.Text) + Convert.ToDouble(reader.GetValue(10)));
            }
            cn1.Close();

            rmtxt.Text = "0";
            //YAHAN PAR HAMID NY OPAR WAALA CODE COPY KR K REPLACE KIA HAI ......!!!
            string sql1 = "select Distinct(Employ_Name) from EmployRec"; // where Company_Name='" + cnmcombo.Text + "'";
            da = new SqlDataAdapter(sql1, cn1);
            ds = new DataSet();
            da.Fill(ds, "EmployRec");
            c = ds.Tables["EmployRec"].Rows.Count;
            for (i = 0; i <= c - 1; i++)
            {
                enm = ds.Tables["EmployRec"].Rows[i]["Employ_Name"].ToString();
                cn1.Close();
                /*    string sql2 = "select * from Khata_Record where E_Name='" + enm.Trim() + "'";// and Date between '"+dateTimePicker1.Value+"' and '"+dateTimePicker2.Value+"'";
                    cn1.Open();
                    cmd.Connection = cn1;
                    cmd.CommandText = sql2;
                    reader = cmd.ExecuteReader();
                    while(reader.Read())
                   {
                       rmtxt.Text = Convert.ToString(Convert.ToDouble(rmtxt.Text) + Convert.ToDouble(reader.GetValue(12)));
                    }
                }
                cn1.Close();*/

                cshtxt.Text = "0";
                string sql5 = "select * from Incoming where C_Name='" + cnmcombo.Text + "'";// and Income_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql5;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cshtxt.Text = Convert.ToString(Convert.ToDouble(cshtxt.Text) + Convert.ToDouble(reader.GetValue(7)));
                }
                cn1.Close();

                extxt.Text = "0";
                string sql6 = "select * from Expance_Record where Company_Name='" + cnmcombo.Text + "' and Expance_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql6;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    extxt.Text = Convert.ToString(Convert.ToDouble(extxt.Text) + Convert.ToDouble(reader.GetValue(4)));
                }
                cn1.Close();

                exptxt.Text = "0";
                string sql7 = "select * from Expired_Stock where C_Name='" + cnmcombo.Text + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql7;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    exptxt.Text = Convert.ToString(Convert.ToDouble(exptxt.Text) + Convert.ToDouble(reader.GetValue(4)));
                }
                cn1.Close();
                //YAHAN PAR COMPANY KY BEHALF PAR ROI CALCULATE K LYE FORMULA COPY KR K PASTE KIA HAI AOR TABLE SALE_INVOICE CAL KI HAI .......!!!
                /*  roitxt.Text = "0";
                  string sql12 = "select * from Sale_Invoice where C_Name='" + cnmcombo.Text + "' and Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";// ";//Group By P_Name having P_Name='" + pnm + "'";
                  cn1.Open();
                  cmd.Connection = cn1;
                  cmd.CommandText = sql12;
                  reader = cmd.ExecuteReader();
                  while (reader.Read())
                  {
                      ct = Convert.ToDouble(reader.GetValue(11));
                      roitxt.Text = Convert.ToString(Convert.ToDouble(roitxt.Text) + ct);
                  }
                  cn1.Close();*/
            }
        }

        private void enmcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            roitxt.Text = "0";
            if (enmcombo.Text != "ALL Employes")
            {
                //YAHAN HAMID NY ROI M SE DISCOUNT AOR PERCENTAGE KI VALUE MINUS KRNY K LYE CODING KI HY
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
               
                string sql12 = "select * from Sale_Invoice where C_Name='" + cnmcombo.Text + "'and E_Name='"+enmcombo.Text+"' and Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";// ";//Group By P_Name having P_Name='" + pnm + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql12;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ct = Convert.ToDouble(reader.GetValue(11));
                    roitxt.Text = Convert.ToString(Convert.ToDouble(roitxt.Text) + ct);
                    
                        
                }
                cn1.Close();
            }
            else if(enmcombo.Text=="ALL Employes")
            {   //NECHY HAMID NY SALE INVOICE TABLE KO SK SALE BILL TABLE SE REPLACE KIA HAI ......!!!!!! 
                distxt.Text = "0";
                string sql12 = "select * from Sale_Invoice where C_Name='" + cnmcombo.Text + "' and Sale_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";// ";//Group By P_Name having P_Name='" + pnm + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql12;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ct = Convert.ToDouble(reader.GetValue(11));
                    roitxt.Text = Convert.ToString(Convert.ToDouble(roitxt.Text) + ct);
                }
                cn1.Close();
                string sql13 = "select * from SK_Sale_Bill where C_Name='" + cnmcombo.Text + "' and Bill_Date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";// ";//Group By P_Name having P_Name='" + pnm + "'";
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
               
            }
        }

        private void inctxt_Leave(object sender, EventArgs e)
        {
            if (inctxt.TextLength == 0)
            {
                MessageBox.Show("Please Fill the Incentive");
                inctxt.Focus();
            }
            
        }

        private void totxt_Leave(object sender, EventArgs e)
        {
            if (totxt.TextLength == 0)
            {
                MessageBox.Show("Please Fill the TO_Claim");
               totxt.Focus();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please Verify All the Data Before Submit", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cnmcombo.Text == "" || enmcombo.Text == "")
                {
                    MessageBox.Show("Please Fill All the Boxes");
                }
                else
                {
                    if (MessageBox.Show("Please Varify The Target Incentive and TO_Claim Amount\n Target Incentive=" + inctxt.Text + "\n TO_Claim=" + totxt.Text, "Verification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        pertxt.Text = "0";
                        tinvtxt.Text = Convert.ToString(Convert.ToDouble(pptxt.Text) + Convert.ToDouble(rmtxt.Text) + Convert.ToDouble(cshtxt.Text) + Convert.ToDouble(exptxt.Text) + Convert.ToDouble(totxt.Text));
                        troitxt.Text = Convert.ToString((Convert.ToDouble(roitxt.Text) + Convert.ToDouble(inctxt.Text)) - Convert.ToDouble(extxt.Text));
                        pertxt.Text = Convert.ToString(Convert.ToDouble(troitxt.Text) / Convert.ToDouble(tinvtxt.Text) * 100);
                        string sql2 = "Insert Into ROI_Record(From_Date,To_Date,C_Name,Total_Investment,Total_ROI,ROI_Per)Values('" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "','" + cnmcombo.Text.Trim() + "','" + tinvtxt.Text + "','" + troitxt.Text + "','" + pertxt.Text + "')";
                        cn1.Open();
                        cmd.Connection = cn1;
                        cmd.CommandText = sql2;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Stored", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cn1.Close();

                        ROIReport roi = new ROIReport();
                        SqlConnection con = new SqlConnection();
                        DataSet ds1 = new DataSet();
                        SqlDataAdapter da1 = new SqlDataAdapter();
                        con.ConnectionString = ConfigurationManager.ConnectionStrings["Hamid_Bhutta_and_Brothers.Properties.Setting.DistributionSetup"].ToString();
                        TextObject frdt, todt, comnm, empnum, rroi, incs, expnc, ttroi, rovsin, tsv, ttcr, chinh, exst, clam, tinv;
                        frdt = (TextObject)roi.ReportDefinition.ReportObjects["Text2"];
                        todt = (TextObject)roi.ReportDefinition.ReportObjects["Text4"];
                        comnm = (TextObject)roi.ReportDefinition.ReportObjects["Text6"];
                        empnum = (TextObject)roi.ReportDefinition.ReportObjects["Text8"];
                        rroi = (TextObject)roi.ReportDefinition.ReportObjects["Text10"];
                        incs = (TextObject)roi.ReportDefinition.ReportObjects["Text12"];
                        expnc = (TextObject)roi.ReportDefinition.ReportObjects["Text14"];
                        ttroi = (TextObject)roi.ReportDefinition.ReportObjects["Text16"];
                        rovsin = (TextObject)roi.ReportDefinition.ReportObjects["Text18"];
                        tsv = (TextObject)roi.ReportDefinition.ReportObjects["Text20"];
                        ttcr = (TextObject)roi.ReportDefinition.ReportObjects["Text22"];
                        chinh = (TextObject)roi.ReportDefinition.ReportObjects["Text24"];
                        exst = (TextObject)roi.ReportDefinition.ReportObjects["Text26"];
                        clam = (TextObject)roi.ReportDefinition.ReportObjects["Text28"];
                        tinv = (TextObject)roi.ReportDefinition.ReportObjects["Text30"];
                        frdt.Text = Convert.ToString(dateTimePicker1.Value);
                        todt.Text = Convert.ToString(dateTimePicker2.Value);
                        comnm.Text = cnmcombo.Text;
                        empnum.Text = enmcombo.Text;
                        rroi.Text = roitxt.Text;
                        incs.Text = inctxt.Text;
                        expnc.Text = extxt.Text;
                        ttroi.Text = troitxt.Text;
                        rovsin.Text = pertxt.Text;
                        tsv.Text = pptxt.Text;
                        ttcr.Text = rmtxt.Text;
                        chinh.Text = cshtxt.Text;
                        exst.Text = exptxt.Text;
                        clam.Text = totxt.Text;
                        tinv.Text = tinvtxt.Text;
                        crystalReportViewer1.ReportSource = roi;
                        roi.PrintOptions.PrinterName = printDocument1.PrinterSettings.PrinterName;
                        roi.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                        //  crystalReportViewer1.PrintReport();
                        crystalReportViewer1.Refresh();

                        cnmcombo.Text = ""; enmcombo.Text = ""; roitxt.Text = "0"; inctxt.Text = "0";
                        extxt.Text = "0"; troitxt.Text = "0"; pertxt.Text = "0"; pptxt.Text = "0";
                        rmtxt.Text = "0"; cshtxt.Text = "0"; exptxt.Text = "0"; totxt.Text = "0";
                        tinvtxt.Text = "0";

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cnmcombo.Text = ""; enmcombo.Text = ""; roitxt.Text = "0"; inctxt.Text = "0";
            extxt.Text = "0"; troitxt.Text = "0"; pertxt.Text = "0"; pptxt.Text = "0";
            rmtxt.Text = "0"; cshtxt.Text = "0"; exptxt.Text = "0"; totxt.Text = "0";
            tinvtxt.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
           /* ROIReport roi = new ROIReport();
            SqlConnection con = new SqlConnection();
            DataSet ds1 = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Hamid_Bhutta_and_Brothers.Properties.Setting.DistributionSetup"].ToString();
            TextObject frdt, todt,comnm,empnum,rroi, incs, expnc, ttroi, rovsin,tsv,ttcr,chinh,exst,clam,tinv;
            frdt = (TextObject)roi.ReportDefinition.ReportObjects["Text2"];
            todt = (TextObject)roi.ReportDefinition.ReportObjects["Text4"];
            comnm = (TextObject)roi.ReportDefinition.ReportObjects["Text6"];
            empnum = (TextObject)roi.ReportDefinition.ReportObjects["Text8"];
            rroi = (TextObject)roi.ReportDefinition.ReportObjects["Text10"];
            incs = (TextObject)roi.ReportDefinition.ReportObjects["Text12"];
            expnc = (TextObject)roi.ReportDefinition.ReportObjects["Text14"];
            ttroi = (TextObject)roi.ReportDefinition.ReportObjects["Text16"];
            rovsin = (TextObject)roi.ReportDefinition.ReportObjects["Text18"];
            tsv = (TextObject)roi.ReportDefinition.ReportObjects["Text20"];
            ttcr = (TextObject)roi.ReportDefinition.ReportObjects["Text22"];
            chinh = (TextObject)roi.ReportDefinition.ReportObjects["Text24"];
            exst = (TextObject)roi.ReportDefinition.ReportObjects["Text26"];
            clam = (TextObject)roi.ReportDefinition.ReportObjects["Text28"];
            tinv = (TextObject)roi.ReportDefinition.ReportObjects["Text30"];
            frdt.Text =Convert.ToString(dateTimePicker1.Value);
            todt.Text =Convert.ToString(dateTimePicker2.Value);
            comnm.Text = cnmcombo.Text;
            empnum.Text = enmcombo.Text;
            rroi.Text = roitxt.Text;
            incs.Text = inctxt.Text;
            expnc.Text = extxt.Text;
            ttroi.Text = troitxt.Text;
            rovsin.Text = pertxt.Text;
            tsv.Text = pptxt.Text;
            ttcr.Text = rmtxt.Text;
            chinh.Text = cshtxt.Text;
            exst.Text = exptxt.Text;
            clam.Text = totxt.Text;
            tinv.Text = tinvtxt.Text;            
            crystalReportViewer1.ReportSource =roi;
            crystalReportViewer1.PrintReport();
            crystalReportViewer1.Refresh();*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rmtxt_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
