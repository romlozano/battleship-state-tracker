using BattleshipStateTracker.BLL.Models.Requests;
using BattleshipStateTracker.BLL.Services;
using BattleshipStateTracker.BLL.UnitTests.TestData;
using BattleshipStateTracker.Core.Exceptions;
using BattleshipStateTracker.DAL.Models;
using BattleshipStateTracker.DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

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
            mock.Setup(repo => repo.AddShip(It.IsAny<Board>(), It.IsAny<ICollection<ShipPosition>>())).Returns(true);
            shipService = new ShipService(mock.Object);
        }

        [TestMethod]
        public void AddShip_ReturnTrue()
        {
            mock.Setup(repo => repo.GetBoard(It.Is<Guid>(id => id == ShipService_AddShipShould_TestData.ValidBoardId))).Returns(new Board());
            bool result = shipService.AddShip(ShipService_AddShipShould_TestData.AddShipRequestWithValidBoardId);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddShip_ShouldAddShip()
        {
            mock.Setup(repo => repo.GetBoard(It.Is<Guid>(id => id == ShipService_AddShipShould_TestData.ValidBoardId))).Returns(new Board());
            shipService.AddShip(ShipService_AddShipShould_TestData.AddShipRequestWithValidBoardId);

            mock.Verify(repo => repo.AddShip(It.IsAny<Board>(), It.IsAny<ICollection<ShipPosition>>()), Times.Once);
        }

        [TestMethod]
        public void AddShip_ShouldThrowBusinessArgumentException_IfBoardIsInvalid()
        {
            mock.Setup(repo => repo.GetBoard(It.Is<Guid>(id => id == ShipService_AddShipShould_TestData.InvalidBoardId))).Returns((Board)null);

            Assert.ThrowsException<BusinessArgumentException>(() => shipService.AddShip(ShipService_AddShipShould_TestData.AddShipRequestWithInValidBoardId));
        }

        [DynamicData(nameof(ShipService_AddShipShould_TestData.GetInvalidAddShipRequestData), typeof(ShipService_AddShipShould_TestData), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void AddShip_ShouldThrowBusinessArgumentException_IfAddShipRequestIsInvalid(AddShipRequest request)
        {
            mock.Setup(repo => repo.GetBoard(It.Is<Guid>(id => id == ShipService_AddShipShould_TestData.ValidBoardId))).Returns(new Board());

            Assert.ThrowsException<BusinessArgumentException>(() => shipService.AddShip(request));
        }

        [TestMethod]
        public void AddShip_ShouldThrowShipCollisionException_IfAShipAlreadyExistsOnACoordinate()
        {
            Ship ship = new Ship();
            Board board = new Board();
            ship.Positions.Add(new ShipPosition { XCoordinate = 5, YCoordinate = 5 });
            ship.Positions.Add(new ShipPosition { XCoordinate = 5, YCoordinate = 6 });
            ship.Positions.Add(new ShipPosition { XCoordinate = 5, YCoordinate = 7 });
            board.Ships.Add(ship);
            mock.Setup(repo => repo.GetBoard(It.Is<Guid>(id => id == ShipService_AddShipShould_TestData.ValidBoardId))).Returns(board);

            Assert.ThrowsException<ShipCollisionException>(() => shipService.AddShip(ShipService_AddShipShould_TestData.AddShipRequestWithShipCollision));
        }
    }
}
