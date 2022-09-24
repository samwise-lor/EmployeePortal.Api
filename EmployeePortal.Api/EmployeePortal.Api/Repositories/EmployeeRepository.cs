using EmployeePortal.Api.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeePortal.Api.Exceptions;
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
            try
            {
                return _context.Employee.Include(nameof(Address)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //Meaningful error after logging the error or complete exception can be thrown (e)
                throw new InternalServerException($"An error occurred in processing the request");
            }
        }

        public Employee GetEmployee(Guid employeeId)
        {
            try
            {
                return _context.Employee.Include(nameof(Address)).FirstOrDefault(x => x.Id == employeeId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //Meaningful error after logging the error or complete exception can be thrown (e)
                throw new InternalServerException($"An error occurred in processing the request {employeeId} ");
            }
        }
        
        public List<Employee> SearchEmployee(Employee request)
        {
            var employees = GetEmployees();
            if (!string.IsNullOrEmpty(request.FirstName))
            {
                employees = employees.Where(x => string.Equals(x.FirstName, request.FirstName, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(request.LastName))
            {
                employees = employees.Where(x => string.Equals(x.LastName, request.LastName, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(request.Email))
            {
                employees = employees.Where(x => string.Equals(x.Email, request.Email, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            
            return employees;
        }

        public Employee UpdateEmployee(Guid employeeId, Employee request)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                //Meaningful error after logging the error or complete exception can be thrown (e)
                throw new InternalServerException($"An error occurred in processing the request {employeeId} ");
            }
        }

        public void DeleteEmployee(Guid employeeId)
        {
            try
            {
                var employee = GetEmployee(employeeId);
                if (employee == null) return;
                _context.Employee.Remove(employee);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //Meaningful error after logging the error or complete exception can be thrown (e)
                throw new InternalServerException($"An error occurred in processing the request {employeeId} ");
            }
        }

        public Employee AddEmployee(Employee request)
        {
            try
            {
                var employee = _context.Employee.Add(request);
                _context.SaveChanges();
                return employee.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //Meaningful error after logging the error or complete exception can be thrown (e)
                throw new InternalServerException($"An error occurred in processing the request");
            }
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
