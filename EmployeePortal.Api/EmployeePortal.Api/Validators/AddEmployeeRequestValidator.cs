using EmployeePortal.Api.DomainModels;
using EmployeePortal.Api.Repositories;
using FluentValidation;

namespace EmployeePortal.Api.Validators
{
    public class AddEmployeeRequestValidator : AbstractValidator<AddEmployee>
    {
        public AddEmployeeRequestValidator(IEmployeeRepository employeeRepository)
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("A valid email is required");
            RuleFor(x => x.Mobile).GreaterThan(99999).LessThan(10000000000).WithMessage("Phone number must between 5-10 number");
            RuleFor(x => x.Age).GreaterThan(0).LessThan(150).WithMessage("Age must between 1-150 number");
        }
    }
}