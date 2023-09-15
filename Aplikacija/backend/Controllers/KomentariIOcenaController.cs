using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Aplikacija_swe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KomentariIOcenaController : ControllerBase
    {

        public SajtContext Context {get; set;}
        public KomentariIOcenaController(SajtContext context)
        {
            Context = context;
        }

        // [Route("GetKomentariIOcene")]
        // [HttpGet]
        // public ActionResult Preuzmi()
        // {
        //     var komentariIOcene = Context.KomentarIOcena;
           
        //     return Ok(komentariIOcene);
        // }

        // [Route("DeleteKomentarIOcena/{id}")]
        // [HttpDelete]

        // public async Task<ActionResult> DeleteKorisnik(int id)
        // {
        //     var komentarIOcena = Context.KomentarIOcena.Where(p => p.ID == id).FirstOrDefault();
        //     if (komentarIOcena == null)
        //     {
        //         return BadRequest("Ne postoji");
        //     }
        //     try
        //     {
        //         var komentarIOcenaZaBrisanje = await Context.KomentarIOcena.FindAsync(komentarIOcena.ID);
        //         Context.KomentarIOcena.Remove(komentarIOcenaZaBrisanje);
        //         await Context.SaveChangesAsync();
        //         return Ok("Uspesno izbrisno");
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        
        [Route("KreiranjeKomentaraIOcene/{komentar}/{idStrucnogLica}/{idKorisnika}/{ocena}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> KreiranjeKomentaraIOcene (string komentar,int idStrucnogLica,int idKorisnika, int ocena)
        {
            var korisnik2 = Context.Korisnici.Where(p => p.ID == idKorisnika).FirstOrDefault();
            if(korisnik2.Autorizacija == "Korisnik"){
            try
            {
           
                if (string.IsNullOrWhiteSpace(komentar))
                {
                    return BadRequest("Niste uneli komentar");
                }
                if (ocena> 5 && ocena < 1)
                {
                    return BadRequest("Uneli ste ocenu izvan opsega");
                }
                var strucnoLice = await Context.StrucnaLIca.FindAsync(idStrucnogLica);
                var korisnik = await Context.Korisnici.FindAsync(idKorisnika);
                KomentarIOcena komentarIOcena = new KomentarIOcena();
                komentarIOcena.Komentar=komentar;
                komentarIOcena.Ocena=ocena;
                komentarIOcena.OcenaKomentarStrucnjak=strucnoLice;
                komentarIOcena.OcenaKomentarKorisnik=korisnik;
                
                if(komentarIOcena!= null){                          
                Context.KomentarIOcena.Add(komentarIOcena);
                await Context.SaveChangesAsync();
                return Ok();
                }
                else 
                {
                    return BadRequest("Neuspesno kreiranje");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            }
            else{
                return Unauthorized();
            }

        }




    }
}