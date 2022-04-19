using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ARM_zoo
{
    public partial class Product : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= ARM.mdb";
        private OleDbConnection myConnection;
        public Product()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aRMDataSet.Товар". При необходимости она может быть перемещена или удалена.
            this.товарTableAdapter.Fill(this.aRMDataSet.Товар);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Name = textBox7.Text;
            string query = "SELECT [Код], Наименование, Категория, Стоимость, Количество, Поставщик FROM Товар WHERE  Категория LIKE '%" + Name + "%' ";
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable dt = new DataTable();
            command.Fill(dt);
            dataGridView1.DataSource = dt;
            myConnection.Close();
            textBox7.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            dataGridView1.DataSource = товарBindingSource;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox8.Text);
            string query = "DELETE FROM Товар WHERE [Код] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.товарTableAdapter.Fill(this.aRMDataSet.Товар);
            textBox8.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string Name = textBox2.Text;
            string category = textBox3.Text;
            string Price = textBox4.Text;
            string kolvo = textBox5.Text;
            string supp = textBox6.Text;
            string query = "INSERT INTO Товар ([Код], [Наименование], [Категория], [Стоимость], [Количество], [Поставщик]) VALUES (" + kod + ",'" + Name + "','" + category + "', '" + Price + "','" + kolvo + "','" + supp + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.товарTableAdapter.Fill(this.aRMDataSet.Товар);
            textBox1.Clear();
            textBox2.Clear(); 
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
