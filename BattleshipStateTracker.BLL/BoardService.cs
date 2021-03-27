using System;

namespace BattleshipStateTracker.BLL.UnitTests
{
    public class BoardService
    {
        public BoardService()
        {
        }

        public Guid CreateBoard()
        {
            return Guid.NewGuid();
        }
    }
}