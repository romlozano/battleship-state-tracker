using System.Collections.Generic;

namespace BattleshipStateTracker.DAL.Models
{
    public class Ship
    {
        public Ship()
        {
            Positions = new List<ShipPosition>();
        }

        public IEnumerable<ShipPosition> Positions { get; set; }
    }
}
