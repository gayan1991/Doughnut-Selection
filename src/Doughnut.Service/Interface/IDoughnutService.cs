using Doughnut.Service.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doughnut.Service.Interface
{
    public interface IDoughnutService
    {
        Task<SuccessDto> GetSelectionTree();
        Task<SuccessDto> GetSelectionTree(int code);
    }
}
