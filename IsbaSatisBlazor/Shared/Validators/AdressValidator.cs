using FluentValidation;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Shared.Validators
{
    public class AdressValidator:AbstractValidator<AdressDTO>
    {
        public AdressValidator()
        {
            RuleFor(c => c.City).MaximumLength(30).WithMessage("Şehir Alanı 30 Karakterden Fazla Olamaz");
            RuleFor(c => c.County).MaximumLength(30).WithMessage("İlçe Alanı 30 Karakterden Fazla Olamaz");
            RuleFor(c => c.District).MaximumLength(30).WithMessage("Mahalle Alanı 30 Karakterden Fazla Olamaz");
            RuleFor(c => c.FullAddress).MaximumLength(200).WithMessage("Adres Alanı 30 Karakterden Fazla Olamaz");
           

        }
    }
}
