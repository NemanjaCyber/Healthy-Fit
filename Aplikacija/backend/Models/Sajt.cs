using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Sajt")]
    public class Sajt
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public string Naziv { get; set; }

        [Required]
        public string UsloviIPravilaKoriscenja { get; set; }

        public List<Administrator> Admini { get; set; }

        public List<Korisnik> Korisnici { get; set; }

        public List<Plan> Planovi { get; set; }

        public List<StrucnoLice> StrucnaLica { get; set; }

    }
}