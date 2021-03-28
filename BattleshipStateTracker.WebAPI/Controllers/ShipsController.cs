using BattleshipStateTracker.BLL.Models.Requests;
using BattleshipStateTracker.BLL.Services;
using BattleshipStateTracker.Core.Enums;
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
        /// <returns>true</returns>
        /// <response code="201">true</response>
        /// <response code="400"></response>
        /// <response code="404"></response>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> AddShip(AddShipRequest request)
        {
            bool result = shipService.AddShip(request);

            return Created("", result); // TODO: Return a better response
        }

        // POST api/ships/attack
        /// <summary>
        /// Attack a ship on an existing board
        /// </summary>
        /// <param name="request">The add ship request with board id and attack position</param>
        /// <returns>AttackShipResultEnum</returns>
        /// <response code="200">AttackShipResultEnum</response>
        /// <response code="400"></response>
        /// <response code="404"></response>
        [HttpPost("attack")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AttackShipResultEnum))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AttackShipResultEnum> AttackShip(AttackShipRequest request)
        {
            AttackShipResultEnum result = shipService.AttackShip(request);

            return Ok(result); // TODO: Return a better response
        }
    }
}
