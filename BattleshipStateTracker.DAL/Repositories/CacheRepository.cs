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

        public Guid CreateBoard(Board board)
        {
            board.Id = Guid.NewGuid();
            memoryCache.Set(board.Id, board);

            return board.Id;
        }

        public void SaveBoard(Board board)
        {
            memoryCache.Set(board.Id, board);
        }
    }
}
