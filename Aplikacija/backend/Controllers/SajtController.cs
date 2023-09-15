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
    public class SajtController : ControllerBase
    {

        public SajtContext Context {get; set;}
        public SajtController(SajtContext context)
        {
            Context = context;
        }

        // [Route("GetSajt")]
        // [HttpGet]
        // public ActionResult Preuzmi()
        // {
        //     var sajt = Context.Sajt;
           
        //     return Ok(sajt);
        // }

        // [Route("AddSajt")]
        // [HttpPost]
        // public async Task<ActionResult> AddSajt ([FromBody] Sajt sajt)
        // {
        //     try
        //     {

        //         var sajt2 = Context.Sajt.Where(p => p.Naziv == sajt.Naziv).FirstOrDefault();
        //         if (sajt2 != null)
        //         {
        //             return BadRequest("Sajt vec postoji");
        //         }             
        //         if (string.IsNullOrWhiteSpace(sajt.Naziv))
        //         {
        //             return BadRequest("Niste uneli naziv sajta");
        //         }
        //         if (sajt.Naziv.Length > 50)
        //         {
        //             return BadRequest("Uneli ste predugacko ime");
        //         }
              

        //         Context.Sajt.Add(sajt);
        //         await Context.SaveChangesAsync();
        //         return Ok($"Sve ok! ID je: {sajt.ID}");
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }

        // }

        // [Route("DeleteSajt/{id}")]
        // [HttpDelete]

        // public async Task<ActionResult> DeleteSajt(int id)
        // {
        //     var sajt2 = Context.Sajt.Where(p => p.ID == id).FirstOrDefault();
        //     if (sajt2 == null)
        //     {
        //         return BadRequest("Sajt ne postoji");
        //     }
        //     try
        //     {
        //         var sajt = await Context.Sajt.FindAsync(sajt2.ID);
        //         Context.Sajt.Remove(sajt);
        //         await Context.SaveChangesAsync();
        //         return Ok("Uspesno izbrisan sajt");
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

    }
}
