using Carseer.Services.Dto;
using Carseer.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace CarseerAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarModelController : ControllerBase
    {
        private readonly ICarModelService _carModelService;

        public CarModelController(ICarModelService carModelService)
        {
            _carModelService = carModelService;
        }

        [HttpGet]
        public async Task<List<CarModelDto>> GetCarModels([FromQuery] int makeId, [FromQuery]  int modelYear)
        {
            return await _carModelService.GetCarModelAsync(makeId, modelYear);
        }
    }
}
