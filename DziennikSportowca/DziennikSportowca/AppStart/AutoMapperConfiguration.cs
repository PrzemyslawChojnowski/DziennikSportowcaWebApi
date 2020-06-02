using AutoMapper;
using DziennikSportowca.Common.MappingProfiles;
using DziennikSportowca.Infrastructure.EntityFramework.Data.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikSportowca.AppStart
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureMappings(IMapperConfigurationExpression cfg)
        {
            #region Domain profiles

            cfg.AddProfile<UserProfile>();

            #endregion Domain profiles

            #region EF profiles

            cfg.AddProfile<UserMappingProfile>();

            #endregion EF profiles
        }
    }
}
