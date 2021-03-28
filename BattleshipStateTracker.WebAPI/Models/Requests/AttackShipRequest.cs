using System;

namespace BattleshipStateTracker.WebAPI.Models.Requests
{
    public class AttackShipRequest
    {
        /// <summary>
        /// The id of an existing board
        /// </summary>
        public Guid BoardId { get; set; }
        /// <summary>
        /// The position of the ship being attacked
        /// </summary>
        public ShipPosition ShipPosition { get; set; }
    }
}
