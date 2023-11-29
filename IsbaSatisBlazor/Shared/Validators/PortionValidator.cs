using FluentValidation;
using IsbaSatisBlazor.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.Validators
{
    public class PortionValidator:AbstractValidator<PortionDTO>
    {
        public PortionValidator()
        {
            RuleFor(c => c.Price).PrecisionScale(10, 2, true);
            RuleFor(c => c.SupplementaryMaterialMultiplier).PrecisionScale(4, 2, true);
            RuleFor(c => c.ProductName).MaximumLength(50).WithMessage("50 karakterden fazla giriş yapılamaz");
        }
    }
}
