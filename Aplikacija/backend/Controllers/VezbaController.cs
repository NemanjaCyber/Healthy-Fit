using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Aplikacija_swe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VezbaController : ControllerBase
    {

        public SajtContext Context {get; set;}
        public VezbaController(SajtContext context)
        {
            Context = context;
        }

        // [Route("GetVezba")]
        // [HttpGet]
        // public ActionResult Preuzmi()
        // {
        //     var vezbe = Context.Vezbe;
           
        //     return Ok(vezbe);
        // }

        // [Route("AddVezba")]
        // [HttpPost]
        // public async Task<ActionResult> AddVezba ([FromBody] Vezba vezba)
        // {
        //     try
        //     {

        //         var vezba2 = Context.Vezbe.Where(p => p.Opis == vezba.Opis).FirstOrDefault();
        //         if (vezba2 != null)
        //         {
        //             return BadRequest("Vezba vec postoji");
        //         }             
        //         if (string.IsNullOrWhiteSpace(vezba.Opis))
        //         {
        //             return BadRequest("Niste uneli opis");
        //         }
              

        //         Context.Vezbe.Add(vezba);
        //         await Context.SaveChangesAsync();
        //         return Ok($"Sve ok! ID je: {vezba.ID}");
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }

        // }

        // [Route("ChangeVezba")]
        // [HttpPut]
        // public async Task<ActionResult> ChangeVezba([FromBody] Vezba vezba)
        // {
        //     var vezba2 = Context.Vezbe.Where(p => p.ID == vezba.ID).FirstOrDefault();
        //     if (vezba2 == null)
        //     {
        //         return BadRequest("Vezba ne postoji");
        //     }
        //     try
        //     {
        //         var vezbaZaPromenu = await Context.Vezbe.FindAsync(vezba2.ID);
        //         vezbaZaPromenu.Dan = vezba.Dan;
        //         vezbaZaPromenu.BrojPonavljanja = vezba.BrojPonavljanja;
        //         vezbaZaPromenu.SlikaPutanja = vezba.SlikaPutanja;
        //         vezbaZaPromenu.Opis = vezba.Opis;
        //         vezbaZaPromenu.PeriodDanaKadaSeVezbaIzvodi=vezba.PeriodDanaKadaSeVezbaIzvodi;

        //         await Context.SaveChangesAsync();
        //         return Ok("Vezba je uspesno izmenjena");
        //     }

        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        // [Route("DeleteVezba/{id}")]
        // [HttpDelete]

        // public async Task<ActionResult> DeleteVezba(int id)
        // {
        //     var vezba2 = Context.Vezbe.Where(p => p.ID == id).FirstOrDefault();
        //     if (vezba2 == null)
        //     {
        //         return BadRequest("Vezba ne postoji");
        //     }
        //     try
        //     {
        //         var vezba = await Context.Vezbe.FindAsync(vezba2.ID);
        //         Context.Vezbe.Remove(vezba);
        //         await Context.SaveChangesAsync();
        //         return Ok("Uspesno izbrisana vezba");
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

    }
}