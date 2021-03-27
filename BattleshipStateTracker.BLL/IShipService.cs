using System;

namespace BattleshipStateTracker.BLL
{
    public interface IShipService
    {
        bool AddShip(Guid guid);
    }
}
