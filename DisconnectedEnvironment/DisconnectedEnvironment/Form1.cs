using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DisconnectedEnvironment

{
    public partial class Form1 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRDataSet9.empdetails' table. You can move, or remove it, as needed.
            this.empdetailsTableAdapter6.Fill(this.hRDataSet9.empdetails);
            // TODO: This line of code loads data into the 'hRDataSet.empdetails' table. You can move, or remove it, as needed.
            this.empdetailsTableAdapter.Fill(this.hRDataSet.empdetails);

            this.empdetailsTableAdapter.Fill(this.hRDataSet.empdetails);

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox1.Items.Add("MANAGER");
            comboBox1.Items.Add("AUTHOR");
            comboBox1.Items.Add("DESIGNER");
            comboBox2.Items.Add("MARKETING");
            comboBox2.Items.Add("FINANCE");
            comboBox2.Items.Add("IDO");
            button2.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            int ctr, len;
            string codeval;
            dt = hRDataSet.Tables["empdetails"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            code = dr["ccode"].ToString();
            codeval = code.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);
            if((ctr>=1) && (ctr< 9))
            {
                ctr = ctr + 1;
                textBox1.Text = "C00" + ctr;


            }
            else if ((ctr >= 9) && (ctr <99))
            {
                textBox1.Text = "C0" + ctr;
            }
            else if (ctr >= 99)
            {
                ctr = ctr + 1;
                textBox1.Text = "C" + ctr;

            }

            button1.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt = hRDataSet.Tables["empdetails"];
            dr = dt.NewRow();

            dr[0] = textBox1.Text;
            dr[1] = textBox2.Text;
            dr[2] = textBox3.Text;
            dr[3] = textBox4.Text; 
            dr[4] = textBox5.Text;
            dr[5] = comboBox1.SelectedItem;
            dr[6] = comboBox2.SelectedItem;
            dt.Rows.Add(dr);
            empdetailsTableAdapter.Update(hRDataSet);
            textBox1.Text = System.Convert.ToString(dr[0]);
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            this.empdetailsTableAdapter.Fill(this.hRDataSet.empdetails);
            button1.Enabled = true;
            button2.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string code;
            code = textBox1.Text;
            dr = hRDataSet.Tables["empdetails"].Rows.Find(code);
            dr.Delete();
            empdetailsTableAdapter.Update(hRDataSet);
        }
    }
}
