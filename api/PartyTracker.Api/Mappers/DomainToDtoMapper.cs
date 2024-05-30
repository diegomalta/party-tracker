using System;
using PartyTracker.Api.Contracts.Data;
using PartyTracker.Api.Domain;
using PartyTracker.Api.Domain.Common;

namespace PartyTracker.Api.Mappers
{
	public static class DomainToDtoMapper
	{
		public static EventDto ToEventDto(this Event evnt)
		{
			return new EventDto
			{
				Id = evnt.Id.ToString(),
				WelcomeMessage = evnt.WelcomeMessage,
				AddressMapUrl = evnt.AddressMapUrl.Value,
				Address = evnt.Address.Value,
				ContactPhoneNumber = evnt.ContactPhoneNumber.Value,
				EventDate = evnt.EventDate,
				FromTo = evnt.FromTo
			};
		}

		public static Event ToEvent(this EventDto evntDto)
		{
			return new Event
			{
				Id = Guid.Parse(evntDto.Id),
				WelcomeMessage = evntDto.WelcomeMessage,
				AddressMapUrl = AddressMapUrl.From(evntDto.AddressMapUrl),
				Address = Address.From(evntDto.Address),
				ContactPhoneNumber = PhoneNumber.From(evntDto.ContactPhoneNumber),
				EventDate = evntDto.EventDate,
				FromTo = evntDto.FromTo
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

