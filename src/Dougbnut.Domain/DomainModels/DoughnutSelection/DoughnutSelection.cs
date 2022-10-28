using Doughnut.Domain.Util;

namespace Doughnut.Domain.DomainModels.DoughnutSelection
{
    public class DoughnutSelection : BaseModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        private readonly List<DoughnutSelectionSteps> _steps = new();
        public IReadOnlyList<DoughnutSelectionSteps> Steps => _steps;

        public DoughnutSelection(Guid userId, string createdBy = "System") : base(createdBy)
        {
            UserId = userId;
        }

        public void Update(SelectionSteps step, string updatedBy)
        {
            _steps.Add(new DoughnutSelectionSteps(this, step, updatedBy));
            Update(updatedBy);
        }
    }
}
