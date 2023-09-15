using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Poruke")]
    public class Poruka
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public string PorukaSadrzaj { get; set; }

        [Required]
        [JsonIgnore]
        public Korisnik PorukaKorisnik { get; set; }

        [Required]
        [JsonIgnore]
        public StrucnoLice PorukaStrucnjak { get; set; }

    }
}