using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinishka.mvvm.model
{
  /*  internal class TagsRepository
    {
        private TagsRepository()
        {

        }
        static TagsRepository instance;
        public static TagsRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new TagsRepository();
                return instance;
            }
        }

        internal List<Tag> GetTags()
        {
            List<Tag> result = new List<Tag>();
            var connect = MySqlDB.Instance.GetConnection();
            if (connect == null)
                return result;

            string sql = "SELECT * FROM Tags";
            using (var mc = new MySqlCommand(sql, connect))
            using (var reader = mc.ExecuteReader())
            {
                while (reader.Read())
                {
                    var tag = new Tag
                    {
                        ID = reader.GetInt32("id"),
                        Title = reader.GetString("Title"),
                        filmgenre = reader.GetString("filmgenre")
                    };
                    result.Add(tag);
                }
            }
            return result;
        }
    }*/
}
