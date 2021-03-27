using BattleshipStateTracker.Core.Enums;
using BattleshipStateTracker.DAL.Models;

namespace BattleshipStateTracker.BLL.Models.Requests
{
    public class AddShipRequest
    {
        public ShipPosition StartPosition { get; set; }
        public int ShipLength { get; set; }
        public ShipDirectionEnum Direction { get; set; }
    }
}
