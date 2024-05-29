using System;
using PartyTracker.Api.Domain;
using PartyTracker.Api.Contracts.Request;
using PartyTracker.Api.Domain.Common;

namespace PartyTracker.Api.Mappers
{
	public static class ContractToDomainMapper
	{
		public static Event ContractToEvent(this EventRequest eventRequest)
		{
			return new Event
			{
				WelcomeMessage = eventRequest.WelcomeMessage,
				AddressMapUrl = AddressMapUrl.From(eventRequest.AddressMapUrl),
				Address = Address.From(eventRequest.Address),
				ContactPhoneNumber = PhoneNumber.From(eventRequest.ContactPhoneNumber),
				EventDate = eventRequest.EventDate,
				FromTo = eventRequest.FromTo
			};
		}

		public static Guest ContractToGuest(this GuestRequest guestRequest)
		{
			return new Guest
			{
				EventId = Domain.Common.EventId.From(guestRequest.EventId),
				Name = FullName.From(guestRequest.Name),
				PhoneNumber = PhoneNumber.From(guestRequest.PhoneNumber)
			};
		}

		public static Guest ContractToGuestUpdate(this GuestRequest guestRequest)
		{
			return new Guest
			{
				PhoneNumber = PhoneNumber.From(guestRequest.PhoneNumber),
                Rsvp = Rsvp.From(guestRequest.Rsvp),
                Parents = Parents.From(guestRequest.Parents),
                Message = guestRequest.Message
            };
		}
	}
}

