namespace Hamid_Bhutta_and_Brothers
{
    partial class Sale_Reports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sale_Reports));
            this.enmcombo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.deptxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cnmtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Cretxt = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.distxt = new System.Windows.Forms.TextBox();
            this.areacombo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // enmcombo
            // 
            this.enmcombo.Font = new System.Drawing.Font("New Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enmcombo.FormattingEnabled = true;
            this.enmcombo.Items.AddRange(new object[] {
            "ALL EMPLOYS"});
            this.enmcombo.Location = new System.Drawing.Point(117, 35);
            this.enmcombo.Name = "enmcombo";
            this.enmcombo.Size = new System.Drawing.Size(174, 28);
            this.enmcombo.TabIndex = 2;
            this.enmcombo.Text = "Select Employ";
            this.enmcombo.SelectedIndexChanged += new System.EventHandler(this.enmcombo_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("New Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(27, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 19);
            this.label9.TabIndex = 76;
            this.label9.Text = "To_Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("New Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 19);
            this.label7.TabIndex = 75;
            this.label7.Text = "From_Date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("New Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(17, 92);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(94, 21);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("New Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(17, 38);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(94, 21);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // deptxt
            // 
            this.deptxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.deptxt.Enabled = false;
            this.deptxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deptxt.Location = new System.Drawing.Point(598, 27);
            this.deptxt.Multiline = true;
            this.deptxt.Name = "deptxt";
            this.deptxt.ReadOnly = true;
            this.deptxt.Size = new System.Drawing.Size(90, 35);
            this.deptxt.TabIndex = 77;
            this.deptxt.TabStop = false;
            this.deptxt.Text = "0";
            this.deptxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.deptxt.TextChanged += new System.EventHandler(this.deptxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("New Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(503, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 78;
            this.label1.Text = "Total_Sale";
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.button5.FlatAppearance.BorderSize = 3;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(804, 9);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 48);
            this.button5.TabIndex = 80;
            this.button5.TabStop = false;
            this.button5.Text = "Exit";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 119);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(911, 265);
            this.dataGridView1.TabIndex = 81;
            this.dataGridView1.TabStop = false;
            // 
            // cnmtxt
            // 
            this.cnmtxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cnmtxt.Enabled = false;
            this.cnmtxt.Location = new System.Drawing.Point(329, 80);
            this.cnmtxt.Multiline = true;
            this.cnmtxt.Name = "cnmtxt";
            this.cnmtxt.ReadOnly = true;
            this.cnmtxt.Size = new System.Drawing.Size(113, 23);
            this.cnmtxt.TabIndex = 82;
            this.cnmtxt.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("New Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(320, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 19);
            this.label2.TabIndex = 83;
            this.label2.Text = "Company &Name";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(713, 37);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(85, 20);
            this.linkLabel1.TabIndex = 120;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Print_Out";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(298, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(178, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("New Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(676, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 19);
            this.label3.TabIndex = 123;
            this.label3.Text = "Total_Return";
            // 
            // Cretxt
            // 
            this.Cretxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Cretxt.Enabled = false;
            this.Cretxt.Location = new System.Drawing.Point(794, 77);
            this.Cretxt.Multiline = true;
            this.Cretxt.Name = "Cretxt";
            this.Cretxt.ReadOnly = true;
            this.Cretxt.Size = new System.Drawing.Size(90, 35);
            this.Cretxt.TabIndex = 124;
            this.Cretxt.TabStop = false;
            this.Cretxt.Text = "0";
            this.Cretxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Cretxt.TextChanged += new System.EventHandler(this.Cretxt_TextChanged_1);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("New Century Schoolbook", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(445, 81);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 19);
            this.label20.TabIndex = 126;
            this.label20.Text = "Total Disc.";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // distxt
            // 
            this.distxt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.distxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.distxt.Enabled = false;
            this.distxt.Font = new System.Drawing.Font("New Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distxt.ForeColor = System.Drawing.Color.Red;
            this.distxt.Location = new System.Drawing.Point(550, 76);
            this.distxt.Multiline = true;
            this.distxt.Name = "distxt";
            this.distxt.ReadOnly = true;
            this.distxt.Size = new System.Drawing.Size(114, 31);
            this.distxt.TabIndex = 125;
            this.distxt.TabStop = false;
            this.distxt.Text = "0";
            this.distxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.distxt.TextChanged += new System.EventHandler(this.distxt_TextChanged);
            // 
            // areacombo
            // 
            this.areacombo.Font = new System.Drawing.Font("New Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.areacombo.FormattingEnabled = true;
            this.areacombo.Location = new System.Drawing.Point(117, 83);
            this.areacombo.Name = "areacombo";
            this.areacombo.Size = new System.Drawing.Size(174, 28);
            this.areacombo.TabIndex = 127;
            this.areacombo.Text = "Area Wise Sale";
            this.areacombo.SelectedIndexChanged += new System.EventHandler(this.areacombo_SelectedIndexChanged);
            // 
            // Sale_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(918, 386);
            this.Controls.Add(this.areacombo);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.distxt);
            this.Controls.Add(this.Cretxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cnmtxt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deptxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.enmcombo);
            this.KeyPreview = true;
            this.Name = "Sale_Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale_Reports";
            this.Load += new System.EventHandler(this.Sale_Reports_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Sale_Reports_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox enmcombo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox deptxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox cnmtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Cretxt;
        private System.EventHandler cnmtxt_TextChanged;
        private System.EventHandler Cretxt_TextChanged;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox distxt;
        private System.Windows.Forms.ComboBox areacombo;
    }
}