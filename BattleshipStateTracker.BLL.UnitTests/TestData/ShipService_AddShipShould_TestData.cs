using BattleshipStateTracker.BLL.Models.Requests;
using BattleshipStateTracker.Core.Enums;
using BattleshipStateTracker.DAL.Models;
using System;
using System.Collections.Generic;

namespace BattleshipStateTracker.BLL.UnitTests.TestData
{
    public class ShipService_AttackShipShould_TestData
    {
        private static readonly Guid invalidBoardId = Guid.NewGuid();
        private static readonly Guid validBoardId = Guid.NewGuid();

        public static Guid InvalidBoardId => invalidBoardId;
        public static Guid ValidBoardId => validBoardId;
        public static AttackShipRequest AttackShipRequestWithValidBoardId => new AttackShipRequest
        {
            BoardId = validBoardId,
            ShipPosition = new ShipPosition { XCoordinate = 5, YCoordinate = 5 }
        };
        public static AttackShipRequest AttackShipRequestWithInValidBoardId => new AttackShipRequest
        {
            BoardId = invalidBoardId,
            ShipPosition = new ShipPosition { XCoordinate = 5, YCoordinate = 5 }
        };
    }
}
