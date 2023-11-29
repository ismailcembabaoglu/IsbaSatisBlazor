using FluentValidation;
using IsbaSatisBlazor.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.Validators
{
    public class PaymentMotionValidator:AbstractValidator<PaymentMotionDTO>
    {
        public PaymentMotionValidator()
        {

            RuleFor(c => c.Price).PrecisionScale(10, 2, true);
            RuleFor(c => c.PaymentName).MaximumLength(50).WithMessage("50 Karakterden falza olamaz");
        }
    }
}
