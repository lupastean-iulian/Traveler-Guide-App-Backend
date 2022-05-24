using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelerGuideApp.API.DTOs;
using TravelerGuideApp.Application.Commands;
using TravelerGuideApp.Application.Queries;

namespace TravelerGuideApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LocationsController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Admin/")]
        public async Task<IActionResult> CreateLocation([FromBody] LocationPutPostDto location)
        {
            var command = new CreateLocationCommand
            {
                CityId = location.CityId,
                Name = location.Name,
                Address = location.Address,
                Latitude = location.Latitude,
                Longitude = location.Longitude
            };
            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<LocationGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetLocationsQuery());
            var mappedResult = _mapper.Map<List<LocationGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{cityId}/Locations")]
        public async Task<IActionResult> GetLocationsForCity(int cityId)
        {
            var result = await _mediator.Send(new GetLocationsForCity { CityId = cityId });
            var mappedResult = _mapper.Map<List<LocationGetDto>>(result);
            if (mappedResult.Count == 0)
            {
                return NotFound();
            }

            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("{locationId}")]
        public async Task<IActionResult> GetById(int locationId)
        {
            var result = await _mediator.Send(new GetLocationByIdQuery { Id = locationId });
            var mappedResult = _mapper.Map<LocationGetDto>(result);
            if (mappedResult == null)
                return NotFound();
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("Admin/{locationId}")]
        public async Task<IActionResult> UpdateLocation(int locationId, [FromBody] LocationPutPostDto updatedLocation)
        {
            var command = new UpdateLocationCommand
            {
                Id = locationId,
                Name = updatedLocation.Name,
                Address = updatedLocation.Address,
                Latitude = updatedLocation.Latitude,
                Longitude = updatedLocation.Longitude,
                CityId = updatedLocation.CityId,
            };
            var result = await _mediator.Send(command);
            var mappedResult = _mapper.Map<LocationPutPostDto>(result);
            if (mappedResult == null)
            {
                return NotFound();
            }
            return Ok(mappedResult);
        }

        [HttpDelete]
        [Route("Admin/{locationId}")]
        public async Task<IActionResult> DeleteLocation(int locationId)
        {
            var result = await _mediator.Send(new DeleteLocationCommand { Id = locationId });
            return NoContent();
        }

    }
}
