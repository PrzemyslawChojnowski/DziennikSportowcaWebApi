using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DziennikSportowca.Common.Exceptions;
using DziennikSportowca.Common.Models.Settings;
using DziennikSportowca.Common.Models.User;
using DziennikSportowca.Common.Models.VM.UserVM;
using DziennikSportowca.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DziennikSportowca.Controllers.Api
{
    [Authorize]
    [ApiController]
    [Route("api/account")]
    public class AccountController : BaseApiController
    {
        private readonly AppSettings _appSettings;
        private readonly IUserSrv _userSrv;

        public AccountController(
            IUserSrv userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings): base(mapper)
        {
            _appSettings = appSettings.Value;
            _userSrv = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserVM userVm)
        {
            var user = _userSrv.Authenticate(userVm.Username, userVm.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserVM userVm)
        {
            var user = _mapper.Map<User>(userVm);

            try
            {
                _userSrv.Create(user, userVm.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userSrv.GetAll();
            var userDtos = _mapper.Map<IList<UserVM>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userSrv.GetById(id);
            var userDto = _mapper.Map<UserVM>(user);
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UserVM userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id = id;

            try
            {
                _userSrv.Update(user, userDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userSrv.Delete(id);
            return Ok();
        }
    }
}