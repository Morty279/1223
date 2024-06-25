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
    /// Логика взаимодействия для FilmSearch.xaml
    /// </summary>
    public partial class FilmSearch : Window
    {
        public FilmSearch()
        {
            InitializeComponent();
            FillData();
        }

        private void FillData()
        {
            using (MySqlConnection connection = MySqlDB.Instance.GetConnection())
            {
                try
                {
                    connection.Open(); // Открытие соединения
                    string query = "SELECT Title FROM film";
                    MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    lstMovies.ItemsSource = dataTable.DefaultView;
                    lstMovies.DisplayMemberPath = "Title";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void lstMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)lstMovies.SelectedItem;
            string movieTitle = dataRowView["Title"].ToString();
            ShowMovieDetails(movieTitle);
        }

        private void ShowMovieDetails(string title)
        {
            // Обновленная строка подключения для MySQL
            string connectionString = "Server=localhost; Database=kino;Uid=morty;Pwd=123654;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Открытие соединения
                    string query = "SELECT * FROM film WHERE Title=@title";
                    MySqlCommand sqlCommand = new MySqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@title", title);
                    MySqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show($"Название: {reader["Title"]}\nРежиссер: {reader["regiser"]}\nГод выпуска: {reader["create"]}\nЖанр: {reader["filmgenre"]}\nОписание: {reader["Description"]}\nЦена:{reader["Price"]}");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close(); // Закрытие соединения
                }
            }
        }
    }
}
