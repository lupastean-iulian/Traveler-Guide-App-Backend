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
    public class TravelItineraryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TravelItineraryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTravelItinerary([FromBody] TravelItineraryPutPostDto travelItinerary)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _mediator.Send(_mapper.Map<CreateTravelItineraryCommand>(travelItinerary));
            var mappedResult = _mapper.Map<TravelItineraryGetDto>(created);
            if (mappedResult == null)
                return Conflict();
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetAllForUser(int userId)
        {
            var result = await _mediator.Send(new GetTravelItinerariesQuery { UserId = userId });

            var mappedResult = _mapper.Map<List<TravelItineraryGetDto>>(result);
            if (mappedResult.Count == 0)
                return NotFound();
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("Admin/{travelItineraryId}")]
        public async Task<IActionResult> GetById(int travelItineraryId)
        {
            var result = await _mediator.Send(new GetTravelItineraryByIdQuery { Id = travelItineraryId });
            var mappedResult = _mapper.Map<TravelItineraryGetDto>(result);
            if (mappedResult == null)
                return NotFound();
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("{travelItineraryId}")]
        public async Task<IActionResult> UpdateTravelItinerary(int travelItineraryId,
            [FromBody] TravelItineraryPutPostDto updatedTravelItinerary)
        {
            var command = new UpdateTravelItineraryCommand
            {
                Id = travelItineraryId,
                Name = updatedTravelItinerary.Name,
                Status = updatedTravelItinerary.Status,
                TravelDate = updatedTravelItinerary.TravelDate.ToLocalTime(),

            };
            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<TravelItineraryGetDto>(result);
            if (mappedResult == null)
                return NotFound();
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("{travelItineraryId}")]
        public async Task<IActionResult> DeleteTravelItinerary(int travelItineraryId)
        {
            var result = await _mediator.Send(new DeleteTravelItineraryCommand { Id = travelItineraryId });
            return NoContent();
        }
    }

}
