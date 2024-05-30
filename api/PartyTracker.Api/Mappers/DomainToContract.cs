using System;
using PartyTracker.Api.Contracts.Responses;
using PartyTracker.Api.Domain;

namespace PartyTracker.Api.Mappers
{
	public static class DomainToContract
	{
        public static EventResponse ToEventResponse(this Event eventCreated)
        {
            return new EventResponse
            {
                Id = eventCreated.Id,
                WelcomeMessage = eventCreated.WelcomeMessage,
                AddressMapUrl = eventCreated.AddressMapUrl.Value,
                Address = eventCreated.Address.Value,
                ContactPhoneNumber = eventCreated.ContactPhoneNumber.Value,
                EventDate = eventCreated.EventDate,
                FromTo = eventCreated.FromTo
            };
        }

        public static GuestResponse ToGuestResponse(this Guest guestCreated, Event eventCreated = null)
        {
            return new GuestResponse
            {
                Id = guestCreated.Id,
                EventId = guestCreated.EventId.Value,
                Name = guestCreated.Name.Value,
                PhoneNumber = guestCreated.PhoneNumber?.Value,
                Rsvp = guestCreated.Rsvp?.Value,
                Parents = guestCreated.Parents?.Value,
                Message = guestCreated.Message,
                Event = eventCreated == null ? null : eventCreated.ToEventResponse()
            };
        }
    }
}

