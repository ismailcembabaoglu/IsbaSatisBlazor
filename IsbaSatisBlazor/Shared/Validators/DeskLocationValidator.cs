using FluentValidation;
using IsbaSatisBlazor.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.Validators
{
    public class DeskLocationValidator:AbstractValidator<DeskLocationDTO>
    {
        public DeskLocationValidator()
        {
            RuleFor(c => c.LocationName).MaximumLength(70).WithMessage("70 Karakterden falza olamaz");
        }
    }
}
