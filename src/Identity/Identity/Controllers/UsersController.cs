using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Venu.Identity.Domain;
using Venu.Identity.Dtos;
using Venu.Identity.Helpers;
using Venu.Identity.Services;

namespace Venu.Identity.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateUserDto authenticateUserDto)
        {
            var user = _userService.Authenticate(authenticateUserDto.Username, authenticateUserDto.Password);

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
            
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = tokenString;

            return Ok(userDto);
        }
        
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterUserDto registerUserDto)
        {
            var user = _mapper.Map<User>(registerUserDto);

            try
            {
                _userService.Create(user, registerUserDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(_mapper.Map<UserInfoDto>(user));
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateUserDto updateUserDto)
        {
            var user = _mapper.Map<User>(updateUserDto);
            user.Id = id;

            try
            {
                _userService.Update(user, updateUserDto.Password);
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
            _userService.Delete(id);
            return Ok();
        }
    }
}