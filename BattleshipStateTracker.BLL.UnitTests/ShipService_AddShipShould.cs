using BattleshipStateTracker.DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BattleshipStateTracker.BLL.UnitTests
{
    [TestClass]
    public class ShipService_AddShipShould
    {
        [TestMethod]
        public void AddShip_ReturnTrue()
        {
            var mock = new Mock<IBoardRepository>();
            var shipService = new ShipService(mock.Object);
            bool result = shipService.AddShip();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddShip_ShouldAddShip()
        {
            var mock = new Mock<IBoardRepository>();
            var shipService = new ShipService(mock.Object);
            bool result = shipService.AddShip();

            mock.Verify(repo => repo.AddShip(), Times.Once);
        }
    }
}
