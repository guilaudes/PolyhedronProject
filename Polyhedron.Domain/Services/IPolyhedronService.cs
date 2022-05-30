
using Polyhedron.Domain.Entities;

namespace Polyhedron.Domain.Services
{
    public interface IPolyhedronService<T> where T : RegularPolyhedron
    {
        bool IsPolyhedronCollide(T polyhedron1, T polyhedron2);
        decimal GetIntersectedVolume(T polyhedron1, T polyhedron2);
        bool IsCoordinateCollide(decimal coordMin1, decimal coordMin2, decimal coordMax1, decimal coordMax2);
    }
}
