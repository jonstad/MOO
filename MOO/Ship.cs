using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOO
{
    public class Ship
    {
        public Location CurrentLocation { get; set; }
        public Planet Destination { get; set; }
        public bool Docked { get; set; }
        public int  HomePlanet { get; set; }
        public int Size { get; set; }
        public Color BodyColor { get; set; }
        public Ship(int homeplanet, Location currentlocation)
        {
            CurrentLocation = currentlocation;
            HomePlanet = homeplanet;
            Docked = true;
            Size = 4;
            BodyColor = Color.Red;
        }
    }
}
