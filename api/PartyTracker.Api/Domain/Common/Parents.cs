using System;
using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace PartyTracker.Api.Domain.Common;
public class Parents : ValueOf<string, Parents>
{
    private static readonly Regex parentsRegex =
        new("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    protected override void Validate()
    {
        if (Value is null)
            return;

        if (!parentsRegex.IsMatch(Value))
        {
            var message = $"{Value} is not valid";
            throw new ValidationException(message, new[]
            {
                    new ValidationFailure(nameof(Parents), message)
                });
        }
    }
}
