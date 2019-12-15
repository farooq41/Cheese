using System;
using System.Threading.Tasks;
using CheeseModel;
using CheeseService;
using Microsoft.AspNetCore.Mvc;

namespace CheeseWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheeseController : ControllerBase
    {
        private ICheeseService _cheeseService;

        public CheeseController(ICheeseService cheeseService)
        {
            _cheeseService = cheeseService;
        }

        // GET: api/cheese/allCheese
        [HttpGet("allCheese")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _cheeseService.GetCheeses();
            return Ok(result);
        }

        // GET: api/cheese/create
        [HttpPost("create"), DisableRequestSizeLimit]
        public async Task<IActionResult> CreateCheese()
        {
            var cheeseInput = new Cheese();
            cheeseInput.Picture = new CheesePicture() { Image = Request.Form.Files[0] };
            cheeseInput.Name = Request.Form["Name"];
            cheeseInput.Description = Request.Form["Description"];
            cheeseInput.Price = Convert.ToInt32(Request.Form["Price"]);
            
            var result = await _cheeseService.CreateCheese(cheeseInput);

            if (result)
                return Ok();
            else
                return StatusCode(500);
        }

        // GET: api/cheese/update
        [HttpPut("update"), DisableRequestSizeLimit]
        public async Task<IActionResult> UpdateCheese()
        {
            var cheeseInput = new Cheese();
            cheeseInput.Picture = new CheesePicture() { Image = Request.Form.Files[0] };
            cheeseInput.Name = Request.Form["Name"];
            cheeseInput.Description = Request.Form["Description"];
            cheeseInput.Price = Convert.ToInt32(Request.Form["Price"]);

            var result = await _cheeseService.UpdateCheese(cheeseInput);

            if (result)
                return Ok();
            else
                return StatusCode(500);
        }

        // GET: api/cheese/delete/id
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCheese(int id)
        {
            var result = await _cheeseService.DeleteCheese(id);

            if (result)
                return Ok();
            else
                return StatusCode(500);
        }
    }
}
