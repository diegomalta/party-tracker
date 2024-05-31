using PartyTracker.Api.Contracts.Data;
using PartyTracker.Api.Domain;
using PartyTracker.Api.Domain.Common;

namespace PartyTracker.Api.Mappers;
public static class DtoToDomainMapper
{
    public static Guest ToGuest(this GuestDto guest)
    {
        return new Guest
        {
            Id = Guid.Parse(guest.Id),
            EventId = Domain.Common.EventId.From(Guid.Parse(guest.EventId)),
            Name = FullName.From(guest.Name),
            PhoneNumber = PhoneNumber.From(guest.PhoneNumber),
            Rsvp = Rsvp.From(guest.Rsvp),
            Parents = Parents.From(guest.Parents),
            Message = guest.Message
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
}
