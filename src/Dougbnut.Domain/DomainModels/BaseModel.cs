using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Doughnut.Domain.DomainModels
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public BaseModel() { }

        public BaseModel(string actionBy)
        {
            Id = Guid.NewGuid();
            Create(actionBy);
        }

        public void Create(string actionBy)
        {
            UpdatedBy = CreatedBy = actionBy;
            UpdatedAt = CreatedAt = DateTimeOffset.UtcNow;
        }

        public void Update(string actionBy)
        {
            UpdatedBy = actionBy;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

    }
}
