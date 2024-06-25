using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinishka.mvvm.model
{
   /*  public class FilmRepository
    {
        private FilmRepository()
        {

        }

        static FilmRepository instance;
        public static FilmRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new FilmRepository();
                return instance;
            }
        }

        internal IEnumerable<Film> GetAllFilms(string sql)
        {
            var result = new List<Film>();
            var connect = MySqlDB.Instance.GetConnection();
            if (connect == null)
                return result;
            using (var mc = new MySqlCommand(sql, connect))
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
                        film.Price = reader.GetDouble("Price");

                    }
                    Tag tag = new Tag
                    {
                        ID = reader.GetInt32("tagId"),
                        Title = reader.GetString("tagTitle"),
                        filmgenre = reader.GetString("tagfilmgenre"),
                    };
                    film.Tags.Add(tag);
                }
            }

            return result;
        }


        internal void UpdateFilm(Film film)
        {
            using (var connect = MySqlDB.Instance.GetConnection())
            {
                if (connect == null) return;

                var transaction = connect.BeginTransaction();
                try
                {
                    // Удаление связей фильма с тегами
                    string sql = "DELETE FROM FilmTag WHERE idfilm = @filmId;";
                    using (var mc = new MySqlCommand(sql, connect))
                    {
                        mc.Parameters.AddWithValue("@filmId", film.ID);
                        mc.ExecuteNonQuery();
                    }

                    // Обновление информации о фильме
                    sql = "UPDATE film SET Title = @title, regiser = @regiser, create = @create, filmgenre = @filmgenre, Description = @description, Price = @price WHERE Id = @filmId;";
                    using (var mc = new MySqlCommand(sql, connect))
                    {
                        mc.Parameters.AddWithValue("@title", film.Title);
                        mc.Parameters.AddWithValue("@regiser", film.regiser);
                        mc.Parameters.AddWithValue("@create", film.create);
                        mc.Parameters.AddWithValue("@filmgenre", film.filmgenre);
                        mc.Parameters.AddWithValue("@description", film.Description);
                        mc.Parameters.AddWithValue("@price", film.Price);
                        mc.Parameters.AddWithValue("@filmId", film.ID);
                        mc.ExecuteNonQuery();
                    }

                    // Добавление новых связей фильма с тегами
                    foreach (var tag in film.Tags)
                    {
                        sql = "INSERT INTO FilmTag (idfilm, idtag) VALUES (@filmId, @tagId);";
                        using (var mcCross = new MySqlCommand(sql, connect))
                        {
                            mcCross.Parameters.AddWithValue("@filmId", film.ID);
                            mcCross.Parameters.AddWithValue("@tagId", tag.ID);
                            mcCross.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        internal IEnumerable<Film> Search(string searchText, Tag selectedTag)
        {
            string sql = "SELECT d.id, d.Title,  d.Price, d.filmgenre, d.Description,  tt.id AS tagId, tt.Title AS tagTitle FROM FilmTag cdt, film d, TagsTable tt WHERE cdt.idfilm = d.id AND cdt.idtag = tt.id";
            sql += " AND (d.Title LIKE '%" + searchText + "%'";
            sql += " OR d.Description LIKE '%" + searchText + "%') order by d.id";

            if (selectedTag.ID != 0)
            {
                var result = GetAllFilms(sql).Where(s => s.Tags.FirstOrDefault(s => s.ID == selectedTag.ID) != null);
                return result;
            }
            return GetAllFilms(sql);
        }

        internal void Remove(Film film)
        {
            var connect = MySqlDB.Instance.GetConnection();
            if (connect == null)
                return;

            string sql = "DELETE FROM FilmTag WHERE idfilm = '" + film.ID + "';";
            sql += "DELETE FROM film WHERE id = '" + film.ID + "';";

            using (var mc = new MySqlCommand(sql, connect))
                mc.ExecuteNonQuery();
        }

        internal void AddFilm(Film film)
        {
            var connect = MySqlDB.Instance.GetConnection();
            if (connect == null)
                return;

            int id = MySqlDB.Instance.GetAutoID("film");

            string sql = "INSERT INTO film VALUES (0, @title,  @regiser,@create,@filmgenre, @description,@price)";
            using (var mc = new MySqlCommand(sql, connect))
            {
                mc.Parameters.Add(new MySqlParameter("title", film.Title));
                mc.Parameters.Add(new MySqlParameter("regiser", film.regiser));
                mc.Parameters.Add(new MySqlParameter("create", film.create));
                mc.Parameters.Add(new MySqlParameter("filmgenre", film.filmgenre));
                mc.Parameters.Add(new MySqlParameter("description", film.Description));
                mc.Parameters.Add(new MySqlParameter("price", film.Price));
                if (mc.ExecuteNonQuery() > 0)
                {
                    sql = "";
                    foreach (var tag in film.Tags)
                        sql += "INSERT INTO FilmTag VALUES (" + id + "," + tag.ID + ");";
                    using (var mcCross = new MySqlCommand(sql, connect))
                        mcCross.ExecuteNonQuery();
                }
            }
        }
    }*/
}
