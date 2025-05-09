using System;
using System.Collections.Generic;
using cat.itb.store_VillodresAdrian.clieDAO;
using cat.itb.store_VillodresAdrian.empDAO;
using cat.itb.store_VillodresAdrian.depDAO;
using cat.itb.gestioHR.empDAO;

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
            EmployeeDAO empDAOFile = new SQLEmployeeImpl();

            ClientDAO cliDAOSQL = new SQLClientImpl();
            ClientDAO cliDAOMongo = new MongoClientImpl();
            ClientDAO cliDAOFile = new FileClientImpl();
        }

    }
}