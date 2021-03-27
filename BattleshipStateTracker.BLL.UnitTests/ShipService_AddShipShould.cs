using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipStateTracker.BLL.UnitTests
{
    [TestClass]
    public class ShipService_AddShipShould
    {
        [TestMethod]
        public void AddShip_ReturnTrue()
        {
            var shipService = new ShipService();
            bool result = shipService.AddShip();

            Assert.IsTrue(result);
        }
    }
}
