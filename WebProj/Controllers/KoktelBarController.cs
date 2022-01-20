using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProj.Models;

namespace WebProj.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class KoktelBarController : ControllerBase{
        public KoktelBarContext Context;
        public KoktelBarController(KoktelBarContext context){
            Context = context;
        }

        [Route("PreuzmiKoktelBar")]
        [HttpGet]
        public async Task<List<KoktelBar>> PreuzmiKoktelBar()
        {
            return await Context.KBarovi.Include(p=>p.Stolovi)
                                        .Include(p=>p.Porudzbine)
                                        .ToListAsync();
        }

        [Route("UpisiKoktelBar")]
        [HttpPost]
        public async Task UpisiKoktelBar([FromBody] KoktelBar kBar)
        {
            Context.KBarovi.Add(kBar);
            await Context.SaveChangesAsync();
        }

        [Route("IzmeniKoktelBar")]
        [HttpPut]
        public async Task IzmeniKoktelBar([FromBody] KoktelBar kBar)
        {
            Context.KBarovi.Update(kBar);
            await Context.SaveChangesAsync();

        }

        [Route("IzbrisiKoktelBar/{id}")]
        [HttpDelete]
        public async Task IzbrisiKoktelBar(int id)
        {
            var kBar = await Context.KBarovi.FindAsync(id);
            Context.KBarovi.Remove(kBar);
            await Context.SaveChangesAsync();
        }

        [Route("ZauzmiSto/{id}")]
        [HttpPost]
        public async Task<IActionResult>  ZauzmiSto(int id, [FromBody] Sto sto)
        {
            
            var kBar= await Context.KBarovi.FindAsync(id);
            sto.KoktelBar=kBar;
            var sto_pret= await Context.Stolovi.Where(s=> s.BrojStola==sto.BrojStola && s.KoktelBar.ID==id).FirstOrDefaultAsync();
            if(sto_pret!=null)
            {
                 return StatusCode(406);

            }
            else{
                Context.Stolovi.Add(sto);
                await Context.SaveChangesAsync();
                return Ok();
            }
            
            //Context.Stolovi.Add(sto);
            //await Context.SaveChangesAsync();

        }

        [Route("OslobodiSto/{br}/{id}")]
        [HttpDelete]
        public async Task OslobodiSto(int br, int id)
        {
            var sto= await Context.Stolovi.Where(s=> s.BrojStola==br && s.KoktelBar.ID==id).FirstOrDefaultAsync();
            Context.Stolovi.Remove(sto);
            await Context.SaveChangesAsync();
        }

        // [Route("OslobodiSto/{br}/{id}")]
        // [HttpDelete]
        // public async Task OslobodiSto(int br, int id)
        // {
        //     var sto= await Context.Stolovi.Where(s=> s.BrojStola==br && s.KoktelBar.ID==null).FirstOrDefaultAsync();
        //     Context.Stolovi.Remove(sto);
        //     await Context.SaveChangesAsync();
        // }


        [Route("IzmeniSto/{br}/{ime}/{prezime}/{brljudi}")]
        [HttpPut]
        public async Task IzmeniSto(int br, string ime, string prezime, int brljudi)
        {
            var sto= await Context.Stolovi.Where(s=> s.BrojStola==br).FirstOrDefaultAsync();
            sto.Ime=ime;
            sto.Prezime=prezime;
            sto.KapacitetStola=brljudi;
            await Context.SaveChangesAsync();

        }

        [Route("DodajPorudzbinu/{id}")]
        [HttpPost]
        public async Task DodajPorudzbinu(int id, [FromBody]Porudzbina por)
        {
            var kBar = await Context.KBarovi.FindAsync(id);
            por.KoktelBar = kBar;
            Context.Porudzbine.Add(por);
            await Context.SaveChangesAsync();
        }

        [Route("OtkaziPorudzbinu/{br}")]
        [HttpDelete]
        public async Task OtkaziPorudzbinu(int br)
        {
            var por= await Context.Porudzbine.Where(p=>p.IDPorudzbine==br).FirstOrDefaultAsync();
            Context.Porudzbine.Remove(por);
            await Context.SaveChangesAsync();

        }

        [Route("IzmeniPorudzbinu/{br}/{deserti}/{pice}")]
        [HttpPut]
        public async Task IzmeniPorudzbinu(int br, string deserti, string pice)
        {
            var por= await Context.Porudzbine.Where(p=>p.IDPorudzbine==br).FirstOrDefaultAsync();
            por.Deserti=deserti;
            por.Pice=pice;
            await Context.SaveChangesAsync();
        }

        [Route("PreuzmiStolove/{idStola}")]
        [HttpGet]
        public async Task<List<Sto>> PreuzmiStolove(int id)
        {
            return await Context.Stolovi.Where(sto=>sto.KoktelBar.ID==id).ToListAsync();
        }

        [Route("PreuzmiStolove1")]
        [HttpGet]
        public async Task<List<Sto>> PreuzmiStolove1()
        {
            return await Context.Stolovi.ToListAsync();
        }
        
    }
}