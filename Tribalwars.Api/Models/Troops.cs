using System;
using Tribalwars.Api.Enums;

namespace Tribalwars.Api.Models
{
    public class Troops
    {
        public TroopTypes Type { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
