using BattleshipStateTracker.DAL.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace BattleshipStateTracker.DAL.Repositories
{
    public class CacheRepository : IBoardRepository
    {
        private readonly IMemoryCache memoryCache;
        private MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpiration = DateTime.Now.AddDays(1),
            SlidingExpiration = TimeSpan.FromHours(12),
            Priority = CacheItemPriority.High,
        };

        public CacheRepository(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public Board GetBoard(Guid boardId)
        {
            bool boardExists = memoryCache.TryGetValue(boardId, out Board board);

            if (boardExists)
            {
                return board;
            }
            else
            {
                return null;
            }
        }

        public Guid SaveBoard(Board board)
        {
            board.Id = Guid.NewGuid();
            memoryCache.Set(board.Id, board);

            return board.Id;
        }

        public bool AddShip(Board board, ICollection<ShipPosition> shipPositions)
        {
            Ship ship = new Ship();
            ship.Positions = shipPositions;
            board.Ships.Add(ship);
            memoryCache.Set(board.Id, board);

            return true;
        }
    }
}
