using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("StrucnoLice")]
    public class StrucnoLice
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
      //  [RegularExpression("^[a-zA-Z0-9]+$")]
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
        public string OblastStruke { get; set; }

        [Required]

        public string Obrazovanje { get; set; } //zavrsena skola
        
        [Required]
        public bool OdobrenjeAdmina { get; set; } // ovo se setuje na true kad ga admin odobri
    
        [Required]
        public int KolicinaNovca { get; set; }

        public int BrojRacuna { get; set; } // bankovni racun

         ////////////////////
        public string Autorizacija { get; set; }
          //////////////////   

        public string Cet { get; set; } // ovo je zamisao da se cet cuva u bazu

        public Sajt StrucnjakSajt { get; set; }

        public List<Plan> StrucnaLicaPlanovi { get; set; }

        public List<KomentarIOcena> StrucnaLicaKomentariIOcene { get; set; }

        public List<Poruka> StrucnaLicaPoruke { get; set; }


    }
}