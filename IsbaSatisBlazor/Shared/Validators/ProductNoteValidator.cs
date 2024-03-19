using FluentValidation;
using IsbaSatisBlazor.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.Validators
{
    public class ProductNoteValidator:AbstractValidator<ProductNoteDTO>
    {
        public ProductNoteValidator()
        {
            RuleFor(c => c.Note).MaximumLength(100).WithMessage("100 Karakterden Fazla Olamaz");
        }
    }
}
