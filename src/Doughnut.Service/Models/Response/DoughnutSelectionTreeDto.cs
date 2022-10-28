using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doughnut.Domain.DomainModels.Referential;

namespace Doughnut.Service.Models.Response
{
    public class DoughnutSelectionTreeDto
    {
        public int Code { get; set; }
        public string Text { get; set; } = null!;
        public List<DoughnutSelectionTreeDto> Selection { get; set; } = null!;
    }

    public static class RefSelectionProcessExtension
    {
        public static DoughnutSelectionTreeDto ToSelectionDto(this RefSelectionProcess obj)
        {
            var rtnObj = new DoughnutSelectionTreeDto()
            {
                Code = obj.Code,
                Text = obj.Text,
                Selection = obj.NextSelection.Select(x => x.ToSelectionDto()).ToList()
            };
            return rtnObj;
        }
    }

   
}
