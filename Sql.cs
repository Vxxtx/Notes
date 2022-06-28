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
         * connects to notes.db and checks if table exists. If not, then creates it.
        */
        public static SQLiteConnection Connect()
        {
            
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
            return con;
        }

        public static void InsertNotesData(List<NoteCategory> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                SQLiteCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Categories (Category, Notes) VALUES (@cat, @note)";
               // cmd.CommandText = "INSERT OR REPLACE INTO Categories (Category, Notes) VALUES (select Category FROM Categories WHERE Category = @cat)";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SQLiteParameter("@cat", data[i].categoryName));
                cmd.Parameters.Add(new SQLiteParameter("@note", JsonConvert.SerializeObject(data[i].notes)));

                cmd.ExecuteNonQuery();
            }
        }

        public static void CloseConnection()
        {
            con.Close();
        }
    }
}
