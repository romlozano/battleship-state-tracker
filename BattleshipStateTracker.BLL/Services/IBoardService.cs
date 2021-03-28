using BattleshipStateTracker.DAL.Models;
using System;

namespace BattleshipStateTracker.BLL.Services
{
    public interface IBoardService
    {
        Guid CreateBoard();
    }
}
