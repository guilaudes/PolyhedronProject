using Polyhedron.Domain.Entities;
using Polyhedron.Domain.Services;

namespace Polyhedron.Test.Domain.Services
{
    public class CubeServiceTest
    {
        [Theory]
        [MemberData(nameof(DataIsCoordinateCollide))]
        public void IsCoordinateCollideTheoryMemberData(decimal coordMin1, decimal coordMin2, decimal coordMax1, decimal coordMax2, bool expected)
        {
            CubeService cubeService = new();

            var result = cubeService.IsCoordinateCollide(coordMin1, coordMin2, coordMax1, coordMax2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(DataIsCubesCollide))]
        public void IsCubesCollideTheoryMemberData(Cube cube1, Cube cube2, bool expected)
        {
            CubeService cubeService = new();

            var result = cubeService.IsCubesCollide(cube1, cube2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(DataGetIntersectedVolume))]
        public void GetIntersectedVolumeTheoryMemberData(Cube cube1, Cube cube2, decimal expected)
        {
            CubeService cubeService = new();

            var result = cubeService.GetIntersectedVolume(cube1, cube2);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> DataIsCoordinateCollide =>
        new List<object[]>
        {
            new object[] { 1, 5, 6, 6, true },
            new object[] { 1, 5, 4, 6, false },
            new object[] { 6, 12, 13, 15, true },
            new object[] { 12, 6, 14, 15, true },
            new object[] { 12, 6, 14, 13, true },
            new object[] { 12, 14, 14, 15, false }
        };


        public static IEnumerable<object[]> DataGetIntersectedVolume =>
        new List<object[]>
        {
            new object[] { new Cube(2,2,2,2), new Cube(1,1,3,1), 0.125 },
            new object[] { new Cube(2,2,2,4), new Cube(1,1,3,2), 8 },
            new object[] { new Cube(0,0,0,2), new Cube(0,0,0,2), 8 },
            new object[] { new Cube(3,0,0,2), new Cube(0,0,0,2), 0 }
        };

        public static IEnumerable<object[]> DataIsCubesCollide =>
        new List<object[]>
        {
            new object[] { new Cube(2,2,2,2), new Cube(1,1,3,0), false },
            new object[] { new Cube(2,2,2,4), new Cube(1,1,3,0), true },
            new object[] { new Cube(0,0,0,2), new Cube(0,0,0,2), true },
            new object[] { new Cube(3,0,0,2), new Cube(0,0,0,2), false }
        };
    }
}