using BattleshipStateTracker.Core;
using BattleshipStateTracker.DAL.Models;
using BattleshipStateTracker.DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BattleshipStateTracker.BLL.UnitTests
{
    [TestClass]
    public class ShipService_AddShipShould
    {
        private Mock<IBoardRepository> mock;
        private ShipService shipService;
        private Guid NonExistentBoardId = Guid.NewGuid();

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IBoardRepository>();
            mock.Setup(repo => repo.AddShip()).Returns(true);
            mock.Setup(repo => repo.GetBoard(It.Is<Guid>(id => id == NonExistentBoardId))).Returns((Board)null);
            shipService = new ShipService(mock.Object);
        }

        [TestMethod]
        public void AddShip_ReturnTrue()
        {
            bool result = shipService.AddShip();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddShip_ShouldAddShip()
        {
            shipService.AddShip();

            mock.Verify(repo => repo.AddShip(), Times.Once);
        }

        [TestMethod]
        public void AddShip_ShouldThrowBusinessArgumentException_IfBoardIsNull()
        {
            Assert.ThrowsException<BusinessArgumentException>(() => shipService.AddShip());
        }
    }
}
