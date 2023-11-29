using FluentValidation;
using IsbaSatisBlazor.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.Validators
{
    public class CustomerValidator:AbstractValidator<CustomerDTO>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Company).MaximumLength(100).WithMessage("100 Karakterden falza olamaz");
            RuleFor(c => c.CardNumber).MaximumLength(20).WithMessage("20 Karakterden falza olamaz");
            RuleFor(c => c.CustomerName).MaximumLength(50).WithMessage("50 Karakterden falza olamaz");
            RuleFor(c => c.CustomerSurname).MaximumLength(50).WithMessage("50 Karakterden falza olamaz");
        }
    }
}
