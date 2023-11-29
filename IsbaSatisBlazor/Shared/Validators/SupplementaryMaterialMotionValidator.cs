using FluentValidation;
using IsbaSatisBlazor.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.Validators
{
    public class SupplementaryMaterialMotionValidator:AbstractValidator<SupplementaryMaterialMotionDTO>
    {
        public SupplementaryMaterialMotionValidator()
        {
            RuleFor(c => c.SupplementaryMaterialName).MaximumLength(50).WithMessage("100 Karakterden Fazla Olamaz");
            RuleFor(c => c.Price).PrecisionScale(10, 2, true);
        }
    }
}
