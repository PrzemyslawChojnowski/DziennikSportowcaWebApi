using AutoMapper;
using DziennikSportowca.EntityFramework.Data;

namespace DziennikSportowca.EntityFramework.Services
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