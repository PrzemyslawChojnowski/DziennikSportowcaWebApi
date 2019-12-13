using AutoMapper;
using DziennikSportowca.Common.Models.User;
using DziennikSportowca.EntityFramework.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DziennikSportowca.EntityFramework.Data.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<tUser, User>()
                .ReverseMap();
        }
    }
}
