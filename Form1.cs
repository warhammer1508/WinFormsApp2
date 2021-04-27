using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.MinimumSize = new System.Drawing.Size(818,497);
            InitializeComponent();
            //this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size

            //this.AutoSize = true;
            //.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //label3.Location = new System.Drawing.Point(100, 50);
            //int a= this.Size.Width;
            //MessageBox.Show(" "+a);
            this.Resize += Form1_resize;

        }

        private void Form1_resize(object sender, EventArgs e)
        {
            //int H = this.Size.Height;
            int w = this.Size.Width ;
            int h = (this.Size.Height * 80) / 1080;
            int h_fix = this.Size.Height;
            label3.Location = new System.Drawing.Point( ( w - label3.Size.Width ) / 2, h);
            label1.Location = new System.Drawing.Point( 225 + (w - 800) / 2, 133 + ( h_fix - 450 )/2);
            label2.Location = new System.Drawing.Point( 225 + (w - 800) / 2, 170 + (h_fix - 450) / 2);
            textBox1.Location = new System.Drawing.Point( 310 + (w - 800) / 2, 133 + (h_fix - 450) / 2);
            textBox2.Location = new System.Drawing.Point( 310 + (w - 800) / 2, 170 + (h_fix - 450) / 2);
            checkBox1.Location = new System.Drawing.Point( 225 + (w - 800) / 2, 206 + (h_fix - 450) / 2);
            button1.Location = new System.Drawing.Point( 342 + (w - 800) / 2, 248 + (h_fix - 450) / 2);

            //MessageBox.Show(" " + w);
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //da_services = new SqlDataAdapter("SELECT * from table WHERE column=@column AND column2=@column2", conn);
                //da_services.SelectCommand.Parameters.AddWithValue("@column", textBox1.Text);
                //da_services.SelectCommand.Parameters.AddWithValue("@column2", somestring);
                using SqlConnection con = new SqlConnection(@"Data Source=desktop-7275d5a\sqlexpress;Initial Catalog=wpn_program;Integrated Security=True;User ID=sa;Password=admin"); // making connection   
                using SqlDataAdapter sda = new SqlDataAdapter("SELECT FirstName, LastName, Designation , Rank FROM user_details WHERE IC_number= @column_1 AND password=@column_2", con);
                //modify for SQL injection protection
                sda.SelectCommand.Parameters.AddWithValue("@column_1", textBox1.Text);
                sda.SelectCommand.Parameters.AddWithValue("@column_2", textBox2.Text);
                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    textBox1.Text = ""; textBox2.Text = "";
                    var form2 = new Form2(dt);
                    //from2.Closed += (sender, e) => this.Close();
                    form2.Show();
                    form2.Location = this.Location;
                    form2.Size = this.Size;
                    if (this.WindowState == FormWindowState.Maximized) form2.WindowState = FormWindowState.Maximized;
                    this.Close();

                }
                else
                    MessageBox.Show("Invalid username or password");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

    }
}
