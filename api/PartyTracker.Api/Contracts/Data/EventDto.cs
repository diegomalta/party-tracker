using System.Text.Json.Serialization;

namespace PartyTracker.Api.Contracts.Data;
public class EventDto
{
    [JsonPropertyName("PK")]
    public string Pk => $"EVENT#{Id}";

    [JsonPropertyName("SK")]
    public string Sk => Pk;

    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("welcomeMessage")]
    public string WelcomeMessage { get; set; } = default!;

    [JsonPropertyName("addressMapUrl")]
    public string AddressMapUrl { get; set; } = default!;

    [JsonPropertyName("Address")]
    public string Address { get; set; } = default!;

    [JsonPropertyName("contactPhoneNumber")]
    public string ContactPhoneNumber { get; set; } = default!;

    [JsonPropertyName("eventDate")]
    public DateTime EventDate { get; set; } = default!;

    [JsonPropertyName("fromTo")]
    public string FromTo { get; set; } = default!;


}
