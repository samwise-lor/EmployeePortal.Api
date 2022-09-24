using EmployeePortal.Api.DataModels;
using EmployeePortal.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePortal.Api.Tests.Tests
{
    public class EmployeePortalFakes : IEmployeeRepository
    {
        private readonly List<Employee> _employees;
        
        public EmployeePortalFakes()
        {
            _employees = new List<Employee>
            {
                new Employee
                {
                    Id = new Guid("f8b599f3-5aa4-487a-a9b7-c6f3ae1c3192"),
                    FirstName = "Captain",
                    LastName = "America",
                    Age = 20,
                    Email = "captain.america@anywhere.com",
                    Mobile = 1234567890
                },
                new Employee
                {
                    Id = new Guid("c29fd52b-c87b-4538-9e9e-d865a398e4cf"),
                    FirstName = "Iron",
                    LastName = "Man",
                    Age = 30,
                    Email = "iron.man@anywhere.com",
                    Mobile = 2345678901
                },
                new Employee
                {
                    Id = new Guid("212cdeda-0771-4d69-b756-9b702c713f37"),
                    FirstName = "Black",
                    LastName = "Widow",
                    Age = 20,
                    Email = "black.widow@anywhere.com",
                    Mobile = 3456789012
                }
            };
        }
        
        public List<Employee> GetEmployees()
        {
            return _employees;
        }
        
        public Employee GetEmployee(Guid employeeId)
        {
            return _employees.SingleOrDefault(x => x.Id == employeeId);
        }
        
        public Employee AddEmployee(Employee request)
        {
            request.Id = Guid.NewGuid();
            _employees.Add(request);
            return request;
        }
        
        public Employee UpdateEmployee(Guid employeeId, Employee request)
        {
            var existing = _employees.First(a => a.Id == employeeId);
            if (existing == null) return null;
            existing.FirstName = request.FirstName;
            existing.LastName = request.LastName;
            existing.Email = request.Email;
            existing.Mobile = request.Mobile;
            existing.Age = request.Age;
            return existing;
        }
        
        public List<Employee> SearchEmployee(Employee request)
        {
            return _employees;
        }

        public void DeleteEmployee(Guid employeeId)
        {
            var existing = _employees.First(a => a.Id == employeeId);
            _employees.Remove(existing);
        }
        
        public bool Exists(Guid employeeId)
        {
            return _employees.Any(x => x.Id == employeeId);
        }
        
        public bool DuplicateEmployee(string firstName, string lastName, string email)
        {
            return _employees.Any(x => string.Equals(x.FirstName, firstName, StringComparison.CurrentCultureIgnoreCase)
                                       && string.Equals(x.LastName, lastName, StringComparison.CurrentCultureIgnoreCase)
                                       || string.Equals(x.Email, email, StringComparison.CurrentCultureIgnoreCase));
        }

    }
}