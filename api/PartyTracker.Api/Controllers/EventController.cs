using System;
using Microsoft.AspNetCore.Mvc;
using PartyTracker.Api.Contracts.Request;
using PartyTracker.Api.Mappers;
using PartyTracker.Api.Services;

namespace PartyTracker.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EventController : ControllerBase
	{
		private readonly IEventService _eventService;

		public EventController(IEventService eventService)
		{
			_eventService = eventService;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] EventRequest createEvent)
		{
			var evenReq = createEvent.ContractToEvent();
			var result = await _eventService.CreateAsync(evenReq);
            return Ok(result.ToEventResponse());
		}

	}
}

