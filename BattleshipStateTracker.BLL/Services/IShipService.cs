using BattleshipStateTracker.BLL.Models.Requests;
using System;

namespace BattleshipStateTracker.BLL.Services
{
    public interface IShipService
    {
        bool AddShip(AddShipRequest request);
    }
}
