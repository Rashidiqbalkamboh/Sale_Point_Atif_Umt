namespace Hamid_Bhutta_and_Brothers
{
    partial class Expense_Sheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Expense_Sheet));
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.IDtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.amttxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dettxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.catcombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cattxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.cnmcombo = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cnmtxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pamttxt = new System.Windows.Forms.TextBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Date ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(61, 27);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(94, 20);
            this.dateTimePicker1.TabIndex = 14;
            this.dateTimePicker1.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(9, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(103, 16);
            this.label17.TabIndex = 57;
            this.label17.Text = "Expense I.D #";
            // 
            // IDtxt
            // 
            this.IDtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDtxt.ForeColor = System.Drawing.Color.Red;
            this.IDtxt.Location = new System.Drawing.Point(119, 87);
            this.IDtxt.MaxLength = 50;
            this.IDtxt.Multiline = true;
            this.IDtxt.Name = "IDtxt";
            this.IDtxt.Size = new System.Drawing.Size(73, 29);
            this.IDtxt.TabIndex = 1;
            this.IDtxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IDtxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDtxt_KeyPress);
            this.IDtxt.Leave += new System.EventHandler(this.IDtxt_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 32);
            this.label1.TabIndex = 59;
            this.label1.Text = "Select Expense\r\n    Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 61;
            this.label2.Text = "Expense Amount";
            // 
            // amttxt
            // 
            this.amttxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amttxt.ForeColor = System.Drawing.Color.Red;
            this.amttxt.Location = new System.Drawing.Point(142, 176);
            this.amttxt.MaxLength = 50;
            this.amttxt.Multiline = true;
            this.amttxt.Name = "amttxt";
            this.amttxt.Size = new System.Drawing.Size(101, 29);
            this.amttxt.TabIndex = 4;
            this.amttxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.amttxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amttxt_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 16);
            this.label3.TabIndex = 63;
            this.label3.Text = "Expense_Description";
            // 
            // dettxt
            // 
            this.dettxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dettxt.ForeColor = System.Drawing.Color.Red;
            this.dettxt.Location = new System.Drawing.Point(34, 249);
            this.dettxt.MaxLength = 50;
            this.dettxt.Multiline = true;
            this.dettxt.Name = "dettxt";
            this.dettxt.Size = new System.Drawing.Size(271, 41);
            this.dettxt.TabIndex = 5;
            this.dettxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(523, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 122);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Functions";
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.button5.FlatAppearance.BorderSize = 3;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(6, 67);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(114, 48);
            this.button5.TabIndex = 12;
            this.button5.TabStop = false;
            this.button5.Text = "Exit";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.button4.FlatAppearance.BorderSize = 3;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(126, 67);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 48);
            this.button4.TabIndex = 11;
            this.button4.TabStop = false;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.button2.FlatAppearance.BorderSize = 3;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(126, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 48);
            this.button2.TabIndex = 9;
            this.button2.TabStop = false;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(6, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 48);
            this.button1.TabIndex = 6;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // catcombo
            // 
            this.catcombo.FormattingEnabled = true;
            this.catcombo.Items.AddRange(new object[] {
            "New"});
            this.catcombo.Location = new System.Drawing.Point(131, 133);
            this.catcombo.MaxDropDownItems = 12;
            this.catcombo.Name = "catcombo";
            this.catcombo.Size = new System.Drawing.Size(165, 21);
            this.catcombo.Sorted = true;
            this.catcombo.TabIndex = 3;
            this.catcombo.SelectedIndexChanged += new System.EventHandler(this.catcombo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(379, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 32);
            this.label4.TabIndex = 66;
            this.label4.Text = "Make New Expense\r\n       Category";
            // 
            // cattxt
            // 
            this.cattxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cattxt.ForeColor = System.Drawing.Color.Red;
            this.cattxt.Location = new System.Drawing.Point(391, 87);
            this.cattxt.MaxLength = 50;
            this.cattxt.Multiline = true;
            this.cattxt.Name = "cattxt";
            this.cattxt.Size = new System.Drawing.Size(126, 29);
            this.cattxt.TabIndex = 1;
            this.cattxt.TabStop = false;
            this.cattxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(200, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 70;
            this.label5.Text = "Date ";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(249, 25);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(94, 20);
            this.dateTimePicker2.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(246, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 18);
            this.label9.TabIndex = 71;
            this.label9.Text = "To_Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(55, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 18);
            this.label7.TabIndex = 72;
            this.label7.Text = "From_Date";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 296);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(902, 452);
            this.dataGridView1.TabIndex = 73;
            this.dataGridView1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(222, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 32);
            this.label6.TabIndex = 74;
            this.label6.Text = "Select Company\r\n      &Name";
            // 
            // cnmcombo
            // 
            this.cnmcombo.FormattingEnabled = true;
            this.cnmcombo.Location = new System.Drawing.Point(204, 95);
            this.cnmcombo.MaxDropDownItems = 12;
            this.cnmcombo.Name = "cnmcombo";
            this.cnmcombo.Size = new System.Drawing.Size(165, 21);
            this.cnmcombo.Sorted = true;
            this.cnmcombo.TabIndex = 2;
            this.cnmcombo.SelectedIndexChanged += new System.EventHandler(this.cnmcombo_SelectedIndexChanged);
            this.cnmcombo.Enter += new System.EventHandler(this.cnmcombo_Enter);
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.MediumPurple;
            this.button6.FlatAppearance.BorderSize = 3;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(523, 219);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(247, 70);
            this.button6.TabIndex = 75;
            this.button6.TabStop = false;
            this.button6.Text = "View Record\r\n  &&  Print";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(307, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 32);
            this.label10.TabIndex = 76;
            this.label10.Text = "Company\r\n      &Name";
            // 
            // cnmtxt
            // 
            this.cnmtxt.Enabled = false;
            this.cnmtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cnmtxt.ForeColor = System.Drawing.Color.Red;
            this.cnmtxt.Location = new System.Drawing.Point(391, 135);
            this.cnmtxt.MaxLength = 50;
            this.cnmtxt.Multiline = true;
            this.cnmtxt.Name = "cnmtxt";
            this.cnmtxt.ReadOnly = true;
            this.cnmtxt.Size = new System.Drawing.Size(126, 29);
            this.cnmtxt.TabIndex = 77;
            this.cnmtxt.TabStop = false;
            this.cnmtxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(307, 181);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 32);
            this.label11.TabIndex = 78;
            this.label11.Text = "Previous\r\nAmount";
            // 
            // pamttxt
            // 
            this.pamttxt.Enabled = false;
            this.pamttxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pamttxt.ForeColor = System.Drawing.Color.Red;
            this.pamttxt.Location = new System.Drawing.Point(391, 181);
            this.pamttxt.MaxLength = 50;
            this.pamttxt.Multiline = true;
            this.pamttxt.Name = "pamttxt";
            this.pamttxt.ReadOnly = true;
            this.pamttxt.Size = new System.Drawing.Size(126, 29);
            this.pamttxt.TabIndex = 79;
            this.pamttxt.TabStop = false;
            this.pamttxt.Text = "0";
            this.pamttxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // Expense_Sheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(908, 750);
            this.Controls.Add(this.pamttxt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cnmtxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.cnmcombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.cattxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.catcombo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dettxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.amttxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.IDtxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePicker1);
            this.KeyPreview = true;
            this.Name = "Expense_Sheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expense_Sheet";
            this.Load += new System.EventHandler(this.Expense_Sheet_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Expense_Sheet_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox IDtxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox amttxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dettxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox catcombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cattxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cnmcombo;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox cnmtxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox pamttxt;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}