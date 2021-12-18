using Community.Models.Map;
using Community.Services;
using Microsoft.AspNetCore.Mvc;

namespace Community.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreesController : ControllerBase
    {
        private readonly ILogger<TreesController> _logger;
        private readonly ITreeService _treeService;

        public TreesController(ILogger<TreesController> logger, ITreeService treeService)
        {
            _logger = logger;
            _treeService = treeService;
        }

        [HttpGet]
        public async Task<IEnumerable<Tree>> Get()
        {
            return await _treeService.All();
        }
    }
}