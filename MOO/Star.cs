using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOO
{
    class Star
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Location Location { get; set; }
        public List<Planet> Planets { get; set; }
        public List<Astroid> Astroids { get; set; }
        public int Diameter { get; set; }
        public Color Color { get; set; }
        public String Name { get; set; }
        public Star()
        {

        }
        public Star(int x, int y , int diameter, Color color, String name, int seed)
        {
            Location.X = x;
            Location.Y = y;
            Diameter = diameter;
            Color = color;
            Name = name;
            InitPlanets( seed);
        }
        private void InitPlanets(int seed)
        {
            Planets = new List<Planet>();
            Random r = new Random(seed);
            int numberofplanets = r.Next(0, 10);
            for (int i = 1; i <= numberofplanets; i++)
            {
                Planets.Add(new Planet(i, r, Location));
            }
        }
    }
}
