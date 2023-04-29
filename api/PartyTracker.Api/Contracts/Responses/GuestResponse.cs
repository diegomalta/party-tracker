using System;
namespace PartyTracker.Api.Contracts.Responses
{
	public class GuestResponse
	{
        public Guid Id { get; init; }
        public Guid EventId { get; init; }
        public string Name { get; init; } = default!;
        public string? PhoneNumber { get; init; }
    }
}

