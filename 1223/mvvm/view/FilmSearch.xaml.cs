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
            try
            {


                /*using (MySqlConnection connection = MySqlDB.Instance.GetConnection())
                {
                    try
                    {

                        string query = "SELECT Title FROM film";
                        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(query, connection);*/
                var connect = MySqlDB.Instance.GetConnection();
                if (connect == null)
                    return;
                string query = "SELECT Title FROM film";
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(query, connect);
                DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    lstMovies.ItemsSource = dataTable.DefaultView;
                    lstMovies.DisplayMemberPath = "Title";
                MySqlDB.Instance.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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

            try
            {


                /* using (MySqlConnection connection = new MySqlConnection(connectionString))
                 {
                     try
                     {

                         string query = "SELECT * FROM film WHERE Title=@Title";
                         MySqlCommand sqlCommand = new MySqlCommand(query, connection);*/
                /* var connect = MySqlDB.Instance.GetConnection();
                 if (connect == null)
                     return;*/
                string query = $"SELECT * FROM film WHERE Title like '{title}';";
                /* using (var sqlCommand = new MySqlCommand(query, connect))
                 using (MySqlDataReader reader = sqlCommand.ExecuteReader())
                 {*/
                var result = new List<Film>();
                var connect = MySqlDB.Instance.GetConnection();
                if (connect == null)
                    return;
                using (var mc = new MySqlCommand(query, connect))
                using (var reader = mc.ExecuteReader())
                {
                    Film film = null;
                    int id;
                    while (reader.Read())
                    {
                        id = reader.GetInt32("id");
                        film = result.FirstOrDefault(s => s.ID == id);
                        if (film == null)
                        {
                            film = new Film();
                            result.Add(film);
                            film.ID = id;
                            film.Title = reader.GetString("Title");
                            film.regiser = reader.GetString("regiser");
                            film.filmgenre = reader.GetString("filmgenre");
                            film.create = reader.GetString("create");
                            film.Description = reader.GetString("Description");
                            film.Price = reader.GetDecimal("Price");

                        }

                        {
                            foreach (var item in result)

                                MessageBox.Show($"Название: {item.Title}\nРежиссер: {item.regiser}\nГод выпуска: {item.create}\nЖанр: {item.filmgenre}\nОписание: {item.Description}\nЦена:{item.Price}");
                        }

                        //  sqlCommand.Parameters.AddWithValue("@Title", title);

                        /*if (reader.Read())
                        {
                        }*/

                        // }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

     
    }
}

