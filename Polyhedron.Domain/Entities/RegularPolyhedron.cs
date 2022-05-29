using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyhedron.Domain.Entities
{
    public class RegularPolyhedron
    {
        public int Size { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public int ZCoord { get; set; }
        public Scope Scope { get; set; }
    }
}
