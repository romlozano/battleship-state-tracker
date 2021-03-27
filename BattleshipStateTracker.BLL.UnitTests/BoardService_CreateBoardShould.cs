using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BattleshipStateTracker.BLL.UnitTests
{
    [TestClass]
    public class BoardService_CreateBoardShould
    {
        [TestMethod]
        public void CreateBoard_ReturnGuid()
        {
            var boardService = new BoardService();
            var boardId = boardService.CreateBoard();

            Assert.IsInstanceOfType(boardId, typeof(Guid));
        }
    }
}
