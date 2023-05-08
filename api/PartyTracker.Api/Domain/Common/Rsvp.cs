using System;
using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace PartyTracker.Api.Domain.Common
{
	public class Rsvp : ValueOf<string, Rsvp>
    {
        private static readonly Regex RsvpRegex =
            new("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        protected override void Validate()
        {
            if (Value is null)
                return;

            if (!RsvpRegex.IsMatch(Value))
            {
                var message = $"{Value} is not a valid";
                throw new ValidationException(message, new[]
                {
                    new ValidationFailure(nameof(Rsvp), message)
                });
            }
        }
    }
}

