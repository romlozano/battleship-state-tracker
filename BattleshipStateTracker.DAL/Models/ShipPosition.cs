namespace BattleshipStateTracker.DAL.Models
{
    // TODO: Refactor to Presentation layer to include comments in the xml file
    public class ShipPosition
    {
        /// <summary>
        /// The x-coordinate of the ship's start position [0-9]
        /// </summary>
        public int XCoordinate { get; set; }
        /// <summary>
        /// The y-coordinate of the ship's start position [0-9]
        /// </summary>
        public int YCoordinate { get; set; }
    }
}
