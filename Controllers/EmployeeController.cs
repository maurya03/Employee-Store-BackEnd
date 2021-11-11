using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Angular_WebAPI_Project.Models;
using System.Web.Http.Cors;

namespace Angular_WebAPI_Project.Controllers
{
    [EnableCors(origins:"*",headers:"*", methods:"*")]
    public class EmployeeController : ApiController
    {
        private IEmployeeRepository repository;
        EmployeeController()
        {
            repository = new EmployeeSQLImp();
        }

        public List<Employee> Get()
        {
            return repository.getAllEmployees();
        }

        public Employee Get(int id)
        {
            return repository.GetEmpById(id);
        }

        public Employee Post(Employee employee)
        {
            return repository.AddEmployee(employee);
        }

        public void Put(int id, Employee employee)
        {
            repository.UpdateEmployee(id, employee);
        }

        public void Delete(int id)
        {
            repository.DeleteEmployee(id);
        }
    }
}
