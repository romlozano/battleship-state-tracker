using BattleshipStateTracker.BLL.Models.Requests;
using BattleshipStateTracker.Core.Enums;

namespace BattleshipStateTracker.BLL.Services
{
    public interface IShipService
    {
        bool AddShip(AddShipRequest request);
        AttackShipResultEnum AttackShip(AttackShipRequest request);
    }
}
