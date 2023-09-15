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
    public class PorukaController : ControllerBase
    {

        public SajtContext Context {get; set;}
        public PorukaController(SajtContext context)
        {
            Context = context;
        }

        // [Route("GetPoruke")]
        // [HttpGet]
        // public ActionResult Preuzmi()
        // {
        //     var poruke = Context.Poruke;
           
        //     return Ok(poruke);
        // }

        // [Route("DeletePoruka/{id}")]
        // [HttpDelete]

        // public async Task<ActionResult> DeletePoruka(int id)
        // {
        //     var poruka = Context.Poruke.Where(p => p.ID == id).FirstOrDefault();
        //     if (poruka == null)
        //     {
        //         return BadRequest("Ne postoji");
        //     }
        //     try
        //     {
        //         var porukaZaBrisanje = await Context.Poruke.FindAsync(poruka.ID);
        //         Context.Poruke.Remove(porukaZaBrisanje);
        //         await Context.SaveChangesAsync();
        //         return Ok("Uspesno izbrisno");
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        
        [Route("KreiranjePorukeKorisnik/{porukaSadrzaj}/{idStrucnogLica}/{idKorisnika}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> KreiranjeKomentaraIOceneKorisnik (string porukaSadrzaj,int idStrucnogLica,int idKorisnika)
        {
            var korisnik2 = Context.Korisnici.Where(p => p.ID == idKorisnika).FirstOrDefault();
            if(korisnik2.Autorizacija == "Korisnik"){
            try
            {
           
                if (string.IsNullOrWhiteSpace(porukaSadrzaj))
                {
                    return BadRequest("Niste uneli sadrzaj poruke");
                }
                
                var strucnoLice = await Context.StrucnaLIca.FindAsync(idStrucnogLica);
                var korisnik = await Context.Korisnici.FindAsync(idKorisnika);
                Poruka poruka = new Poruka();
                poruka.PorukaSadrzaj=korisnik.Ime+" "+korisnik.Prezime+":"+porukaSadrzaj;
                poruka.PorukaStrucnjak=strucnoLice;
                poruka.PorukaKorisnik=korisnik;
                
                if(poruka!= null){                          
                Context.Poruke.Add(poruka);
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

        [Route("KreiranjePorukeStrucnoLice/{porukaSadrzaj}/{idStrucnogLica}/{idKorisnika}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> KreiranjeKomentaraIOceneStrucnoLice (string porukaSadrzaj,int idStrucnogLica,int idKorisnika)
        {
             var strucnoLice2 = Context.StrucnaLIca.Where(p => p.ID == idStrucnogLica).FirstOrDefault();
            if(strucnoLice2.Autorizacija == "StrucnoLice"){
            try
            {
           
                if (string.IsNullOrWhiteSpace(porukaSadrzaj))
                {
                    return BadRequest("Niste uneli sadrzaj poruke");
                }
                
                var strucnoLice = await Context.StrucnaLIca.FindAsync(idStrucnogLica);
                var korisnik = await Context.Korisnici.FindAsync(idKorisnika);
                Poruka poruka = new Poruka();
                poruka.PorukaSadrzaj=strucnoLice.Ime+" "+strucnoLice.Prezime+":"+porukaSadrzaj;
                poruka.PorukaStrucnjak=strucnoLice;
                poruka.PorukaKorisnik=korisnik;
                
                if(poruka!= null){                          
                Context.Poruke.Add(poruka);
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