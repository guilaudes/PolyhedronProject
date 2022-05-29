using Polyhedron.Api.Dto;
using Polyhedron.Api.Services;
using Polyhedron.Domain.Services;

namespace Polyhedron.Test
{
    public class CubeApiServiceTest
    {
        [Theory]
        [MemberData(nameof(DataGetIntersectionInfo))]
        public void GetIntersectionInfoTheoryMemberData(IntersectionInfoRequestDto data, IntersectionInfoResponseDto expected)
        {
            CubeService cubeService = new();
            CubeApiService cubeApiService = new(cubeService);

            var result = cubeApiService.GetIntersectionInfo(data);

            Assert.Equal(expected.IntersectedVolume, result.IntersectedVolume);
            Assert.Equal(expected.IsCollide, result.IsCollide);
        }

        public static IEnumerable<object[]> DataGetIntersectionInfo =>
        new List<object[]>
        {
            new object[] {
                new IntersectionInfoRequestDto {
                    Cube1Params = new ShapeDto { Size = 2, Coordinate = new CoordinateDto { X = 2, Y = 2, Z = 2 } },
                    Cube2Params = new ShapeDto { Size = 1, Coordinate = new CoordinateDto { X = 1, Y = 1, Z = 3 } },
                },
                new IntersectionInfoResponseDto { IsCollide = true, IntersectedVolume = Convert.ToDecimal(0.125) }
            },
            new object[] {
                new IntersectionInfoRequestDto {
                    Cube1Params = new ShapeDto { Size = 4, Coordinate = new CoordinateDto { X = 2, Y = 2, Z = 2 } },
                    Cube2Params = new ShapeDto { Size = 2, Coordinate = new CoordinateDto { X = 1, Y = 1, Z = 3 } },
                },
                new IntersectionInfoResponseDto { IsCollide = true, IntersectedVolume = 8 }
            },
            new object[] {
                new IntersectionInfoRequestDto {
                    Cube1Params = new ShapeDto { Size = 2, Coordinate = new CoordinateDto { X = 0, Y = 0, Z = 0 } },
                    Cube2Params = new ShapeDto { Size = 2, Coordinate = new CoordinateDto { X = 0, Y = 0, Z = 0 } },
                },
                new IntersectionInfoResponseDto { IsCollide = true, IntersectedVolume = 8 }
            },
            new object[] {
                new IntersectionInfoRequestDto {
                    Cube1Params = new ShapeDto { Size = 2, Coordinate = new CoordinateDto { X = 3, Y = 0, Z = 0 } },
                    Cube2Params = new ShapeDto { Size = 2, Coordinate = new CoordinateDto { X = 0, Y = 0, Z = 0 } },
                },
                new IntersectionInfoResponseDto { IsCollide = false, IntersectedVolume = 0 }
            },
        };

       
    }
}