using BottlesApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BottlesApp.Services
{
    public class RepositoryService : IRepository
    {
        private Lazy<SQLiteAsyncConnection> _database;

        public RepositoryService()
        {
            _database = new Lazy<SQLiteAsyncConnection>(() =>
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.DatabaseName);
                var database = new SQLiteAsyncConnection(path);

              //  database.CreateTableAsync<PinModel>();
             //   database.CreateTableAsync<UserModel>();
                database.CreateTablesAsync( CreateFlags.AutoIncPK ,typeof(UserModel), typeof(UserProfileModel), typeof(PinModel));

                return database;
            });
        }

        public Task<List<T>> GetAllAsync<T>() where T : class, IEntityBase, new()
        {
            return _database.Value.Table<T>().ToListAsync();
        }

        public Task<T> GetSingleInstanceAsync<T>(Expression<Func<T, bool>> predicate) where T : class, IEntityBase, new()
        {
            return _database.Value.Table<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<int> SaveOrUpdateAsync<T>(T entity) where T : class, IEntityBase, new()
        {
            var row = 0;
            var instance = await GetSingleInstanceAsync<T>(e => e.Id == entity.Id);

            if (instance == null)
            {
                row = await _database.Value.InsertOrReplaceAsync(entity);
            }
            else
            {
                row = await _database.Value.UpdateAsync(entity);
            }

            return row;
        }
    }
}
