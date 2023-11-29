using FluentValidation;
using IsbaSatisBlazor.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.Validators
{
    public class AdisyonValidator:AbstractValidator<AdisyonDTO>
    {
        public AdisyonValidator()
        {
            RuleFor(c => c.TotalAmount).PrecisionScale(10,2,true);
            RuleFor(c => c.Discount).PrecisionScale(5,2,true).WithMessage("En Fazla 5 karakter olabilir virgülden sonra 2 karakter gelir");
            RuleFor(c => c.DeskName).MaximumLength(50).WithMessage("50 Karakterden falza olamaz");
            RuleFor(c => c.CustomerName).MaximumLength(50).WithMessage("50 Karakterden falza olamaz");
            RuleFor(c => c.GarsonName).MaximumLength(50).WithMessage("50 Karakterden falza olamaz");
        }
    }
}
