using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyhedron.Domain.Entities
{
    public class Cube : RegularPolyhedron
    {
        public Cube (int x, int y, int z, int size)
        {
            XCoord = x;
            YCoord = y;
            ZCoord = z;
            Size = size;
            Scope = new Scope(this);
        }

       

    }
}
