using Kinishka.mvvm.model;
using Kinishka.mvvm.view;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kinishka.mvvm.viewmodel
{
   /* public class ListFilmVM : BaseVM
    {
        private MainVM mainVM;
        private string searchText = "";
        private ObservableCollection<Film> films;
        private Tag selectedTag;

        public VmCommand Create { get; set; }
        public VmCommand Edit { get; set; }
        public VmCommand Delete { get; set; }

        public Tag SelectedTag
        {
            get => selectedTag;
            set
            {
                selectedTag = value;
                Signal();
                Search();
            }
        }

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                Search();
            }
        }

        public ObservableCollection<Tag> AllTags { get; set; }
        public Film SelectedFilm { get; set; }
        public ObservableCollection<Film> Films
        {
            get => films;
            set
            {
                films = value;
                Signal();
            }
        }

        public ListFilmVM()
        {
            AllTags = new ObservableCollection<Tag>(TagsRepository.Instance.GetTags());
            AllTags.Insert(0, new Tag { ID = 0, Title = "Все теги" });
            SelectedTag = AllTags[0];
            string sql = "SELECT d.id, d.Title, d.Price,d.filmgenre d.Description, d.Image, tt.id AS tagId, tt.Title AS tagTitle FROM FilmTag cdt, film d, TagsTable tt WHERE cdt.idfilm = d.id AND cdt.idtag = tt.id order by d.id";

            Films = new ObservableCollection<Film>(FilmRepository.Instance.GetAllFilms(sql));

            Create = new VmCommand(() =>
            {
                  //ainVM.CurrentPage = new FilmCreate(mainVM);
            });

            Edit = new VmCommand(() => {
                if (SelectedFilm == null)
                    return;
                  //mainVM.CurrentPage = new FilmCreate(mainVM, SelectedFilm);
            });

            Delete = new VmCommand(() => {
                if (SelectedFilm == null)
                    return;

                if (MessageBox.Show("Удаление Фильма", "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    FilmRepository.Instance.Remove(SelectedFilm);
                    Films.Remove(SelectedFilm);
                }
            });

        }

        internal void SetMainVM(MainVM mainVM)
        {
            this.mainVM = mainVM;
        }

        private void Search()
        {
            Films = new ObservableCollection<Film>(films);
            FilmRepository.Instance.Search(SearchText, SelectedTag);

        }
    }*/
}
