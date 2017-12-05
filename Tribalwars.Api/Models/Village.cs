using System.Collections.Generic;

namespace Tribalwars.Api.Models
{
    public class Village
    {
        public string Name { get; set; }

        public Coordinates Coordinates { get; set; }

        public Resources Resources { get; set; }

        public List<Building> Buildings { get; set; }

        public List<Troops> Army { get; set; }
    }
}
