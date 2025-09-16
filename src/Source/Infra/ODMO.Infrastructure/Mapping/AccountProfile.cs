using AutoMapper;
using ODMO.Commons.DTOs.Account;
using ODMO.Commons.Models.Account;

namespace ODMO.Infrastructure.Mapping
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountModel, AccountDTO>()
                .ReverseMap();

            CreateMap<AccountBlockModel, AccountBlockDTO>()
                .ReverseMap();

            CreateMap<SystemInformationModel, SystemInformationDTO>()
                .ReverseMap();
        }
    }
}