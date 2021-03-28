using System;
using System.Collections.Generic;

namespace BattleshipStateTracker.DAL.Models
{
    public class Board
    {
        public Board()
        {
            Ships = new List<Ship>();
        }

        public Guid Id { get; set; }
        public ICollection<Ship> Ships { get; set; }
    }
}