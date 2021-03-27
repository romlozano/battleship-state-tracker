using BattleshipStateTracker.DAL;
using System;

namespace BattleshipStateTracker.BLL
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
            boardRepository.SaveBoard(new Board());

            return Guid.NewGuid();
        }
    }
}