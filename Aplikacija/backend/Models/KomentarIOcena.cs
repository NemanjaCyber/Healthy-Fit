using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("KomentarIOcena")]
    public class KomentarIOcena
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public string Komentar { get; set; }

        [Required]
        [Range(0,5)]
        public int Ocena { get; set; }  

        [Required]
        [JsonIgnore]
        public Korisnik OcenaKomentarKorisnik { get; set; }
        [Required]
        [JsonIgnore]
        public StrucnoLice OcenaKomentarStrucnjak { get; set; }

    }
}