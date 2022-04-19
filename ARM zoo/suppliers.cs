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
    public partial class suppliers : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= ARM.mdb";
        private OleDbConnection myConnection;
        public suppliers()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void suppliers_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aRMDataSet.Поставщики". При необходимости она может быть перемещена или удалена.
            this.поставщикиTableAdapter.Fill(this.aRMDataSet.Поставщики);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string Name = textBox2.Text;
            string contact = textBox3.Text;
            string Tovar = textBox4.Text;
            string Price = textBox5.Text;
            string query = "INSERT INTO Поставщики ([Код], [Наименование], [Контакты], [Товар], [Оптовая цена]) VALUES (" + kod + ",'" + Name + "','" + contact + "', '" + Tovar + "','" + Price + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.поставщикиTableAdapter.Fill(this.aRMDataSet.Поставщики);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox8.Text);
            string query = "DELETE FROM Поставщики WHERE [Код] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.поставщикиTableAdapter.Fill(this.aRMDataSet.Поставщики);
            textBox8.Clear();
        }
    }
}
