using BattleshipStateTracker.BLL.Models.Requests;
using BattleshipStateTracker.BLL.Services;
using BattleshipStateTracker.Core.Enums;
using BattleshipStateTracker.DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BattleshipStateTracker.BLL.UnitTests.Tests
{
    [TestClass]
    public class ShipService_AttackShipShould
    {
        private Mock<IBoardRepository> mock;
        private ShipService shipService;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IBoardRepository>();
            shipService = new ShipService(mock.Object);
        }

        [TestMethod]
        public void AttackShip_ReturnAttackShipResultEnum()
        {
            AttackShipResultEnum result = shipService.AttackShip(new AttackShipRequest());

            Assert.IsInstanceOfType(result, typeof(AttackShipResultEnum));
        }
    }
}
