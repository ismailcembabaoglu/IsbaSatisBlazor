using FluentValidation;
using IsbaSatisBlazor.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.Validators
{
    public class GarsonValidator:AbstractValidator<GarsonDTO>
    {
        public GarsonValidator()
        {
            RuleFor(c => c.Name).MaximumLength(50).WithMessage("50 Karakterden falza olamaz");
            RuleFor(c => c.Surname).MaximumLength(50).WithMessage("50 Karakterden falza olamaz");
        }
    }
}
