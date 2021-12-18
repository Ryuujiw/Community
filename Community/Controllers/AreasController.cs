using Community.Models.Map;
using Community.Services;
using Microsoft.AspNetCore.Mvc;

namespace Community.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreasController : ControllerBase
    {
        private readonly ILogger<AreasController> _logger;
        private readonly IAreaService _areaService;

        public AreasController(ILogger<AreasController> logger, IAreaService areaService)
        {
            _logger = logger;
            _areaService = areaService;
        }

        [HttpGet]
        public async Task<IEnumerable<Area>> Get()
        {
            return await _areaService.All();
        }
    }
}
