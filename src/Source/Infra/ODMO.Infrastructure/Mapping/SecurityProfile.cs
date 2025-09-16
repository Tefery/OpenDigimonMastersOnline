using AutoMapper;
using ODMO.Commons.Models.Chat;
using ODMO.Commons.Models.Security;
using ODMO.Commons.DTOs.Account;
using ODMO.Commons.DTOs.Chat;

namespace ODMO.Infrastructure.Mapping
{
    public class SecurityProfile : Profile
    {
        public SecurityProfile()
        {
            CreateMap<LoginTryModel, LoginTryDTO>()
                .ReverseMap();

            CreateMap<ChatMessageModel, ChatMessageDTO>()
                .ReverseMap();
        }
    }
}