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
    public class ObrokController : ControllerBase
    {

        public SajtContext Context {get; set;}
        public ObrokController(SajtContext context)
        {
            Context = context;
        }

        // [Route("GetObrok")]
        // [HttpGet]
        // public ActionResult Preuzmi()
        // {
        //     var obroci = Context.Obroci;
           
        //     return Ok(obroci);
        // }

        // [Route("AddObrok")]
        // [HttpPost]
        // public async Task<ActionResult> AddObrok ([FromBody] Obrok obrok)
        // {
        //     try
        //     {

        //         var obrok2 = Context.Obroci.Where(p => p.Opis == obrok.Opis).FirstOrDefault();
        //         if (obrok2 != null)
        //         {
        //             return BadRequest("Obrok vec postoji");
        //         }             
        //         if (string.IsNullOrWhiteSpace(obrok.Opis))
        //         {
        //             return BadRequest("Niste uneli opis");
        //         }
        //         /// odavde na dole
        //         if (string.IsNullOrWhiteSpace(obrok.Dan))
        //         {
        //             return BadRequest("Niste uneli dan");
        //         }
        //         if (string.IsNullOrWhiteSpace(obrok.TipObroka))
        //         {
        //             return BadRequest("Niste uneli tip obroka");
        //         }
        //         ///
              

        //         Context.Obroci.Add(obrok);
        //         await Context.SaveChangesAsync();
        //         return Ok($"Sve ok! ID je: {obrok.ID}");
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }

        // }

        // [Route("ChangeObrok")]
        // [HttpPut]
        // public async Task<ActionResult> ChangeObrok([FromBody] Obrok obrok)
        // {
        //     var obrok2 = Context.Obroci.Where(p => p.ID == obrok.ID).FirstOrDefault();
        //     if (obrok2 == null)
        //     {
        //         return BadRequest("Obrok ne postoji");
        //     }
        //     try
        //     {
        //         var obrokZaPromenu = await Context.Obroci.FindAsync(obrok2.ID);
        //         obrokZaPromenu.Dan = obrok.Dan;
        //         obrokZaPromenu.TipObroka = obrok.TipObroka;
        //         obrokZaPromenu.SlikaPutanja = obrok.SlikaPutanja;
        //         obrokZaPromenu.Opis = obrok.Opis;
                

        //         await Context.SaveChangesAsync();
        //         return Ok("Obrok je uspesno izmenjen");
        //     }

        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        // [Route("DeleteObrok/{id}")]
        // [HttpDelete]

        // public async Task<ActionResult> DeleteObrok(int id)
        // {
        //     var obrok2 = Context.Obroci.Where(p => p.ID == id).FirstOrDefault();
        //     if (obrok2 == null)
        //     {
        //         return BadRequest("Obrok ne postoji");
        //     }
        //     try
        //     {
        //         var obrok = await Context.Obroci.FindAsync(obrok2.ID);
        //         Context.Obroci.Remove(obrok);
        //         await Context.SaveChangesAsync();
        //         return Ok("Uspesno izbrisan obrok");
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

    }
}