using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form2 : Form
    {
        private string gc_id = "", weapon_id = "";
        private bool facial_recognition = false;
        private DataTable UserDetails;
        public Form2( DataTable dt )
        {
            UserDetails = dt;
            this.MinimumSize = new System.Drawing.Size(818, 497);
            InitializeComponent();
            this.label2.Text = UserDetails.Rows[0][3].ToString() + ". " + UserDetails.Rows[0][0].ToString() + " " + UserDetails.Rows[0][1].ToString();

            this.Resize += Form2_resize;
        }
        private void Form2_resize(object sender, EventArgs e)
        {
            this.button1.Location = new Point(this.Size.Width-button1.Size.Width-10,button1.Location.Y);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var form1 =new Form1();
            form1.Location = this.Location;
            form1.Size = this.Size;
            if (this.WindowState == FormWindowState.Maximized) form1.WindowState = FormWindowState.Maximized;

            form1.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click 'Facial Recognition' button to match GC ID and face", "Hint",MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /* 1. Check if gc_id isnt blank
             * 2. Check If designation is knco-> make sure weapon id matches gc issue
             *                         if ccdr-> make sure company is same
             *                         if adjt-> exception
             * 3. Get directory of facial model
             * 4. run python cmd and get opt if yes->update label1.text="✓"
             *                                       update label1.ForeColor=Color.Green
             *                                   no-> stay red 
             *                                     ->MessageBox.Show("Face Didnt Match",MessageBoxButtons.OK)
             * 5. Display Issue Messagebox or button
             * */
            this.textBox2.Text = "123456789";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* 1. Run scan barcode function
             * 2. Change textBox1.text 
             * 3. Update weapon_id
             * 4. Show list of GC's that can accept weapon
             * */

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.label1.Text = "X";
            this.label1.ForeColor = Color.Red;
        }
    }
}
