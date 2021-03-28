using BattleshipStateTracker.BLL.Models.Requests;
using BattleshipStateTracker.Core.Enums;
using BattleshipStateTracker.DAL.Models;
using System;
using System.Collections.Generic;

namespace BattleshipStateTracker.BLL.UnitTests.TestData
{
    public class ShipService_AddShipShould_TestData
    {
        private static readonly Guid invalidBoardId = Guid.NewGuid();
        private static readonly Guid validBoardId = Guid.NewGuid();

        public static Guid InvalidBoardId => invalidBoardId;
        public static Guid ValidBoardId => validBoardId;
        public static AddShipRequest ValidAddShipRequest => new AddShipRequest
        {
            StartPosition = new ShipPosition { XCoordinate = 5, YCoordinate = 5 },
            ShipLength = 5,
            Direction = ShipDirectionEnum.Right
        };
        public static AddShipRequest AddShipRequestWithShipCollision => new AddShipRequest
        {
            StartPosition = new ShipPosition { XCoordinate = 3, YCoordinate = 5 },
            ShipLength = 3,
            Direction = ShipDirectionEnum.Right
        };
        public static IEnumerable<object[]> GetInvalidAddShipRequestData()
        {
            yield return new object[] { AddShipRequestXCoordinateIsInvalid };
            yield return new object[] { AddShipRequestYCoordinateIsInvalid };
            yield return new object[] { AddShipRequestXCoordinateExceedsLimit };
            yield return new object[] { AddShipRequestYCoordinateExceedsLimit };
            yield return new object[] { AddShipRequestLengthIsInvalid };
            yield return new object[] { AddShipRequestLengthExceedsLimit };
            yield return new object[] { AddShipRequestShipExceedsXDimension };
            yield return new object[] { AddShipRequestShipExceedsYDimension };
        }

        private static AddShipRequest AddShipRequestXCoordinateIsInvalid => new AddShipRequest
        {
            StartPosition = new ShipPosition { XCoordinate = -1, YCoordinate = 0 },
            ShipLength = 10,
            Direction = ShipDirectionEnum.Right
        };

        private static AddShipRequest AddShipRequestYCoordinateIsInvalid => new AddShipRequest
        {
            StartPosition = new ShipPosition { XCoordinate = 0, YCoordinate = -1 },
            ShipLength = 10,
            Direction = ShipDirectionEnum.Down
        };

        private static AddShipRequest AddShipRequestXCoordinateExceedsLimit => new AddShipRequest
        {
            StartPosition = new ShipPosition { XCoordinate = 10, YCoordinate = 0 },
            ShipLength = 10,
            Direction = ShipDirectionEnum.Right
        };

        private static AddShipRequest AddShipRequestYCoordinateExceedsLimit => new AddShipRequest
        {
            StartPosition = new ShipPosition { XCoordinate = 0, YCoordinate = 10 },
            ShipLength = 10,
            Direction = ShipDirectionEnum.Down
        };

        private static AddShipRequest AddShipRequestLengthIsInvalid => new AddShipRequest
        {
            StartPosition = new ShipPosition { XCoordinate = 0, YCoordinate = 0 },
            ShipLength = -1,
            Direction = ShipDirectionEnum.Right
        };

        private static AddShipRequest AddShipRequestLengthExceedsLimit => new AddShipRequest
        {
            StartPosition = new ShipPosition { XCoordinate = 0, YCoordinate = 0 },
            ShipLength = 11,
            Direction = ShipDirectionEnum.Right
        };

        private static AddShipRequest AddShipRequestShipExceedsXDimension => new AddShipRequest
        {
            StartPosition = new ShipPosition { XCoordinate = 5, YCoordinate = 0 },
            ShipLength = 6,
            Direction = ShipDirectionEnum.Right
        };

        private static AddShipRequest AddShipRequestShipExceedsYDimension => new AddShipRequest
        {
            StartPosition = new ShipPosition { XCoordinate = 0, YCoordinate = 5 },
            ShipLength = 6,
            Direction = ShipDirectionEnum.Down
        };
    }
}
