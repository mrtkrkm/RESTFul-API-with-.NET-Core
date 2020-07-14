using AutoMapper;
using MG.Core.Dtos.Concrete;
using MG.Core.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ask2Friends.BLL.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
            CreateMap<UserDto, User>();
        }
    }
}
