using EasyTraningsAPI.DbContext;
using Microsoft.EntityFrameworkCore;

namespace EasyTraningsAPI.Repositories.Generic;

public class Repository<T>: IRepository<T> where T: class
{
    private readonly AppDbContext _context;
    private  readonly DbSet<T> _dbSet;
    
    protected Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public async Task<T> AddAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>?> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task UpdateAsync(int id, T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var existingEntity = await _dbSet.FindAsync(id);
        if (existingEntity == null)
        {
            throw new ArgumentException($"Entity with {id} is not found");
        }

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
        {
            throw new ArgumentException($"Entity with {id} is not found");
        }
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}