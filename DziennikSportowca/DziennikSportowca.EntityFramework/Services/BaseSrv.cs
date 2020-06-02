using AutoMapper;
using DziennikSportowca.Infrastructure.EntityFramework.Data;

namespace DziennikSportowca.Infrastructure.EntityFramework.Services
{
    public class BaseSrv
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly IMapper _mapper;

        public BaseSrv(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}