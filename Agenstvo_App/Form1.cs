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

namespace Agenstvo_App
{
    public partial class Form1 : Form
    {
        #region Строка Подключения
        public static string connectString = "Server=DESKTOP-FE1KLBU;Database=BAZA;Integrated Security=true";
        SqlConnection myConnection = new SqlConnection(connectString);
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region Работники
        public new void Update()
        {
            myConnection.Open();

            string query = @"Select 
                      [id_Emp] as ID
                      ,[Fam_Emp] as Фамилия
                      ,[Zap] as Зарплата
                      ,[Pos] as Должность
                    FROM [BAZA].[dbo].[Employe]";

            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            command.ExecuteNonQuery();
            dataGridView1.Columns["ID"].Visible = false;
            myConnection.Close();
        }



        private void button13_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Employe] (Fam_Emp, Zap, Pos) VALUES (@Fam_Emp, @Zap, @Pos)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Fam_Emp", textBox1.Text);
                cmd.Parameters.AddWithValue("@Zap", textBox3.Text);
                cmd.Parameters.AddWithValue("@Pos", textBox2.Text);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            Update();
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                string s = dataGridView1[0, rowindex].Value.ToString();
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Employe] SET Fam_Emp = @Fam_Emp, Zap = @Zap, Pos = @Pos WHERE id_Emp = @id_Emp");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@id_Emp", s);
                cmd.Parameters.AddWithValue("@Fam_Emp", textBox1.Text);
                cmd.Parameters.AddWithValue("@Zap", textBox3.Text);
                cmd.Parameters.AddWithValue("@Pos", textBox2.Text);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                string s = dataGridView1[0, rowindex].Value.ToString();
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Employe] WHERE id_Emp = @id_Emp");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@id_Emp", s);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            Update();
        }

        #endregion

        #region Клиенты
        public void Update2()
        {
            myConnection.Open();

            string query = @"Select 
                     [id_Cust] as ID
                    ,[Fum_Cust] as Фамилия
                    ,[Number] as Номер_телефона
                    FROM [BAZA].[dbo].[Customers]";

            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            command.ExecuteNonQuery();
            dataGridView2.Columns["ID"].Visible = false;
            myConnection.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Customers] (Fum_Cust, Number) VALUES (@Fum_Cust, @Number)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Fum_Cust", textBox4.Text);
                cmd.Parameters.AddWithValue("@Number", maskedTextBox1.Text);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            Update2();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            int rowindex = dataGridView2.CurrentCell.RowIndex;
            textBox4.Text = dataGridView2.Rows[rowindex].Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView2.Rows[rowindex].Cells[2].Value.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                int rowindex = dataGridView2.CurrentCell.RowIndex;
                string s = dataGridView2[0, rowindex].Value.ToString();
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Customers] SET Fum_Cust = @Fum_Cust, Number = @Number WHERE id_Cust = @id_Cust");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@id_Cust", s);
                cmd.Parameters.AddWithValue("@Fum_Cust", textBox4.Text);
                cmd.Parameters.AddWithValue("@Number", maskedTextBox1.Text);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            Update2();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                int rowindex = dataGridView2.CurrentCell.RowIndex;
                string s = dataGridView2[0, rowindex].Value.ToString();
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Customers] WHERE id_Cust = @id_Cust");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@id_Cust", s);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            Update2();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Update2();
        }
        #endregion

        #region Отели
        public void Update3()
        {
            myConnection.Open();

            string query = @"Select 
                      [id_hotel] as ID
                     ,[Name] as Название
                     ,[Num_star] as Звезды
                     ,[Country] as Страна
                     ,[Breakfast] as Завтрак
                     ,[WiFi] as WIFI
                    FROM [BAZA].[dbo].[Hotel]";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            command.ExecuteNonQuery();
            dataGridView3.Columns["ID"].Visible = false;
            myConnection.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Update3();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Hotel] (Name, Num_star,Country, Breakfast, WiFi) VALUES (@Name, @Num_star, @Country,@Breakfast, @WiFi)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Name", textBox13.Text);
                cmd.Parameters.AddWithValue("@Num_star", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Country", textBox5.Text);
                if (checkBox1.Checked)
                {
                    cmd.Parameters.AddWithValue("@Breakfast", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Breakfast", 0);
                }

                if (checkBox2.Checked)
                {
                    cmd.Parameters.AddWithValue("@WiFi", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@WiFi", 0);
                }

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            Update3();

        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            int rowindex = dataGridView3.CurrentCell.RowIndex;
            textBox13.Text = dataGridView3.Rows[rowindex].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView3.Rows[rowindex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView3.Rows[rowindex].Cells[3].Value.ToString();
            if (dataGridView3.Rows[rowindex].Cells[4].Value.ToString() == "True")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }

            if (dataGridView3.Rows[rowindex].Cells[5].Value.ToString() == "True")
            {

                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                int rowindex = dataGridView3.CurrentCell.RowIndex;
                string s = dataGridView3[0, rowindex].Value.ToString();
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Hotel] SET Name = @Name, Num_star = @Num_star, Country=@Country, Breakfast = @Breakfast, WiFi = @WiFi WHERE id_hotel = @id_hotel");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@id_hotel", s);
                cmd.Parameters.AddWithValue("@Name", textBox13.Text);
                cmd.Parameters.AddWithValue("@Num_star", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Country", textBox5.Text);
                if (checkBox1.Checked)
                {
                    cmd.Parameters.AddWithValue("@Breakfast", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Breakfast", 0);
                }

                if (checkBox2.Checked)
                {
                    cmd.Parameters.AddWithValue("@WiFi", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@WiFi", 0);
                }
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            Update3();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                int rowindex = dataGridView3.CurrentCell.RowIndex;
                string s = dataGridView3[0, rowindex].Value.ToString();
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Hotel] WHERE id_hotel = @id_hotel");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@id_hotel", s);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            Update3();
        }
        #endregion

        #region Журнал
        public void Update4()
        {
            myConnection.Open();

            string query = @"SELECT
                      [id_jur] as ID
                     ,[Name] as Отель
                     ,[Fam_Emp] as Работник
                     ,[Fum_Cust] as Клиент
                     ,[Data] as Дата
                     ,[Prise] as Цена
                      FROM [BAZA].[dbo].[Jurnal]
                      LEFT JOIN [BAZA].[dbo].[Hotel]
                      ON Jurnal.id_hotel=Hotel.id_hotel
                      LEFT JOIN [BAZA].[dbo].[Employe]
                      ON Jurnal.id_Emp=Employe.id_Emp
                      LEFT JOIN [BAZA].[dbo].[Customers]
                      ON Jurnal.id_Cust=Customers.id_Cust
                      ORDER BY Data";

            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView5.DataSource = dt;
            command.ExecuteNonQuery();
            dataGridView5.Columns["ID"].Visible = false;
            myConnection.Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Update4();
            cmb();
        }
        public void cmb()
        {
            using (SqlConnection conn = new SqlConnection(@"Server=DESKTOP-FE1KLBU;Database=BAZA;Integrated Security=true"))
            {


                string query1 = "SELECT Name, id_hotel FROM Hotel";
                SqlDataAdapter da1 = new SqlDataAdapter(query1, conn);
                conn.Open();
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "Hotel");
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "id_hotel";
                comboBox2.DataSource = ds1.Tables["Hotel"];

                string query2 = "SELECT Fam_Emp,id_Emp FROM Employe";
                SqlDataAdapter da2 = new SqlDataAdapter(query2, conn);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2, "Employe");
                comboBox3.DisplayMember = "Fam_Emp";
                comboBox3.ValueMember = "id_Emp";
                comboBox3.DataSource = ds2.Tables["Employe"];

                string query3 = "SELECT Fum_Cust, id_Cust FROM Customers";
                SqlDataAdapter da3 = new SqlDataAdapter(query3, conn);
                DataSet ds3 = new DataSet();
                da3.Fill(ds3, "Customers");
                comboBox4.DisplayMember = "Fum_Cust";
                comboBox4.ValueMember = "id_Cust";
                comboBox4.DataSource = ds3.Tables["Customers"];
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Jurnal] (id_hotel, id_Emp , id_Cust, Data, Prise) VALUES (@id_hotel, @id_Emp, @id_Cust, @Data, @Prise) ");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@id_hotel", comboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@id_Emp", comboBox3.SelectedValue);
                cmd.Parameters.AddWithValue("@id_Cust", comboBox4.SelectedValue);
                cmd.Parameters.AddWithValue("@Data", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Prise", textBox10.Text);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            Update4();
        }

        private void dataGridView5_SelectionChanged(object sender, EventArgs e)
        {
          
            int rowindex = dataGridView5.CurrentCell.RowIndex;
            comboBox2.Text = dataGridView5.Rows[rowindex].Cells[1].Value.ToString();
            comboBox3.Text = dataGridView5.Rows[rowindex].Cells[2].Value.ToString();
            comboBox4.Text = dataGridView5.Rows[rowindex].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView5.Rows[rowindex].Cells[4].Value.ToString();
            textBox10.Text = dataGridView5.Rows[rowindex].Cells[5].Value.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                int rowindex = dataGridView5.CurrentCell.RowIndex;
                string s = dataGridView5[0, rowindex].Value.ToString();
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Jurnal]  SET id_hotel = @id_hotel, Id_Emp = @Id_Emp, id_Cust = @id_Cust, Data=@Data, Prise=@Prise  WHERE id_jur = @id_jur");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@id_jur", s);
                cmd.Parameters.AddWithValue("@id_hotel", comboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@Id_Emp", comboBox3.SelectedValue);
                cmd.Parameters.AddWithValue("@id_Cust", comboBox4.SelectedValue);
                cmd.Parameters.AddWithValue("@Data", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Prise", textBox10.Text);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            Update4();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                int rowindex = dataGridView5.CurrentCell.RowIndex;
                string s = dataGridView5[0, rowindex].Value.ToString();
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Jurnal] WHERE id_jur = @id_jur");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@id_jur", s);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            Update4();
        }
        #endregion

        #region Статистика по менеджерам в label (фильтрация+вычислительные операции)
        private void button8_Click(object sender, EventArgs e)
        {
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            if (checkBox3.Checked)
            {
                myConnection.Open();
                string query = @"SELECT 
                                 MAX(Zap)
                                 FROM [BAZA].[dbo].[Employe]
                                 WHERE Pos='Менеджер'";
                SqlCommand command = new SqlCommand(query, myConnection);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                label10.Text = dt.Rows[0][0].ToString();
                command.ExecuteNonQuery();
                myConnection.Close();
            }
            if (checkBox4.Checked)
            {
                myConnection.Open();
                string query = @"SELECT 
                                 MIN(Zap)
                                 FROM [BAZA].[dbo].[Employe]
                                 WHERE Pos='Менеджер'";
                SqlCommand command = new SqlCommand(query, myConnection);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                label11.Text = dt.Rows[0][0].ToString();
                command.ExecuteNonQuery();
                myConnection.Close();
            }
            if (checkBox5.Checked)
            {
                myConnection.Open();
                string query = @"SELECT 
                                 AVG(Zap)
                                 FROM [BAZA].[dbo].[Employe]
                                 WHERE Pos='Менеджер'";
                SqlCommand command = new SqlCommand(query, myConnection);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                label12.Text = dt.Rows[0][0].ToString();
                command.ExecuteNonQuery();
                myConnection.Close();
            }
            else
            {
                return;
            }
        }
        #endregion

        #region Фамилии от А-Я (сортировка)
        private void button9_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            string query = @"SELECT 
                              [id_Emp] as ID
                             ,[Fam_Emp] as Фамилия
                             ,[Zap] as Зарплата
                             ,[Pos] as Должность
                             FROM[BAZA].[dbo].[Employe]
                             ORDER BY Fam_Emp";

            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            command.ExecuteNonQuery();
            dataGridView1.Columns["ID"].Visible = false;
            myConnection.Close();
        }
        #endregion

        #region Сумма продаж по каждому сотруднику (группировка+джоин)
        private void button19_Click(object sender, EventArgs e)
        {
            myConnection.Open();

            string query = @"SELECT
                            Fam_Emp as Сотрудник
                            ,SUM(Jurnal.Prise) as Продажи
                            FROM Jurnal
                            JOIN Employe
                            ON Employe.id_Emp=Jurnal.id_Emp
                            GROUP BY Employe.Fam_Emp";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            command.ExecuteNonQuery();
            myConnection.Close();
        }
        #endregion

        #region Продажи в этом месяце(функция+фильтрация)
        private void button7_Click(object sender, EventArgs e)
        {
            myConnection.Open();

            string query =   @"SELECT
                               Fam_Emp as Сотрудник
                              ,Prise as Продажи
                              ,[Data] as Дата
                               FROM Jurnal
                               JOIN Employe
                               ON Employe.id_Emp=Jurnal.id_Emp
                               WHERE MONTH(Data)=MONTH(GETDATE())
                               GROUP BY Employe.Fam_Emp, Jurnal.[Data], Jurnal.[Prise]";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView6.DataSource = dt;
            command.ExecuteNonQuery();
            myConnection.Close();
        }
        #endregion

        #region Зарплата работников (подзапрос)
        private void button22_Click(object sender, EventArgs e)
        {
            myConnection.Open();

            string query = @"SELECT
                             Fam_Emp as Сотрудник
                            ,Zap as Зарплата
                             FROM Employe
                             WHERE Zap>(SELECT AVG(Zap) FROM Employe)";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView7.DataSource = dt;
            command.ExecuteNonQuery();
            myConnection.Close();
        }
        #endregion

        #region Средняя зарплата работников
        private void button23_Click(object sender, EventArgs e)
        {
            label23.Text = "";
            if (checkBox6.Checked)
            {
                myConnection.Open();
                string query = @"SELECT 
                                 AVG(Zap)
                                 FROM [BAZA].[dbo].[Employe]";
                SqlCommand command = new SqlCommand(query, myConnection);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                label23.Text = dt.Rows[0][0].ToString();
                command.ExecuteNonQuery();
                myConnection.Close();
            }
            else
            {
                return;
            }
        }

        #endregion

    }
}
