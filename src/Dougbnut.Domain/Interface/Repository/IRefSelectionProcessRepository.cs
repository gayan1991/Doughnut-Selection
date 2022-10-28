using Doughnut.Domain.DomainModels.Referential;

namespace Doughnut.Domain.Interface.Repository
{
    public interface IRefSelectionProcessRepository: IRepository<RefSelectionProcess>
    {
        Task<RefSelectionProcess?> GetSelectionBasedOnCodeAsync(int code);
    }
}
