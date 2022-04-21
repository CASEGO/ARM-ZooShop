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
    
    public partial class Staff : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= ARM.mdb";
        private OleDbConnection myConnection;
        public Staff()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aRMDataSet.Сотрудники". При необходимости она может быть перемещена или удалена.
            this.сотрудникиTableAdapter.Fill(this.aRMDataSet.Сотрудники);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "UPDATE Сотрудники SET Должность ='" + textBox2.Text + "' WHERE [Код] = " + kod;
            string query1 = "UPDATE Сотрудники SET Зарплата ='" + textBox3.Text + "' WHERE [Код] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            OleDbCommand command1 = new OleDbCommand(query1, myConnection);
            command1.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.сотрудникиTableAdapter.Fill(this.aRMDataSet.Сотрудники);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox4.Text);
            string Name = textBox3.Text;
            string ZP = textBox4.Text;
            string Status = textBox5.Text;
            string Time = textBox5.Text;
            string query = "INSERT INTO Сотрудники ([Код], [ФИО], [Зарплата], [Должность], [Дата]) VALUES (" + kod + ",'" + Name + "','" + ZP + "', '" + Status + "','" + Time + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.сотрудникиTableAdapter.Fill(this.aRMDataSet.Сотрудники);
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox9.Text);
            string query = "DELETE FROM Сотрудники WHERE [Код] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены!");
            this.сотрудникиTableAdapter.Fill(this.aRMDataSet.Сотрудники);
            textBox9.Clear();
        }
    }
}
