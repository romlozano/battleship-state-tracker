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

        public bool AddShip(Guid boardId, AddShipRequest request)
        {
            ValidateShipStartPosition(request);
            ValidateShipLength(request);
            ValidateIfShipCanFit(request);

            Board board = boardRepository.GetBoard(boardId);
            if (board == null)
            {
                throw new BusinessArgumentException("Board Id is not valid", nameof(boardId));
            }

            IEnumerable<ShipPosition> shipPositions = GenerateShipPositions(request);
            ValidateIfShipWillCollideWithExistingShip(board, shipPositions);

            return boardRepository.AddShip();
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
            if (request.Direction == ShipDirectionEnum.Right)
            {
                if (shipLength < 0 || shipLength > MaxShipHorizontalLength)
                {
                    throw new BusinessArgumentException("Ship Length is not valid", nameof(shipLength));
                }
            }
            else if (request.Direction == ShipDirectionEnum.Down)
            {
                if (shipLength < 0 || shipLength > MaxShipVerticalLength)
                {
                    throw new BusinessArgumentException("Ship Length is not valid", nameof(shipLength));
                }
            }
        }

        // TODO: Refactor this method to a ShipValidatonService. The corresponding unit tests should be refactored as well.
        private void ValidateIfShipCanFit(AddShipRequest request)
        {
            if (request.Direction == ShipDirectionEnum.Right)
            {
                int maxShipXCoordinate = request.StartPosition.XCoordinate + request.ShipLength - 1;
                if (maxShipXCoordinate >= MaxShipHorizontalLength)
                {
                    throw new BusinessArgumentException("Ship will not fit on the board", "ship request");
                }
            }
            else if (request.Direction == ShipDirectionEnum.Down)
            {
                int maxShipYCoordinate = request.StartPosition.YCoordinate + request.ShipLength - 1;
                if (maxShipYCoordinate >= MaxShipVerticalLength)
                {
                    throw new BusinessArgumentException("Ship will not fit on the board", "ship request");
                }
            }
        }

        // TODO: Refactor this method to a different service and add unit tests
        private IEnumerable<ShipPosition> GenerateShipPositions(AddShipRequest request)
        {
            ICollection<ShipPosition> shipPositions = new List<ShipPosition>();
            if (request.Direction == ShipDirectionEnum.Right)
            {
                int startXCoordinate = request.StartPosition.XCoordinate;
                for (int coordinate = startXCoordinate; coordinate < startXCoordinate + request.ShipLength; coordinate++)
                {
                    shipPositions.Add(new ShipPosition { XCoordinate = coordinate, YCoordinate = request.StartPosition.YCoordinate });
                }
            }
            else if (request.Direction == ShipDirectionEnum.Down)
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
