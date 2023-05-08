using System;
namespace PartyTracker.Api.Contracts.Request
{
	public class GuestRequest
	{
        public Guid EventId { get; init; } = default!;
        public string Name { get; init; } = default!;
        public string? PhoneNumber { get; init; }
        public string? Rsvp { get; init; }
        public string? Parents { get; init; }
        public string? Message { get; init; }
    }
}

