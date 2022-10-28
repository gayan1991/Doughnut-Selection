using Doughnut.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Doughnut.Application.Controllers
{
    public class DoughnutController : ControllerBase
    {
        private readonly IDoughnutService _doughnutService;

        public DoughnutController(IDoughnutService doughnutService)
        {
            _doughnutService = doughnutService;
        }

        [HttpPost("")]
        public ActionResult SaveDoughnutSelection([FromBody] object obj)
        {
            return Ok(_doughnutService.u);
        }

        [HttpPatch("{id:guid}")]
        public ActionResult SaveDoughnutSelection(Guid id, [FromBody] object obj)
        {
            return Ok();
        }

        [HttpGet("")]
        public ActionResult GetDoughnut()
        {
            return Ok(_doughnutService.GetDoughnut());
        }

        [HttpPost("")]
        public ActionResult SaveDoughnutSelection([FromBody] object obj)
        {
            return Ok(_doughnutService.u);
        }
    }
}
