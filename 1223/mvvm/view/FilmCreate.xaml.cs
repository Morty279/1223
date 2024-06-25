using Kinishka.mvvm.model;
using MySqlConnector;
using System;
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
    /// Логика взаимодействия для FilmCreate.xaml
    /// </summary>
    public partial class FilmCreate : Window
    {
        public FilmCreate()
        {
            InitializeComponent();
        }



        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            string regiser = txtregiser.Text;
            string create = txtcreate.Text;
            string filmgenre = txtfilmgenre.Text;
            string description = txtDescription.Text;
            string price = txtPrice.Text;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(regiser) || string.IsNullOrEmpty(create) || string.IsNullOrEmpty(filmgenre) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(price))
            {
                MessageBox.Show("Введите все данные");
                return;
            }

           

            // Создание нового соединения внутри блока using
            using (MySqlConnection connection = MySqlDB.Instance.GetConnection())
            {


              
                    connection.Open(); // Открытие подключения к базе данных
                


                try
                {
                        
                    
                    
                    string query = "INSERT INTO film (Title, Regiser, Create, Filmgenre, Description, Price) VALUES (@Title, @Regiser, @Create, @Filmgenre, @Description, @Price)";
                    MySqlCommand sqlCmd = new MySqlCommand(query, connection);
                    {
                        sqlCmd.Parameters.AddWithValue("@Title", title);
                        sqlCmd.Parameters.AddWithValue("@Regiser", regiser);
                        sqlCmd.Parameters.AddWithValue("@Create", create);
                        sqlCmd.Parameters.AddWithValue("@Filmgenre", filmgenre);
                        sqlCmd.Parameters.AddWithValue("@Description", description);
                        sqlCmd.Parameters.AddWithValue("@Price", price);
                        sqlCmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Фильм создан успешно.");
                    
                    /*else
                    {
                        MessageBox.Show("Соединение с базой данных не открыто.");
                    }*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при создании фильма: " + ex.Message);
                }
                // Блок finally не требуется, так как блок using автоматически закроет соединение
            }
            // Здесь код для обновления интерфейса или закрытия окна
        }
    }
}
