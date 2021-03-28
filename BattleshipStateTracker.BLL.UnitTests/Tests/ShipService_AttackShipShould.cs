using BattleshipStateTracker.BLL.Models.Requests;
using BattleshipStateTracker.BLL.Services;
using BattleshipStateTracker.BLL.UnitTests.TestData;
using BattleshipStateTracker.Core.Enums;
using BattleshipStateTracker.Core.Exceptions;
using BattleshipStateTracker.DAL.Models;
using BattleshipStateTracker.DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

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
            mock.Setup(repo => repo.SaveBoard(It.IsAny<Board>()));
            shipService = new ShipService(mock.Object);
        }

        [TestMethod]
        public void AttackShip_ReturnAttackShipResultEnum()
        {
            AttackShipResultEnum result = shipService.AttackShip(new AttackShipRequest());

            Assert.IsInstanceOfType(result, typeof(AttackShipResultEnum));
        }

        [TestMethod]
        public void AttackShip_ShouldCallSaveBoard()
        {
            shipService.AttackShip(new AttackShipRequest());

            mock.Verify(repo => repo.SaveBoard(It.IsAny<Board>()), Times.Once);
        }

        [TestMethod]
        public void AttackShip_ShouldThrowBusinessArgumentException_IfBoardIsInvalid()
        {
            mock.Setup(repo => repo.GetBoard(It.Is<Guid>(id => id == ShipService_AttackShipShould_TestData.InvalidBoardId))).Returns((Board)null);

            Assert.ThrowsException<BusinessArgumentException>(() => shipService.AttackShip(ShipService_AttackShipShould_TestData.AttackShipRequestWithInValidBoardId));
        }
    }
}
