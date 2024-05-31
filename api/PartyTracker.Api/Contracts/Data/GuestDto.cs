using System.Text.Json.Serialization;

namespace PartyTracker.Api.Contracts.Data;
public class GuestDto
{
    [JsonPropertyName("PK")]
    public string Pk => $"GUEST#{Id}";

    [JsonPropertyName("SK")]
    public string Sk => Pk;

    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("eventId")]
    public string EventId { get; set; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }

    [JsonPropertyName("rsvp")]
    public string? Rsvp { get; set; }

    [JsonPropertyName("parents")]
    public string? Parents { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

