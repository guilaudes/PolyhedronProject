
using Polyhedron.Api.Dto;
using Polyhedron.Domain.Entities;
using Polyhedron.Domain.Services;

namespace Polyhedron.Api.Services
{
    public class CubeApiService
    {
        private readonly CubeService _cubeService;
        public CubeApiService(CubeService cubeService)
        {
            _cubeService = cubeService;
        }
        private static Cube GetCube(ShapeDto data)
        {
            return new Cube(
                data.Coordinate.X,
                data.Coordinate.Y,
                data.Coordinate.Z,
                data.Size);
        }

        public IntersectionInfoResponseDto GetIntersectionInfo(IntersectionInfoRequestDto data)
        {
            IntersectionInfoResponseDto result = new();

            Cube cube1 = GetCube(data.Cube1Params);
            Cube cube2 = GetCube(data.Cube2Params);

            result.IsCollide = _cubeService.IsCubesCollide(cube1, cube2);
            result.IntersectedVolume = _cubeService.GetIntersectedVolume(cube1, cube2);

            return result;
        }
    }
}
