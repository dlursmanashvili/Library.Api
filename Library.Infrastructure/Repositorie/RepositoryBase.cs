using Library.Infrastructure.DataBaseHelper;
using Library.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositorie;

public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<TModel> _table;

    public RepositoryBase(ApplicationDbContext context)
    {
        _context = context;
        _table = _context.Set<TModel>();
    }

    public virtual async Task AddAsync(TModel entity)
    {
        await _table.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<IEnumerable<TModel>> LoadAsync()
        => _table;

    public virtual async Task<TModel> GetByIdAsync(object id)
        => (await _table.FindAsync(id))!;

    public virtual async Task UpdateAsync(TModel entity)
    {
        _table.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task RemoveAsync(TModel entity)
    {
        _table.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task RemoveById(object id)
    {
        _table.Remove(_table.Find(id)!);
        await _context.SaveChangesAsync();
    }
}
