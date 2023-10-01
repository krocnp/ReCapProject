using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandsService;

        public BrandsController(IBrandService brandsService)
        {
            _brandsService = brandsService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll() 
        {
            var result = _brandsService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyıd")]
        public IActionResult GetdById(int id)
        {
            var result = _brandsService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandsService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandsService.Delete(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandsService.Update(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
