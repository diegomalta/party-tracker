using System;
using PartyTracker.Api.Domain;
using PartyTracker.Api.Mappers;
using PartyTracker.Api.Repositories;

namespace PartyTracker.Api.Services
{
	public class GuestService : IGuestService
	{
        private readonly IGuestRepository _guestRepository;

		public GuestService(IGuestRepository guestRepository)
		{
            _guestRepository = guestRepository;
		}

        public async Task<Guest> CreateAsync(Guest guest)
        {
            var guestDto = guest.ToGuestDto();
            await _guestRepository.CreateAsync(guestDto);
            return guest;
        }

        public async Task<Guest?> GetByIdAsync(Guid id)
        {
            var guestDto = await _guestRepository.GetByIdAsync(id);
            return guestDto?.ToGuest();
        }

        public async Task<Guest> Update(Guest guest)
        {
            var guestDto = guest.ToGuestDto();
            await _guestRepository.UpdateAsync(guestDto);
            return guest;
        }
    }
}

