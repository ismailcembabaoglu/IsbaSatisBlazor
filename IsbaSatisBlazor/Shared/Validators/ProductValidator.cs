using FluentValidation;
using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Shared.Validators
{
    public class ProductValidator:AbstractValidator<ProductDTO>
    {
        public ProductValidator()
        {
                RuleFor(c=>c.ProductName).NotEmpty().WithMessage("Lütfen bir ürün adı giriniz").MaximumLength(50).WithMessage("50 karakterden fazla giriş yapılamaz");
                RuleFor(c=>c.ProductGroupId).NotEmpty().WithMessage("Lütfen bir Grup seçiniz");
                RuleFor(c=>c.Barcode).NotEmpty().WithMessage("Lütfen bir Grup seçiniz").MaximumLength(20).WithMessage("20 karakterden fazla giriş yapılamaz");


        }
    }
}
