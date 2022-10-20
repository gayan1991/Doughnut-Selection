using Doughnut.Domain.DomainModels.Referential;
using Doughnut.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Doughnut.Infrastructure.Repository
{
    internal class RefSelectionProcessRepository : IRefSelectionProcessRepository
    {
        private readonly DoughnutDbContext _db;

        public RefSelectionProcessRepository(DoughnutDbContext dbContext)
        {
            _db = dbContext;
        }

        #region From IRepository

        public Task<List<RefSelectionProcess>> GetAllAsync()
        {
            return _db.RefSelectionProcess.ToListAsync();
        }

        public Task<List<RefSelectionProcess>> GetAllAsync(Expression<Func<RefSelectionProcess, bool>> exp)
        {
            return _db.RefSelectionProcess.Where(exp).ToListAsync();
        }

        public Task SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }

        #endregion

        public Task<List<RefSelectionProcess>> GetSelectionsBasedOnCodeAsync(int code)
        {
            return _db.RefSelectionProcess.Where(exp => exp.Code == code).ToListAsync();
        }
    }
}
