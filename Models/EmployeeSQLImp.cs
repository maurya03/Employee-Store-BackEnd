using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Angular_WebAPI_Project.Models
{
    public class EmployeeSQLImp : IEmployeeRepository
    {
        public Employee AddEmployee(Employee employee)
        {
            string res;
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "insert into Employee values('"+employee.Id+"','"+employee.Name+"','"+employee.Email+"')";
                conn.Open();
                //SqlDataReader dr = comm.ExecuteReader();
                int row = comm.ExecuteNonQuery();

                res = "'" + row + "' affected!!";
                

            }
            return employee;
        }

        public void DeleteEmployee(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "delete from Employee where id = " + id;
                conn.Open();
                int row = comm.ExecuteNonQuery();
            }
        }

        public List<Employee> getAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string connectionStrings = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionStrings))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from Employee";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while(dr.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = dr.GetInt32(0);
                    employee.Name = dr.GetString(1);
                    employee.Email = dr.GetString(2);
                    employees.Add(employee);
                }
            }
            return employees;
        }

        public Employee GetEmpById(int id)
        {
            Employee employee = new Employee();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from Employee where id = " + id;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
               while(dr.Read())
                {
                    employee.Id = dr.GetInt32(0);
                    employee.Name = dr.GetString(1);
                    employee.Email = dr.GetString(2);
                }
            }
            return employee;
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "Update Employee set Name='" + employee.Name + "',Email='" + employee.Email + "' where id = "+id;
                conn.Open();
                comm.ExecuteNonQuery();
            }
        }
    }
}