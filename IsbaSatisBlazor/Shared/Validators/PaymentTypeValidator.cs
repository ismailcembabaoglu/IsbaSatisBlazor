using FluentValidation;
using IsbaSatisBlazor.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.Validators
{
    public class PaymentTypeValidator:AbstractValidator<PaymentTypeDTO>
    {
        public PaymentTypeValidator()
        {
            RuleFor(c => c.PaymentName).MaximumLength(50).WithMessage("50 Karakterden falza olamaz");
        }
    }
}
