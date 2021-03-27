using BattleshipStateTracker.DAL.Models;
using System;

namespace BattleshipStateTracker.DAL.Repositories
{
    public interface IBoardRepository
    {
        Guid SaveBoard(Board board);
    }
}