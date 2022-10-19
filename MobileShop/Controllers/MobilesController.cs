using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileShop.Data;
using MobileShop.Models;
using System.Data.Common;

namespace MobileShop.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class MobilesController : Controller
    {
        private readonly MobileShopDBContext dBContext;

        public MobilesController(MobileShopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetMobiles()
        {
            var result = await dBContext.Mobiles.ToListAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddMobiles([FromBody] AddMobiles addMobiles)
        {
            var mobiles = new Mobiles()
            {
                Id = Guid.NewGuid(),
                ModelName = addMobiles.ModelName,
                ModelNumber = addMobiles.ModelNumber,
                Price = addMobiles.Price

            };
            var result=await dBContext.Mobiles.AddAsync(mobiles);
            await dBContext.SaveChangesAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateMobile([FromRoute] Guid id, Mobiles mobiles)
        {
            var result = await dBContext.Mobiles.FindAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            result.ModelName = mobiles.ModelName;
            result.ModelNumber = mobiles.ModelNumber;
            result.Price = mobiles.Price;
            await dBContext.SaveChangesAsync();
            return Ok(result);

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteMobile([FromRoute] Guid id)
        {
            var mobile = await dBContext.Mobiles.FindAsync(id);
            if (mobile == null)
            {
                return NotFound();
            }
             dBContext.Mobiles.Remove(mobile);
            await dBContext.SaveChangesAsync();
            return Ok(mobile);

        }


    }
}
