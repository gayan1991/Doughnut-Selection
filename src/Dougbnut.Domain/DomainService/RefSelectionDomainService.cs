using Doughnut.Domain.DomainModels.Referential;
using Doughnut.Domain.Interface.DomainService;
using Doughnut.Domain.Interface.Repository;
using Doughnut.Domain.Util.Exceptions;

namespace Doughnut.Domain.DomainService
{
    public class RefSelectionDomainService : IRefSelectionDomainService
    {
        private readonly IRefSelectionProcessRepository _repository;

        public RefSelectionDomainService(IRefSelectionProcessRepository repository)
        {
            _repository = repository;
        }

        public Task<RefSelectionProcess> GetSelectionProcessAsync()
        {
            return GenerateTreeBasedOnSelectionCodeAsync();
        }

        public Task<RefSelectionProcess> GetSelectionProcessAsync(int code)
        {
            return GenerateTreeBasedOnSelectionCodeAsync(code);
        }

        #region Private

        private async Task<RefSelectionProcess> GenerateTreeBasedOnSelectionCodeAsync(int code = 0)
        {
            var selection = await _repository.GetSelectionBasedOnCodeAsync(code);

            if (selection == null)
            {
                throw new NotFoundException("Requested code is not found");
            }

            await PopulateChildSelections(selection);
            return selection;
        }

        private async Task PopulateChildSelections(RefSelectionProcess selection)
        {
            var selectionList = await _repository.GetAllAsync(x => x.ParentCode == selection.Code);

            foreach (var item in selectionList)
            {
                await PopulateChildSelections(item);
                selection.AddNextSelection(item);
            }
        }

        #endregion
    }
}
