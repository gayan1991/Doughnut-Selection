using Doughnut.Domain.DomainModels.DoughnutSelection;
using Doughnut.Domain.Interface.Repository;
using Doughnut.Domain.Util;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Doughnut.Infrastructure.Repository
{
    public class DoughnutRepository : IDoughnutRepository
    {
        private readonly DoughnutDbContext _db;

        public DoughnutRepository(DoughnutDbContext dbContext)
        {
            _db = dbContext;
        }

        #region From IRepository

        public Task<List<DoughnutSelection>> GetAllAsync()
        {
            return _db.DoughnutSelections.ToListAsync();
        }

        public Task<List<DoughnutSelection>> GetAllAsync(Expression<Func<DoughnutSelection, bool>> exp)
        {
            return _db.DoughnutSelections.Where(exp).ToListAsync();
        }

        public Task SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }

        #endregion

        public Task<List<DoughnutSelection>> GetAllDoughnutSelectionByStepAsync(SelectionSteps selection)
        {
            return _db.DoughnutSelections.Where(exp => exp.Steps.Any(s => s.Step == selection)).ToListAsync();
        }

        public Task<List<DoughnutSelection>> GetAllPendingSelectionsAsync()
        {
            return _db.DoughnutSelections.Where(exp => exp.Steps.Any(s =>
                                                                                   s.Step != SelectionSteps.AmSure ||
                                                                                   s.Step != SelectionSteps.AmNotSure ||
                                                                                   s.Step != SelectionSteps.ItIsAGoodDoughnut ||
                                                                                   s.Step != SelectionSteps.ItIsNotAGoodDoughnut)
                                                                                    ).ToListAsync();
        }

        public Task<DoughnutSelection?> GetDoughnutSelectionByUserAsync(Guid userId)
        {
            return _db.DoughnutSelections.Where(exp => exp.UserId == userId).FirstOrDefaultAsync();
        }

        public Task<bool> IsSelectionPendingForUserAsync(Guid userId)
        {
            return _db.DoughnutSelections.AnyAsync(exp => exp.UserId == userId &&
                                                                          exp.Steps.Any(s =>
                                                                              s.Step != SelectionSteps.AmSure ||
                                                                              s.Step != SelectionSteps.AmNotSure ||
                                                                              s.Step != SelectionSteps.ItIsAGoodDoughnut ||
                                                                              s.Step != SelectionSteps.ItIsNotAGoodDoughnut));
        }

        public Task UpsertDoughnutSelectionAsync(DoughnutSelection selection)
        {
            
        }
    }
}
