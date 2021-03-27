using BattleshipStateTracker.DAL.Repositories;

namespace BattleshipStateTracker.BLL
{
    public class ShipService : IShipService
    {
        private readonly IBoardRepository boardRepository;

        public ShipService(IBoardRepository boardRepository)
        {
            this.boardRepository = boardRepository;
        }

        public bool AddShip()
        {
            return true;
        }
    }
}
