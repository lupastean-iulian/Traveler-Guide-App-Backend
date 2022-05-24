using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelerGuideApp.API.DTOs;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Queries;
namespace TravelerGuideApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExperienceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserExperienceController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserExperience([FromBody] UserExperiencePutPostDto userExperience)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _mediator.Send(_mapper.Map<CreateUserExperience>(userExperience));
            var mappedResult = _mapper.Map<UserExperienceGetDto>(created);
            if (mappedResult == null)
                return BadRequest();
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("{userId}/{travelId}/{locationId}")]
        public async Task<IActionResult> UpdateUserExperience(int userId, int travelId, int locationId,
            [FromBody] UserExperiencePutPostDto updatedUserExperience)
        {
            var command = new UpdateUserExperience
            {
                UserId = userId,
                TravelItineraryId = travelId,
                LocationId = locationId,
                Priority = updatedUserExperience.Priority,
                Budget = updatedUserExperience.Budget,
                Description = updatedUserExperience.Description
            };
            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<UserExperienceGetDto>(result);
            if (mappedResult == null)
                return NotFound();
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{userId}/{travelId}/{locationId}")]
        public async Task<IActionResult> DeleteUserExperience(int userId, int travelId, int locationId)
        {
            var result = await _mediator.Send(new DeleteUserExperience
            { UserId = userId, TravelItineraryId = travelId, LocationId = locationId });
            return NoContent();
        }

        [HttpGet]
        [Route("{userId}/{travelId}/{locationId}")]
        public async Task<IActionResult> GetById(int userId, int travelId, int locationId)
        {
            var result = await _mediator.Send(new GetUserExperienceQuery
            { UserId = userId, TravelItineraryId = travelId, LocationId = locationId });
            var mappedResult = _mapper.Map<UserExperienceGetDto>(result);
            if (mappedResult == null)
            {
                return NotFound();
            }

            return Ok(mappedResult);
        }
    }
}
