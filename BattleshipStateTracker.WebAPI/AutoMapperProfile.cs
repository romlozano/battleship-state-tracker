using AutoMapper;
using BattleshipStateTracker.WebAPI.Models;
using BattleshipStateTracker.WebAPI.Models.Requests;
using BLLModels = BattleshipStateTracker.BLL.Models;
using BLLModelRequests = BattleshipStateTracker.BLL.Models.Requests;

namespace BattleshipStateTracker.WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddShipRequest, BLLModelRequests.AddShipRequest>()
                .ForMember(dest => dest.BoardId, opt => opt.MapFrom(src => src.BoardId))
                .ForMember(dest => dest.Direction, opt => opt.MapFrom(src => src.Direction))
                .ForMember(dest => dest.ShipLength, opt => opt.MapFrom(src => src.ShipLength))
                .ForMember(dest => dest.StartPosition, opt => opt.MapFrom(src => src.StartPosition));

            CreateMap<ShipPosition, BLLModels.ShipPosition>()
                .ForMember(dest => dest.XCoordinate, opt => opt.MapFrom(src => src.XCoordinate))
                .ForMember(dest => dest.YCoordinate, opt => opt.MapFrom(src => src.YCoordinate));

            CreateMap<AttackShipRequest, BLLModelRequests.AttackShipRequest>()
                .ForMember(dest => dest.BoardId, opt => opt.MapFrom(src => src.BoardId))
                .ForMember(dest => dest.ShipPosition, opt => opt.MapFrom(src => src.ShipPosition));
        }
    }
}
