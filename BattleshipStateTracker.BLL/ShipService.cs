using BattleshipStateTracker.Core;
using BattleshipStateTracker.DAL.Repositories;
using System;

namespace BattleshipStateTracker.BLL
{
    public class ShipService : IShipService
    {
        private readonly IBoardRepository boardRepository;

        public ShipService(IBoardRepository boardRepository)
        {
            this.boardRepository = boardRepository;
        }

        public bool AddShip(Guid guid)
        {
            var board = boardRepository.GetBoard(guid);
            if (board == null)
            {
                throw new BusinessArgumentException("Guid is not valid", nameof(guid));
            }

            return boardRepository.AddShip();
        }
    }
}
