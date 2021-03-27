using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BattleshipStateTracker.BLL.UnitTests
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
            boardService = new BoardService(mock.Object);
        }

        [TestMethod]
        public void CreateBoard_ReturnGuid()
        {
            
            var boardId = boardService.CreateBoard();

            Assert.IsInstanceOfType(boardId, typeof(Guid));
        }

        [TestMethod]
        public void CreateBoard_ShouldSaveBoard()
        {
            var boardId = boardService.CreateBoard();

            mock.Verify(repo => repo.SaveBoard(), Times.Once);
        }
    }
}
