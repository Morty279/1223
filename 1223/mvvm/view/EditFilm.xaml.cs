using Kinishka.mvvm.model;
using MySqlConnector;
using System;
using System.Collections.Generic;
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

namespace _1223.mvvm.view
{
    /// <summary>
    /// Логика взаимодействия для EditFilm.xaml
    /// </summary>
    public partial class EditFilm : Window
    {
        public EditFilm(Film selectedFilm)
        {
            InitializeComponent();

        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            string regiser = txtregiser.Text;
            string create = txtcreate.Text;
            string filmgenre = txtfilmgenre.Text;
            string description = txtDescription.Text;
            decimal price;

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Некорректная цена");
                return;
            }

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(regiser) || string.IsNullOrEmpty(create) || string.IsNullOrEmpty(filmgenre) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Введите все данные");
                return;
            }

            try
            {
               
                using (MySqlConnection connection = MySqlDB.Instance.GetConnection())
                {
                    if (connection == null)
                    {
                        return;
                    }

                    int ID = MySqlDB.Instance.GetAutoID("film");
                    
                    string query = "UPDATE film SET Title = @Title, Regiser = @Regiser, `Create` = @Create, Filmgenre = @Filmgenre, Description = @Description, Price = @Price WHERE ID = @ID";
                    using (MySqlCommand sqlCmd = new MySqlCommand(query, connection))
                    {
                        sqlCmd.Parameters.Add(new MySqlParameter("ID",ID));
                        sqlCmd.Parameters.Add(new MySqlParameter("Title", title));
                        sqlCmd.Parameters.Add(new MySqlParameter("Regiser", regiser));
                        sqlCmd.Parameters.Add(new MySqlParameter("Create", create));
                        sqlCmd.Parameters.Add(new MySqlParameter("Filmgenre", filmgenre));
                        sqlCmd.Parameters.Add(new MySqlParameter("Description", description));
                        sqlCmd.Parameters.Add(new MySqlParameter("Price", price));
                        sqlCmd.ExecuteNonQuery();
                        //  mc.Parameters.Add(new MySqlParameter("TeacherTitle", teacher.TeacherTitle));
                    }
                    MessageBox.Show("Фильм изменен.");

                    SpisokAdmina spisokAdmina = new SpisokAdmina();
                    spisokAdmina.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении фильма: " + ex.Message);
            }
        }
    }
}



