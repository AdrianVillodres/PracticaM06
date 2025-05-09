using System;
using System.Collections.Generic;
using cat.itb.store_VillodresAdrian.connections;
using cat.itb.store_VillodresAdrian.empDAO;
using Npgsql;

namespace cat.itb.gestioHR.empDAO
{
    public class SQLEmployeeImpl : EmployeeDAO
    {
        
        private NpgsqlConnection conn;

        public void DeleteAll()
        {
            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();
            
            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM employees", conn);

            try
            {
                cmd.ExecuteNonQuery();
              
                Console.WriteLine("employees deleted");
            }
            catch
            {
                Console.WriteLine("Couldn't delete employees");
                
            }

            conn.Close();
         
        }
        
        public void InsertAll(List<Employee> emps)
        {
            DeleteAll();
            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();
            
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO employees VALUES (@prodNum, @descripcio)", conn);
            
            foreach (var dep in emps)
            {
                cmd.Parameters.AddWithValue("empno", dep._id);
                cmd.Parameters.AddWithValue("nom", dep.surname);
                cmd.Parameters.AddWithValue("job", dep.job);
                cmd.Prepare();
                try
                {
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Employee with Id {0} and Name {1} added",
                        dep._id, dep.surname);
                }
                catch
                {
                    Console.WriteLine("Couldn't add Employee with Id {0}", dep._id);
                }
                
                cmd.Parameters.Clear();
            }
            
            conn.Close();
        }
        
        public List<Employee> SelectAll()
        {
            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();

            var cmd = new NpgsqlCommand("SELECT * FROM employees", conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            List<Employee> emps = new List<Employee>(); 
            
            while (dr.Read())
            {
                Employee emp = new Employee();
                emp._id = dr.GetInt32(0);
                emp.surname = dr.GetString(1);
                emp.job = dr.GetString(2);
                emp.managerid = dr.GetInt32(3);
                emp.startdate = dr.GetDateTime(4);
                emp.salary = dr.GetDouble(5);
                emp.comission = dr.GetDouble(6);
                emp.depid = dr.GetInt32(7);                
            }

            conn.Close();
            return emps;
        }
        
        public Employee Select(int empId)
        {
       
           SQLConnection db = new SQLConnection();
           conn = db.GetConnection();
           
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM employees WHERE _id =" + empId, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            Employee emp = new Employee();
            
            if (dr.Read())
            {
                emp._id = dr.GetInt32(0);
                emp.surname = dr.GetString(1);
                emp.job = dr.GetString(2);
                emp.managerid = dr.GetInt32(3);
                emp.startdate = dr.GetDateTime(4);
                emp.salary = dr.GetDouble(5);
                emp.comission = dr.GetDouble(6);
                emp.depid = dr.GetInt32(7);
            }
            else
            {
                emp = null;
               
            }
            conn.Close();
            return emp;
            
        }

        public Boolean Insert(Employee dep)
        {
   
           SQLConnection db = new SQLConnection();
           conn = db.GetConnection();
           
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO employees VALUES (@empid, @nom, @job)", conn);

            Boolean bol; 
            cmd.Parameters.AddWithValue("depno", dep._id);
            cmd.Parameters.AddWithValue("nom", dep.surname);
            cmd.Parameters.AddWithValue("loc", dep.job);
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
                bol = true;
                Console.WriteLine("Employee with Id {0} and Name {1} added",
                    dep._id, dep.surname);
            }
            catch
            {
                bol = false;
                Console.WriteLine("Couldn't add Employee with Id {0}", dep._id);
            }
           
            conn.Close();
            return bol;

        }

        public Boolean Delete(int empId)
        {
          
           SQLConnection db = new SQLConnection();
           conn = db.GetConnection();
            Boolean bol; 
            
            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM employees WHERE _id =" + empId, conn);

            try
            {
                 cmd.ExecuteNonQuery();
                 bol = true;
                 Console.WriteLine("Employee with Id {0} deleted",
                    empId);
            }
            catch
            {
                Console.WriteLine("Couldn't delete Employee with Id {0}", empId);
                bol = false;
            }

            conn.Close();
            return bol;
        }

        public Boolean Update(Employee dep)
        {
            SQLConnection db = new SQLConnection();
           conn = db.GetConnection();
            NpgsqlCommand cmd = new NpgsqlCommand("UPDATE employees SET surname = @nom, job = @loc  WHERE _id = @empId", conn);
            Boolean bol; 
          
            cmd.Parameters.AddWithValue("surname", dep.surname);
            cmd.Parameters.AddWithValue("job", dep.job);
            cmd.Parameters.AddWithValue("empId", dep._id);
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
                bol = true;
                Console.WriteLine("Employee with ID {0} updated", dep._id);
            }
            catch
            {
                bol = false;
                Console.WriteLine("Couldn't update Employee {0}", dep.surname);
            }
            
            
            conn.Close();
            return bol;
        }
        
    }
}