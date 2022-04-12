using FluentValidation;
using WebAPI.DTOs;

namespace WebAPI.Validators;
public class ProductValidator : AbstractValidator<ProductDTO>
{
    public ProductValidator()
    {
        RuleFor(x => x.Description).NotEmpty().WithMessage("Hola ");
    }
}

