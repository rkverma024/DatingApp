using API.Data;
using API.DTOs;
using API.Entities;
using API.InterfaceRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]

    public class UsersController : BaseApiController
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        //[AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>>GetUsers() 
        {
            var users = await userRepository.GetMembersAsync();            

            return Ok(users);
        }
        
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            var user =  await userRepository.GetMemberAsync(username);
            return user;
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await userRepository.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            mapper.Map(memberUpdateDto, user);

            if (await userRepository.SaveAllAsync())
            { 
                return NoContent();
            }

            return BadRequest("Failed to update user");
        }
    }
}
