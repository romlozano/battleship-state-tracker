using BattleshipStateTracker.BLL.Models.Requests;
using BattleshipStateTracker.Core.Enums;
using BattleshipStateTracker.Core.Exceptions;
using BattleshipStateTracker.DAL.Models;
using BattleshipStateTracker.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace BattleshipStateTracker.BLL.Services
{
    public class ShipService : IShipService
    {
        private const int MinShipXCoordinate = 0;
        private const int MinShipYCoordinate = 0;
        private const int MaxShipHorizontalLength = 10;
        private const int MaxShipVerticalLength = 10;
        private readonly IBoardRepository boardRepository;

        public ShipService(IBoardRepository boardRepository)
        {
            this.boardRepository = boardRepository;
        }

        public bool AddShip(AddShipRequest request)
        {
            ValidateShipStartPosition(request);
            ValidateShipLength(request);
            ValidateShipDirection(request);
            ValidateIfShipCanFit(request);

            Board board = boardRepository.GetBoard(request.BoardId);
            if (board == null)
            {
                throw new BusinessArgumentException("Board Id is not valid", nameof(request.BoardId));
            }

            ICollection<ShipPosition> shipPositions = GenerateShipPositions(request);
            ValidateIfShipWillCollideWithExistingShip(board, shipPositions);

            return boardRepository.AddShip(board, shipPositions);
        }

        // TODO: Refactor this method to a ShipValidatonService. The corresponding unit tests should be refactored as well.
        private void ValidateShipStartPosition(AddShipRequest request)
        {
            int shipXCoordinate = request.StartPosition.XCoordinate;
            if (shipXCoordinate < MinShipXCoordinate || shipXCoordinate > MaxShipHorizontalLength)
            {
                throw new BusinessArgumentException("Ship X-Coordinate is not valid", nameof(shipXCoordinate));
            }

            int shipYCoordinate = request.StartPosition.YCoordinate;
            if (shipYCoordinate < MinShipYCoordinate || shipYCoordinate > MaxShipHorizontalLength)
            {
                throw new BusinessArgumentException("Ship Y-Coordinate is not valid", nameof(shipYCoordinate));
            }
        }

        // TODO: Refactor this method to a ShipValidatonService. The corresponding unit tests should be refactored as well.
        private void ValidateShipLength(AddShipRequest request)
        {
            int shipLength = request.ShipLength;
            // TODO: Refactor and optimise enum comparison
            if (request.Direction == ShipDirectionEnum.Right.ToString().ToLower())
            {
                if (shipLength < 1 || shipLength > MaxShipHorizontalLength)
                {
                    throw new BusinessArgumentException("Ship Length is not valid", nameof(shipLength));
                }
            }
            // TODO: Refactor and optimise enum comparison
            else if (request.Direction == ShipDirectionEnum.Down.ToString().ToLower())
            {
                if (shipLength < 0 || shipLength > MaxShipVerticalLength)
                {
                    throw new BusinessArgumentException("Ship Length is not valid", nameof(shipLength));
                }
            }
        }

        // TODO: Refactor this method to a ShipValidatonService. The corresponding unit tests should be refactored as well.
        private void ValidateShipDirection(AddShipRequest request)
        {
            // TODO: Refactor and optimise enum comparison
            string shipDirection = request.Direction;
            if (shipDirection != ShipDirectionEnum.Down.ToString().ToLower() && shipDirection != ShipDirectionEnum.Right.ToString().ToLower())
            {
                throw new BusinessArgumentException("Ship direction is not valid", nameof(shipDirection));
            }
        }

        // TODO: Refactor this method to a ShipValidatonService. The corresponding unit tests should be refactored as well.
        private void ValidateIfShipCanFit(AddShipRequest request)
        {
            // TODO: Refactor and optimise enum comparison
            if (request.Direction == ShipDirectionEnum.Right.ToString().ToLower())
            {
                int maxShipXCoordinate = request.StartPosition.XCoordinate + request.ShipLength - 1;
                if (maxShipXCoordinate >= MaxShipHorizontalLength)
                {
                    throw new BusinessArgumentException("Ship will not fit on the board", "ship request");
                }
            }
            // TODO: Refactor and optimise enum comparison
            else if (request.Direction == ShipDirectionEnum.Down.ToString().ToLower())
            {
                int maxShipYCoordinate = request.StartPosition.YCoordinate + request.ShipLength - 1;
                if (maxShipYCoordinate >= MaxShipVerticalLength)
                {
                    throw new BusinessArgumentException("Ship will not fit on the board", "ship request");
                }
            }
        }

        // TODO: Refactor this method to a different service and add unit tests
        private ICollection<ShipPosition> GenerateShipPositions(AddShipRequest request)
        {
            ICollection<ShipPosition> shipPositions = new List<ShipPosition>();
            if (request.Direction == ShipDirectionEnum.Right.ToString().ToLower())
            {
                int startXCoordinate = request.StartPosition.XCoordinate;
                for (int coordinate = startXCoordinate; coordinate < startXCoordinate + request.ShipLength; coordinate++)
                {
                    shipPositions.Add(new ShipPosition { XCoordinate = coordinate, YCoordinate = request.StartPosition.YCoordinate });
                }
            }
            else if (request.Direction == ShipDirectionEnum.Down.ToString().ToLower())
            {
                int startYCoordinate = request.StartPosition.YCoordinate;
                for (int coordinate = startYCoordinate; coordinate < startYCoordinate + request.ShipLength; coordinate++)
                {
                    shipPositions.Add(new ShipPosition { XCoordinate = request.StartPosition.XCoordinate, YCoordinate = coordinate });
                }
            }

            return shipPositions;
        }

        // TODO: Refactor this method to a ShipValidatonService. The corresponding unit tests should be refactored as well.
        private void ValidateIfShipWillCollideWithExistingShip(Board board, IEnumerable<ShipPosition> shipPositions)
        {
            // TODO: Optimise this if possible
            foreach (Ship ship in board.Ships)
            {
                foreach (ShipPosition existingShipPosition in ship.Positions)
                {
                    foreach (ShipPosition shipPosition in shipPositions)
                    {
                        if (shipPosition.XCoordinate == existingShipPosition.XCoordinate && shipPosition.YCoordinate == existingShipPosition.YCoordinate)
                        {
                            throw new ShipCollisionException();
                        }
                    }
                }
            }
        }
    }
}
