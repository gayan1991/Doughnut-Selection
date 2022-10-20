using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doughnut.Domain.Interface.Repository;
using Doughnut.Service.Interface;

namespace Doughnut.Service.Impl
{
    public class DoughnutService : IDoughnutService
    {
        private readonly IDoughnutRepository _repository;

        public DoughnutService(IDoughnutRepository repository)
        {
            _repository = repository;
        }
    }
}
