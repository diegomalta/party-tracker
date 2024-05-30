using System;
namespace PartyTracker.Api.Contracts.Responses
{
	public class GuestResponse
	{
        public Guid Id { get; init; }
        public Guid EventId { get; init; }
        public string Name { get; init; } = default!;
        public string? PhoneNumber { get; init; }
        public string? Rsvp { get; init; }
        public string? Parents { get; init; }
        public string? Message { get; init; }
        public EventResponse? Event { get; init; }
    }
}

