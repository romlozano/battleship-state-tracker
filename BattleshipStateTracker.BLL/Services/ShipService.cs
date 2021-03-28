using BattleshipStateTracker.BLL.Models.Requests;
using BattleshipStateTracker.Core.Enums;
using BattleshipStateTracker.Core.Exceptions;
using BattleshipStateTracker.DAL.Models;
using BattleshipStateTracker.DAL.Repositories;
using System;

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

            return boardRepository.AddShip();
        }

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

            if (request.Direction == ShipDirectionEnum.Down)
            {
                if (shipLength < 0 || shipLength > MaxShipVerticalLength)
                {
                    throw new BusinessArgumentException("Ship Length is not valid", nameof(shipLength));
                }
            }
        }

        private void ValidateIfShipCanFit(AddShipRequest request)
        {
            if (request.Direction == ShipDirectionEnum.Right)
            {
                var maxShipXCoordinate = request.StartPosition.XCoordinate + request.ShipLength - 1;
                if (maxShipXCoordinate >= MaxShipHorizontalLength)
                {
                    throw new BusinessArgumentException("Ship will not fit on the board", "ship request");
                }
            }

            if (request.Direction == ShipDirectionEnum.Down)
            {
                var maxShipYCoordinate = request.StartPosition.YCoordinate + request.ShipLength - 1;
                if (maxShipYCoordinate >= MaxShipVerticalLength)
                {
                    throw new BusinessArgumentException("Ship will not fit on the board", "ship request");
                }
            }
        }
    }
}
