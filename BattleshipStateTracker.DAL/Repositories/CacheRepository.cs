using BattleshipStateTracker.DAL.Models;
using Microsoft.Extensions.Caching.Memory;
using System;

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

        public Guid SaveBoard(Board board)
        {
            board.Id = Guid.NewGuid();
            memoryCache.Set(board.Id, board);

            return board.Id;
        }

        public bool AddShip()
        {
            return true;
        }
    }
}
