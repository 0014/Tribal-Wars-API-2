using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tribalwars.Models
{
    public class FarmVillages
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        public string Name { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int TimesAttacked { get; set; }

        public DateTime DateAttacked { get; set; }
    }
}
