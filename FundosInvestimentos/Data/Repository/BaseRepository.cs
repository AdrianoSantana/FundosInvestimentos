using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundosInvestimentos.Interfaces;
using FundosInvestimentos.Models;
using Microsoft.EntityFrameworkCore;

namespace FundosInvestimentos.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly MyContext _context;
        private DbSet<T> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var entidadeProcurada = await _dataset.SingleOrDefaultAsync(entidade => entidade.Id.Equals(id));
            if (entidadeProcurada == null)
                return false;

            _dataset.Remove(entidadeProcurada);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> InsertAsync(T item)
        {
            if (item.Id == Guid.Empty)
            {
                item.Id = new Guid();
                item.CreatedAt = DateTime.UtcNow;
            }
            _dataset.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            return await _dataset.FirstOrDefaultAsync(entidade => entidade.Id == id);
        }

        public T Select(Guid id)
        {
            return _dataset.FirstOrDefault(entidade => entidade.Id == id);
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            return await _dataset.ToListAsync();
        }

        public async Task<T> UpdateAsync(T item)
        {
            item.UpdatedAt = DateTime.UtcNow;
            _dataset.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}