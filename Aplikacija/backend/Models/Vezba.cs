using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Vezba")]
    public class Vezba
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public string Dan { get; set; }

        
        public string PeriodDanaKadaSeVezbaIzvodi { get; set; }
               
        public int BrojPonavljanja { get; set; }    


        [Required]
        public string SlikaPutanja { get; set; }

        [Required]
        public string Opis { get; set; }

        [Required]
        [JsonIgnore]
        public Plan VezbaPlan { get; set; }
        

    }
}