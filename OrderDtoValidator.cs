namespace WebApplication5
{
    using FluentValidation;
    using WebApplication5.DTOs;

    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            RuleFor(o => o.OrderDate)
                .NotEmpty().WithMessage("Order date is required.");

            RuleFor(o => o.TotalAmount)
                .GreaterThan(0).WithMessage("Total amount must be greater than 0.");

            RuleFor(o => o.UserId)
                .GreaterThan(0).WithMessage("UserId must be valid.");
        }
    }

}
