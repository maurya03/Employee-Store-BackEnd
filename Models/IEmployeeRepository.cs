using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angular_WebAPI_Project.Models
{
    public interface IEmployeeRepository
    {
        List<Employee> getAllEmployees();
        Employee GetEmpById(int id);
        Employee AddEmployee(Employee employee);
        void UpdateEmployee(int id, Employee employee);
        void DeleteEmployee(int id);
    }
}