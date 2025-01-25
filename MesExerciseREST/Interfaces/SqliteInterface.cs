using Microsoft.Data.Sqlite;
using System.ComponentModel.DataAnnotations;

namespace MesExerciseREST.Interfaces
{
    public class SqliteInterface:InterfaceBase
    {
        SqliteConnection _connection;
        public SqliteInterface()
        {
            _connection = new SqliteConnection("Data Source=applicationDB.db");
            _connection.Open();
            ensureTableCreated();
        }

        private void ensureTableCreated()
        {
            var command = _connection.CreateCommand();
            command.CommandText = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name = 'items'";
            var reader = command.ExecuteReader();
            reader.Read();
            if(reader.GetInt32(0) == 0)
            {
                reader.Close();
                command = _connection.CreateCommand();
                command.CommandText =
                    "CREATE TABLE items(Key TEXT NOT NULL PRIMARY KEY," +
                    "Value TEXT NOT NULL);";
                command.ExecuteNonQuery();
            }
            else
            {
                reader.Close();
            }
        }
        public bool DoesItemExist(string Key)
        {
            var command = _connection.CreateCommand();
            command.CommandText = "SELECT count(*) FROM items WHERE Key=$Key";
            command.Parameters.AddWithValue("Key", Key);
            var reader = command.ExecuteReader();
            reader.Read();
            return (reader.GetInt32(0) != 0);
        }
        public ExampleItem GetItem(string Key)
        {
            var command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM items WHERE Key=$Key";
            command.Parameters.AddWithValue("Key", Key);
            var reader = command.ExecuteReader();
            reader.Read();
            ExampleItem item = new ExampleItem();
            item.Key = reader.GetString(0);
            item.Value = reader.GetString(1);
            return item;
        }
        public void AddItem(ExampleItem NewItem)
        {
            var command = _connection.CreateCommand();
            command.CommandText = "INSERT INTO items VALUES($Key,$Value);";
            command.Parameters.AddWithValue("Key", NewItem.Key);
            command.Parameters.AddWithValue("Value", NewItem.Value);
            command.ExecuteNonQuery();
        }
        public void DeleteItem(string key)
        {
            var command = _connection.CreateCommand();
            command.CommandText = "DELETE FROM items WHERE Key=$Key;";
            command.Parameters.AddWithValue("Key", key);
            command.ExecuteNonQuery();
        }
        public void UpdateItem(ExampleItem UpdatedItem)
        {
            var command = _connection.CreateCommand();
            command.CommandText = "UPDATE items SET Value = $Value WHERE Key=$Key;";
            command.Parameters.AddWithValue("Key", UpdatedItem.Key);
            command.Parameters.AddWithValue("Value", UpdatedItem.Value);
            command.ExecuteNonQuery();
        }
        public IEnumerable<ExampleItem> SearchItemsByValue(string value)
        {
            var command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM items WHERE Value LIKE %$Value%;";
            command.Parameters.AddWithValue("Value", value);
            var reader = command.ExecuteReader();
            List<ExampleItem> items = new List<ExampleItem>();
            while (reader.Read())
            {
                ExampleItem Item = new ExampleItem();
                Item.Key = reader.GetString(0);
                Item.Value = reader.GetString(1);
                items.Add(Item);
            }
            return items;
        }
    }
}
