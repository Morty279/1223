using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kinishka.mvvm.model
{
    public class MySqlDB
    {
        MySqlConnection mySqlConnection;

        private MySqlDB()
        {
            
             mySqlConnection = new MySqlConnection("server=localhost;user=morty;password=123654;database=kino;Character Set=utf8mb4");

            
        }

        private bool OpenConnection()
        {
            //if (mySqlConnection.State == System.Data.ConnectionState.Open)
               // return true;

            try
            {
                mySqlConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

       public void CloseConnection()
        {
            try
            {
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal MySqlConnection GetConnection()
        {
            if (mySqlConnection.State != System.Data.ConnectionState.Open)
                if (!OpenConnection())
                    return null;

            return mySqlConnection;
        }

        static MySqlDB instance;
        public static MySqlDB Instance
        {
            get
            {
                if (instance == null)
                    instance = new MySqlDB();
                return instance;
            }
        }

        public int GetAutoID(string table)
        {
            try
            {
                string sql = "SHOW TABLE STATUS WHERE `Name` = '" + table + "'";
                using (var mc = new MySqlCommand(sql, mySqlConnection))
                using (var reader = mc.ExecuteReader())
                {
                    if (reader.Read())
                        return reader.GetInt32("Auto_increment");
                }
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }
    }
}
