using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hamid_Bhutta_and_Brothers
{
    public partial class Main_Form : Form
    {
        string nm="", ps="";
        private string p;
        public Main_Form( string n,string p)
        {
            nm = n;
            ps = p;
            InitializeComponent();
        }

        public Main_Form(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Add_Stock ads = new Add_Stock();
            ads.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            EmployShopkeeperRec esk = new EmployShopkeeperRec();
            esk.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            EmployRecord er = new EmployRecord();
            er.Show();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Expense_Sheet es = new Expense_Sheet();
            es.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 f1=new Form1();
            f1.Show();
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Return_Of_Investment roi = new Return_Of_Investment();
            roi.Show();
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Closing_Report cr =new Closing_Report();
            cr.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            View_Stock vs = new View_Stock();
            vs.Show();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Incoming_Sheet ic=new Incoming_Sheet();
            ic.Show();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Change_Password cp = new Change_Password(nm,ps);
            cp.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            List_Of_Defaulters ld = new List_Of_Defaulters();
            ld.Show();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Sale_Reports sr = new Sale_Reports();
            sr.Show();
        }
        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Expire_Stock_Detail es = new Expire_Stock_Detail();
            es.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Sale_Form sf = new Sale_Form();
            sf.Show();
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            Summary_Of_Today_Supply st = new Summary_Of_Today_Supply();
            st.Show();
        }

        private void pictureBox18_Click_1(object sender, EventArgs e)
        {
            Entry_List_of_Today_Supply el = new Entry_List_of_Today_Supply();
            el.Show();
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            Khata__Register kr = new Khata__Register();
            kr.Show();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            Company_Lager cl = new Company_Lager();
            cl.Show();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            
        }
    }
}
