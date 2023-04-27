using PartyTracker.Api.Contracts.Data;

namespace PartyTracker.Api.Repositories
{
    public interface IEventRepository
    {
        Task<EventDto> CreateAsync(EventDto customer);
    }
}