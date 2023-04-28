using System;
using System.Text.RegularExpressions;
using FluentValidation.Results;
using FluentValidation;
using ValueOf;

namespace PartyTracker.Api.Domain.Common
{
	public class PhoneNumber : ValueOf<string, PhoneNumber>
    {
        private static readonly Regex PhoneNumberRegex =
            new("^[0-9]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        protected override void Validate()
        {
            if (Value is null)
                return;

            if (!PhoneNumberRegex.IsMatch(Value))
            {
                var message = $"{Value} is not a valid phone number";
                throw new ValidationException(message, new[]
                {
                    new ValidationFailure(nameof(PhoneNumber), message)
                });
            }
        }
    }
}

