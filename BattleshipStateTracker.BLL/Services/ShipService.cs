using BattleshipStateTracker.BLL.Models.Requests;
using BattleshipStateTracker.Core.Exceptions;
using BattleshipStateTracker.DAL.Repositories;
using System;

namespace BattleshipStateTracker.BLL.Services
{
    public class ShipService : IShipService
    {
        private readonly IBoardRepository boardRepository;

        public ShipService(IBoardRepository boardRepository)
        {
            this.boardRepository = boardRepository;
        }

        public bool AddShip(Guid boardId, AddShipRequest request)
        {
            var board = boardRepository.GetBoard(boardId);
            if (board == null)
            {
                throw new BusinessArgumentException("Guid is not valid", nameof(boardId));
            }

            return boardRepository.AddShip();
        }
    }
}
