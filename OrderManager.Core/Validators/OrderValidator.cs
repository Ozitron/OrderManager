using FluentValidation;
using OrderManager.Core.Models.DTOs;

namespace OrderManager.Core.Validators
{
    public class OrderValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderValidator()
        {
            RuleFor(a => a.OrderId)
                .NotNull().WithMessage("{PropertyName} must not be null.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");

            RuleFor(a => a.ProductId)
                .NotNull().WithMessage("{PropertyName} must not be null.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.")
                .LessThanOrEqualTo(5).WithMessage("{PropertyName} must be an existing {PropertyName} value.");

            RuleFor(a => a.Quantity)
                .NotNull().WithMessage("{PropertyName} must not be null.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");
        }
    }
}
