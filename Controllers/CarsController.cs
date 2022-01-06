namespace PrintecExam.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    using PrintecExam.Services;
    using PrintecExam.Services.Models;

    [ApiController]
    [Route("cars")]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carsService;
        private readonly IMakesService _makeService;

        public CarsController(
            ICarsService carsService,
            IMakesService makeService)
        {
            _carsService = carsService;
            _makeService = makeService;
        }

        [HttpGet]
        [Route("getByMake")]
        public IEnumerable<CarServiceModel> GetAllByMake(string make)
        {
            var cars = _carsService
                .GetAllByMake(make);

            return cars;
        }

        [HttpGet]
        [Route("getbyid")]
        public IActionResult GetById(string id)
        {
            var car = _carsService.GetById(id);

            return this.Ok(car);
        }

        //more get options

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CarCreateServiceModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            await this._carsService.CreateAsync(data);

            return this.Ok("Created");
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromForm] CarEditServiceModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            await this._carsService.EditAsync(data);

            return this.Ok("Updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await this._carsService.DeleteAsync(id);

            return this.Ok("Deleted");
        }

        [HttpGet]
        [Route("makes")]
        public IEnumerable<MakeServiceModel> GetMakes()
        {
            var makes = _makeService.GetAll();

            return makes;
        }
    }
}
