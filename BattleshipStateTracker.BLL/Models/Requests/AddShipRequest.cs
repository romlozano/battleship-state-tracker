using BattleshipStateTracker.DAL.Models;
using System;

namespace BattleshipStateTracker.BLL.Models.Requests
{
    // TODO: Refactor to Presentation layer to include comments in the xml file
    public class AddShipRequest
    {
        /// <summary>
        /// The id of an existing board
        /// </summary>
        public Guid BoardId { get; set; }
        /// <summary>
        /// The start position of the ship
        /// </summary>
        public ShipPosition StartPosition { get; set; }
        /// <summary>
        /// The length of the ship [1-10]
        /// </summary>
        public int ShipLength { get; set; }
        /// <summary>
        /// The direction of the ship ["right", "down"]
        /// </summary>
        public string Direction { get; set; }
    }
}
