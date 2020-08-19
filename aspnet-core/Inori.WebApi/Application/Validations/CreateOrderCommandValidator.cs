using FluentValidation;
using Inori.WebApi.Application.Commands;
using Microsoft.Extensions.Logging;

namespace Inori.WebApi.Application.Validations
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator(ILogger<CreateOrderCommandValidator> logger)
        {
            RuleFor(command => command.City).NotEmpty();
            logger.LogTrace("----- INSTANCE CREATED -{ClassName}", GetType().Name);
        }
    }
}