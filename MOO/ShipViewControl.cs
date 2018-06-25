using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOO
{
    public partial class ShipViewControl : UserControl
    {
        public ShipViewControl()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("shipid", "Ship ID");
            dataGridView1.Columns.Add("location", "Location");
            dataGridView1.Columns.Add("destination", "Destination");

            dataGridView1.Dock = DockStyle.Fill;
        }
        public void UpdateList()
        {
            dataGridView1.Rows.Clear();
            foreach (var ship in Galaxy.Ships)
            {
                string loc = ship.CurrentLocation.X.ToString() + " " + ship.CurrentLocation.Y.ToString();
                string dest = Galaxy.stars[ship.Destination.IDHomeStar].Location.X.ToString()+" "+ Galaxy.stars[ship.Destination.IDHomeStar].Location.X.ToString();
                dataGridView1.Rows.Add(ship.HomePlanet.ToString(),loc,dest );
            }
        }
    }
}
