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
    public class TravelItineraryLocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TravelItineraryLocationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("{travelItineraryId}/locations/{locationId}")]
        public async Task<IActionResult> AddLocationToTravelItinerary(int travelItineraryId, int locationId)
        {
            var command = new AddLocationsToTravelItinerary
            {
                TravelItineraryId = travelItineraryId,
                LocationId = locationId
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("{travelItineraryId}/locations")]
        public async Task<IActionResult> GetLocationsForTravelItinerary(int travelItineraryId)
        {
            var result = await _mediator.Send(new GetLocationsForTravelItineraryQuery { travelItineraryId = travelItineraryId });
            var mappedResult = _mapper.Map<List<LocationGetDto>>(result);
            if (mappedResult.Count == 0)
            {
                return NotFound();
            }
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{locationId}/travelItineraries")]
        public async Task<IActionResult> GetTravelItinerariesForLocation(int locationId)
        {
            var result = await _mediator.Send(new GetTravelItinerariesForLocationQuery { locationId = locationId });
            var mappedResult = _mapper.Map<List<TravelItineraryGetDto>>(result);
            if (mappedResult.Count == 0)
            {
                return NotFound();
            }
            return Ok(mappedResult);
        }
        [HttpDelete]
        [Route("{travelItineraryId}/locations/{locationId}")]
        public async Task<IActionResult> RemoveLocationFromTravelItinerary(int travelItineraryId, int locationId)
        {
            var command = new RemoveLocationFromTravelitinerary
            {
                travelItineraryId = travelItineraryId,
                LocationId = locationId
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
