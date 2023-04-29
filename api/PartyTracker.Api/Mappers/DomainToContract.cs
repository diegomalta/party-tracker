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
                Id = eventCreated.Id
            };
        }

        public static GuestResponse ToGuestResponse(this Guest guestCreated)
        {
            return new GuestResponse
            {
                Id = guestCreated.Id,
                EventId = guestCreated.EventId.Value,
                Name = guestCreated.Name.Value,
                PhoneNumber = guestCreated.PhoneNumber?.Value
               
            };
        }
    }
}

