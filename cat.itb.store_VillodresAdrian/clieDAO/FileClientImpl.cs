using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace cat.itb.store_VillodresAdrian.clieDAO
{
    public class FileClientImpl : ClientDAO
    {
        public void DeleteAll()
        {
            throw new System.NotImplementedException();
        }

        public void InsertAll(List<Client> clis)
        {
            FileInfo file = new FileInfo("../../../files/clients.json");
            StreamWriter sw = file.CreateText();
            try
            {
                foreach (var cli in clis)
                    sw.WriteLine(JsonConvert.SerializeObject(cli));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSuccesful inserts in file clients.json");
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInserts in clients.json couldn't be executed");
            }
            sw.Close();
            Console.ResetColor();
        }

        public List<Client> SelectAll()
        {
            FileInfo file = new FileInfo("../../../files/clients.json");
            StreamReader sr = file.OpenText();
            string cli;
            List<Client> list = new List<Client>();
            while ((cli = sr.ReadLine()) != null)
                list.Add(JsonConvert.DeserializeObject<Client>(cli));
            sr.Close();

            return list;
        }

        public Client Select(int cliId)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Client cli)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int cliId)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Client cli)
        {
            throw new System.NotImplementedException();
        }
        public List<Client> SelectByEmpId(int cliId)
        {
            throw new System.NotImplementedException();
        }

        public List<Client> SelectByEmpSurname(string surname)
        {
            throw new System.NotImplementedException();
        }
    }
}
