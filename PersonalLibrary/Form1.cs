using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySqlConnector;
using System.Linq;

namespace PersonalLibrary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        //Бутон за Вкарване на данни.
        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost; database=personallibrary; uid=root; password=123456;";

            MySqlConnection connection = new MySqlConnection(constring);
            connection.Open();

            MySqlCommand cmd = new MySqlCommand("insert into userlib values (@ID,@Title,@Author,@Pages)", connection);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Title", textBox2.Text);
            cmd.Parameters.AddWithValue("@Author", textBox3.Text);
            cmd.Parameters.AddWithValue("@Pages", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            
            connection.Close();
            MessageBox.Show("Successfully Saved");
           
        }
        //бутон за ъпдейтване на данни.
        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost; database=personallibrary; uid=root; password=123456;";

            MySqlConnection connection = new MySqlConnection(constring);
            connection.Open();

            MySqlCommand cmd = new MySqlCommand("Update userlib set Title=@Title, Author=@Author, Pages=@Pages where ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Title", textBox2.Text);
            cmd.Parameters.AddWithValue("@Author", textBox3.Text);
            cmd.Parameters.AddWithValue("@Pages", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Successfully Updated");

        }
        //Бутон за изтриване на данни.
        private void button3_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost; database=personallibrary; uid=root; password=123456;";

            MySqlConnection connection = new MySqlConnection(constring);
            connection.Open();

            MySqlCommand cmd = new MySqlCommand("Delete from userlib where ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Successfully Deleted");
        }
        //Бутон за Търсене на данни.
        private void button4_Click(object sender, EventArgs e)
        {
            string constring = "Server=localhost; database=personallibrary; uid=root; password=123456;";

            MySqlConnection connection = new MySqlConnection(constring);
            connection.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from userlib where ID=@ID", connection);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            dataGridView1.DataSource = datatable;

        }
          //метод за показване на базата данни в DataGridView при отваряне на приложението.
        private void list()
        {
            string constring = "Server=localhost; database=personallibrary; uid=root; password=123456;";
            MySqlConnection connection = new MySqlConnection(constring);
            connection.Open();

            string query = "Select * From userlib";
            MySqlDataAdapter da = new MySqlDataAdapter(query,connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource= dt;
            connection.Close();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            list();
        }
    }
}