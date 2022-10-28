using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doughnut.Domain.DomainModels.Referential;

namespace Doughnut.Domain.Interface.DomainService
{
    public interface IRefSelectionDomainService
    {
        Task<RefSelectionProcess> GetSelectionProcessAsync();
        Task<RefSelectionProcess> GetSelectionProcessAsync(int code);
    }
}
