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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SqlConnection getSqlConnection()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DE; 
                                        Initial Catalog=dotnet; 
                                        Integrated Security=True");
            return conn;

        }
        private void clear()
        {
            id.Clear();
            std_name.Clear();
            std_address.Clear();
            std_phone.Clear();
        }
        public void display()
        {
            SqlConnection conn = getSqlConnection();
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter dat = new SqlDataAdapter("Select * from student", conn);
            dat.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string query = $"insert into student values (@id,@name,@address,@phone_number)";
            cmd.Parameters.AddWithValue("@id", int.Parse(id.Text));
            cmd.Parameters.AddWithValue("@name", std_name.Text);
            cmd.Parameters.AddWithValue("@address", std_address.Text);
            cmd.Parameters.AddWithValue("@phone_number", std_phone.Text);
            cmd.CommandText = query;

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data inserted successfully");

            display();

            clear();


            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            display();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string query = $"UPDATE student SET std_name = @name, std_address = @address, std_phone = @phone_number WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", int.Parse(id.Text));
            cmd.Parameters.AddWithValue("@name", std_name.Text);
            cmd.Parameters.AddWithValue("@address", std_address.Text);
            cmd.Parameters.AddWithValue("@phone_number", std_phone.Text);
            cmd.CommandText = query;

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data updated successfully");

            display();

            clear();

            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = getSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string query = $"DELETE FROM student WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", int.Parse(id.Text));
            cmd.CommandText = query;

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data deleted successfully");

            display();

            clear();

            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            std_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            std_address.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            std_phone.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            display();
        }
    }
}
