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
        public KoktelBarContext dbContext;
        public KoktelBarController(KoktelBarContext context){
            dbContext = context;
        }

        
        
    }
}