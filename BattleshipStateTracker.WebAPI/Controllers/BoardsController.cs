using BattleshipStateTracker.BLL.Services;
using BattleshipStateTracker.WebAPI.Models.Response;
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
        /// <returns>A board response object with id of the new board</returns>
        /// <response code="201">A board response object with id of the new board</response>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateBoardResponse))]
        public ActionResult<Guid> CreateBoard()
        {
            Guid id = boardService.CreateBoard();

            return Created("", new CreateBoardResponse { BoardId = id }); // TODO: Implement GetBoard and update uri
        }
    }
}
