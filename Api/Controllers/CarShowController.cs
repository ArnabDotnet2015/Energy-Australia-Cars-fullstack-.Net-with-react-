using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Domains.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarShowController : ControllerBase
    {
        private ICarShowService _carShowService { get; set; }
        /// <summary>Initializes a new instance of the <see cref="CarShowController"/> class.</summary>
        /// <param name="carShowService">The car show service.</param>
        public CarShowController(ICarShowService carShowService)
        {
            _carShowService = carShowService;
        }

        /// <summary>Gets the make asynchronously.</summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<IList<Make>> GetMakeAsync()
        {
            return await _carShowService.GetCarShows();
        }
    }
}