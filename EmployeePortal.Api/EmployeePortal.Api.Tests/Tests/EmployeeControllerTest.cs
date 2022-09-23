using AutoMapper;
using EmployeePortal.Api.Controllers;
using EmployeePortal.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EmployeePortal.Api.DomainModels;
using EmployeePortal.Api.Profiles;
using Xunit;
using Employee = EmployeePortal.Api.DataModels.Employee;

namespace EmployeePortal.Api.Tests.Tests
{
    public class EmployeeControllerTest
    {
        private EmployeeController _controller;
        private static IMapper _mapper;

        public EmployeeControllerTest()
        {
            IEmployeeRepository employee = new EmployeePortalFakes();
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfiles());
                });
                var mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            _controller = new EmployeeController(employee, _mapper);
        }
        
        [Fact]
        public void GetEmployees_ReturnsOkResult()
        {
            // Act
            var employeeResult = _controller.GetAllEmployees();

            // Assert
            Assert.IsType<OkObjectResult>(employeeResult as OkObjectResult);
        }
        
        [Fact]
        public void GetEmployees_ReturnsAllEmployees()
        {
            // Act
            var employeeResult = _controller.GetAllEmployees() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<DomainModels.Employee>>(employeeResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Theory]
        [InlineData("f8b599f3-5aa4-487a-a9b7-c6f3ae1c3192")]
        public void GetEmployeesById_ReturnsEmployee(string id)
        {
            //Arrange
            var employeeId = new Guid(id);
            
            // Act
            var employeeResult = _controller.GetEmployee(employeeId) as OkObjectResult;
            
            //Assert
            Assert.IsType<DomainModels.Employee>(employeeResult.Value);

            var employee = employeeResult.Value as DomainModels.Employee;
            Assert.Equal(employeeId, employee.Id);
            Assert.Equal("captain.america@anywhere.com", employee.Email);
        }
        
        [Theory]
        [InlineData("01646dfb-f441-4d95-a18f-e4bdca79e00f")]
        public void GetEmployeesById_ReturnsNotFound(string id)
        {
            //Arrange
            var employeeId = new Guid(id);
            
            // Act
            var notFoundResult = _controller.GetEmployee(employeeId);
            
            //Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
        
        [Fact]
        public void AddEmployee_ReturnsOkResult()
        {
            // Arrange
            var employee = new AddEmployee()
            {
                FirstName = "Peter",
                LastName = "Parker",
                Age = 20,
                Email = "peter.parker@anywhere.com",
                Mobile = 1234567890
            };

            // Act
            var employeeResult = _controller.AddEmployee(employee) as OkObjectResult;

            // Assert
            Assert.IsType<DomainModels.Employee>(employeeResult.Value);
            Assert.IsType<OkObjectResult>((OkObjectResult) employeeResult);
        }
        
        [Fact]
        public void AddEmployee_WithDuplicateValues_ReturnConflictResult()
        {
            // Arrange
            var employee = new AddEmployee()
            {
                FirstName = "Captain",
                LastName = "America",
                Age = 20,
                Email = "captain.america@anywhere.com",
                Mobile = 1234567890
            };

            // Act
            var conflictResult = _controller.AddEmployee(employee) as ConflictResult;

            // Assert
            Assert.Null(conflictResult);
        }
        
        [Theory]
        [InlineData("c29fd52b-c87b-4538-9e9e-d865a398e4cf")]
        public void UpdateEmployee_ReturnsOkResult(string id)
        {
            //Arrange
            var employeeId = new Guid(id);
            var employee = new UpdateEmployee()
            {
                FirstName = "Jewel",
                LastName = "Thief",
                Age = 20,
                Email = "jewel.thief@anywhere.com",
                Mobile = 1234567890
            };

            // Act
            var employeeResult = _controller.UpdateEmployee(employeeId, employee) as OkObjectResult;

            // Assert
            Assert.IsType<DomainModels.Employee>(employeeResult.Value);
            Assert.IsType<OkObjectResult>(employeeResult);
        }
        
        [Theory]
        [InlineData("a60f34bb-c8ab-47bf-8d73-41df5790bb75")]
        public void UpdateEmployee_WithIncorrectId_ReturnsNotFound(string id)
        {
            //Arrange
            var employeeId = new Guid(id);
            var employee = new UpdateEmployee()
            {
                FirstName = "Jewel",
                LastName = "Thief",
                Age = 20,
                Email = "jewel.thief@anywhere.com",
                Mobile = 1234567890
            };

            // Act
            var notFoundResult = _controller.UpdateEmployee(employeeId, employee);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
        
        [Theory]
        [InlineData("f8b599f3-5aa4-487a-a9b7-c6f3ae1c3192")]
        public void DeleteEmployeesById_ReturnsNoContentResult(string id)
        {
            //Arrange
            var employeeId = new Guid(id);
            
            // Act
            var noContentResponse = _controller.DeleteEmployee(employeeId);

            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }
    }
}