using BattleshipStateTracker.BLL.Models.Requests;
using BattleshipStateTracker.BLL.Services;
using BattleshipStateTracker.BLL.UnitTests.TestData;
using BattleshipStateTracker.Core.Exceptions;
using BattleshipStateTracker.DAL.Models;
using BattleshipStateTracker.DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BattleshipStateTracker.BLL.UnitTests.Tests
{
    [TestClass]
    public class ShipService_AddShipShould
    {
        private Mock<IBoardRepository> mock;
        private ShipService shipService;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IBoardRepository>();
            mock.Setup(repo => repo.AddShip()).Returns(true);
            mock.Setup(repo => repo.GetBoard(It.Is<Guid>(id => id == ShipService_AddShipShould_TestData.InvalidBoardId))).Returns((Board)null);
            mock.Setup(repo => repo.GetBoard(It.Is<Guid>(id => id == ShipService_AddShipShould_TestData.ValidBoardId))).Returns(new Board());
            shipService = new ShipService(mock.Object);
        }

        [TestMethod]
        public void AddShip_ReturnTrue()
        {
            bool result = shipService.AddShip(ShipService_AddShipShould_TestData.ValidBoardId, ShipService_AddShipShould_TestData.ValidAddShipRequest);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddShip_ShouldAddShip()
        {
            shipService.AddShip(ShipService_AddShipShould_TestData.ValidBoardId, ShipService_AddShipShould_TestData.ValidAddShipRequest);

            mock.Verify(repo => repo.AddShip(), Times.Once);
        }

        [TestMethod]
        public void AddShip_ShouldThrowBusinessArgumentException_IfBoardIsInvalid()
        {
            Assert.ThrowsException<BusinessArgumentException>(() => shipService.AddShip(ShipService_AddShipShould_TestData.InvalidBoardId,
                ShipService_AddShipShould_TestData.ValidAddShipRequest));
        }

        [DynamicData(nameof(ShipService_AddShipShould_TestData.GetInvalidAddShipRequestData), typeof(ShipService_AddShipShould_TestData), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void AddShip_ShouldThrowBusinessArgumentException_IfAddShipRequestIsInvalid(AddShipRequest request)
        {
            Assert.ThrowsException<BusinessArgumentException>(() => shipService.AddShip(ShipService_AddShipShould_TestData.ValidBoardId, request));
        }
    }
}
