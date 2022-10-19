using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileShop.Data;
using MobileShop.Models;

namespace MobileShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaptopController : Controller
    {
        private readonly MobileShopDBContext dBContext;

        public LaptopController(MobileShopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetLaptops()
        {
            var laptops =await dBContext.Laptops.ToListAsync();
            return Ok(laptops);
        }
        [HttpPost]
        public async Task<IActionResult> AddLaptops([FromBody] AddLaptops addLaptops)
        {
            var laptops = new Laptops()
            {
                Id = Guid.NewGuid(),
                ModelName = addLaptops.ModelName,
                ModelNumber = addLaptops.ModelNumber,
                Price = addLaptops.Price,
            };
            var result=await dBContext.Laptops.AddAsync(laptops);
            await dBContext.SaveChangesAsync();
            return Ok(result);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateLaptop([FromRoute] Guid id, Laptops laptops)
        {
            var laptop = await dBContext.Laptops.FindAsync(id);
            if(laptop == null)
            {
                return NotFound();
            }
            laptop.ModelName = laptops.ModelName;
            laptop.ModelNumber = laptops.ModelNumber;
            laptop.Price = laptops.Price;
            var result= await dBContext.AddAsync(laptop);
            await dBContext.SaveChangesAsync();
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteLaptop([FromRoute] Guid id)
        {
            var laptop = await dBContext.Laptops.FindAsync(id);
            if(laptop==null)
            {
                return NotFound();
            }
            var result = dBContext.Laptops.Remove(laptop);
            await dBContext.SaveChangesAsync();
            return Ok(result);
        }
    }
}
