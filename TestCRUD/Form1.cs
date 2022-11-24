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

namespace TestCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con= new SqlConnection("Data Source=REKE-LAPTOP; Initial Catalog=My_TestDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Usertab set Name=@Name,Age=@Age where Id=@Id",con);
            
            cmd.Parameters.AddWithValue("@Id",int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name",(textBox2.Text));
            cmd.Parameters.AddWithValue("@Age",double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Se actualizó con exito");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=REKE-LAPTOP;Initial Catalog=My_TestDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete Usertab where Id=@Id", con);

            cmd.Parameters.AddWithValue("@Id",int.Parse(textBox1.Text));
            
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Se elimió con exito");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=REKE-LAPTOP;Initial Catalog=My_TestDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Usertab where Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id",int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=REKE-LAPTOP;Initial Catalog=My_TestDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Usertab values(@Id,@Name,@Age)",con);

            cmd.Parameters.AddWithValue("@Id",int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name",(textBox2.Text));
            cmd.Parameters.AddWithValue("@Age",double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Se guardó con exito");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
