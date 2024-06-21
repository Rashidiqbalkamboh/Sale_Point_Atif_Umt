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
using System.Drawing.Drawing2D;
using System.IO;

namespace Hamid_Bhutta_and_Brothers
{
    public partial class Change_Password : Form
    {
        SqlConnection cn1 = new SqlConnection("data source=(localdb)\\MSSqlLocalDb;initial catalog=DistributionSetup;integrated security=true");
        SqlCommand cmd = new SqlCommand();
      //  SqlDataReader reader;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        string n="", p="";
        public Change_Password(string nm,string ps)
        {
            n = nm;
            p = ps;
            InitializeComponent();
        }

        private void Change_Password_Load(object sender, EventArgs e)
        {
            nmtxt.Text = n;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (curtxt.Text != p)
                MessageBox.Show("Current Password is Not Correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string sql = "Update Log_In set Password='" +npsstxt.Text + "' where Password='" + p + "'";
                cn1.Open();
                cmd.Connection = cn1;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Password Update Successfully....!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Question);
                cn1.Close();
               curtxt.Clear();
              npsstxt.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           curtxt.Clear();
          npsstxt.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void npsstxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(npsstxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }

        private void Change_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void curtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(curtxt, true, true, true, true);

                }
                e.Handled = true;
            }
        }
    }
}
