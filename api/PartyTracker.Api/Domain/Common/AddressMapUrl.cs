using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace PartyTracker.Api.Domain.Common;

public class AddressMapUrl : ValueOf<string, AddressMapUrl>
{
  private static readonly string ValidUrl = "https://www.google.com/maps/embed?";

    protected override void Validate()
    {
        if (!Value.StartsWith(ValidUrl))
        {
          var message = $"{Value} is not a valid Address Map Url";
          throw new ValidationException(message, new[]
          {
              new ValidationFailure(nameof(FullName), message)
          });
        }
    }
}