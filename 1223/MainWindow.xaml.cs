using Kinishka.mvvm.model;
using Kinishka.mvvm.view;
using MongoDB.Driver.Core.Configuration;
using MySqlConnector;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1223
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        public MainWindow()
        {
            InitializeComponent();

        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Получение значений из текстовых полей
            string username = txtName.Text;
            string password = txtPassword.Password;

            // Проверка на заполнение всех полей
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста введите пароль и логин."); // Показ сообщения, если поля пусты
                return;
            }





            using (MySqlConnection connection =  MySqlDB.Instance.GetConnection())
            {
               
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open(); // Открытие подключения к базе данных
                }
                try
                {

                    string query = "SELECT Role FROM login WHERE Name = @Name AND Password = @Password";
                    MySqlCommand sqlCmd = new MySqlCommand(query, connection);
                    {
                        // Добавление параметров запроса
                        sqlCmd.Parameters.AddWithValue("@Name", username);
                        sqlCmd.Parameters.AddWithValue("@Password", password);
                        // object result = sqlCmd.ExecuteScalar(); // Выполнение запроса и получение роли пользователя

                        object result = sqlCmd.ExecuteScalar(); // Выполнение запроса и получение роли пользователя



                        if (result != null)
                        {
                            string role = result.ToString();
                            if (role == "Admin")
                            {
                                // Открытие окна CreateFilm для администратора
                                FilmCreate filmCreate = new FilmCreate();
                                filmCreate.Show();
                            }
                            else if (role == "User")
                            {
                                MessageBox.Show("Успешный вход."); // Показ сообщения об успешном входе для пользователя
                                                                   // Переход на основную форму для пользователя
                                FilmSearch filmSearch = new FilmSearch();
                                filmSearch.Show();
                            }
                            else
                            {
                                MessageBox.Show("Ошибка, Неверная роль");
                            }
                            connection.Close();
                            this.Close(); // Закрытие текущего окна
                            
                        }
                        else
                        {
                            MessageBox.Show("Неправильный логин или пароль."); // Показ сообщения об ошибке входа
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message); // Показ сообщения об ошибке
                }
                finally
                {
                    connection.Close(); // Явное закрытие соединения
                }
            }
        }


            private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            Registr registr = new Registr();
            registr.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FilmCreate filmCreate=new FilmCreate();
            filmCreate.Show();
        }
    }
}