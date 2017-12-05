using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tribalwars.Models
{
    public class FarmAttacks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        public int FarmId{ get; set; }

        public int AmountLc { get; set; }

        public DateTime Date { get; set; }
    }
}
