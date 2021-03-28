using BattleshipStateTracker.BLL.Models.Requests;
using BattleshipStateTracker.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;

namespace BattleshipStateTracker.WebAPI.Controllers
{
    [Route("api/ships")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ShipsController : ControllerBase
    {
        private readonly IShipService shipService;

        public ShipsController(IShipService shipService)
        {
            this.shipService = shipService;
        }

        // POST api/ships
        /// <summary>
        /// Adds a ship to an existing board
        /// </summary>
        /// <param name="request">The add ship request with start position, length, and direction</param>
        /// <returns>true</returns>
        /// <response code="201">true</response>
        /// <response code="400"></response>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> AddShip(AddShipRequest request)
        {
            bool result = shipService.AddShip(request);

            return Created("", result); // TODO: Return a better response
        }
    }
}
