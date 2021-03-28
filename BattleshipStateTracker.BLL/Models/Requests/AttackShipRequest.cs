using BattleshipStateTracker.DAL.Models;
using System;

namespace BattleshipStateTracker.BLL.Models.Requests
{
    public class AttackShipRequest
    {
        public Guid BoardId { get; set; }
        public ShipPosition ShipPosition { get; set; }
    }
}
