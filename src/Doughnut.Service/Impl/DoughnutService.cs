using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doughnut.Domain.Interface.DomainService;
using Doughnut.Domain.Interface.Repository;
using Doughnut.Domain.Util;
using Doughnut.Service.Interface;
using Doughnut.Service.Models.Response;

namespace Doughnut.Service.Impl
{
    public class DoughnutService : IDoughnutService
    {
        private readonly IDoughnutRepository _repository;
        private readonly IRefSelectionDomainService _refSelectionDomainService;

        public DoughnutService(IDoughnutRepository repository, IRefSelectionDomainService refSelectionDomainService)
        {
            _repository = repository;
            _refSelectionDomainService = refSelectionDomainService;
        }

        public async Task<SuccessDto> GetSelectionTree()
        {
            var selection = await _refSelectionDomainService.GetSelectionProcessAsync();
            return new SuccessDto(Constants.SuccessfullyRetreived, selection.ToSelectionDto());
        }

        public async Task<SuccessDto> GetSelectionTree(int code)
        {
            if (code < 0)
            {
                throw new ArgumentException($"{nameof(code)} : {code} is invalid.");
            }

            var selection = await _refSelectionDomainService.GetSelectionProcessAsync()ionProcessAsync();

            if (!selection.NextSelection.Any())
            {
                throw new InvalidOperationException($"{nameof(code)} : {code} is invalid selection as the process is finished.");
            }

            return new SuccessDto(Constants.SuccessfullyRetreived, selection.ToSelectionDto());
        }

        public Task UpSertDoughnutAsync()
    }
}
