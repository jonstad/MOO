using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOO
{
    class Ship
    {
        public Location CurrentLocation { get; set; }
        public Location Destination { get; set; }

        public Planet HomePlanet { get; set; }
        public int Size { get; set; }
    }
}
