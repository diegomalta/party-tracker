using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyTracker.Api.Contracts.Request;
using PartyTracker.Api.Mappers;
using PartyTracker.Api.Middleware;
using PartyTracker.Api.Services;

namespace PartyTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuestController : ControllerBase
	{
		private readonly IGuestService _guestService;
        private readonly ILogger _logger;

		public GuestController(IGuestService guestService, ILogger<LoggerMiddleware> logger)
		{
			_guestService = guestService;
            _logger = logger;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync (GuestRequest guestRequest)
		{
			var guest = guestRequest.ContractToGuest();
			var response = await _guestService.CreateAsync(guest);
			return Ok(response.ToGuestResponse());
		}

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var guest = await _guestService.GetByIdAsync(id);

            if (guest is null)
            {
                return NotFound();
            }

            return Ok(guest.ToGuestResponse());
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] GuestRequest guestRequest)
        {
            var guest = await _guestService.GetByIdAsync(id);

            if (guest is null)
            {
                return NotFound();
            }

            _logger.LogInformation(JsonSerializer.Serialize(guestRequest));

            var guestToUpdate = guestRequest.ContractToGuestUpdate();

            //Update only required propierties
            guest.PhoneNumber = guestToUpdate.PhoneNumber;
            guest.Rsvp = guestToUpdate.Rsvp;
            guest.Parents = guestToUpdate.Parents;
            guest.Message = guestToUpdate.Message;

            var updateResponse = await _guestService.Update(guest);
            return Ok(updateResponse.ToGuestResponse());
        }

    }
}

