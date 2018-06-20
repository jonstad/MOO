using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOO
{
    public enum PlanetType { Rocky, Gas}
    public class Planet
    {
        
        public PlanetType Type { get; set; }
        public int PlanetNumber { get; set; }
        public int IDHomeStar { get; set; }
        public Random Random { get; set; }
        public Planet(PlanetType planetType, int location)
        {
            Type = planetType;
        }
        public Planet(int location, Random random, int idhomestar)
        {
            IDHomeStar = idhomestar;
            PlanetNumber = location;
            Random = random;
        }
        public void Update() { }
    }
}
