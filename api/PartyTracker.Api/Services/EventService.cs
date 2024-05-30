using PartyTracker.Api.Domain;
using PartyTracker.Api.Mappers;
using PartyTracker.Api.Repositories;

namespace PartyTracker.Api.Services
{
	public class EventService : IEventService
	{
		private readonly IEventRepository _eventRepository;

		public EventService(IEventRepository eventRepository)
		{
			_eventRepository = eventRepository;
		}

    public async Task<Event> CreateAsync(Event eventReq)
    {
			var eventDto = eventReq.ToEventDto();
			await _eventRepository.CreateAsync(eventDto);
			return eventReq;
    }

		public async Task<Event?> GetEventByIdAsync(Guid id)
		{
			var eventDto = await _eventRepository.GetByIdAsync(id);
			return eventDto?.ToEvent();
		}
  }
}

