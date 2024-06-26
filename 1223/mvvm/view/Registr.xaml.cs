using _1223;
using Kinishka.mvvm.model;
using MongoDB.Driver.Core.Configuration;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kinishka.mvvm.view
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {

        public Registr()
        {
            InitializeComponent();
        }

       
        

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

            string username = txtName.Text;
            string password = txtPassword.Password;
            string role=txtRole.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите имя и пароль.");
                return;
            }
            try { 
            /*using (MySqlConnection connection = MySqlDB.Instance.GetConnection())
            {
                
                try
                {
               
                    string query = "INSERT INTO login (Name, Password, Role) VALUES (@Name, @Password, @Role)";
                    MySqlCommand sqlCmd = new MySqlCommand(query, connection);*/
            var connect = MySqlDB.Instance.GetConnection();
            if (connect == null)
                return;
            string query = "INSERT INTO login (Name, Password, Role) VALUES (@Name, @Password, @Role)";
            using (var sqlCmd = new MySqlCommand(query, connect))
            {
                        // Добавление параметров запроса
                        sqlCmd.Parameters.AddWithValue("@Name", username);
                        sqlCmd.Parameters.AddWithValue("@Password", password);
                        sqlCmd.Parameters.AddWithValue("@Role", role);
                        sqlCmd.ExecuteNonQuery(); // Выполнение запроса
                    }

                    MessageBox.Show("Вы успешно зарегистрировались."); // Показ сообщения об успешной регистрации
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                catch (MySqlException ex) when (ex.Number == 2627) // Unique constraint violation
                {
                    MessageBox.Show("Такой пользователь существует."); // Показ сообщения, если имя пользователя уже существует
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message); // Показ сообщения об ошибке
                }
               
            }
           
        }
    }


