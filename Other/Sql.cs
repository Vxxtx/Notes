using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Newtonsoft.Json;

namespace Notes
{
    public class Sql
    {
        static SQLiteConnection con = new SQLiteConnection("Data Source=notes.db");

        /*
         * connects to notes.db and checks if table exists. If not, then creates it. Also loads data
        */
        public static List<NoteCategory> ConnectAndLoad()
        {
            List<NoteCategory> Categories = new List<NoteCategory>();

            try
            {
                con.Open();
            }
            catch
            {
                SQLiteCommand cmd_createdb = con.CreateCommand();
                cmd_createdb.CommandText = "CREATE DATABASE IF NOT EXISTS notes";
            }

            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS Categories (Category TEXT, Notes TEXT, PRIMARY KEY (Category))";
            cmd.ExecuteNonQuery();

            SQLiteCommand cmd_fetch = con.CreateCommand();
            cmd_fetch.CommandText = "SELECT * FROM Categories";
            cmd_fetch.CommandType = System.Data.CommandType.Text;

            SQLiteDataReader reader = cmd_fetch.ExecuteReader();

            while (reader.Read())
            {
                NoteCategory newCat = new NoteCategory(Convert.ToString(reader["Category"]), JsonConvert.DeserializeObject<List<NoteItem>>(Convert.ToString(reader["Notes"])));
                Categories.Add(newCat);
            }

            con.Close();
            return Categories;
        }

        public static void InsertNotesData(List<NoteCategory> data)
        {
            con.Open();

            // Empties table to be sure if data count is 0
            if (data.Count == 0)
            {
                SQLiteCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Categories";
                cmd.ExecuteNonQuery();

                con.Close();
                return;
            }

            // Get data, convert to json and insert
            for (int i = 0; i < data.Count; i++)
            {
                SQLiteCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Categories (Category, Notes) VALUES (@cat, @note) ON CONFLICT (Category) DO UPDATE SET Notes = @note";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SQLiteParameter("@cat", data[i].categoryName));
                cmd.Parameters.Add(new SQLiteParameter("@note", JsonConvert.SerializeObject(data[i].notes)));

                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        public static void CloseConnection()
        {
            con.Close();
        }
    }
}
