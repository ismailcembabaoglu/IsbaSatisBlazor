using FluentValidation;
using IsbaSatisBlazor.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.Validators
{
    public class DeskValidator:AbstractValidator<DeskDTO>
    {
        public DeskValidator()
        {
            RuleFor(c => c.Name).MaximumLength(50).WithMessage("100 Karakterden falza olamaz");
        }
    }
}
