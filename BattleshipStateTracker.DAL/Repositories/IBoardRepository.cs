using BattleshipStateTracker.DAL.Models;
using System;
using System.Collections.Generic;

namespace BattleshipStateTracker.DAL.Repositories
{
    public interface IBoardRepository
    {
        Board GetBoard(Guid boardId);
        Guid SaveBoard(Board board);
        bool AddShip(Board board, IEnumerable<ShipPosition> shipPositions);
    }
}