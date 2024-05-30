using System;
namespace PartyTracker.Api.Contracts.Responses
{
	public class EventResponse
	{
        public Guid Id { get; init; }
        public string WelcomeMessage { get; init; } = default!;
        public string AddressMapUrl { get; init; } = default!;
        public string Address { get; init; } = default!;
        public string ContactPhoneNumber { get; set; } = default!;
        public DateTime EventDate { get; set; }
        public string FromTo { get; init; } = default!;
    }
}

