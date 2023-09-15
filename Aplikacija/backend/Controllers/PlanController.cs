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
    public class PlanController : ControllerBase
    {

        public SajtContext Context {get; set;}
        public PlanController(SajtContext context)
        {
            Context = context;
        }

        [Route("GetSviPlanovi/{emailKorisnika}")]
        [HttpGet]
        public ActionResult Preuzmi(string emailKorisnika)
        {
             var korisnik = Context.Korisnici
            .Where(e => e.Email==emailKorisnika).FirstOrDefault();
            if(korisnik.Autorizacija == "Korisnik"){

            var planovi = Context.Planovi
            .Include(p => p.PlanObroci)
            .Include(q => q.PlanVezbe);
           
            return Ok(planovi);
            }
        else{
                return Unauthorized();
            }
        }
        // [Route("GetSviPlanoviBezVezbiIObroka")]
        // [HttpGet]
        // public ActionResult GetSviPlanoviBezVezbiIObroka()
        // {
        //     var planovi = Context.Planovi;
           
        //     return Ok(planovi);
        // }

        // [Route("AddPlan")]
        // [HttpPost]
        // public async Task<ActionResult> AddPlan ([FromBody] Plan plan)
        // {
        //     try
        //     {

        //         var plan2 = Context.Planovi.Where(p => p.NazivPlana == plan.NazivPlana).FirstOrDefault();
        //         if (plan2 != null)
        //         {
        //             return BadRequest("Plan vec postoji");
        //         }             
        //         if (string.IsNullOrWhiteSpace(plan.NazivPlana))
        //         {
        //             return BadRequest("Niste uneli naziv plana");
        //         }
        //         if (plan.NazivPlana.Length > 50)
        //         {
        //             return BadRequest("Uneli ste predugacko ime");
        //         }
              

        //         Context.Planovi.Add(plan);
        //         await Context.SaveChangesAsync();
        //         return Ok($"Sve ok! ID je: {plan.ID}");
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }

        // }

        // [Route("ChangePlan")]
        // [HttpPut]
        // public async Task<ActionResult> ChangePlan([FromBody] Plan plan)
        // {
        //     var plan2 = Context.Planovi.Where(p => p.ID == plan.ID).FirstOrDefault();
        //     if (plan2 == null)
        //     {
        //         return BadRequest("Plan ne postoji");
        //     }
        //     try
        //     {
        //         var planZaPromenu = await Context.Planovi.FindAsync(plan2.ID);
        //         planZaPromenu.NazivPlana = plan.NazivPlana;
        //         planZaPromenu.Oblast = plan.Oblast;
        //         planZaPromenu.Cena = plan.Cena;
         
                

        //         await Context.SaveChangesAsync();
        //         return Ok("Plan je uspesno izmenjen");
        //     }

        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }
        
        [Route("ChangePlanStrucnjak/{idPlana}/{idStrucnjaka}/{nazivPlana}/{opisPlana}/{cena}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> ChangePlan(int idPlana,int idStrucnjaka,string nazivPlana,string opisPlana,int cena)
        {
            var strucnoLiceA = Context.StrucnaLIca.Where(p => p.ID == idStrucnjaka).FirstOrDefault();
            if(strucnoLiceA.Autorizacija == "StrucnoLice"){
            var plan2 = Context.Planovi.Where(p => p.ID == idPlana).FirstOrDefault();
            if (plan2 == null)
            {
                return BadRequest("Plan ne postoji");
            }
            try
            {
                var planZaPromenu = await Context.Planovi.FindAsync(plan2.ID);
                var strucnjak = await Context.StrucnaLIca.FindAsync(idStrucnjaka);
                planZaPromenu.NazivPlana = nazivPlana;
                planZaPromenu.OpisPlana = opisPlana;
                planZaPromenu.Cena = cena;
                planZaPromenu.PlanStrucnjak=strucnjak;
                

                await Context.SaveChangesAsync();
                return Ok();
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

        [Route("DeletePlan/{id}/{emailStrucnjak}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult> DeletePlan(int id, string emailStrucnjak)
        {
            var strucnoLiceA = Context.StrucnaLIca.Where(p => p.Email == emailStrucnjak).FirstOrDefault();
            if(strucnoLiceA.Autorizacija == "StrucnoLice"){
            var plan2 = Context.Planovi.Where(p => p.ID == id).FirstOrDefault();
            if (plan2 == null)
            {
                return BadRequest("Plan ne postoji");
            }
            try
            {
                var plan = await Context.Planovi.FindAsync(plan2.ID);
                Context.Planovi.Remove(plan);
                await Context.SaveChangesAsync();
                return Ok("");
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

        [Route("DodajVezbu/{idPlana}/{dan}/{periodDanaKadaSeVezbaIzvodi}/{brojPonavljanja}/{slikaPutanja}/{opis}/{emailStrucnjak}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> KreiranjeVezbe (int idPlana,string dan,string periodDanaKadaSeVezbaIzvodi, int brojPonavljanja, string slikaPutanja, string opis, string emailStrucnjak)
        {
            var strucnoLiceA = Context.StrucnaLIca.Where(p => p.Email == emailStrucnjak).FirstOrDefault();
            if(strucnoLiceA.Autorizacija == "StrucnoLice"){
            try
            {

                var plan2 = Context.Planovi.Where(p => p.ID == idPlana).FirstOrDefault();
                if (plan2 == null)
                {
                    return BadRequest("Plan ne postoji");
                }             
                if (plan2.Oblast=="ishrana")
                {
                    return BadRequest("Ne mozete uneti vezbu u plan ishrane");
                }// odavde na dole
                if(dan == "")
                {
                    return BadRequest("Niste uneli dan");
                }
                if(periodDanaKadaSeVezbaIzvodi == "")
                {
                    return BadRequest("Niste uneli period dana");
                }
                if(opis == "")
                {
                    return BadRequest("Niste uneli opis");
                }

               
                var plan = await Context.Planovi.FindAsync(idPlana);
                Vezba vezba = new Vezba();
                vezba.Dan= dan;
                vezba.PeriodDanaKadaSeVezbaIzvodi=periodDanaKadaSeVezbaIzvodi;
                vezba.BrojPonavljanja=brojPonavljanja;
                vezba.SlikaPutanja=slikaPutanja;
                vezba.Opis=opis;
                vezba.VezbaPlan=plan;
                if(plan!= null){                          
                Context.Vezbe.Add(vezba);
                await Context.SaveChangesAsync();
                return Ok($"Sve ok! ID je: {plan.ID}");
                }
                else 
                {
                    return BadRequest("Neuspesno kreiranje vezbe");
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

        [Route("DodajObrok/{idPlana}/{dan}/{tipObroka}/{slikaPutanja}/{opis}/{emailStrucnjak}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> KreiranjeObroka (int idPlana,string dan,string tipObroka, string slikaPutanja, string opis, string emailStrucnjak)
        {
            var strucnoLiceA = Context.StrucnaLIca.Where(p => p.Email == emailStrucnjak).FirstOrDefault();
            if(strucnoLiceA.Autorizacija == "StrucnoLice"){
            try
            {

                var plan2 = Context.Planovi.Where(p => p.ID == idPlana).FirstOrDefault();
                if (plan2 == null)
                {
                    return BadRequest("Plan ne postoji");
                }             
                if (plan2.Oblast=="fitnes")
                {
                    return BadRequest("Ne mozete uneti obrok u plan vezbanja");
                }// odavde na dole
                if(dan == "")
                {
                    return BadRequest("Niste uneli dan");
                }
                if(tipObroka == "")
                {
                    return BadRequest("Niste uneli tip obroka");
                }
                if( opis == "")
                {
                    return BadRequest("Niste uneli opis");
                }
               
                var plan = await Context.Planovi.FindAsync(idPlana);
                Obrok obrok = new Obrok();
                obrok.Dan= dan;
                obrok.TipObroka=tipObroka;
                obrok.SlikaPutanja=slikaPutanja;
                obrok.Opis=opis;
                obrok.ObrokPlan=plan;
                if(plan!= null){                          
                Context.Obroci.Add(obrok);
                await Context.SaveChangesAsync();
                return Ok();
                }
                else 
                {
                    return BadRequest("Neuspesno kreiranje obroka");
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