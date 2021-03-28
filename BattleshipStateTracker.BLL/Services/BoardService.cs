using BattleshipStateTracker.DAL.Models;
using BattleshipStateTracker.DAL.Repositories;
using System;

namespace BattleshipStateTracker.BLL.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository boardRepository;

        public BoardService(IBoardRepository boardRepository)
        {
            this.boardRepository = boardRepository;
        }

        public Guid CreateBoard()
        {
            return boardRepository.CreateBoard(new Board());
        }
    }
}