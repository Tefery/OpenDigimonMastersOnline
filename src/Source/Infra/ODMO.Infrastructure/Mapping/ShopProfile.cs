using AutoMapper;
using ODMO.Commons.DTOs.Account;
using ODMO.Commons.DTOs.Events;
using ODMO.Commons.DTOs.Shop;
using ODMO.Commons.Models.Account;
using ODMO.Commons.Models.Mechanics;
using ODMO.Commons.Models.TamerShop;


namespace ODMO.Infrastructure.Mapping
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {

            CreateMap<ConsignedShop, ConsignedShopDTO>()
                .ReverseMap();

            CreateMap<ConsignedShopLocation, ConsignedShopLocationDTO>()
               .ReverseMap();
        }
    }
}
