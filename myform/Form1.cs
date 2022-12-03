using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace myform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-09FDKG9;Initial Catalog=ASR_TP;Integrated Security=True");
            con.Open();
          

            SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT Table1 ON; insert into Table1 (ID,Book_name,number,content) values (@ID, @Book_name, @number,@content);SET IDENTITY_INSERT Table1 OFF;", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@Book_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@number",int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@content", textBox3.Text);
            cmd.ExecuteNonQuery();
           

            con.Close();
            MessageBox.Show("succesfully Added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-09FDKG9;Initial Catalog=ASR_TP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update  Table1  set Book_name=@Book_name, number=@number, content=@content where ID = @ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@Book_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@number", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@content", textBox3.Text);
            cmd.ExecuteNonQuery();


            con.Close();
            MessageBox.Show("succesfully updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-09FDKG9;Initial Catalog=ASR_TP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Table1 where ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();



            con.Close();
            MessageBox.Show("succesfully Deleted");
        }

        private void SEARCH_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-09FDKG9;Initial Catalog=ASR_TP;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Table1", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void s(object sender, EventArgs e)
        {

        }
    }
}
