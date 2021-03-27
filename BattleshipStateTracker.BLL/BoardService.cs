using System;

namespace BattleshipStateTracker.BLL.UnitTests
{
    public class BoardService
    {
        private readonly IBoardRepository boardRepository;

        public BoardService(IBoardRepository boardRepository)
        {
            this.boardRepository = boardRepository;
        }

        public Guid CreateBoard()
        {
            boardRepository.SaveBoard();

            return Guid.NewGuid();
        }
    }
}