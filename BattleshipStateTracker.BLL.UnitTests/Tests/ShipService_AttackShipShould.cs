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
            mock.Setup(repo => repo.GetBoard(It.Is<Guid>(id => id == ShipService_AttackShipShould_TestData.ValidBoardId))).Returns(new Board());
            AttackShipResultEnum result = shipService.AttackShip(ShipService_AttackShipShould_TestData.AttackShipRequestWithValidBoardId);

            Assert.IsInstanceOfType(result, typeof(AttackShipResultEnum));
        }

        [TestMethod]
        public void AttackShip_ShouldCallSaveBoard()
        {
            mock.Setup(repo => repo.GetBoard(It.Is<Guid>(id => id == ShipService_AttackShipShould_TestData.ValidBoardId))).Returns(new Board());
            shipService.AttackShip(ShipService_AttackShipShould_TestData.AttackShipRequestWithValidBoardId);

            mock.Verify(repo => repo.SaveBoard(It.IsAny<Board>()), Times.Once);
        }

        [TestMethod]
        public void AttackShip_ShouldThrowBusinessArgumentException_IfBoardIsInvalid()
        {
            mock.Setup(repo => repo.GetBoard(It.Is<Guid>(id => id == ShipService_AttackShipShould_TestData.InvalidBoardId))).Returns((Board)null);

            Assert.ThrowsException<BusinessArgumentException>(() => shipService.AttackShip(ShipService_AttackShipShould_TestData.AttackShipRequestWithInValidBoardId));
        }

        [DynamicData(nameof(ShipService_AttackShipShould_TestData.GetInvalidAttackShipRequestData), typeof(ShipService_AttackShipShould_TestData), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void AttackShip_ShouldThrowBusinessArgumentException_IfAttackShipRequestIsInvalid(AttackShipRequest request)
        {
            mock.Setup(repo => repo.GetBoard(It.Is<Guid>(id => id == ShipService_AttackShipShould_TestData.ValidBoardId))).Returns(new Board());

            Assert.ThrowsException<BusinessArgumentException>(() => shipService.AttackShip(request));
        }

        [TestMethod]
        public void Attackship_ShouldReturnHitAttackShipResultEnum_IfShipPositionIsOccupied()
        {
            mock.Setup(repo => repo.GetBoard(It.Is<Guid>(id => id == ShipService_AttackShipShould_TestData.ValidBoardId))).Returns(ShipService_AttackShipShould_TestData.BoardWithExistingShip);
            AttackShipResultEnum result = shipService.AttackShip(ShipService_AttackShipShould_TestData.AttackShipRequestWithHitCapability);

            Assert.AreEqual(AttackShipResultEnum.Hit, result);
        }

        [TestMethod]
        public void Attackship_ShouldReturnMissAttackShipResultEnum_IfShipPositionWasAlreadyAttacked()
        {
            mock.Setup(repo => repo.GetBoard(It.Is<Guid>(id => id == ShipService_AttackShipShould_TestData.ValidBoardId))).Returns(ShipService_AttackShipShould_TestData.BoardWithExistingShipHavingAttackedPosition);
            AttackShipResultEnum result = shipService.AttackShip(ShipService_AttackShipShould_TestData.AttackShipRequestWithHitCapability);

            Assert.AreEqual(AttackShipResultEnum.Miss, result);
        }
    }
}
