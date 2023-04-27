using System;
using System.Text.Json.Serialization;

namespace PartyTracker.Api.Contracts.Data
{
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
    }
}

