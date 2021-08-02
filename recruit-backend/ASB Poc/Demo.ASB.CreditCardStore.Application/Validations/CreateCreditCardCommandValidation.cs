
using Demo.ASB.CreditCardStore.Application.Commands;
using FluentValidation;
using System;

namespace Demo.ASB.CreditCardStore.Application.Validations
{
    public class CreateCreditCardCommandValidation: AbstractValidator<CreateCreditCardCommand>
    {
        public CreateCreditCardCommandValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(50).Matches("^\\w+$");
            RuleFor(x => x.CreditCardNumber).NotEmpty().NotNull();
            RuleFor(x => x.CVC).Must(ValidateCVC);
            RuleFor(x => x.ExpiryDate).Must(BeAValidDate);
        }
        private bool BeAValidDate(DateTime date) =>!date.Equals(default(DateTime));
        private bool ValidateCVC(int cvc)
        {
            var stringcvc = cvc.ToString();
            return (int.TryParse(stringcvc, out cvc) && stringcvc.Length == 3);
        }
    }
}