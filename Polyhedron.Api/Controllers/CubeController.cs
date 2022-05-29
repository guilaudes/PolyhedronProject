using Polyhedron.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using Polyhedron.Api.Services;

namespace Polyhedron.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CubeController : ControllerBase
    {
        private readonly CubeApiService _service;
        public CubeController(CubeApiService service)
        {
            _service = service;
        }

        [HttpPost("GetIntersectionInfo")]
        public IntersectionInfoResponseDto GetIntersectionInfo([FromBody] IntersectionInfoRequestDto data)
        {
            return _service.GetIntersectionInfo(data);
        }
    }
}