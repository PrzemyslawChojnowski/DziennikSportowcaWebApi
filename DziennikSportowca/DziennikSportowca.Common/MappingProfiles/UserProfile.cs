using AutoMapper;
using DziennikSportowca.Common.Models.User;
using DziennikSportowca.Common.Models.VM.UserVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace DziennikSportowca.Common.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserVM>()
                .ReverseMap()
                .ForMember(d => d.PasswordHash, e => e.Ignore())
                .ForMember(d => d.PasswordSalt, e => e.Ignore());
        }
    }
}
