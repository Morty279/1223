using Kinishka.mvvm.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kinishka.mvvm.viewmodel
{
   /* public class FilmCreateVM : BaseVM
    {
        MainVM mainVM;
        ListBox listTags;
        private Film film = new();

        public Film Film
        {
            get => film;
            set
            {
                film = value;
                Signal();
            }
        }
        public VmCommand Save { get; set; }
        public List<Tag> AllTags { get; set; }

        public FilmCreateVM()
        {
            AllTags = TagsRepository.Instance.GetTags();

            Save = new VmCommand(() => {
                Film.Tags.Clear();
                foreach (Tag tag in listTags.SelectedItems)
                    Film.Tags.Add(tag);

                if (Film.ID == 0)
                    FilmRepository.Instance.AddFilm(Film);
                else
                    FilmRepository.Instance.UpdateFilm(Film);

                //mainVM.CurrentPage = new FilmCreate(mainVM);
            });



        }

        internal void SetMainVM(MainVM mainVM,
            ListBox listTags)
        {
            this.mainVM = mainVM;
            this.listTags = listTags;
        }

        internal void SetEditFilm(Film selectedFilm, System.Windows.Threading.Dispatcher dispatcher)
        {
            Film = selectedFilm;
            foreach (var tag in Film.Tags)
            {
                var search = AllTags.FirstOrDefault(s => s.ID == tag.ID);
                if (search != null)
                {
                    search.Selected = true;
                }
            }
        }
    }*/
}
