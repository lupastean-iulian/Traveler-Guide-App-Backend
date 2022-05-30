using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelerGuideApp.API.DTOs;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Interfaces;
using TravelerGuideApp.Application.Queries;
using TravelerGuideApp.Domain.Entities;

namespace TravelerGuideApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IMediator mediator, ITokenService tokenService)
        {
            _mediator = mediator;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser([FromBody] UserPutPostDto user)
        {
            var created = await _mediator.Send(_mapper.Map<CreateUserCommand>(user));

            var mappedResult = _mapper.Map<UserGetDto>(created);
            return Ok(mappedResult);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserAuthDto>> LoginUser([FromBody] UserLoginDto userLogin)
        {

            var user = await _mediator.Send(new GetUserByEmailQuery { Email = userLogin.Email });
            var result = await _mediator.Send(new GetUserByEmailQuery { Email = user.Email });
            if (result == null)
                return BadRequest("Email Is Wrong");
            if (user.Password != result.Password)
                return BadRequest("Password Is Wrong");

            return new UserAuthDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetUsersQuery());
            var mappedResult = _mapper.Map<List<UserGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var result = await _mediator.Send(new GetUserByIdQuery { Id = userId });
            var mappedResult = _mapper.Map<UserGetDto>(result);
            if (mappedResult == null)
                return NotFound();
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UserPutPostDto updatedUser)
        {
            var command = new UpdateUserCommand
            {
                Id = userId,
                FirstName = updatedUser.FirstName,
                LastName = updatedUser.LastName,
                Email = updatedUser.Email,
                Password = updatedUser.Password,
                UserType = updatedUser.UserType
            };
            var result = await _mediator.Send(command);
            var mappedUser = _mapper.Map<UserGetDto>(result);
            if (mappedUser == null)
                return NotFound();
            return Ok(mappedUser);
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await _mediator.Send(new DeleteUserCommand { Id = userId });
            return NoContent();
        }


    }
}
