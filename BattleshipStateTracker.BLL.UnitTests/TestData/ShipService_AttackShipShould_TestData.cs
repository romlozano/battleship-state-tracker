using BattleshipStateTracker.BLL.Models;
using BattleshipStateTracker.BLL.Models.Requests;
using System;
using System.Collections.Generic;
using DALModels = BattleshipStateTracker.DAL.Models;

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
        public static AttackShipRequest AttackShipRequestWithMissCapability => new AttackShipRequest
        {
            BoardId = validBoardId,
            ShipPosition = new ShipPosition { XCoordinate = 5, YCoordinate = 6 }
        };
        public static DALModels.Board BoardWithExistingShip => new DALModels.Board
        {
            Id = validBoardId,
            Ships = new List<DALModels.Ship> {
                new DALModels.Ship
                {
                    Positions = new List<DALModels.ShipPosition>
                    {
                        new DALModels.ShipPosition { XCoordinate = 5, YCoordinate = 5},
                        new DALModels.ShipPosition { XCoordinate = 6, YCoordinate = 5},
                        new DALModels.ShipPosition { XCoordinate = 7, YCoordinate = 5},
                    }
                }
            }
        };
        public static DALModels.Board BoardWithExistingShipHavingAttackedPosition => new DALModels.Board
        {
            Id = validBoardId,
            Ships = new List<DALModels.Ship> {
                new DALModels.Ship
                {
                    Positions = new List<DALModels.ShipPosition>
                    {
                        new DALModels.ShipPosition { XCoordinate = 5, YCoordinate = 5},
                        new DALModels.ShipPosition { XCoordinate = 6, YCoordinate = 5},
                        new DALModels.ShipPosition { XCoordinate = 7, YCoordinate = 5},
                    },
                    AttackedPositions = new List<DALModels.ShipPosition>
                    {
                        new DALModels.ShipPosition { XCoordinate = 6, YCoordinate = 5},
                    }
                }
            }
        };
        public static DALModels.Board BoardWithExistingShipThatIsAlmostSunk => new DALModels.Board
        {
            Id = validBoardId,
            Ships = new List<DALModels.Ship> {
                new DALModels.Ship
                {
                    Positions = new List<DALModels.ShipPosition>
                    {
                        new DALModels.ShipPosition { XCoordinate = 5, YCoordinate = 5},
                        new DALModels.ShipPosition { XCoordinate = 6, YCoordinate = 5},
                        new DALModels.ShipPosition { XCoordinate = 7, YCoordinate = 5},
                    },
                    AttackedPositions = new List<DALModels.ShipPosition>
                    {
                        new DALModels.ShipPosition { XCoordinate = 5, YCoordinate = 5},
                        new DALModels.ShipPosition { XCoordinate = 7, YCoordinate = 5},
                    }
                },
                new DALModels.Ship
                {
                    Positions = new List<DALModels.ShipPosition>
                    {
                        new DALModels.ShipPosition { XCoordinate = 0, YCoordinate = 0},
                        new DALModels.ShipPosition { XCoordinate = 0, YCoordinate = 1},
                        new DALModels.ShipPosition { XCoordinate = 0, YCoordinate = 2},
                    }
                }
            }
        };
        public static DALModels.Board BoardWithOnlyOneShipThatIsAlmostSunk => new DALModels.Board
        {
            Id = validBoardId,
            Ships = new List<DALModels.Ship> {
                new DALModels.Ship
                {
                    Positions = new List<DALModels.ShipPosition>
                    {
                        new DALModels.ShipPosition { XCoordinate = 5, YCoordinate = 5},
                        new DALModels.ShipPosition { XCoordinate = 6, YCoordinate = 5},
                        new DALModels.ShipPosition { XCoordinate = 7, YCoordinate = 5},
                    },
                    AttackedPositions = new List<DALModels.ShipPosition>
                    {
                        new DALModels.ShipPosition { XCoordinate = 5, YCoordinate = 5},
                        new DALModels.ShipPosition { XCoordinate = 7, YCoordinate = 5},
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
