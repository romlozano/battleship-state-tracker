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
        public static AttackShipRequest AttackShipRequestWithHitCapability => new AttackShipRequest
        {
            BoardId = validBoardId,
            ShipPosition = new ShipPosition { XCoordinate = 6, YCoordinate = 5 }
        };
        public static Board BoardWithExistingShip => new Board
        {
            Id = validBoardId,
            Ships = new List<Ship> {
                new Ship
                {
                    Positions = new List<ShipPosition>
                    {
                        new ShipPosition { XCoordinate = 5, YCoordinate = 5},
                        new ShipPosition { XCoordinate = 6, YCoordinate = 5},
                        new ShipPosition { XCoordinate = 7, YCoordinate = 5},
                    }
                }
            }
        };
        public static Board BoardWithExistingShipHavingAttackedPosition => new Board
        {
            Id = validBoardId,
            Ships = new List<Ship> {
                new Ship
                {
                    Positions = new List<ShipPosition>
                    {
                        new ShipPosition { XCoordinate = 5, YCoordinate = 5},
                        new ShipPosition { XCoordinate = 6, YCoordinate = 5},
                        new ShipPosition { XCoordinate = 7, YCoordinate = 5},
                    },
                    AttackedPositions = new List<ShipPosition>
                    {
                        new ShipPosition { XCoordinate = 6, YCoordinate = 5},
                    }
                }
            }
        };
        public static IEnumerable<object[]> GetInvalidAttackShipRequestData()
        {
            yield return new object[] { AttackShipRequestXCoordinateIsInvalid };
            yield return new object[] { AttackShipRequestYCoordinateIsInvalid };
            yield return new object[] { AttackShipRequestXCoordinateExceedsLimit };
            yield return new object[] { AttackShipRequestYCoordinateExceedsLimit };
        }
        private static AttackShipRequest AttackShipRequestXCoordinateIsInvalid => new AttackShipRequest
        {
            BoardId = validBoardId,
            ShipPosition = new ShipPosition { XCoordinate = -1, YCoordinate = 0 }
        };
        private static AttackShipRequest AttackShipRequestYCoordinateIsInvalid => new AttackShipRequest
        {
            BoardId = validBoardId,
            ShipPosition = new ShipPosition { XCoordinate = 0, YCoordinate = -1 }
        };
        private static AttackShipRequest AttackShipRequestXCoordinateExceedsLimit => new AttackShipRequest
        {
            BoardId = validBoardId,
            ShipPosition = new ShipPosition { XCoordinate = 10, YCoordinate = 0 }
        };
        private static AttackShipRequest AttackShipRequestYCoordinateExceedsLimit => new AttackShipRequest
        {
            BoardId = validBoardId,
            ShipPosition = new ShipPosition { XCoordinate = 0, YCoordinate = 10 }
        };
    }
}
