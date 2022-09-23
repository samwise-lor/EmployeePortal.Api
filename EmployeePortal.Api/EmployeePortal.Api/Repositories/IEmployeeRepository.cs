using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeePortal.Api.DataModels;

namespace EmployeePortal.Api.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(Guid employeeId);
        Employee UpdateEmployee(Guid employeeId, Employee request);
        void DeleteEmployee(Guid employeeId);
        Employee AddEmployee(Employee request);
        bool Exists(Guid employeeId);
        bool DuplicateEmployee(string firstName, string lastName, string email);
    }
}
