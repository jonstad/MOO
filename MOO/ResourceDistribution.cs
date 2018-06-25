using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOO
{
    public class ResourceDistribution
    {
        public int Industry { get; set; }
        public int Commercial { get; set; }
        public int Ecology { get; set; }
        public int Tehnology { get; set; }
        public int Ship { get; set; }
        public ResourceDistribution()
        {
            Industry = 50;
            Commercial = 50;
            Ecology = 0;
            Tehnology = 0;
            Ship = 0;
        }
    }
}
