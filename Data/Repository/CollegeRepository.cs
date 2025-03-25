using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CollegeApp.Data.Repository
{
  public class CollegeRepository<T> : ICollegeRepository<T> where T : class
  {
    private readonly CollegeDBContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public CollegeRepository(CollegeDBContext dbContext)
    {
      _dbContext = dbContext;
      _dbSet = _dbContext.Set<T>();
    }

    public async Task<List<T>> GetAllAsync()
    {
      return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> filter, bool useNoTracking = false)
    {
      return useNoTracking
        ? await _dbSet.AsNoTracking().FirstOrDefaultAsync(filter)
        : await _dbSet.FirstOrDefaultAsync(filter);
    }



    public async Task<T> CreateAsync(T dbRecord)
    {
      await _dbSet.AddAsync(dbRecord);
      await _dbContext.SaveChangesAsync();
      return dbRecord;
    }

    public async Task<T> UpdateAsync(T dbRecord)
    {
      _dbSet.Update(dbRecord);
      await _dbContext.SaveChangesAsync();
      return dbRecord;
    }

    public async Task<bool> DeleteAsync(T dbRecord)
    {
      _dbSet.Remove(dbRecord);
      await _dbContext.SaveChangesAsync();
      return true;
    }
  }
}