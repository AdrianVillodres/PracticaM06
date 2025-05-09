using System;
using System.Collections.Generic;
using cat.itb.store_VillodresAdrian.connections;
using cat.itb.store_VillodresAdrian.empDAO;
using Npgsql;

namespace cat.itb.store_VillodresAdrian.empDAO
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

            var cmd = new NpgsqlCommand(@"INSERT INTO employees VALUES (@id, @surname, @job, @managerid, @startdate, @salary, @commission, @depid)", conn);
            foreach (var emp in emps)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", emp._id);
                cmd.Parameters.AddWithValue("surname", emp.surname);
                cmd.Parameters.AddWithValue("job", emp.job);
                cmd.Parameters.AddWithValue("managerid", emp.managerid);
                cmd.Parameters.AddWithValue("startdate", emp.startdate);
                cmd.Parameters.AddWithValue("salary", emp.salary);
                cmd.Parameters.AddWithValue("commission", emp.comission); 
                cmd.Parameters.AddWithValue("depid", emp.depid);
                cmd.Prepare();
                try
                {
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Employee with Id {0} and Name {1} added",
                        emp._id, emp.surname);
                }
                catch
                {
                    Console.WriteLine("Couldn't add Employee with Id {0}", emp._id);
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
                try
                {
                    emp.managerid = dr.GetInt32(3);
                }
                catch (Exception e)
                {
                    emp.managerid = 0;
                }
                emp.startdate = dr.GetDateTime(4);
                emp.salary = dr.GetDouble(5);
                try
                {
                    emp.comission = dr.GetDouble(6);
                }
                catch (Exception e)
                {
                    emp.comission = 0;
                }
                emp.depid = dr.GetInt32(7);
                emps.Add(emp);
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
                try
                {
                    emp.managerid = dr.GetInt32(3);
                } catch (Exception e)
                {
                    emp.managerid = 0;
                }
                emp.startdate = dr.GetDateTime(4);
                emp.salary = dr.GetDouble(5);
                try
                {
                    emp.comission = dr.GetDouble(6);
                } catch (Exception e)
                {
                    emp.comission = 0;
                }
                emp.depid = dr.GetInt32(7);
            }
            else
            {
                emp = null;
               
            }
            conn.Close();
            return emp;
            
        }

        public Boolean Insert(Employee emp)
        {
   
           SQLConnection db = new SQLConnection();
           conn = db.GetConnection();

            var cmd = new NpgsqlCommand(@"INSERT INTO employees 
    VALUES (@id, @surname, @job, @managerid, @startdate, 
            @salary, @commission, @depid)", conn);

            Boolean bol;

            cmd.Parameters.AddWithValue("id", emp._id);
            cmd.Parameters.AddWithValue("surname", emp.surname);
            cmd.Parameters.AddWithValue("job", emp.job);
            cmd.Parameters.AddWithValue("managerid", emp.managerid);
            cmd.Parameters.AddWithValue("startdate", emp.startdate);
            cmd.Parameters.AddWithValue("salary", emp.salary);
            cmd.Parameters.AddWithValue("commission", emp.comission ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("depid", emp.depid);
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
                bol = true;
                Console.WriteLine("Employee with Id {0} and Name {1} added",
                    emp._id, emp.surname);
            }
            catch
            {
                bol = false;
                Console.WriteLine("Couldn't add Employee with Id {0}", emp._id);
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

        public Boolean Update(Employee emp)
        {
            SQLConnection db = new SQLConnection();
           conn = db.GetConnection();
            var cmd = new NpgsqlCommand(@"UPDATE employees 
    SET surname = @surname, job = @job, managerid = @managerid, startdate = @startdate, 
        salary = @salary, commission = @commission, depid = @depid 
    WHERE _id = @id", conn);
            Boolean bol;

            cmd.Parameters.AddWithValue("surname", emp.surname);
            cmd.Parameters.AddWithValue("job", emp.job);
            cmd.Parameters.AddWithValue("managerid", emp.managerid);
            cmd.Parameters.AddWithValue("startdate", emp.startdate);
            cmd.Parameters.AddWithValue("salary", emp.salary);
            cmd.Parameters.AddWithValue("commission", emp.comission ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("depid", emp.depid);
            cmd.Parameters.AddWithValue("id", emp._id);
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
                bol = true;
                Console.WriteLine("Employee with ID {0} updated", emp._id);
            }
            catch
            {
                bol = false;
                Console.WriteLine("Couldn't update Employee {0}", emp.surname);
            }
            
            
            conn.Close();
            return bol;
        }
        
    }
}