

namespace Polyhedron.Domain.Entities
{
    public class Scope
    {
        public decimal MinX { get; set; }
        public decimal MaxX { get; set; }
        public decimal MinY { get; set; }
        public decimal MaxY { get; set; }
        public decimal MinZ { get; set; }
        public decimal MaxZ { get; set; }

        public Scope(RegularPolyhedron polyhedron)
        {
            MinX = getMinScope(polyhedron.XCoord, polyhedron.Size);
            MinY = getMinScope(polyhedron.YCoord, polyhedron.Size);
            MinZ = getMinScope(polyhedron.ZCoord, polyhedron.Size);

            MaxX = getMaxScope(polyhedron.XCoord, polyhedron.Size);
            MaxY = getMaxScope(polyhedron.YCoord, polyhedron.Size);
            MaxZ = getMaxScope(polyhedron.ZCoord, polyhedron.Size);

        }

        public decimal getMaxScope(int coordinate, int size)
        {
            return coordinate + ((decimal)size / 2);
        }

        public decimal getMinScope(int coordinate, int size)
        {
            return coordinate - ((decimal)size / 2);
        }



    }
}
