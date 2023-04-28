using System;
using Microsoft.AspNetCore.Mvc;
using PartyTracker.Api.Contracts.Request;
using PartyTracker.Api.Mappers;
using PartyTracker.Api.Services;

namespace PartyTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuestController : ControllerBase
	{
		private readonly IGuestService _guestService;

		public GuestController(IGuestService guestService)
		{
			_guestService = guestService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync (GuestRequest guestRequest)
		{
			var guest = guestRequest.ContractToGuest();
			var response = await _guestService.CreateAsync(guest);
			return Ok(response.ToGuestResponse());
		}

	}
}

