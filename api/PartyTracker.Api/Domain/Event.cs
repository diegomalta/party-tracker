using System;
namespace PartyTracker.Api.Domain
{
	public class Event
	{
        public Guid Id { get; set; } = Guid.NewGuid();
        public string WelcomeMessage { get; set; } = default!;
    }
}

