using BattleshipStateTracker.DAL.Models;
using System;

namespace BattleshipStateTracker.DAL.Repositories
{
    public interface IBoardRepository
    {
        Board GetBoard(Guid guid);
        Guid SaveBoard(Board board);
        bool AddShip();
    }
}