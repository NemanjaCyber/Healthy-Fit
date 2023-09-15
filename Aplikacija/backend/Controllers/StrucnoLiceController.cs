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
    public class StrucnoLiceController : ControllerBase
    {

        public SajtContext Context {get; set;}
        public StrucnoLiceController(SajtContext context)
        {
            Context = context;
        }
        //Cisto za proveru baze
        [Route("GetStrucnaLica")]
        [HttpGet]
        public ActionResult PreuzmiSva()
        {
            var strucnaLica = Context.StrucnaLIca
            .Where(e => e.OdobrenjeAdmina==true)
            .Include(p => p.StrucnaLicaPlanovi)
            .ThenInclude(r => r.PlanObroci)
            .Include(p => p.StrucnaLicaPlanovi)
            .ThenInclude(r => r.PlanVezbe)
            .Include(q => q.StrucnaLicaKomentariIOcene);

            foreach (var strucnjak in strucnaLica)
            {
                strucnjak.Sifra=Encript.ConverToDecrypt(strucnjak.Sifra);
            }
           
            return Ok(strucnaLica);
        }
        //Glavna za login
        [Route("GetStrucnaLica/{email}/{pass}")]
        [HttpGet]
        public ActionResult Preuzmi(string email,string pass)
        {
            var strucnaLica = Context.StrucnaLIca
            .Where(e => e.OdobrenjeAdmina==true)
            .Include(p => p.StrucnaLicaPlanovi)
            .ThenInclude(r => r.PlanObroci)
            .Include(p => p.StrucnaLicaPlanovi)
            .ThenInclude(r => r.PlanVezbe)
            .Include(q => q.StrucnaLicaKomentariIOcene)
            .Where(p=> p.Email==email && p.Sifra==Encript.ConvertToEncrypt(pass));
           
            return Ok(strucnaLica);
        }

        [Route("GetStrucnaLicaZaPrijemPoruka/{emailKorisnika}")]
        [HttpGet]
        public ActionResult GetStrucnaLicaZaPrijemPoruka(string emailKorisnika)
        {
            var korisnik = Context.Korisnici
            .Where(e => e.Email==emailKorisnika).FirstOrDefault();

            if(korisnik.Autorizacija == "Korisnik"){

            var strucnaLica = Context.StrucnaLIca
            .Where(e => e.OdobrenjeAdmina==true);
           
            return Ok(strucnaLica);
             }
            else{
                return Unauthorized();
            }
        }

        [Route("GetStrucnaLicaZaOdobrenje/{emailAdmin}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult GetStrucnaLicaZaOdobrenje(string emailAdmin)
        {
            var admin = Context.Admini.Where(p => p.Email == emailAdmin).FirstOrDefault();
            if(admin.Autorizacija == "Admin"){
            var strucnaLica = Context.StrucnaLIca
            .Where(e => e.OdobrenjeAdmina==false);
            
           
            return Ok(strucnaLica);
            }
            else{
                return Unauthorized();
            }
        }
        [Route("LoginStrucnoLice/{email}")]
        [HttpGet]
        public ActionResult LoginStrucnoLice(string email)
        {
            var strucnoLice = Context.StrucnaLIca
            .Where(e => e.Email==email).FirstOrDefault();
            if(strucnoLice.Autorizacija == "StrucnoLice"){

            var strucnaLica = Context.StrucnaLIca
            .Where(e => e.Email==email)
            .Include(p => p.StrucnaLicaPlanovi)
            .ThenInclude(r => r.PlanObroci)
            .Include(p => p.StrucnaLicaPlanovi)
            .ThenInclude(r => r.PlanVezbe)
            .Include(q => q.StrucnaLicaKomentariIOcene);
           
            return Ok(strucnaLica);
            }
            else{
                return Unauthorized();
            }
        }
                 //////////////////////
        [Route("StrucnoLiceLogovanje/{email}")]
        [HttpPut]
        public async Task<ActionResult> StrucnoLiceLogovanje(string email)/////Napravljeno da bude asink
        {
            var strucnjaci = Context.StrucnaLIca
            .Where(e => e.Email==email);
           
             if(strucnjaci.Count() == 0){
            return BadRequest("Greska u reg");
           }
           else{
            var strucnjak = Context.StrucnaLIca
            .Where(e => e.Email==email).FirstOrDefault();
            strucnjak.Autorizacija="StrucnoLice";
            await Context.SaveChangesAsync();

            return Ok();
           }
        }
        [Route("StrucnoLiceLogOut/{email}")]
        [HttpPut]
        public async Task<ActionResult> LogOutStrucnoLice(string email)
        {
            var strucnjaci = Context.StrucnaLIca
            .Where(e => e.Email==email);
           
             if(strucnjaci.Count() == 0){
            return BadRequest("Ne postoji strucno lice");
           }
           else{
            var strucnjak = Context.StrucnaLIca
            .Where(e => e.Email==email).FirstOrDefault();
            strucnjak.Autorizacija="";
            await Context.SaveChangesAsync();

            return Ok();
           }
        }
/////////////////
        [Route("PorukeStrucnoLice/{email}")]
        [HttpGet]
        public ActionResult PorukeStrucnoLice(string email)
        {
            var strucnoLice = Context.StrucnaLIca
            .Where(e => e.Email==email).FirstOrDefault();
            if(strucnoLice.Autorizacija == "StrucnoLice"){

            var strucnaLica = Context.StrucnaLIca
            .Where(e => e.Email==email)
            .Include(p => p.StrucnaLicaPoruke);
            
           
            return Ok(strucnaLica);

             }
            else{
                return Unauthorized();
            }
        }
         [Route("ProveraRegistracijeStrucnoLice/{korisnickoIme}")]
        [HttpGet]
        public ActionResult ProveraRegistracijeStrucnoLice(string korisnickoIme)
        {
            var strucnaLica = Context.StrucnaLIca
            .Where(e => e.KorisnickoIme==korisnickoIme)
            .Include(p => p.StrucnaLicaPlanovi)
            .ThenInclude(r => r.PlanObroci)
            .Include(p => p.StrucnaLicaPlanovi)
            .ThenInclude(r => r.PlanVezbe)
            .Include(q => q.StrucnaLicaKomentariIOcene);
           
            return Ok(strucnaLica);
        }
        

        [Route("AddStrucnoLica")]
        [HttpPost]
        public async Task<ActionResult> AddStrucnoLica ([FromBody] StrucnoLice strucnoLice)
        {
            try
            {

                var strucnoLice2 = Context.StrucnaLIca.Where(p => p.Email == strucnoLice.Email).FirstOrDefault();
                if (strucnoLice2 != null)
                {
                    return BadRequest("Strucno lice vec postoji");
                }
                if (string.IsNullOrWhiteSpace(strucnoLice.Ime))
                {
                    return BadRequest("Niste uneli ime");
                }
                if (strucnoLice.Ime.Length > 50)
                {
                    return BadRequest("Uneli ste predugacko ime");
                }
                if (!(Regex.Match(strucnoLice.Ime, "^[a-zA-Z0-9]+$")).Success)
                {
                    return BadRequest("Uneli ste nedozvoljen karakter");
                }/// odavde na dole validacije
                if (string.IsNullOrWhiteSpace(strucnoLice.Prezime))
                {
                    return BadRequest("Niste uneli prezime");
                }
                if (strucnoLice.Prezime.Length > 50)
                {
                    return BadRequest("Uneli ste predugacko prezime");
                }
                if (string.IsNullOrWhiteSpace(strucnoLice.KorisnickoIme))
                {
                    return BadRequest("Niste uneli korisnicko ime");
                }
                if (strucnoLice.KorisnickoIme.Length > 50)
                {
                    return BadRequest("Uneli ste predugacko korisnicko ime");
                }
                if (string.IsNullOrWhiteSpace(strucnoLice.Email))
                {
                    return BadRequest("Niste uneli email");
                }
                if (strucnoLice.Email.Length > 50)
                {
                    return BadRequest("Uneli ste predugacki email");
                }

                ////ENKRIPCIJA
                strucnoLice.Sifra= Encript.ConvertToEncrypt(strucnoLice.Sifra);

                Context.StrucnaLIca.Add(strucnoLice);
                await Context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("ChangeStrucnoLice")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> ChangeStrucnoLice([FromBody] StrucnoLice strucnoLice)
        {
            var strucnoLice2 = Context.StrucnaLIca.Where(p => p.Email == strucnoLice.Email).FirstOrDefault();
            if(strucnoLice2.Autorizacija == "StrucnoLice"){
            if (strucnoLice2 == null)
            {
                return BadRequest("Strucno lice ne postoji");
            }
            try
            {
                var strucnoLiceZaPromenu = await Context.StrucnaLIca.FindAsync(strucnoLice2.ID);
                strucnoLiceZaPromenu.Ime = strucnoLice.Ime;
                strucnoLiceZaPromenu.Prezime = strucnoLice.Prezime;
                strucnoLiceZaPromenu.Email = strucnoLice.Email;
                strucnoLiceZaPromenu.BrojRacuna=strucnoLice.BrojRacuna;
                strucnoLiceZaPromenu.DatumRodjenja = strucnoLice.DatumRodjenja;
                strucnoLiceZaPromenu.KorisnickoIme = strucnoLice.KorisnickoIme;
                strucnoLiceZaPromenu.Pol = strucnoLice.Pol;
                strucnoLiceZaPromenu.Slika = strucnoLice.Slika; //ovo
                strucnoLiceZaPromenu.OblastStruke = strucnoLice.OblastStruke;
                strucnoLiceZaPromenu.Obrazovanje = strucnoLice.Obrazovanje;
                //Enkripcija
                if(strucnoLice.Sifra!=strucnoLiceZaPromenu.Sifra){
                strucnoLiceZaPromenu.Sifra = Encript.ConvertToEncrypt(strucnoLice.Sifra); 
                }else{
                strucnoLiceZaPromenu.Sifra = strucnoLice.Sifra;
                }
                ////ima jos da se dodaju

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
        [Route("DeleteStrucnoLiceLicno/{korisnickoIme}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult> DeleteStrucnoLiceLicno(string korisnickoIme)
        {
            
             
            var strucnoLice2 = Context.StrucnaLIca.Where(p => p.KorisnickoIme == korisnickoIme).FirstOrDefault();
            if (strucnoLice2 == null)
            {
                return BadRequest("Strucno lice ne postoji");
            }
            if(strucnoLice2.Autorizacija == "StrucnoLice"){
            try
            {   
                
                var strucnoLice = await Context.StrucnaLIca.FindAsync(strucnoLice2.ID);
                Context.StrucnaLIca.Remove(strucnoLice);
                await Context.SaveChangesAsync();
                return Ok("Uspesno izbrisno strucno lice");
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

        [Route("DeleteStrucnoLice/{korisnickoIme}/{adminEmail}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult> DeleteStrucnoLice(string korisnickoIme, string adminEmail)
        {
            var admin = Context.Admini.Where(p => p.Email == adminEmail).FirstOrDefault();
            if(admin.Autorizacija == "Admin"){ 
            var strucnoLice2 = Context.StrucnaLIca.Where(p => p.KorisnickoIme == korisnickoIme).FirstOrDefault();
            if (strucnoLice2 == null)
            {
                return BadRequest("Strucno lice ne postoji");
            }
            try
            {   
                
                var strucnoLice = await Context.StrucnaLIca.FindAsync(strucnoLice2.ID);
                Context.StrucnaLIca.Remove(strucnoLice);
                await Context.SaveChangesAsync();
                return Ok("Uspesno izbrisno strucno lice");
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

        [Route("KreiranjePlana/{nazivPlana}/{idStrucnogLica}/{oblast}/{cenaPlana}/{opisPlana}")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> KreiranjePlana (string nazivPlana,int idStrucnogLica,string oblast, int cenaPlana,string opisPlana)
        {
            var strucnoLiceA = Context.StrucnaLIca.Where(p => p.ID == idStrucnogLica).FirstOrDefault();
            if(strucnoLiceA.Autorizacija == "StrucnoLice"){
            try
            {

                var plan2 = Context.Planovi.Where(p => p.NazivPlana == nazivPlana).FirstOrDefault();
                if (plan2 != null)
                {
                    return BadRequest("Plan vec postoji");
                }             
                if (string.IsNullOrWhiteSpace(nazivPlana))
                {
                    return BadRequest("Niste uneli naziv plana");
                }
                if (nazivPlana.Length > 50)
                {
                    return BadRequest("Uneli ste predugacko ime");
                }
                var strucnoLice = await Context.StrucnaLIca.FindAsync(idStrucnogLica);
                Plan plan = new Plan();
                plan.NazivPlana=nazivPlana;
                plan.Oblast=oblast;
                plan.Cena=cenaPlana;
                plan.OpisPlana=opisPlana;
                plan.IdStrucnogLice=idStrucnogLica; // ovo sam poslednje dodao
                plan.PlanStrucnjak=strucnoLice;
                if(plan!= null){                          
                Context.Planovi.Add(plan);
                await Context.SaveChangesAsync();
                return Ok();
                }
                else 
                {
                    return BadRequest("Neuspesno kreiranje plana");
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

        [Route("IsplatiNovac/{idStrucnogLica}/{kolicinaNovca}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> StrucnoLiceIsplatiNovac(int idStrucnogLica, int kolicinaNovca)
        {
            var strucnoLice2 = Context.StrucnaLIca.Where(p => p.ID == idStrucnogLica).FirstOrDefault();
            if(strucnoLice2.Autorizacija == "StrucnoLice"){
            if (strucnoLice2 == null)
            {
                return BadRequest("Strucno lice ne postoji");
            }
             if (strucnoLice2.KolicinaNovca < kolicinaNovca)
            {
                return BadRequest("Nemate dovoljno novca");
            }
            try
            {
                var strucnoLiceZaPromenu = await Context.StrucnaLIca.FindAsync(strucnoLice2.ID);
                strucnoLiceZaPromenu.KolicinaNovca = strucnoLiceZaPromenu.KolicinaNovca - kolicinaNovca;
                await Context.SaveChangesAsync();
                return Ok("Uspesna isplata");
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