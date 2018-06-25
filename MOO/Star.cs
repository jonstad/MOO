using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOO
{
    public class Star
    {
        public Location Location { get; set; }
        public List<Planet> Planets { get; set; }
        public List<Astroid> Astroids { get; set; }
        public ResourceDistribution ResourceDistribution { get; set; }
        public int Diameter { get; set; }
        public Color Color { get; set; }
        public String Name { get; set; }
        public int ID { get; set; }
        public int TotalIndustry { get; set; }
        public int TotalCommercial { get; set; }
        //public int Ecology { get; set; }
        //public int Technology { get; set; }

        public Star()
        {
            TotalIndustry = 1;
            TotalCommercial = 1;
            //Ecology = 1;
            //Technology = 1;
            ResourceDistribution = new ResourceDistribution();
        }
        public Star(int x, int y , int diameter, Color color, String name, int seed,int id): this()
        {
            ID = id;
            Location = new Location(x, y);
            Diameter = diameter;
            Color = color;
            Name = name;
            InitPlanets(seed);
        }
        private void InitPlanets(int seed)
        {
            Planets = new List<Planet>();
            Random r = new Random(seed);
            int numberofplanets = r.Next(1, 10);
            for (int i = 1; i <= numberofplanets; i++)
            {
                Planets.Add(new Planet(i, r, ID));
            }
        }
        public void UpdateStar()
        {
            foreach (var planet in Planets)
            {
                planet.Update();
            }
        }
    }
}
