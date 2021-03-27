using BattleshipStateTracker.DAL.Models;
using BattleshipStateTracker.DAL.Repositories;
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
            return boardRepository.SaveBoard(new Board());
        }
    }
}