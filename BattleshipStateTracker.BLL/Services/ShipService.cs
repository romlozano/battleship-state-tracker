using BattleshipStateTracker.BLL.Models.Requests;
using BattleshipStateTracker.Core.Enums;
using BattleshipStateTracker.Core.Exceptions;
using BattleshipStateTracker.DAL.Models;
using BattleshipStateTracker.DAL.Repositories;
using System.Collections.Generic;

namespace BattleshipStateTracker.BLL.Services
{
    public class ShipService : IShipService
    {
        // TODO: Refactor the following const to appSettings.json
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

            Ship ship = new Ship();
            ship.Positions = shipPositions;
            board.Ships.Add(ship);
            boardRepository.SaveBoard(board);

            return true;
        }

        public AttackShipResultEnum AttackShip(AttackShipRequest request)
        {
            ValidateShipAttackPosition(request);
            Board board = boardRepository.GetBoard(request.BoardId);
            if (board == null)
            {
                throw new BusinessArgumentException("Board Id is not valid", nameof(request.BoardId));
            }
            AttackShipResultEnum result = GetAttackResult(board, request.ShipPosition);

            boardRepository.SaveBoard(board);

            return result;
        }

        private void ValidateShipStartPosition(AddShipRequest request)
        {
            ValidateShipCoordinates(request.StartPosition.XCoordinate, request.StartPosition.YCoordinate);
        }

        // TODO: Refactor this method to a ShipValidatonService. The corresponding unit tests should be refactored as well.
        private void ValidateShipCoordinates(int shipXCoordinate, int shipYCoordinate)
        {
            if (shipXCoordinate < MinShipXCoordinate || shipXCoordinate >= MaxShipHorizontalLength)
            {
                throw new BusinessArgumentException("Ship X-Coordinate is not valid", nameof(shipXCoordinate));
            }

            if (shipYCoordinate < MinShipYCoordinate || shipYCoordinate >= MaxShipVerticalLength)
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
                if (shipLength < 1 || shipLength > MaxShipHorizontalLength)
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
        private void ValidateShipDirection(AddShipRequest request)
        {
            ShipDirectionEnum shipDirection = request.Direction;
            if (shipDirection != ShipDirectionEnum.Down && shipDirection != ShipDirectionEnum.Right)
            {
                throw new BusinessArgumentException("Ship direction is not valid", nameof(shipDirection));
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
        private ICollection<ShipPosition> GenerateShipPositions(AddShipRequest request)
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

        private void ValidateShipAttackPosition(AttackShipRequest request)
        {
            ValidateShipCoordinates(request.ShipPosition.XCoordinate, request.ShipPosition.YCoordinate);
        }

        // TODO: Refactor this method to a ShipValidatonService. The corresponding unit tests should be refactored as well.
        private AttackShipResultEnum GetAttackResult(Board board, ShipPosition attackPosition)
        {
            // TODO: Optimise this if possible
            foreach (Ship ship in board.Ships)
            {
                foreach (ShipPosition position in ship.AttackedPositions)
                {
                    if (position.XCoordinate == attackPosition.XCoordinate && position.YCoordinate == attackPosition.YCoordinate)
                    {
                        return AttackShipResultEnum.Miss;
                    }
                }

                foreach (ShipPosition position in ship.Positions)
                {
                    if (position.XCoordinate == attackPosition.XCoordinate && position.YCoordinate == attackPosition.YCoordinate)
                    {
                        ship.AttackedPositions.Add(new ShipPosition { XCoordinate = attackPosition.XCoordinate, YCoordinate = attackPosition.YCoordinate });

                        return AttackShipResultEnum.Hit;
                    }
                }
            }

            return AttackShipResultEnum.Miss;
        }
    }
}
