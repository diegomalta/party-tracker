using System;
using PartyTracker.Api.Contracts.Data;
using PartyTracker.Api.Domain;
using PartyTracker.Api.Domain.Common;

namespace PartyTracker.Api.Mappers
{
	public static class DtoToDomainMapper
	{
        public static Guest ToGuest(this GuestDto guest)
        {
            return new Guest
            {
                Id = Guid.Parse(guest.Id),
                EventId = Domain.Common.EventId.From(Guid.Parse(guest.EventId)),
                Name = FullName.From(guest.Name),
                PhoneNumber = PhoneNumber.From(guest.PhoneNumber)
            };
        }
    }
}

