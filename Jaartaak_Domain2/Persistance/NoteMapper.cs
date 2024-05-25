using Jaartaak.Business;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaartaak.Persistance
{
    internal class NoteMapper
    {
        //fields
        private string _connectionstring;

        //constructor
        public NoteMapper(string connectionstring)
        {
            _connectionstring = connectionstring;
        }
        public List<Note> getNotesFromDB(int userID)
        {
            //select notitie.noteID, gebruiker.username, notitie.title, notitie.content, notitie.creationDate from databasenotities.notitie inner join databasenotities.gebruiker on notitie.userID  = gebruiker.userID
            //select notitie.*, gebruiker.username from databasenotities.notitie inner join databasenotities.gebruiker on notitie.userID = gebruiker.userID
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("select notitie.*, gebruiker.username from databasenotities.notitie inner join databasenotities.gebruiker on notitie.userID = gebruiker.userID where notitie.userID = @userID", conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Note> List = new List<Note>();
            while (reader.Read())
            {
                Note note = new Note(
                    Convert.ToInt32(reader["noteID"]),
                    Convert.ToString(reader["username"]),
                    Convert.ToString(reader["title"]),
                    Convert.ToString(reader["content"]),
                    Convert.ToDateTime(reader["creationDate"]));

                List.Add(note);

            }
            conn.Close();
            return List;
        }

        
        public Note addItemToDB(int userID, string title, string content, DateTime creationDate)
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO databasenotities.notitie (userID, title, content, creationDate) VALUES (@userID, @title, @content, @creationDate)", conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@content", content);
            cmd.Parameters.AddWithValue("@creationDate", creationDate);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                string userIDString = Convert.ToString(userID);
                // After successfully adding the item to the database, return the corresponding Note object
                int lastInsertedId = (int)cmd.LastInsertedId;
                Note newItem = new Note(lastInsertedId, userIDString, title, content, creationDate);
                return newItem;
            }
            catch (MySqlException ex)
            {
                // Log the exception
                Console.WriteLine("Error adding item to database: " + ex.Message);

                // Handle exceptions if necessary
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public List<Note> SearchNotes(int userID, string title)
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("select notitie.*, gebruiker.username from databasenotities.notitie inner join databasenotities.gebruiker on notitie.userID = gebruiker.userID where notitie.userID = @userID and notitie.title LIKE @title", conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@title","%" + title + "%");
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Note> List = new List<Note>();
            while (reader.Read())
            {
                Note note = new Note(
                    Convert.ToInt32(reader["noteID"]),
                    Convert.ToString(reader["username"]),
                    Convert.ToString(reader["title"]),
                    Convert.ToString(reader["content"]),
                    Convert.ToDateTime(reader["creationDate"]));

                List.Add(note);

            }
            conn.Close();
            return List;

        }

        //UPDATE databasenotities.notitie SET title = @newTitle, content = @newContent WHERE (`noteID` = @noteID);
        public void editNoteInDB(int noteID, string newTitle, string newContent)
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("UPDATE databasenotities.notitie SET title = @newTitle, content = @newContent WHERE (`noteID` = @noteID)", conn);
            cmd.Parameters.AddWithValue("@noteID", noteID);
            cmd.Parameters.AddWithValue("@newTitle", newTitle);
            cmd.Parameters.AddWithValue("@newContent", newContent);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating the note.", ex);
            }
        }

        public Note GetNoteById(int noteID)
        {
            
            string query = "SELECT * FROM databasenotities.notitie WHERE noteID = @noteID";
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@noteID", noteID);
            
            
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

            // After successfully adding the item to the database, return the corresponding Note object
            reader.Read();
            Note note = new Note(
                    Convert.ToString(reader["userID"]),
                    Convert.ToString(reader["title"]),
                    Convert.ToString(reader["content"]),
                    Convert.ToDateTime(reader["creationDate"])
            );
            conn.Close();
            return note;  
        }

        //DELETE FROM databasenotities.notitie WHERE (noteID = @noteID);
        public void deleteNoteFromDB(int noteID)
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM databasenotities.notitie WHERE (noteID = @noteID)", conn);
            cmd.Parameters.AddWithValue("@noteID", noteID);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating the note.", ex);
            }
        }

        //SELECT * FROM databasenotities.notitie WHERE userID = @userID
        //ORDER BY creationDate DESC;

        public List<Note> orderNotesByCreationDateDesc(int userID)
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM databasenotities.notitie WHERE userID = @userID ORDER BY creationDate DESC", conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Note> List = new List<Note>();
            while (reader.Read())
            {
                Note note = new Note(
                    Convert.ToInt32(reader["noteID"]),
                    Convert.ToString(reader["userID"]),
                    Convert.ToString(reader["title"]),
                    Convert.ToString(reader["content"]),
                    Convert.ToDateTime(reader["creationDate"]));

                List.Add(note);

            }
            conn.Close();
            return List;
        }

        public List<Note> orderNotesByCreationDateAsc(int userID)
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM databasenotities.notitie WHERE userID = @userID ORDER BY creationDate ASC", conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Note> List = new List<Note>();
            while (reader.Read())
            {
                Note note = new Note(
                    Convert.ToInt32(reader["noteID"]),
                    Convert.ToString(reader["userID"]),
                    Convert.ToString(reader["title"]),
                    Convert.ToString(reader["content"]),
                    Convert.ToDateTime(reader["creationDate"]));

                List.Add(note);

            }
            conn.Close();
            return List;
        }

        public List<Note> OrderNotesAlphabeticallyAsc(int userID)
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM databasenotities.notitie WHERE userID = @userID ORDER BY title ASC", conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Note> List = new List<Note>();
            while (reader.Read())
            {
                Note note = new Note(
                    Convert.ToInt32(reader["noteID"]),
                    Convert.ToString(reader["userID"]),
                    Convert.ToString(reader["title"]),
                    Convert.ToString(reader["content"]),
                    Convert.ToDateTime(reader["creationDate"]));

                List.Add(note);

            }
            conn.Close();
            return List;
        }

        public List<Note> OrderNotesAlphabeticallyDesc(int userID)
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM databasenotities.notitie WHERE userID = @userID ORDER BY title DESC", conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Note> List = new List<Note>();
            while (reader.Read())
            {
                Note note = new Note(
                    Convert.ToInt32(reader["noteID"]),
                    Convert.ToString(reader["userID"]),
                    Convert.ToString(reader["title"]),
                    Convert.ToString(reader["content"]),
                    Convert.ToDateTime(reader["creationDate"]));

                List.Add(note);

            }
            conn.Close();
            return List;
        }
    }
}
