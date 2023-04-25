using System;
using PartyTracker.Api.Domain;

namespace PartyTracker.Api.Services
{
	public class EventService : IEventService
	{
		public EventService()
		{
		}

        public Task<Event> CreateAsync(Event eventReq)
        {
            throw new NotImplementedException();
        }
    }
}

