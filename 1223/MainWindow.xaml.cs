using _1223.mvvm.view;
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
                /* if (password == "1")
                 {
                     FilmCreate filmCreate = new FilmCreate();
                     filmCreate.Show();
                 }*/
                return;
            }




            try
            {
                /*using (MySqlConnection connection =  MySqlDB.Instance.GetConnection())
                {


                    try
                    {

                        string query = "SELECT Role FROM login WHERE Name = @Name AND Password = @Password";
                        MySqlCommand sqlCmd = new MySqlCommand(query, connection);*/
                var connect = MySqlDB.Instance.GetConnection();
                if (connect == null)
                    return;
                string query = "SELECT Role FROM login WHERE Name = @Name AND Password = @Password";
                using (var sqlCmd = new MySqlCommand(query, connect))
                {
                    // Добавление параметров запроса
                    sqlCmd.Parameters.AddWithValue("@Name", username);
                    sqlCmd.Parameters.AddWithValue("@Password", password);
                    object result = sqlCmd.ExecuteScalar(); // Выполнение запроса и получение роли пользователя





                    if (result != null)
                    {
                        string role = result.ToString();
                        if (role == "Admin")
                        {
                            // Открытие окна CreateFilm для администратора
                            if (MessageBox.Show("Нажми да если создать новый фильм. Нажми нет для изменения и удаления фильмов", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                            {
                                FilmCreate filmCreate = new FilmCreate();
                                filmCreate.Show();
                            }
                            else 
                            {
                                SpisokAdmina spisokAdmina = new SpisokAdmina();
                                spisokAdmina.Show();
                            }
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

        }
        



            private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            Registr registr = new Registr();
            registr.Show();
            this.Close();
        }

       
    }
}