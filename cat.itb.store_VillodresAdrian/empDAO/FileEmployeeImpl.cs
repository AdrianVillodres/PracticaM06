using System;
using System.Collections.Generic;
using System.IO;
using cat.itb.store_VillodresAdrian.empDAO;
using Newtonsoft.Json;

namespace cat.itb.store_VillodresAdrian.empDAO
{
    public class FileEmployeeImpl : EmployeeDAO
    {
        public void DeleteAll()
        {
            throw new System.NotImplementedException();
        }

        public void InsertAll(List<Employee> deps)
        {
            FileInfo file = new FileInfo("../../../files/employees.json");
            StreamWriter sw = file.CreateText();
            try
            {
                foreach (var dep in deps)
                    sw.WriteLine(JsonConvert.SerializeObject(dep));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSuccesful inserts in file employees.json");
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInserts in employees.json couldn't be executed");
            }
            sw.Close();
            Console.ResetColor();
        }

        public List<Employee> SelectAll()
        {
            FileInfo file = new FileInfo("../../../files/employees.json");
            StreamReader sr = file.OpenText();
            string dept;
            List<Employee> list = new List<Employee>();
            while ((dept = sr.ReadLine()) != null)
                list.Add(JsonConvert.DeserializeObject<Employee>(dept));
            sr.Close();

            return list;
        }

        public Employee Select(int depId)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Employee dep)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int depId)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Employee dep)
        {
            throw new System.NotImplementedException();
        }
    }
}
