using BattleshipStateTracker.Core.Enums;
using System;

namespace BattleshipStateTracker.BLL.Models.Requests
{
    public class AddShipRequest
    {
        public Guid BoardId { get; set; }
        public ShipPosition StartPosition { get; set; }
        public int ShipLength { get; set; }
        public ShipDirectionEnum Direction { get; set; }
    }
}
