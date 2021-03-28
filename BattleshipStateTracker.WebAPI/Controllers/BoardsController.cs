using BattleshipStateTracker.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;

namespace BattleshipStateTracker.WebAPI.Controllers
{
    [Route("api/boards")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class BoardsController : ControllerBase
    {
        private readonly IBoardService boardService;

        public BoardsController(IBoardService boardService)
        {
            this.boardService = boardService;
        }

        // POST api/board
        /// <summary>
        /// Creates a board
        /// </summary>
        /// <returns>The id of the new board as a Guid</returns>
        /// <response code="201">Returns the id of the new board as a Guid</response>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        public ActionResult<Guid> CreateBoard()
        {
            Guid id = boardService.CreateBoard();

            return Created("", id); // TODO: Implement GetBoard and update uri
        }
    }
}
