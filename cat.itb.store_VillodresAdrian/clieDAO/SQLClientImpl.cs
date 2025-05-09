using System;
using System.Collections.Generic;
using cat.itb.store_VillodresAdrian.connections;
using Npgsql;

namespace cat.itb.store_VillodresAdrian.clieDAO
{
    public class SQLClientImpl : ClientDAO
    {

        private NpgsqlConnection conn;

        public void DeleteAll()
        {
            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();

            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM clients", conn);

            try
            {
                cmd.ExecuteNonQuery();

                Console.WriteLine("clients deleted");
            }
            catch
            {
                Console.WriteLine("Couldn't delete Clients");

            }

            conn.Close();

        }

        public void InsertAll(List<Client> clis)
        {
            DeleteAll();
            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();

            var cmd = new NpgsqlCommand(@"INSERT INTO clients (_id, name, address, city, st, zipcode, area, phone, empid, credit, comments) VALUES (@id, @name, @address, @city, @st, @zipcode, @area, @phone, @empid, @credit, @comments)", conn);

            foreach (var cli in clis)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", cli._id);
                cmd.Parameters.AddWithValue("name", cli.name);
                cmd.Parameters.AddWithValue("address", cli.address);
                cmd.Parameters.AddWithValue("city", cli.city);
                cmd.Parameters.AddWithValue("st", cli.st ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("zipcode", cli.zipcode);
                cmd.Parameters.AddWithValue("area", cli.area);
                cmd.Parameters.AddWithValue("phone", cli.phone ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("empid", cli.empid);
                cmd.Parameters.AddWithValue("credit", cli.credit);
                cmd.Parameters.AddWithValue("comments", cli.comments ?? (object)DBNull.Value);
                cmd.Prepare();
                try
                {
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Department with Id {0} and Name {1} added",
                        cli._id, cli.name);
                }
                catch
                {
                    Console.WriteLine("Couldn't add Department with Id {0}", cli._id);
                }

                cmd.Parameters.Clear();
            }

            conn.Close();
        }

