
using Polyhedron.Domain.Entities;

namespace Polyhedron.Domain.Services
{
    public class CubeService : IPolyhedronService<Cube>
    {
        public bool IsPolyhedronCollide(Cube cube1, Cube cube2)
        {
            if (IsCoordinateCollide(cube1.Scope.MinX, cube2.Scope.MinX, cube1.Scope.MaxX, cube2.Scope.MaxX) &&
                IsCoordinateCollide(cube1.Scope.MinY, cube2.Scope.MinY, cube1.Scope.MaxY, cube2.Scope.MaxY) &&
                IsCoordinateCollide(cube1.Scope.MinZ, cube2.Scope.MinZ, cube1.Scope.MaxZ, cube2.Scope.MaxZ))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public decimal GetIntersectedVolume(Cube cube1, Cube cube2)
        {
            return (Math.Max(0, Math.Min(cube1.Scope.MaxX, cube2.Scope.MaxX) - Math.Max(cube1.Scope.MinX, cube2.Scope.MinX))) *
                    (Math.Max(0, Math.Min(cube1.Scope.MaxZ, cube2.Scope.MaxZ) - Math.Max(cube1.Scope.MinZ, cube2.Scope.MinZ))) *
                    (Math.Max(0, Math.Min(cube1.Scope.MaxY, cube2.Scope.MaxY) - Math.Max(cube1.Scope.MinY, cube2.Scope.MinY)));
        }

        public bool IsCoordinateCollide(decimal coordMin1, decimal coordMin2, decimal coordMax1, decimal coordMax2)
        {
            return (coordMin1 < coordMax2 && coordMax1 > coordMin2);
        }
    }
}
