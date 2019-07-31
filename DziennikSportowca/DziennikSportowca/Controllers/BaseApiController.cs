using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace DziennikSportowca.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected readonly IMapper _mapper;

        public BaseApiController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("ping")]
        public IActionResult Index()
        {
            return Ok("Pong");
        }
    }
}