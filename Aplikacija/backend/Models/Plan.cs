using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Plan")]
    public class Plan
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public string NazivPlana { get; set; }

        [Required]
        public int IdStrucnogLice { get; set; }

        [Required]
        public string OpisPlana { get; set; }

        [Required]
        public string Oblast { get; set; } // fitnes ili nutricionizam

        [Required]
        public int Cena { get; set; }

        [JsonIgnore]
        [Required]
        public StrucnoLice PlanStrucnjak { get; set; }

        [JsonIgnore]
        public List<Korisnik> PlanoviKorisnici { get; set; }

        public List<Obrok> PlanObroci { get; set; }

        public List<Vezba> PlanVezbe { get; set; }



    }
}