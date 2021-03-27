using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BattleshipStateTracker.BLL.UnitTests
{
    [TestClass]
    public class BoardService_CreateBoardShould
    {
        [TestMethod]
        public void CreateBoard_ReturnGuid()
        {
            var mock = new Mock<IBoardRepository>();
            var boardService = new BoardService(mock.Object);
            var boardId = boardService.CreateBoard();

            Assert.IsInstanceOfType(boardId, typeof(Guid));
        }

        [TestMethod]
        public void CreateBoard_ShouldSaveBoard()
        {
            var mock = new Mock<IBoardRepository>();
            var boardService = new BoardService(mock.Object);
            var boardId = boardService.CreateBoard();

            mock.Verify(repo => repo.SaveBoard(), Times.Once);
        }
    }
}
