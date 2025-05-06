using System;
using System.Collections.Generic;
using cat.itb.gestioHR.depDAO;

namespace cat.itb.testDepDAO
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        
           DepartmentDAO depDAOSQL= new SQLDepartmentImpl();
           DepartmentDAO depDAOMongo= new MongoDepartmentImpl();
           DepartmentDAO depDAOFile = new FileDepartmentImpl();

            //SELECT ALL FROM SQL AND CREATE FILE
            Console.WriteLine("Get from PostgreSQL DB and insert into file:");
            depDAOFile.InsertAll(depDAOSQL.SelectAll());

            //SELECT ALL FROM File AND IMPORT TO MongoDB
            Console.WriteLine("\nGet from file and insert into MongoDB");
            depDAOMongo.InsertAll(depDAOFile.SelectAll());

            //SELECT AND SHOW ALL FROM SQL
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Select all from PostgreSQL");
            List<Department> deps1 = depDAOSQL.SelectAll();
            
            foreach (var dep in deps1)
            {
                Console.WriteLine("Department Id: {0}, Name: {1}, Location:: {2} ",
                    dep._id, dep.Name, dep.Loc);
            }

            //INSERT ONE TO POSTGRESQL
            Console.WriteLine("\nInserting one to PostgreSQL");
            var dep1 = new Department
            {
                _id = 17,
                Name = "NÒMINES",
                Loc = "SEVILLA"
            };
            depDAOSQL.Insert(dep1);    

            //SELECT ONE FROM POSTGRESQL
            Console.WriteLine("\nSelect one from PostgreSQL");
            Department dep2 = depDAOSQL.Select(17);
            Console.WriteLine("Department Id: {0}, Name: {1}, Location:: {2} ", 
                dep2._id, dep2.Name, dep2.Loc);
           
            //UPDATE TO POSTGRESQL
            Console.WriteLine("\nUpdating to PostgreSQL");
            dep2.Name = "nounom";
            dep2.Loc = "novaloc";
            depDAOSQL.Update(dep2);
            
            //DELETE ONE FROM POSTGRESQL
            Console.WriteLine("\nDeleting from PostgreSQL");
            depDAOSQL.Delete(17);            
                    
            //INSERT ALL TO MONGODB
            Console.WriteLine("\nInserting all to MongoDB");
            depDAOMongo.InsertAll(depDAOSQL.SelectAll());

            //SELECT AND SHOW FROM MONGODB
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nSelect from MongoDB");
            List<Department> deps2 = depDAOMongo.SelectAll();
            
            foreach (var dep in deps2)
            {
                Console.WriteLine("Department Id: {0}, Name: {1}, Location:: {2} ",
                    dep._id, dep.Name, dep.Loc);
            }
           
            //INSERT ONE TO MONGODB
            //Console.WriteLine("\nInserting one to MongoDB");
            var dep3 = new Department
            {
            _id = 18,
            Name = "COMPTABILITAT",
            Loc = "REUS"
            };
            depDAOMongo.Insert(dep3);

            //SELECT ONE FROM MONGODB
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nSelect one from MongoDB");
            Department dep4 = depDAOMongo.Select(18);
            Console.WriteLine("Department Id: {0}, Name: {1}, Location:: {2} ", 
            dep4._id, dep4.Name, dep4.Loc);

            //UPDATE TO MONGODB
            Console.WriteLine("\nUpdating to MongoDB");
            dep4.Name = "nounom2";
            dep4.Loc = "novaloc2";
            depDAOMongo.Update(dep4);

            //DELETE ONE FROM MONGODB
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nDeleting from MongoDB");
            depDAOMongo.Delete(18);

            Console.ReadKey();
            
        }
        
    }
}