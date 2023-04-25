using System;
using PartyTracker.Api.Domain;
using PartyTracker.Api.Contracts.Request;
using PartyTracker.Api.Contracts.Responses;

namespace PartyTracker.Api.Mappers
{
	public static class ContractToDomainMapper
	{
		public static Event ContractToEvent(this EventRequest eventRequest)
		{
			return new Event
			{
				WelcomeMessage = eventRequest.WelcomeMessage
			};
		}

		public static EventResponse ToEventResponse(this Event eventCreated)
		{
			return new EventResponse
			{
				Id = eventCreated.Id
			}
		}
	}
}

