//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using MobileShop.Data;
//using MobileShop.Models;

//namespace MobileShop.Core
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class MobileBusinessLogicLayer
//    {
//        private readonly MobileShopDBContext dBContext;

//        public MobileBusinessLogicLayer()
//        {

//        }
//        public MobileBusinessLogicLayer(MobileShopDBContext dBContext)
//        {
//            this.dBContext = dBContext;
//        }
//        [HttpGet]
//        public Task<List<Mobiles>> GetMobiles()
//        {
//            return dBContext.Mobile.ToListAsync();
           
//        }
//        [HttpPost]
//        public async Task<IActionResult> AddMobiles([FromBody] AddMobiles addMobiles)
//        {
//            var mobiles = new Mobiles()
//            {
//                Id = Guid.NewGuid(),
//                ModelName = addMobiles.ModelName,
//                ModelNumber = addMobiles.ModelNumber,
//                Price = addMobiles.Price

//            };
//            await dBContext.Mobile.AddAsync(mobiles);
//            await dBContext.SaveChangesAsync();
//            return Ok(mobiles);
//        }
//        [HttpPut]
//        [Route("{id:Guid}")]
//        public async Task<IActionResult> UpdateMobile([FromRoute] Guid id, Mobiles mobiles)
//        {
//            var result = await dBContext.Mobile.FindAsync(id);
//            if (result == null)
//            {
//                return NotFound();
//            }
//            result.ModelName = mobiles.ModelName;
//            result.ModelNumber = mobiles.ModelNumber;
//            result.Price = mobiles.Price;
//            await dBContext.SaveChangesAsync();
//            return Ok(result);

//        }

//    }
//}
