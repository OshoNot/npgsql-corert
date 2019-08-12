using System;
using Npgsql;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var connString = "Host=database;Port=5432;Username=dbuser;Password=dbpassword;Database=dbsample";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT * FROM map", conn))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        Console.WriteLine("Name: "+reader.GetString(0));

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO map (name, value) VALUES ('newUser', 'newValue')";
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("New record inserted.");
                
                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT * FROM map", conn))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        Console.WriteLine("Name: "+reader.GetString(0));

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE from map WHERE name=@p";
                    cmd.Parameters.AddWithValue("p", "foo");
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Record name 'foo' deleted.");

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT * FROM map", conn))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        Console.WriteLine("Name: "+reader.GetString(0));

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE map SET name = 'updatedUser' WHERE name = @p"";
                    cmd.Parameters.AddWithValue("p", "foo");
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Record name 'wo' updated to 'updatedUser'.");

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT * FROM map", conn))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        Console.WriteLine("Name: "+reader.GetString(0));
            }
        }
    }
}
