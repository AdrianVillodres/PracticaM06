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
            
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO clients VALUES (@name, @address)", conn);
            
            foreach (var cli in clis)
            {
                cmd.Parameters.AddWithValue("_id", cli._id);
                cmd.Parameters.AddWithValue("name", cli.name);
                cmd.Parameters.AddWithValue("address", cli.address);
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
           
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO departments VALUES (@depno, @nom, @loc)", conn);

            Boolean bol; 
            cmd.Parameters.AddWithValue("depno", cli._id);
            cmd.Parameters.AddWithValue("nom", cli.name);
            cmd.Parameters.AddWithValue("loc", cli.address);
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
            
            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM clients WHERE _id =" +cliId, conn);

            try
            {
                 cmd.ExecuteNonQuery();
                 bol = true;
                 Console.WriteLine("Department with Id {0} deleted",
                    cliId);
            }
            catch
            {
                Console.WriteLine("Couldn't delete Department with Id {0}",cliId);
                bol = false;
            }

            conn.Close();
            return bol;
        }

        public Boolean Update(Client cli)
        {
            SQLConnection db = new SQLConnection();
           conn = db.GetConnection();
            NpgsqlCommand cmd = new NpgsqlCommand("UPDATE clients SET name = @nom, address = @address  WHERE _id = @empId", conn);
            Boolean bol; 
          
            cmd.Parameters.AddWithValue("nom", cli.name);
            cmd.Parameters.AddWithValue("address", cli.address);
            cmd.Parameters.AddWithValue("empId", cli._id);
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
        
    }
}