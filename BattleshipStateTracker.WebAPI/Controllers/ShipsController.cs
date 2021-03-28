using BattleshipStateTracker.BLL.Models.Requests;
using BattleshipStateTracker.BLL.Services;
using BattleshipStateTracker.Core.Enums;
using BattleshipStateTracker.WebAPI.Models.Response;
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
        /// <param name="request">The add ship request with board id, start position, length, and direction</param>
        /// <returns>An add ship response with a flag indicating whether the ship was successfully added</returns>
        /// <response code="201">An add ship response with a flag indicating whether the ship was successfully added</response>
        /// <response code="400"></response>
        /// <response code="404"></response>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AddShipResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AddShipResponse> AddShip(AddShipRequest request)
        {
            bool result = shipService.AddShip(request);

            return Created("", new AddShipResponse { Success = result });
        }

        // POST api/ships/attack
        /// <summary>
        /// Attack a ship on an existing board
        /// </summary>
        /// <param name="request">The add ship request with board id and attack position</param>
        /// <returns>An attack ship response with an enum indicating the attack result</returns>
        /// <response code="200">An attack ship response with an enum indicating the attack result</response>
        /// <response code="400"></response>
        /// <response code="404"></response>
        [HttpPost("attack")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttackShipResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AttackShipResponse> AttackShip(AttackShipRequest request)
        {
            AttackShipResultEnum result = shipService.AttackShip(request);

            return Ok(new AttackShipResponse { AttackShipResult = result }); // TODO: Return a better response
        }
    }
}
