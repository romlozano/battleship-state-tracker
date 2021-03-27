using BattleshipStateTracker.BLL.Services;
using BattleshipStateTracker.DAL.Models;
using BattleshipStateTracker.DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BattleshipStateTracker.BLL.UnitTests.Tests
{
    [TestClass]
    public class BoardService_CreateBoardShould
    {
        private Mock<IBoardRepository> mock;
        private BoardService boardService;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IBoardRepository>();
            mock.Setup(repo => repo.SaveBoard(It.IsAny<Board>())).Returns(It.IsAny<Guid>());
            boardService = new BoardService(mock.Object);
        }

        [TestMethod]
        public void CreateBoard_ReturnGuid()
        {
            Guid boardId = boardService.CreateBoard();

            Assert.IsInstanceOfType(boardId, typeof(Guid));
        }

        [TestMethod]
        public void CreateBoard_ShouldSaveBoard()
        {
            boardService.CreateBoard();

            mock.Verify(repo => repo.SaveBoard(It.IsAny<Board>()), Times.Once);
        }
    }
}
