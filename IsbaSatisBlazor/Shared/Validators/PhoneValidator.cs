using FluentValidation;
using IsbaSatisBlazor.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.Validators
{
    public class PhoneValidator:AbstractValidator<PhoneDTO>
    {
        public PhoneValidator()
        {
            RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("Bu alan boş geçilemez").Length(11).WithMessage("Telefon alanı 11 karakterden oluşmaktadır");
            RuleFor(c => c.CustomerName).MaximumLength(50).WithMessage("50 Karakterden falza olamaz");
            RuleFor(c => c.CustomerSurname).MaximumLength(50).WithMessage("50 Karakterden falza olamaz");
        }
    }
}
