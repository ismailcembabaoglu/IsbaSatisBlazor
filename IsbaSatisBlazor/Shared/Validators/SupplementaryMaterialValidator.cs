using FluentValidation;
using IsbaSatisBlazor.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.Validators
{
    public class SupplementaryMaterialValidator:AbstractValidator<SupplementaryMaterialDTO>
    {
        public SupplementaryMaterialValidator()
        {
            RuleFor(c => c.SupplementaryMaterialName).MaximumLength(50).WithMessage("100 Karakterden Fazla Olamaz");
            RuleFor(c => c.Price).PrecisionScale(10, 2, true);
            RuleFor(c => c.ProductName).MaximumLength(50).WithMessage("50 karakterden fazla giriş yapılamaz");
        }
    }
}
