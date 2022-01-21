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
            if (kBar != null) {
                Context.KBarovi.Add(kBar);
                await Context.SaveChangesAsync();
            }
            else {
                BadRequest("Bar nije pronadjen!");
            }
            
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
            if (kBar != null) {
                Context.KBarovi.Remove(kBar);
                await Context.SaveChangesAsync();
            }
            else {
                BadRequest ("Bar nije pronadjen!");
            }
            
        }

        [Route("ZauzmiSto/{id}")]
        [HttpPost]
        public async Task<IActionResult>  ZauzmiSto(int id, [FromBody] Sto sto)
        {
            
            var kBar= await Context.KBarovi.FindAsync(id);
            if (kBar != null) {
                sto.KoktelBar=kBar;
            }
            else {
                BadRequest ("Bar nije pronadjen!");
            }

            var sto_pret= await Context.Stolovi.Where(s=> s.BrojStola==sto.BrojStola && s.KoktelBar.ID==id).FirstOrDefaultAsync();
            if(sto_pret!=null)
            {
                return StatusCode(406); // not acceptable

            }
            else{
                Context.Stolovi.Add(sto);
                // Context.Add(sto);
                await Context.SaveChangesAsync();
                return Ok();
            }


        }

        [Route("OslobodiSto/{br}/{id}")]
        [HttpDelete]
        public async Task OslobodiSto(int br, int id)
        {
            var sto= await Context.Stolovi.Where(s=> s.BrojStola==br && s.KoktelBar.ID==id).FirstOrDefaultAsync();
            if (sto != null) {
                Context.Stolovi.Remove(sto);
                await Context.SaveChangesAsync();
            }
            else {
                BadRequest("Sto nije pronadjen!");
            }
            
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
            if (sto != null) {
                sto.Ime=ime;
                sto.Prezime=prezime;
                sto.KapacitetStola=brljudi;
                await Context.SaveChangesAsync();
            }
            else {
                BadRequest("Sto nije pronadjen!");
            }

        }

        [Route("DodajPorudzbinu/{id}")]
        [HttpPost]
        public async Task DodajPorudzbinu(int id, [FromBody]Porudzbina por)
        {
            var kBar = await Context.KBarovi.FindAsync(id);
            if (kBar != null) {
                por.KoktelBar = kBar;
                Context.Porudzbine.Add(por);
                await Context.SaveChangesAsync();
            }
            else {
                BadRequest ("Bar nije pronadjen!");
            }
            
        }

        [Route("OtkaziPorudzbinu/{br}")]
        [HttpDelete]
        public async Task OtkaziPorudzbinu(int br)
        {
            var por= await Context.Porudzbine.Where(p=>p.IDPorudzbine==br).FirstOrDefaultAsync();
            if (por != null) {
                Context.Porudzbine.Remove(por);
                await Context.SaveChangesAsync();
            }
            else {
                BadRequest ("Porudzbina nije pronadjena!");
            }
            

        }

        [Route("IzmeniPorudzbinu/{br}/{deserti}/{pice}")]
        [HttpPut]
        public async Task IzmeniPorudzbinu(int br, string deserti, string pice)
        {
            var por= await Context.Porudzbine.Where(p=>p.IDPorudzbine==br).FirstOrDefaultAsync();
            if (por != null) {
                por.Deserti=deserti;
                por.Pice=pice;
                await Context.SaveChangesAsync();
            }
            else {
                BadRequest("Porudzbina nije pronadjena!");
            }
            
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