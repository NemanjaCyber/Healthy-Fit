using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Admin")]
    public class Administrator
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

 ////////////////////
        public string Autorizacija { get; set; }
  //////////////////////      
        public Sajt AdminSajt { get; set; }
        


    }
}