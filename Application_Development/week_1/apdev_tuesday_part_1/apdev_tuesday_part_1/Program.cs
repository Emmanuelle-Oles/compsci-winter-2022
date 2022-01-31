using System;
using System.Data.SQLite;


namespace apdev_tuesday_part_1
{
    class Program
    {
        static void Main(string[] args)
        {

            ///////// first part of tutorial 1 /////////////////

            //string cs = "Data Source=:memory:";
            //string stm = "SELECT SQLITE_VERSION()";

            //using var con = new SQLiteConnection(cs);

            //con.Open();

            //using var cmd = new SQLiteCommand(stm, con);

            //string version = cmd.ExecuteScalar().ToString();

            //Console.WriteLine($"SQLite version; {version}");

            ///////// second part of tutorial  /////////////////

            // the @ allows to no escape the backslashes

            //string cs = @"URI=file:C:\Users\Emman\OneDrive\Desktop\test.db";

            //using var con = new SQLiteConnection(cs);

            //con.Open();

            //using var cmd = new SQLiteCommand(con);

            //cmd.CommandText = "DROP TABLE IF EXISTS cars";
            //cmd.ExecuteNonQuery();

            //cmd.CommandText = @"CREATE TABLE cars (id INTERGER PRIMARY KEY, name TEXT, price INT)";

            //cmd.ExecuteNonQuery();

            //cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Audi',52642)";
            //cmd.ExecuteNonQuery();

            //cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Mercedes',57127)";
            //cmd.ExecuteNonQuery();

            //cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Skoda',9000)";
            //cmd.ExecuteNonQuery();

            //cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Volvo',29000)";
            //cmd.ExecuteNonQuery();

            //cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Bentley',350000)";
            //cmd.ExecuteNonQuery();

            //cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Citroen',21000)";
            //cmd.ExecuteNonQuery();

            //cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Hummer',41400)";
            //cmd.ExecuteNonQuery();

            //cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Volkswagen',21600)";
            //cmd.ExecuteNonQuery();

            //Console.WriteLine("Table cars created");

            //cmd.CommandText = "DROP TABLE IF EXISTS cars";
            //cmd.ExecuteNonQuery();

            //cmd.CommandText = @"CREATE TABLE cars(id INTEGER PRIMARY KEY,
            //name TEXT, price INT)";
            //cmd.ExecuteNonQuery();

            //cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Audi',52642)";
            //cmd.ExecuteNonQuery();

            //cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Mercedes',57127)";
            //cmd.ExecuteNonQuery();


            //////////////////// Prepared statements ////////////////////////////


            //string cs = @"URI=file:C:\Users\Emman\OneDrive\Desktop\test.db";

            //using var con = new SQLiteConnection(cs);
            //con.Open();

            //using var cmd = new SQLiteCommand(con);
            //cmd.CommandText = "INSERT INTO cars(name, price) VALUES(@name, @price)";

            //cmd.Parameters.AddWithValue("@name", "BMW");
            //cmd.Parameters.AddWithValue("@price", 36600);

            //cmd.Prepare();

            //cmd.ExecuteNonQuery();

            //Console.WriteLine("row inserted");


            //////////////////// DataReader statements ////////////////////////////


            string cs = @"URI=file:C:\Users\Emman\OneDrive\Desktop\test.db";

            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM cars LIMIT 5";

            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine($"{ rdr.GetInt32(0)} { rdr.GetString(1)} {rdr.GetInt32(2)}");
            }
        }
    }
}
