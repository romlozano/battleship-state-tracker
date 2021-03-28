using System.Collections.Generic;

namespace BattleshipStateTracker.DAL.Models
{
    public class Ship
    {
        public Ship()
        {
            Positions = new List<ShipPosition>();
        }

        public ICollection<ShipPosition> Positions { get; set; }
    }
}
