using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOO
{
    public enum PlanetType { Rocky, Gas}
    class Planet
    {
        public List<Ship> Ships { get; set; }
        public PlanetType Type { get; set; }
        public int PlanetNumber { get; set; }
        public Location StarLocation { get; set; }
        public Random Random { get; set; }
        public Planet(PlanetType planetType, int location)
        {
            Type = planetType;
        }
        public Planet(int location, Random random, Location starlocation)
        {
            StarLocation = starlocation;
            PlanetNumber = location;
            Random = random;
            Ships = new List<Ship>();
        }
        public void Update()
        {
            if (Ships.Count == 0)
            {
                Ships.Add(new Ship() { Size = 10, CurrentLocation = StarLocation });
            }

        }
    }
}
