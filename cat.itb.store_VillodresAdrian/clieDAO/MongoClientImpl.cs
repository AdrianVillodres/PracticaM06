using System;
using System.Collections.Generic;
using cat.itb.store_VillodresAdrian.connections;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace cat.itb.store_VillodresAdrian.clieDAO
{
   public class MongoClientImpl : ClientDAO
   {
       
       public void DeleteAll()
       {
           var database = MongoConnection.GetDatabase("itb");
           database.DropCollection("clients");
           
       }
       
        public void InsertAll( List<Client> clis)
        {
       
            DeleteAll();
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Client>("clients");

            try
            {
               collection.InsertMany(clis);
               Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nCollection clients inserted");
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Collection couldn't be inserted");
            }
            Console.ResetColor();
        }

        public List<Client> SelectAll()
        {
            var database = MongoConnection.GetDatabase("itb");
            var booksCollection = database.GetCollection<Client>("clients");

            var clis = booksCollection.AsQueryable<Client>().ToList();

            return clis;
        }


        public Client Select(int cliId)
        {
            var database = MongoConnection.GetDatabase("itb");
                var collection = database.GetCollection<Client>("clients");

                var dep =  collection.AsQueryable<Client>()
                        .Where(d => d._id == cliId)
                        .Single();
            return dep;
        }

        public Boolean Insert(Client dep)
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Client>("clients");

            Boolean bol;
            try
            {
                collection.InsertOne(dep);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nClients inserted");
                bol = true;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Collection couldn't be inserted");
                bol = false;
            }
            Console.ResetColor();
            
            return bol;
        }
        
      
        public Boolean Delete(int cliId)
        {
            Boolean bol;
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Client>("clients");

            var deleteFilter = Builders<Client>.Filter.Eq("_id", cliId);
            
            var cliDeleted = collection.DeleteOne(deleteFilter);
            Console.WriteLine("Client deleted: " + cliId);
            var num = cliDeleted.DeletedCount;
            if (cliDeleted.DeletedCount != 0)
            {
                bol = true;
            }
            else
            {
                bol = false;
            }

            return bol;
        }

        public Boolean Update(Client cli)
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Client>("clients");

            Delete(cli._id);
            Console.WriteLine("Employee updated: " + cli._id);
            return Insert(cli);
        }

   }
}