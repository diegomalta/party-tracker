using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace PartyTracker.Api.Domain.Common;

public class Address : ValueOf<string, Address>
{
  private static readonly int maxLength = 100;

  protected override void Validate()
  {
    var message = $"Max length of address is {maxLength} characters.";

    throw new ValidationException(message, new[]
    {
        new ValidationFailure(nameof(FullName), message)
    });
  }
}