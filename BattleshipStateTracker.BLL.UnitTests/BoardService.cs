using System;

namespace BattleshipStateTracker.BLL.UnitTests
{
    internal class BoardService
    {
        public BoardService()
        {
        }

        internal Guid CreateBoard()
        {
            return Guid.NewGuid();
        }
    }
}