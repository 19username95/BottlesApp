using BottlesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BottlesApp.Services
{
    public interface IRepository
    {
        Task<T> GetSingleInstanceAsync<T>(Expression<Func<T, bool>> predicate) where T : class, IEntityBase, new();
        Task<int> SaveOrUpdateAsync<T>(T entity) where T : class, IEntityBase, new();
        Task<List<T>> GetAllAsync<T>() where T : class, IEntityBase, new();
    }
}
