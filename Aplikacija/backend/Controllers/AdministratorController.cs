using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models;

namespace Aplikacija_swe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministratorController : ControllerBase
    {

        public SajtContext Context {get; set;}
        public AdministratorController(SajtContext context)
        {
            Context = context;
        }
        //Cisto za proveru u bazi sta ima
        [Route("GetAdminstratoriSvi")]
        [HttpGet]
        public ActionResult PreuzmiSVe()
        {
            var administratori = Context.Admini;

            foreach (var admin in administratori)
            {
                admin.Sifra=Encript.ConverToDecrypt(admin.Sifra);
            }


            return Ok(administratori);
        }
        //Za logovanje glavna f-ja
        [Route("GetAdminstrator/{email}/{pass}")]
        [HttpGet]
        public ActionResult Preuzmi(string email,string pass)
        {
            var administratori = Context.Admini
            .Where(p=> p.Email==email && p.Sifra==Encript.ConvertToEncrypt(pass));
           
            return Ok(administratori);
        }

        //Nakon logovanja
        [Route("AdministratorLogin/{email}")]
        [HttpGet]
        public ActionResult LoginAdministrator(string email)
        {
            var admin = Context.Admini
            .Where(e => e.Email==email).FirstOrDefault();
            if(admin.Autorizacija == "Admin"){

            
            var administratori = Context.Admini
            .Where(e => e.Email==email);
           
            return Ok(administratori);
             }
            else{
                return Unauthorized();
            }
        }
        //////////////////////
        [Route("AdministratorLogovanje/{email}")]
        [HttpPut]
        public async Task<ActionResult> LogovanjeAdministrator(string email)/////Napravljeno da bude asink
        {
            var administratori = Context.Admini
            .Where(e => e.Email==email);
           
             if(administratori.Count() == 0){
            return BadRequest("Greska u reg");
           }
           else{
            var administrator = Context.Admini
            .Where(e => e.Email==email).FirstOrDefault();
            administrator.Autorizacija="Admin";
            await Context.SaveChangesAsync();

            return Ok();
           }
        }
        [Route("AdministratorLogOut/{email}")]
        [HttpPut]
        public async Task<ActionResult> LogOutAdministrator(string email)
        {
            var administratori = Context.Admini
            .Where(e => e.Email==email);
           
             if(administratori.Count() == 0){
            return BadRequest("Ne postoji admin");
           }
           else{
            var administrator = Context.Admini
            .Where(e => e.Email==email).FirstOrDefault();
            administrator.Autorizacija="";
            await Context.SaveChangesAsync();

            return Ok();
           }
        }
/////////////////
        // [Route("AddAdminstrator")]
        // [HttpPost]
        // public async Task<ActionResult> AddAdminstrator ([FromBody] Administrator admin)
        // {
        //     try
        //     {

        //         var admin2 = Context.Admini.Where(p => p.Ime == admin.Ime).FirstOrDefault();
        //         if (admin2 != null)
        //         {
        //             return BadRequest("Admin vec postoji");
        //         }             
        //         if (string.IsNullOrWhiteSpace(admin.Ime))
        //         {
        //             return BadRequest("Niste uneli ime");
        //         }
        //         if (admin.Ime.Length > 50)
        //         {
        //             return BadRequest("Uneli ste predugacko ime");
        //         }
        //         if (!(Regex.Match(admin.Ime, "^[a-zA-Z0-9]+$")).Success)
        //         {
        //             return BadRequest("Uneli ste nedozvoljen karakter");
        //         }///odavde pa nadole
        //          if (string.IsNullOrWhiteSpace(admin.Prezime))
        //         {
        //             return BadRequest("Niste uneli prezime");
        //         }
        //         if (admin.Prezime.Length > 50)
        //         {
        //             return BadRequest("Uneli ste predugacko prezime");
        //         }
        //         if (string.IsNullOrWhiteSpace(admin.KorisnickoIme))
        //         {
        //             return BadRequest("Niste uneli korisnicko ime");
        //         }
        //         if (admin.KorisnickoIme.Length > 50)
        //         {
        //             return BadRequest("Uneli ste predugacko korisnicko ime");
        //         }
        //          if (string.IsNullOrWhiteSpace(admin.Sifra))
        //         {
        //             return BadRequest("Niste uneli sifru");
        //         }
        //         if (admin.Sifra.Length > 50)
        //         {
        //             return BadRequest("Uneli ste predugacku sifru");
        //         }
        //         // dovde
        //         ////ENKRIPCIJA
        //         admin.Sifra= Encript.ConvertToEncrypt(admin.Sifra);


        //         Context.Admini.Add(admin);
        //         await Context.SaveChangesAsync();
        //         return Ok($"Sve ok! ID je: {admin.ID}");
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }

        // }

        // [Route("ChangeAdministrator")]
        // [HttpPut]
        // public async Task<ActionResult> ChangeAdministrator([FromBody] Administrator admin)
        // {
        //     var admin2 = Context.Admini.Where(p => p.ID == admin.ID).FirstOrDefault();
        //     if (admin2 == null)
        //     {
        //         return BadRequest("Admin ne postoji");
        //     }
        //     try
        //     {
        //         var adminZaPromenu = await Context.Admini.FindAsync(admin2.ID);
        //         adminZaPromenu.Ime = admin.Ime;
        //         adminZaPromenu.Prezime = admin.Prezime;
        //         adminZaPromenu.Email = admin.Email;
        //         adminZaPromenu.KorisnickoIme = admin.KorisnickoIme;
        //         adminZaPromenu.Sifra = Encript.ConvertToEncrypt(admin.Sifra);
                

        //         await Context.SaveChangesAsync();
        //         return Ok("Admin je uspesno izmenjen");
        //     }

        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        // [Route("DeleteAdministrator/{id}")]
        // [HttpDelete]

        // public async Task<ActionResult> DeleteKorisnik(int id)
        // {
        //     var admin2 = Context.Admini.Where(p => p.ID == id).FirstOrDefault();
        //     if (admin2 == null)
        //     {
        //         return BadRequest("Admin ne postoji");
        //     }
        //     try
        //     {
        //         var administrator = await Context.Admini.FindAsync(admin2.ID);
        //         Context.Admini.Remove(administrator);
        //         await Context.SaveChangesAsync();
        //         return Ok("Uspesno izbrisan admin");
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }
        ///Prepravljeno
        [Route("AdministratorAutentifikacijaStrucnogLica/{idStrucnogLica}/{emailAdmin}")] 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DozvolaStrucnomLicu( int idStrucnogLica, string emailAdmin)
        {   var admin = Context.Admini.Where(p => p.Email == emailAdmin).FirstOrDefault();
            if(admin.Autorizacija == "Admin"){
            var strucnoLice2 = Context.StrucnaLIca.Where(p => p.ID == idStrucnogLica).FirstOrDefault();
            if (strucnoLice2 == null)
            {
                return BadRequest("Strucno lice ne postoji");
            }
            try
            {
                var strucnoLiceZaPromenuAutentifikacije = await Context.StrucnaLIca.FindAsync(strucnoLice2.ID);
                strucnoLiceZaPromenuAutentifikacije.OdobrenjeAdmina = true;
                await Context.SaveChangesAsync();
                return Ok("Strucno lice je dobilo dozvolu");
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
                // return Unauthorized(e.Message);
            }
            }
            else{
                return Unauthorized();
            }

        }

        [Route("GetKorisniciAdmin/{emailAdmin}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult PreuzmiKorisnike(string emailAdmin)
        {
            var admin = Context.Admini.Where(p => p.Email == emailAdmin).FirstOrDefault();
            if(admin.Autorizacija == "Admin"){
            var korisnici = Context.Korisnici;
            
           
            return Ok(korisnici);
             }
            else{
                return Unauthorized();
            }
        }

        [Route("GetStrucnaLicaAdmin/{emailAdmin}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult PreuzmiStrucnaLica(string emailAdmin)
        {
            var admin = Context.Admini.Where(p => p.Email == emailAdmin).FirstOrDefault();
            if(admin.Autorizacija == "Admin"){
            var strucnaLica = Context.StrucnaLIca
            .Where(e => e.OdobrenjeAdmina==true);
            
           
            return Ok(strucnaLica);
             }
            else{
                return Unauthorized();
            }
        }

    }
}