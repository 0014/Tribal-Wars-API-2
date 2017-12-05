using Tribalwars.Api.Enums;

namespace Tribalwars.Api.Models
{
    public class Building
    {
        public BuildingTypes Type { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }
    }
}
