using BattleshipStateTracker.Core.Enums;

namespace BattleshipStateTracker.WebAPI.Models.Response
{
    public class AttackShipResponse
    {
        /// <summary>
        /// An enum indicating the result of an attack
        /// </summary>
        public AttackShipResultEnum AttackShipResult { get; set; }
    }
}
