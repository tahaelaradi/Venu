using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Venu.Identity.Domain;
using Venu.Identity.Dtos;
using Venu.Identity.Entities;
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

        public UsersController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateUserDto authenticateUserDto)
        {
            var token = _userService.Authenticate(authenticateUserDto.Username, authenticateUserDto.Password);

            if (token == null)
                return BadRequest(new {message = "Username of password incorrect"});

            return Ok(new {Token = token});
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
        
        [AllowAnonymous]
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
        
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}