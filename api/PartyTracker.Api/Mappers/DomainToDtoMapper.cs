using System;
using PartyTracker.Api.Contracts.Data;
using PartyTracker.Api.Domain;

namespace PartyTracker.Api.Mappers
{
	public static class DomainToDtoMapper
	{
		public static EventDto ToEventDto(this Event evnt)
		{
			return new EventDto
			{
				Id = evnt.Id.ToString(),
				WelcomeMessage = evnt.WelcomeMessage
			};
		}

		public static Event ToEvent(this EventDto evntDto)
		{
			return new Event
			{
				Id = Guid.Parse(evntDto.Id),
				WelcomeMessage = evntDto.WelcomeMessage
			};
		}

		public static GuestDto ToGuestDto(this Guest guest)
		{
			return new GuestDto
			{
				Id = guest.Id.ToString(),
				EventId = guest.EventId.Value.ToString(),
				Name = guest.Name.Value,
				PhoneNumber = guest.PhoneNumber?.Value,
				Rsvp = guest.Rsvp?.Value,
				Parents = guest.Parents?.Value,
				Message = guest.Message
			};
		}

	}
}

