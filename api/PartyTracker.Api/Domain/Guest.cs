using System;
using PartyTracker.Api.Domain.Common;

namespace PartyTracker.Api.Domain
{
	public class Guest
	{
        public Guid Id { get; set; } = Guid.NewGuid();
        public Common.EventId EventId { get; set; } = default!;
        public FullName Name { get; set; } = default!;
        public PhoneNumber? PhoneNumber { get; set; } = default;
        public Rsvp? Rsvp { get; set; } = default;
        public Parents? Parents { get; set; } = default;
        public string? Message { get; set; } = default;
    }
}

