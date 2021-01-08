using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FundosInvestimentos.Models;

namespace FundosInvestimentos.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);

        Task<bool> DeleteAsync(Guid id);

        Task<T> SelectAsync(Guid id);

        T Select(Guid id);
        Task<IEnumerable<T>> SelectAsync();
    }
}