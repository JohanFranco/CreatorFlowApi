using AutoMapper;
using CreatorFlowApi.DTOs.Auth;
using CreatorFlowApi.Entities;
using CreatorFlowApi.Repositories.Users;
using CreatorFlowApi.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreatorFlowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("me")]
        public async Task<ActionResult<UserDto>> GetMe()
        {
            var userId = User.GetUserId();
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return NotFound();

            var dto = _mapper.Map<UserDto>(user);
            return Ok(dto);
        }
    }
}
