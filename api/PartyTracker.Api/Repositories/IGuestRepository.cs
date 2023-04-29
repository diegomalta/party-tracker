using System;
using PartyTracker.Api.Contracts.Data;

namespace PartyTracker.Api.Repositories
{
	public interface IGuestRepository
	{
        Task<GuestDto> CreateAsync(GuestDto guest);
        Task<GuestDto?> GetByIdAsync(Guid id);
    }
}