        public List<Client> SelectAll()
        {
            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();

            var cmd = new NpgsqlCommand("SELECT * FROM clients", conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            List<Client> clis = new List<Client>();

            while (dr.Read())
            {
                Client cli = new Client();
                cli._id = dr.GetInt32(0);
                cli.name = dr.GetString(1);
                cli.address = dr.GetString(2);
                cli.city = dr.GetString(3);
                cli.st = dr.IsDBNull(4) ? null : dr.GetString(4);
                cli.zipcode = dr.GetString(5);
                cli.area = dr.GetInt32(6);
                cli.phone = dr.IsDBNull(7) ? null : dr.GetString(7);
                cli.empid = dr.GetInt32(8);
                cli.credit = dr.GetDecimal(9);
                cli.comments = dr.IsDBNull(10) ? null : dr.GetString(10);

                clis.Add(cli);
            }

            conn.Close();
            return clis;
        }

        public Client Select(int cliId)
        {

            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM clients WHERE _id =" + cliId, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            Client cli = new Client();

            if (dr.Read())
            {
                cli._id = dr.GetInt32(0);
                cli.name = dr.GetString(1);
                cli.address = dr.GetString(2);
                cli.city = dr.GetString(3);
                cli.st = dr.IsDBNull(4) ? null : dr.GetString(4);
                cli.zipcode = dr.GetString(5);
                cli.area = dr.GetInt32(6);
                cli.phone = dr.IsDBNull(7) ? null : dr.GetString(7);
                cli.empid = dr.GetInt32(8);
                cli.credit = dr.GetDecimal(9);
                cli.comments = dr.IsDBNull(10) ? null : dr.GetString(10);

            }
            else
            {
                cli = null;

            }
            conn.Close();
            return cli;

        }

        public Boolean Insert(Client cli)
        {

            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();

            var cmd = new NpgsqlCommand(@"INSERT INTO clients 
    (_id, name, address, city, st, zipcode, area, phone, empid, credit, comments)
    VALUES (@id, @name, @address, @city, @st, @zipcode, @area, @phone, @empid, @credit, @comments)", conn);

            Boolean bol;

            cmd.Parameters.AddWithValue("id", cli._id);
            cmd.Parameters.AddWithValue("name", cli.name);
            cmd.Parameters.AddWithValue("address", cli.address);
            cmd.Parameters.AddWithValue("city", cli.city);
            cmd.Parameters.AddWithValue("st", cli.st);
            cmd.Parameters.AddWithValue("zipcode", cli.zipcode);
            cmd.Parameters.AddWithValue("area", cli.area);
            cmd.Parameters.AddWithValue("phone", cli.phone);
            cmd.Parameters.AddWithValue("empid", cli.empid);
            cmd.Parameters.AddWithValue("credit", cli.credit);
            cmd.Parameters.AddWithValue("comments", cli.comments);
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
                bol = true;
                Console.WriteLine("Client with _id {0} and name {1} added",
                    cli._id, cli.name);
            }
            catch
            {
                bol = false;
                Console.WriteLine("Couldn't add Client with Id {0}", cli._id);
            }

            conn.Close();
            return bol;

        }

        public Boolean Delete(int cliId)
        {

            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();
            Boolean bol;

            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM clients WHERE _id =" + cliId, conn);

            try
            {
                cmd.ExecuteNonQuery();
                bol = true;
                Console.WriteLine("Department with Id {0} deleted",
                   cliId);
            }
            catch
            {
                Console.WriteLine("Couldn't delete Department with Id {0}", cliId);
                bol = false;
            }

            conn.Close();
            return bol;
        }

        public Boolean Update(Client cli)
        {
            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();
            var cmd = new NpgsqlCommand(@"UPDATE clients 
    SET name = @name, address = @address, phone = @phone 
    WHERE _id = @id", conn);
            Boolean bol;
            cmd.Parameters.AddWithValue("name", cli.name);
            cmd.Parameters.AddWithValue("address", cli.address);
            cmd.Parameters.AddWithValue("phone", cli.phone);
            cmd.Parameters.AddWithValue("id", cli._id);
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
                bol = true;
                Console.WriteLine("Client with ID {0} updated", cli._id);
            }
            catch
            {
                bol = false;
                Console.WriteLine("Couldn't update Department {0}", cli.name);
            }


            conn.Close();
            return bol;
        }
        public List<Client> SelectByEmpId(int CliId)
        {
            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM clients WHERE empid =" + CliId, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            List<Client> clis = new List<Client>();

            while (dr.Read())
            {
                Client cli = new Client();
                cli._id = dr.GetInt32(0);
                cli.name = dr.GetString(1);
                cli.address = dr.GetString(2);
                clis.Add(cli);
            }

            conn.Close();
            return clis;
        }

        public List<Client> SelectByEmpSurname(string surname)
        {
            List<Client> clis = new List<Client>();
            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();
            string query = @"
            SELECT c._id, c.name, c.address, c.city, c.st, c.zipcode, 
                   c.area, c.phone, c.empid, c.credit, c.comments
            FROM clients c
            JOIN employees e ON c.empid = e._id
            WHERE e.surname ILIKE @surname";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("surname", "%" + surname + "%");

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Client cli = new Client();
                        cli._id = dr.GetInt32(0);
                        cli.name = dr.GetString(1);
                        cli.address = dr.GetString(2);
                        cli.city = dr.GetString(3);
                        cli.st = dr.IsDBNull(4) ? null : dr.GetString(4);
                        cli.zipcode = dr.GetString(5);
                        cli.area = dr.GetInt32(6);
                        cli.phone = dr.IsDBNull(7) ? null : dr.GetString(7);
                        cli.empid = dr.GetInt32(8);
                        cli.credit = dr.GetDecimal(9);
                        cli.comments = dr.IsDBNull(10) ? null : dr.GetString(10);

                        clis.Add(cli);
                    }
                }
            }
            conn.Close();
            return clis;
        }

    }
}
