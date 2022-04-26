using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        //Gevşek bağımlılık
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getallcarimages")]
        public IActionResult GetAllCarImages()
        {
            var result = _carImageService.GetAllCarImages();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallcarimagesbycarid")]
        public IActionResult GetAllCarImagesByCarId(int carId)
        {
            var result = _carImageService.GetAllCarImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete( [FromForm] CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile formFile, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(carImage, formFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); 
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name ="Image")] IFormFile formFile, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(carImage, formFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
