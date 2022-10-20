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


    }
}
