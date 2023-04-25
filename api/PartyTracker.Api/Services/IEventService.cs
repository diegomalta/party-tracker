using PartyTracker.Api.Domain;

namespace PartyTracker.Api.Services
{
    public interface IEventService
    {
        Task<Event> CreateAsync(Event eventReq);
    }
}