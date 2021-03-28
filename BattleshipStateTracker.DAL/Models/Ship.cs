using System.Collections.Generic;

namespace BattleshipStateTracker.DAL.Models
{
    public class Ship
    {
        public Ship()
        {
            Positions = new List<ShipPosition>();
            AttackedPositions = new List<ShipPosition>();
        }

        public ICollection<ShipPosition> Positions { get; set; }
        public ICollection<ShipPosition> AttackedPositions { get; set; }
    }
}
