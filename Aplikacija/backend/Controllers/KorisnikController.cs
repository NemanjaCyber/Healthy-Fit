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
    public class KorisnikController : ControllerBase
    {

        public SajtContext Context {get; set;}
        public KorisnikController(SajtContext context)
        {
            Context = context;
        }
        //Cisto za proveru podataka u bazi
         [Route("GetKorisniciSvi")]
        [HttpGet]
        public ActionResult PreuzmiSvi()
        {
            var korisnici = Context.Korisnici
            .Include(p => p.KorisniciPlanovi)
            .Include(q=> q.KorisniciKomentariIOcene);

            foreach (var korisnik in korisnici)
            {
                korisnik.Sifra=Encript.ConverToDecrypt(korisnik.Sifra);
            }
           
            return Ok(korisnici);
        }
        //Glavna f-ja za login
        [Route("GetKorisnici/{email}/{pass}")]
        [HttpGet]
        public ActionResult Preuzmi(string email,string pass)
        {
            var korisnici = Context.Korisnici
            .Include(p => p.KorisniciPlanovi)
            .Include(q=> q.KorisniciKomentariIOcene)
            .Where(p=> p.Email==email && p.Sifra==Encript.ConvertToEncrypt(pass));
           
            return Ok(korisnici);
        }
        
        [Route("GetKorisniciZaPrijemPoruka/{emailStrucnjaka}")]
        [HttpGet]
        public ActionResult GetKorisniciZaPrijemPoruka(string emailStrucnjaka)
        {
            var strucnoLice = Context.StrucnaLIca
            .Where(e => e.Email==emailStrucnjaka).FirstOrDefault();
            if(strucnoLice.Autorizacija == "StrucnoLice"){

            var korisnici = Context.Korisnici;
           
            return Ok(korisnici);
            }
            else{
                return Unauthorized();
            }
            
        }
        //nakon logina
        [Route("LogovaniKorisnik/{email}")]
        [HttpGet]
        public ActionResult Login(string email)
        {
            var korisnik = Context.Korisnici
            .Where(e => e.Email==email).FirstOrDefault();
            if(korisnik.Autorizacija == "Korisnik"){

             var korisnici = Context.Korisnici
                .Where(e => e.Email==email)
                .Include(p => p.KorisniciPlanovi)
                .ThenInclude(t => t.PlanObroci)
                .Include(p => p.KorisniciPlanovi)
                .ThenInclude(t => t.PlanVezbe);

            
           
            return Ok(korisnici);
            }
            else{
                return Unauthorized();
            }
        }
         //////////////////////
        [Route("KorisnikLogovanje/{email}")]
        [HttpPut]
        public async Task<ActionResult> KorisnikLogovanje(string email)/////Napravljeno da bude asink
        {
            var korisnici = Context.Korisnici
            .Where(e => e.Email==email);
           
             if(korisnici.Count() == 0){
            return BadRequest("Greska u reg");
           }
           else{
            var korisnik = Context.Korisnici
            .Where(e => e.Email==email).FirstOrDefault();
            korisnik.Autorizacija="Korisnik";
            await Context.SaveChangesAsync();

            return Ok();
           }
        }
        [Route("KorisnikLogOut/{email}")]
        [HttpPut]
        public async Task<ActionResult> LogOutKorisnik(string email)
        {
            var korisnici = Context.Korisnici
            .Where(e => e.Email==email);
           
             if(korisnici.Count() == 0){
            return BadRequest("Ne postoji korisnik");
           }
           else{
            var korisnik = Context.Korisnici
            .Where(e => e.Email==email).FirstOrDefault();
            korisnik.Autorizacija="";
            await Context.SaveChangesAsync();

            return Ok();
           }
        }
/////////////////

        [Route("PorukaKorisnika/{email}")]
        [HttpGet]
        public ActionResult PorukaKorisnika(string email)
        {
            var korisnik = Context.Korisnici
            .Where(e => e.Email==email).FirstOrDefault();
            if(korisnik.Autorizacija == "Korisnik"){

            var korisnici = Context.Korisnici
            .Where(e => e.Email==email)
            .Include(p => p.KorisniciPoruke);
            
           
            return Ok(korisnici);
            }
            else{
                return Unauthorized();
            }
        }

        [Route("ProveraRegistracije/{korisnickoIme}")]
        [HttpGet]
        public ActionResult ProveraReg(string korisnickoIme)
        {
            var korisnici = Context.Korisnici
            .Where(e => e.KorisnickoIme==korisnickoIme)
            .Include(p => p.KorisniciPlanovi)
            .Include(q=> q.KorisniciKomentariIOcene);
           
            return Ok(korisnici);
        }

        [Route("AddKorisnika")]
        [HttpPost]
        public async Task<ActionResult> AddKorisnik ([FromBody] Korisnik korisnik)
        {
            try
            {

                var korisnik2 = Context.Korisnici.Where(p => p.Email == korisnik.Email).FirstOrDefault();
                if (korisnik2 != null)
                {
                    return BadRequest("Korisnik vec postoji");
                }
                 if(string.IsNullOrWhiteSpace(korisnik.Email))
                {
                    return BadRequest("Niste uneli e-mail");
                }
                 if(string.IsNullOrWhiteSpace(korisnik.KorisnickoIme))
                {
                    return BadRequest("Niste uneli korisnicko ime");
                }
                 if(string.IsNullOrWhiteSpace(korisnik.Sifra))
                {
                    return BadRequest("Niste uneli sifru");
                }
                 if (string.IsNullOrWhiteSpace(korisnik.Ime))
                {
                    return BadRequest("Niste uneli ime");
                }
                 if (string.IsNullOrWhiteSpace(korisnik.Prezime))
                {
                    return BadRequest("Niste uneli prezime");
                }
                 if (string.IsNullOrWhiteSpace(korisnik.DatumRodjenja))
                {
                    return BadRequest("Niste uneli datum rodjenja");
                }
                 if (string.IsNullOrWhiteSpace(korisnik.Pol))
                {
                    return BadRequest("Niste uneli pol");
                }
                if (korisnik.Email.Length > 50)
                {
                    return BadRequest("Uneli ste nevalidan e-mail");
                }
                if (korisnik.KorisnickoIme.Length > 50)
                {
                    return BadRequest("Uneli ste predugacko korisnicko ime");
                }
                if (korisnik.Ime.Length > 50)
                {
                    return BadRequest("Uneli ste predugacko ime");
                }
                if (korisnik.Prezime.Length > 50)
                {
                    return BadRequest("Uneli ste predugacko prezime");
                }
                  if (korisnik.Sifra.Length < 8)
                {
                    return BadRequest("Uneli ste prekratku sifru");
                }
                if (!(Regex.Match(korisnik.Ime, "^[a-zA-Z0-9]+$")).Success)
                {
                    return BadRequest("Uneli ste nedozvoljen karakter");
                }
                if (!(Regex.Match(korisnik.Prezime, "^[a-zA-Z0-9]+$")).Success)
                {
                    return BadRequest("Uneli ste nedozvoljen karakter");
                }

                ////ENKRIPCIJA
                korisnik.Sifra= Encript.ConvertToEncrypt(korisnik.Sifra);
               
                Context.Korisnici.Add(korisnik);
                await Context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("ChangeKorisnik")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> ChangeKorisnik([FromBody] Korisnik korisnik)
        {
            var korisnik2 = Context.Korisnici.Where(p => p.Email == korisnik.Email).FirstOrDefault();
            if(korisnik2.Autorizacija == "Korisnik"){
            if (korisnik2 == null)
            {
                return BadRequest("Korisnik ne postoji");
            }
            try
            {
                var korisnikZaPromenu = await Context.Korisnici.FindAsync(korisnik2.ID);
                
                korisnikZaPromenu.Ime = korisnik.Ime;
                korisnikZaPromenu.Prezime = korisnik.Prezime;
                korisnikZaPromenu.Email = korisnik.Email;
                korisnikZaPromenu.DatumRodjenja = korisnik.DatumRodjenja;
                korisnikZaPromenu.KorisnickoIme = korisnik.KorisnickoIme;
                korisnikZaPromenu.Pol = korisnik.Pol;
                korisnikZaPromenu.Slika = korisnik.Slika; // ovo
                if(korisnik.Sifra!=korisnikZaPromenu.Sifra){
                korisnikZaPromenu.Sifra = Encript.ConvertToEncrypt(korisnik.Sifra); 
                }else{
                korisnikZaPromenu.Sifra = korisnik.Sifra;
                }
               
               
                

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
        [Route("DeleteKorisnikLicno/{korisnickoIme}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult> DeleteKorisnikLicno(string korisnickoIme)
        {
            
            var korisnik2 = Context.Korisnici.Where(p => p.KorisnickoIme == korisnickoIme).FirstOrDefault();
            if (korisnik2 == null)
            {
                return BadRequest("Korisnik ne postoji");
            }
            if(korisnik2.Autorizacija == "Korisnik"){
            try
            {
                var Korisnik = await Context.Korisnici.FindAsync(korisnik2.ID);
                Context.Korisnici.Remove(Korisnik);
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

        [Route("DeleteKorisnik/{korisnickoIme}/{adminEmail}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult> DeleteKorisnik(string korisnickoIme, string adminEmail)
        {
            var admin = Context.Admini.Where(p => p.Email == adminEmail).FirstOrDefault();
            if(admin.Autorizacija == "Admin"){ 
            var korisnik2 = Context.Korisnici.Where(p => p.KorisnickoIme == korisnickoIme).FirstOrDefault();
            if (korisnik2 == null)
            {
                return BadRequest("Korisnik ne postoji");
            }
            try
            {
                var Korisnik = await Context.Korisnici.FindAsync(korisnik2.ID);
                Context.Korisnici.Remove(Korisnik);
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

        [Route("KorisnikOtkaziPlan/{nazivPlana}/{korisnikId}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> KorisnikOtkaziPlan(string nazivPlana, int korisnikId)
        {
            var korisnik2 = Context.Korisnici.Where(p => p.ID == korisnikId).FirstOrDefault();
            if(korisnik2.Autorizacija == "Korisnik"){
            var plan2 = Context.Planovi.Where(p => p.NazivPlana == nazivPlana).FirstOrDefault();
            if (plan2 == null)
            {
                return BadRequest("Plan ne postoji");
            }
            try
            {
                var korisnik = Context.Korisnici.Where(p => p.ID == korisnikId).FirstOrDefault();
                var planZaPromenu = Context.Planovi.Include(q => q.PlanoviKorisnici).Where(p => p.NazivPlana == nazivPlana).FirstOrDefault();
                planZaPromenu.PlanoviKorisnici.Remove(korisnik); //= null;
         
                

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


 

        [Route("KupovinaPlanaKorisniku/{nazivPlana}/{idKorisnika}/{idStrucnogLica}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> KupovinaPlanaKorisniku (string nazivPlana,int idKorisnika, int idStrucnogLica)
        {
            var korisnik2 = Context.Korisnici.Where(p => p.ID == idKorisnika).FirstOrDefault();
            if(korisnik2.Autorizacija == "Korisnik"){
            try
            {
                
                var plan2 = Context.Planovi.Where(p => p.NazivPlana == nazivPlana).FirstOrDefault();
                if (plan2 == null)
                {
                    return BadRequest("Plan ne postoji");
                }             
                if (string.IsNullOrWhiteSpace(nazivPlana))
                {
                    return BadRequest("Niste uneli naziv plana");
                }
                if (nazivPlana.Length > 50)
                {
                    return BadRequest("Uneli ste predugacko ime");
                }
                ///dodavanje plana kod korisnika
                var korisnik = Context.Korisnici.Where(p => p.ID == idKorisnika).FirstOrDefault();
                var planZaKorisnika = Context.Planovi.Include(q => q.PlanoviKorisnici).Where(p => p.NazivPlana == nazivPlana).FirstOrDefault();
                planZaKorisnika.PlanoviKorisnici.Add(korisnik);
                //// uzme mu pare
                var korisnikZaPromenu = await Context.Korisnici.FindAsync(idKorisnika);
                korisnikZaPromenu.KolicinaNovca=  korisnikZaPromenu.KolicinaNovca - planZaKorisnika.Cena;
                /// da pare strucnom licu
                var strucnoLice = await Context.StrucnaLIca.FindAsync(idStrucnogLica);
                strucnoLice.KolicinaNovca=  strucnoLice.KolicinaNovca + planZaKorisnika.Cena;

                await Context.SaveChangesAsync();
                return Ok("Plan je uspesno kupljen");
              
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

        [Route("UplatiNovac/{idKorisnika}/{kolicinaNovca}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> KorisnikUplatiNovac(int idKorisnika, int kolicinaNovca)
        {
            var korisnik2 = Context.Korisnici.Where(p => p.ID == idKorisnika).FirstOrDefault();
            if (korisnik2 == null)
            {
                return BadRequest("Korisnik ne postoji");
            }
            if(korisnik2.Autorizacija == "Korisnik"){
            try
            {
                var korisnikZaPromenu = await Context.Korisnici.FindAsync(korisnik2.ID);
                korisnikZaPromenu.KolicinaNovca = korisnikZaPromenu.KolicinaNovca + kolicinaNovca;
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

        [Route("pregledStrucnihLicaKorisnika/{emailKorisnika}")]
        [HttpGet]
        public ActionResult Preuzmi(string emailKorisnika)
        {
            var korisnik = Context.Korisnici
            .Where(e => e.Email==emailKorisnika).FirstOrDefault();
            if(korisnik.Autorizacija == "Korisnik"){

            var strucnaLica = Context.StrucnaLIca
            .Where(e => e.OdobrenjeAdmina==true)
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
        




    }
}