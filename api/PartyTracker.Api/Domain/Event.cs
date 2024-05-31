using PartyTracker.Api.Domain.Common;

namespace PartyTracker.Api.Domain;
public class Event
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string WelcomeMessage { get; set; } = default!;
    public AddressMapUrl AddressMapUrl { get; set; } = default!;
    public Address Address { get; set; } = default!;
    public PhoneNumber ContactPhoneNumber { get; set; } = default!;
    public DateTime EventDate { get; set; }
    public string FromTo { get; set; } = default!;
}

