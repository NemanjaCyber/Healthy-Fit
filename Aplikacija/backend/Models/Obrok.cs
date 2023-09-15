using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Obrok")]
    public class Obrok
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Dan { get; set; }

        [Required]
        public string TipObroka { get; set; } // dorucak rucak vecera uzina

        [Required]
        public string SlikaPutanja { get; set; }

        [Required]
        public string Opis { get; set; }

        //dodajte jos nesto ako imate ideju
        
        [Required]
        [JsonIgnore]
        public Plan ObrokPlan { get; set; }

    }
}