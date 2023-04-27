using System;
using PartyTracker.Api.Contracts.Data;
using PartyTracker.Api.Domain;

namespace PartyTracker.Api.Mappers
{
	public static class ComainToDtoMapper
	{
		public static EventDto ToEventDto(this Event e)
		{
			return new EventDto
			{
				Id = e.Id.ToString(),
				WelcomeMessage = e.WelcomeMessage
			};
		}

		public static Event ToEvent(this EventDto eventDto)
		{
			return new Event
			{
				Id = Guid.Parse(eventDto.Id),
				WelcomeMessage = eventDto.WelcomeMessage
			};
		}

	}
}

