using PartyTracker.Api.Domain;

namespace PartyTracker.Api.Services;
public interface IGuestService
{
    Task<Guest> CreateAsync(Guest guest);
    Task<Guest?> GetByIdAsync(Guid id);
    Task<Guest> Update(Guest guest);
}
