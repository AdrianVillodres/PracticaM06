using System;
using System.Collections.Generic;
using cat.itb.store_VillodresAdrian.clieDAO;
using cat.itb.store_VillodresAdrian.empDAO;
using cat.itb.store_VillodresAdrian.depDAO;

namespace cat.itb.storetest_VillodresAdrian
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DepartmentDAO depDAOSQL = new SQLDepartmentImpl();
            DepartmentDAO depDAOMongo = new MongoDepartmentImpl();
            DepartmentDAO depDAOFile = new FileDepartmentImpl();

            EmployeeDAO empDAOSQL = new SQLEmployeeImpl();
            EmployeeDAO empDAOMongo = new MongoEmployeeImpl();
            EmployeeDAO empDAOFile = new FileEmployeeImpl();

            ClientDAO cliDAOSQL = new SQLClientImpl();
            ClientDAO cliDAOMongo = new MongoClientImpl();
            ClientDAO cliDAOFile = new FileClientImpl();

            //Ex3
            /*Console.WriteLine("Get from PostgreSQL DB and insert into file:");
            empDAOFile.InsertAll(empDAOSQL.SelectAll());*/

            //Ex4
            /*Console.WriteLine("Get from PostgreSQL DB and insert into file:");
            cliDAOFile.InsertAll(cliDAOSQL.SelectAll());*/

            //Ex5
            /*Console.WriteLine("\nGet from file and insert into MongoDB");
            empDAOMongo.InsertAll(empDAOFile.SelectAll());*/

            //Ex6
            /*Console.WriteLine("\nGet from file and insert into MongoDB");
            cliDAOMongo.InsertAll(cliDAOFile.SelectAll());*/

            //Ex7
            /*Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nSelect one from MongoDB");
            Employee empMDB = empDAOMongo.Select(7499);
            Console.WriteLine("Employee Id: {0}, Name: {1}, Job: {2}, managerid: {3}, StartDate: {4}, Salary: {5}, Comission: {6}, departmentId: {7} ", empMDB._id, empMDB.surname, empMDB.job, empMDB.managerid, empMDB.startdate, empMDB.salary, empMDB.comission, empMDB.depid);
            Console.WriteLine("\nUpdating to MongoDB");
            empMDB.salary = 1800.00f;
            empDAOMongo.Update(empMDB);

            Console.WriteLine("\nSelect one from PostgreSQL");
            Employee empSQL = empDAOSQL.Select(7499);
            Console.WriteLine("Employee Id: {0}, Name: {1}, Job: {2}, managerid: {3}, StartDate: {4}, Salary: {5}, Comission: {6}, departmentId: {7} ", empSQL._id, empSQL.surname, empSQL.job, empSQL.managerid, empSQL.startdate, empSQL.salary, empSQL.comission, empSQL.depid);
            Console.WriteLine("\nUpdating to PostgreSQL");
            empSQL.salary = 1800.00f;
            empDAOSQL.Update(empSQL);
            empDAOFile.InsertAll(empDAOSQL.SelectAll());*/

            //Ex8
            /*Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nSelect one from MongoDB");
            Client cliMDB = cliDAOMongo.Select(101);
            Console.WriteLine("Employee Id: {0}, Name: {1}, address: {2}, city: {3}, st: {4}, zipcode: {5}, area: {6}, phone: {7}, empid: {8}, credit: {9}, comments: {10}, employee: {11} ", cliMDB._id, cliMDB.name, cliMDB.address, cliMDB.city, cliMDB.st, cliMDB.zipcode, cliMDB.area, cliMDB.phone, cliMDB.empid, cliMDB.credit, cliMDB.comments, cliMDB.employee);
            Console.WriteLine("\nUpdating to MongoDB");
            cliMDB.phone = "555-2331";
            cliDAOMongo.Update(cliMDB);

            Console.WriteLine("\nSelect one from PostgreSQL");
            Client cliSQL = cliDAOSQL.Select(101);
            Console.WriteLine("Employee Id: {0}, Name: {1}, address: {2}, city: {3}, st: {4}, zipcode: {5}, area: {6}, phone: {7}, empid: {8}, credit: {9}, comments: {10}, employee: {11} ", cliSQL._id, cliSQL.name, cliSQL.address, cliSQL.city, cliSQL.st, cliSQL.zipcode, cliSQL.area, cliSQL.phone, cliSQL.empid, cliSQL.credit, cliSQL.comments, cliSQL.employee);
            Console.WriteLine("\nUpdating to PostgreSQL");
            cliSQL.phone = "555-2331";
            cliDAOSQL.Update(cliSQL);
            cliDAOFile.InsertAll(cliDAOSQL.SelectAll());*/

            //Ex9
            /*Console.WriteLine("\nInserting one to PostgreSQL");
            var emp1 = new Employee
            {
                _id = 1567,
                surname = "MAYERS",
                job = "ANALYST",
                managerid = 7566,
                startdate = new DateTime(1996, 12, 17),
                salary = 3000.00f,
                comission = 0.00f,
                depid = 10
            };
            empDAOSQL.Insert(emp1);
            empDAOFile.InsertAll(empDAOSQL.SelectAll());*/


            //Ex10
            /*Employee empSQL = empDAOSQL.Select(7788);
            Department department = depDAOSQL.Select(empSQL.depid);
            Console.WriteLine("Employee Name: {0}, DepartmentLoc: {1} ",empSQL.surname, department.Loc);*/

            //Ex11
            /*List<Client> clisSQL = cliDAOSQL.SelectByEmpId(7844);
            foreach (Client cli in clisSQL)
            {
                Console.WriteLine("Client Id: {0}, Name: {1}, address: {2}, city: {3}, st: {4}, zipcode: {5}, area: {6}, phone: {7}, empid: {8}, credit: {9}, comments: {10}, employee: {11} ", cli._id, cli.name, cli.address, cli.city, cli.st, cli.zipcode, cli.area, cli.phone, cli.empid, cli.credit, cli.comments, cli.employee);
                cliDAOSQL.Delete(cli._id);
            }
            cliDAOFile.InsertAll(cliDAOSQL.SelectAll());
            List<Client> ClisMDB = cliDAOMongo.SelectByEmpId(10);
            foreach (Client cli in ClisMDB) {
                Console.WriteLine("Client Id: {0}, Name: {1}, address: {2}, city: {3}, st: {4}, zipcode: {5}, area: {6}, phone: {7}, empid: {8}, credit: {9}, comments: {10}, employee: {11} ", cli._id, cli.name, cli.address, cli.city, cli.st, cli.zipcode, cli.area, cli.phone, cli.empid, cli.credit, cli.comments, cli.employee);
                cliDAOMongo.Delete(cli._id);
            }*/


            //12
            List<Client> clisSQL2 = cliDAOSQL.SelectByEmpSurname("ARROYO");
            foreach (Client cli in clisSQL2)
            {
                Console.WriteLine("Name: {0}, phone: {1} ", cli.name, cli.phone);
            }
            Console.WriteLine("El numero de clients es: " + clisSQL2.Count);

            List<Client> ClisMDB2 = cliDAOMongo.SelectByEmpSurname("ARROYO");
            foreach (Client cli in ClisMDB2)
            {
                Console.WriteLine("Name: {0}, phone: {1} ", cli.name, cli.phone);
            }
            Console.WriteLine("El numero de clients es: " + ClisMDB2.Count);

        }


    }
}