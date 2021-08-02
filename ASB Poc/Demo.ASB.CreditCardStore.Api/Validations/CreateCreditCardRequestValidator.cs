
using Demo.ASB.CreditCardStore.Contracts.V1.Requests;
using FluentValidation;
using System;
using System.Linq;

namespace Demo.ASB.CreditCardStore.Api.Validations
{
    public class CreateCreditCardRequestValidator : AbstractValidator<CreateCreditCard>
    {
        public CreateCreditCardRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Matches("^\\w+$").WithMessage("Invalid Name, Name can only be alphanumeric").MaximumLength(50);
            RuleFor(x => x.CreditCardNumber).Must(ValidateCreditCardNumber).WithMessage("InValid credit card number");
            RuleFor(x => x.ExpiryDate).Must(ValidateExpiryDate).WithMessage("Invalid Expiry Date");
            RuleFor(x => x.CVC).Must(ValidateCVCValue).WithMessage("Invalid Security Cod");
        }

        private bool ValidateExpiryDate(DateTime expiryDate) => expiryDate > DateTime.Now;
        private bool ValidateCVCValue(int value)
        {
            var str = value.ToString();
            return (int.TryParse(str, out _));
        }

        private bool ValidateCreditCardNumber(string ccNumber)
        {
            // Used Luhn Algorithm to validate credit card number
            // reference https://www.codeproject.com/Tips/515367/Validate-credit-card-number-with-Mod-10-algorithm
            // Test with example credit card number 4012888888881881  

            if (string.IsNullOrEmpty(ccNumber))
                return false;

            int sumOfDigits = ccNumber.Where((e) => e >= '0' && e <= '9')
                            .Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum((e) => e / 10 + e % 10);

            return sumOfDigits % 10 == 0;
        }
    }
}