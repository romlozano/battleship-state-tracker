using BattleshipStateTracker.DAL.Models;
using System;
using System.Collections.Generic;

namespace BattleshipStateTracker.DAL.Repositories
{
    public interface IBoardRepository
    {
        Board GetBoard(Guid boardId);
        Guid CreateBoard(Board board);
        void SaveBoard(Board board);
    }
}