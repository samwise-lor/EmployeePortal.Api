using EmployeePortal.Api.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employee.ToList();
        }

        public Employee GetEmployee(Guid employeeId)
        {
            return _context.Employee.FirstOrDefault(x => x.Id == employeeId);
        }

        public Employee UpdateEmployee(Guid employeeId, Employee request)
        {
            var existingEmployee = GetEmployee(employeeId);
            if (existingEmployee == null) return null;
            existingEmployee.FirstName = request.FirstName;
            existingEmployee.LastName = request.LastName;
            existingEmployee.Email = request.Email;
            existingEmployee.Mobile = request.Mobile;
            existingEmployee.Age = request.Age;

            _context.SaveChanges();
            return existingEmployee;
        }

        public void DeleteEmployee(Guid employeeId)
        {
            var employee = GetEmployee(employeeId);
            if (employee == null) return;
            _context.Employee.Remove(employee);
            _context.SaveChanges();
        }

        public Employee AddEmployee(Employee request)
        {
            var employee = _context.Employee.Add(request);
            _context.SaveChanges();
            return employee.Entity;
        }

        public bool Exists(Guid employeeId)
        {
            return _context.Employee.Any(x => x.Id == employeeId);
        }

        public bool DuplicateEmployee(string firstName, string lastName, string email)
        {
            return _context.Employee.Any(x =>
                string.Equals(x.FirstName, firstName, StringComparison.CurrentCultureIgnoreCase)
                && string.Equals(x.LastName, lastName, StringComparison.CurrentCultureIgnoreCase)
                || string.Equals(x.Email, email, StringComparison.CurrentCultureIgnoreCase));

        }
    }
}
