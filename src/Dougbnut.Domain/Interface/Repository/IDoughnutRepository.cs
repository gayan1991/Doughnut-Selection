using Doughnut.Domain.DomainModels.DoughnutSelection;
using Doughnut.Domain.Util;

namespace Doughnut.Domain.Interface.Repository
{
    public interface IDoughnutRepository : IRepository<DoughnutSelection>
    {
        Task UpsertDoughnutSelectionAsync(DoughnutSelection selection);
        Task<bool> IsSelectionPendingForUserAsync(Guid userId);
        Task<List<DoughnutSelection>> GetAllPendingSelectionsAsync();
        Task<DoughnutSelection?> GetDoughnutSelectionByUserAsync(Guid userId);
        Task<List<DoughnutSelection>> GetAllDoughnutSelectionByStepAsync(SelectionSteps selection);
    }
}
