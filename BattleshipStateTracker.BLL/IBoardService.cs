using BattleshipStateTracker.DAL.Models;
using System;

namespace BattleshipStateTracker.BLL
{
    public interface IBoardService
    {
        Guid CreateBoard();
    }
}
