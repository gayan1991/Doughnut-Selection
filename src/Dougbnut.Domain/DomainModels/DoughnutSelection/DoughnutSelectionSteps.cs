using Doughnut.Domain.Util;

namespace Doughnut.Domain.DomainModels.DoughnutSelection
{
    public class DoughnutSelectionSteps : BaseModel
    {
        public Guid Id { get; set; }
        public byte Step { get; set; }
        public DoughnutSelection DoughnutSelection { get; set; }

        public DoughnutSelectionSteps(DoughnutSelection doughnutSelection, SelectionSteps step, string createdBy = "System") : base(createdBy)
        {
            DoughnutSelection = doughnutSelection;
            Step = step;
        }
    }
}
