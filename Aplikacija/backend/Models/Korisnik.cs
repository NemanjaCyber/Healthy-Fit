using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Korisnik")]
    public class Korisnik
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string KorisnickoIme { get; set; }

        [Required]
        [MaxLength(50)]
        //[RegularExpression("^[a-zA-Z0-9]+$")]
        public string Sifra { get; set; }
        
        [Required]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string Ime { get; set; }
        
        [Required]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string Prezime { get; set; }

        [Required]
        public string Slika { get; set; } // putanja do slike
        
        
        public string DatumRodjenja { get; set; }

        [Required]
        public string Pol { get; set; }

        [Required]
        public int KolicinaNovca { get; set; }

         ////////////////////
        public string Autorizacija { get; set; }
         //////////////////////   

         ////racunnn
        public string Cet { get; set; } // ovo je zamisao da se cet cuva u bazu samo se mora formatira


        public List<Plan> KorisniciPlanovi { get; set; }

        public Sajt KorisnikSajt { get; set; }

        public List<KomentarIOcena> KorisniciKomentariIOcene { get; set; }

        public List<Poruka> KorisniciPoruke { get; set; }
        

    }
}