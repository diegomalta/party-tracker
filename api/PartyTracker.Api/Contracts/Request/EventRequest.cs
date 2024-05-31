namespace PartyTracker.Api.Contracts.Request;

public class EventRequest
{
    public string WelcomeMessage { get; set; } = default!;
    public string AddressMapUrl { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string ContactPhoneNumber { get; set; } = default!;
    public DateTime EventDate { get; set; } = default!;
    public string FromTo { get; set; } = default!;
}
