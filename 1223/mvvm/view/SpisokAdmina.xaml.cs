using Kinishka.mvvm.model;
using Kinishka.mvvm.viewmodel;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для SpisokAdmina.xaml
    /// </summary>
    public partial class SpisokAdmina : Window, INotifyPropertyChanged
    {
        public SpisokAdmina()
        {
            InitializeComponent();
            DataContext = this;
            FillData();
            
        }


           public Film SelectedFilm { get; set; }
        private ObservableCollection<Film> films;
        public ObservableCollection<Film> Films
        {
            get => films;
            set
            {
                films = value;
                Signal();
            }
        }
        protected void Signal([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void FillData()
        { 
            try
            {


               var result = new ObservableCollection<Film>();
                var connect = MySqlDB.Instance.GetConnection();
                if (connect == null)
                    return;
                string query = "SELECT *  FROM film";
                using (var mc = new MySqlCommand(query,connect)) 
                using (var reader = mc.ExecuteReader())
                {
                    Film film = new Film();
                    int id;
                    while (reader.Read())
                    {
                        id = reader.GetInt32("ID");
                        if (film.ID != id)
                        {
                            film = new Film();
                            result.Add(film);
                            film.ID = id;
                            film.Title = reader.GetString("Title");
                            film.regiser = reader.GetString("Regiser");
                            film.create = reader.GetString("Create");
                            film.filmgenre = reader.GetString("Filmgenre");
                            film.Description = reader.GetString("Description");
                            film.Price = reader.GetDecimal("Price");
                        }
                    }
                }
                Films = result;

                



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       

     

        private void delete(object sender, RoutedEventArgs e)
        {
            FilmRepository.Instance.Remove(SelectedFilm);
            Films.Remove(SelectedFilm);
        }

        private void edit(object sender, RoutedEventArgs e)
        {
        FilmRepository.Instance.UpdateFilm(SelectedFilm);
            EditFilm editFilm = new EditFilm(SelectedFilm);
            editFilm.Show();
        }
    }
}
