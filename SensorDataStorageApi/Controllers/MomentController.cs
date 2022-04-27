using Microsoft.AspNetCore.Mvc;
using SensorDataStorageApi.Models;
using SensorDataStorageApi.Services;

namespace SensorDataStorageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MomentController : ControllerBase
    {
        private readonly MomentService _momentService;

        public MomentController(MomentService momentService)
        {
            _momentService = momentService;
        }

        [HttpPost]
        public IActionResult Create(Moment moment)
        {
            _momentService.Create(moment);
            return NoContent();
        }
    }
}
