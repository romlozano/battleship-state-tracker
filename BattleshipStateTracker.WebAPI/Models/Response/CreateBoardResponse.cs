using System;

namespace BattleshipStateTracker.WebAPI.Models.Response
{
    public class CreateBoardResponse
    {
        /// <summary>
        /// The id of the newly created board
        /// </summary>
        public Guid BoardId { get; set; }
    }
}
