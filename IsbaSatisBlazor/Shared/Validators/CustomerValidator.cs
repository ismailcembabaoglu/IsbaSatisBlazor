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
            RuleFor(c => c.Company).NotNull().WithMessage("Bu alan boş geçilemez.").MaximumLength(100).WithMessage("100 Karakterden falza olamaz");
            RuleFor(c => c.CardNumber).NotNull().WithMessage("Bu alan boş geçilemez.").MaximumLength(20).WithMessage("20 Karakterden falza olamaz");
            RuleFor(c => c.CustomerName).NotNull().WithMessage("Bu alan boş geçilemez.").MaximumLength(50).WithMessage("50 Karakterden falza olamaz");
            RuleFor(c => c.CustomerSurname).NotNull().WithMessage("Bu alan boş geçilemez.").MaximumLength(50).WithMessage("50 Karakterden falza olamaz");
            RuleFor(c => c.CustomerType).NotNull().WithMessage("Bu alan boş geçilemez.");
        }
    }
}
