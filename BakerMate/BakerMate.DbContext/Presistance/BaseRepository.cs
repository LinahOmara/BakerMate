
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BakerMate.DbContext.Presistance
{
    public class BaseRepository<T>
          where T : class, new()
    {
        protected readonly BakerMateContext _dbContext;
        protected DbSet<T> _dbSet;

        public BaseRepository(BakerMateContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("DB Context not initialized");

            _dbSet = _dbContext.Set<T>();
        }

        /// <summary>
        /// Returns all T entities from store
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        /// <summary>
        /// Returns all T entities from store filtered by the given predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            var entities = _dbSet.Where(predicate);

            return entities;
        }

        public virtual IQueryable<T> GetAllWithInclude(params Expression<Func<T, object>>[] includeExpressions)
        {
            //If there are include expressions.
            if (includeExpressions.Any())
            {
                var set = includeExpressions.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(_dbSet,
                    (current, expression) => current.Include(expression)
                  );

                return set;
            }

            return _dbSet;
        }

        /// <summary>
        /// Returns the object with the primary key specifies or the default for the type
        /// </summary>
        /// <typeparam name="TU">The type to map the result to</typeparam>
        /// <param name="primaryKey">The primary key</param>
        /// <returns>The result mapped to the specified type</returns>
        public virtual async Task<T> SingleOrDefaultAsync(object primaryKey)
        {
            var dbResult = await _dbSet.FindAsync(primaryKey);
            return dbResult;
        }

        /// <summary>
        /// Check if entity exists in store
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public virtual async Task<bool> ExistsAsync(object primaryKey)
        {
            return await _dbSet.FindAsync(primaryKey) == null ? false : true;
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            var obj = _dbSet.Add(entity).Entity;
            await _dbContext.SaveChangesAsync();

            return obj;
        }

        /// <summary>
        /// Insert a collection of entities in the store
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual async System.Threading.Tasks.Task<IEnumerable<T>> InsertMultipleAsync(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            await this._dbContext.SaveChangesAsync();
            return entities;
        }

        /// <summary>
        /// Updates an entity async
        /// </summary>
        /// <param name="t"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual async Task<T> UpdateAsync(T entity)
        {
            await this._dbContext.SaveChangesAsync();
            return entity;
        }


        /// <summary>
        /// Update a list of entities Async
        /// </summary>
        /// <param name="entities"></param>
        public virtual Task UpdateMultipleAsync(IEnumerable<T> entities)
        {
            return this._dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            dynamic obj = _dbSet.Remove(entity);
            await this._dbContext.SaveChangesAsync();
            return obj.Entity.Id;
        }

        /// <summary>
        /// Deletes multiple entities using entities objects
        /// </summary>
        /// <param name="entities">list of entities to delete</param>
        public virtual async Task DeleteMultipleAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<PaginationList<U>> Paginate<U>(IQueryable<U> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = pageNumber < 1 ? await source.ToListAsync() : await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginationList<U>(items, count);
        }

        public PaginationList<U> Paginate<U>(List<U> source, int pageNumber, int pageSize)
        {
            var count = source.Count;
            var items = pageNumber < 1 ? source.ToList() : source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PaginationList<U>(items, count);
        }

        

        //public async Task BulkInsertAll(IEnumerable<T> entities, List<string> ignoredCols = null)
        //{
        //    if (!entities.Any())
        //    {
        //        return;
        //    }

        //    Type t = typeof(T);
        //    var columns = new List<string>();
        //    try
        //    {
        //        columns = _dbContext.Model.FindEntityType(t.FullName).GetProperties().Select(p => p.Name).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception($"Failed to get columns of Table {t.FullName}");
        //    }

        //    if (ignoredCols != null && ignoredCols.Count > 0)
        //        columns = columns.Except(ignoredCols).ToList();

        //    //using (var bulkCopy = _dbContext.Database.CurrentTransaction == null ? new SqlBulkCopy(_dbContext.Database.GetConnectionString()) : new SqlBulkCopy(_dbContext.Database.GetConnectionString(), SqlBulkCopyOptions.UseInternalTransaction))
        //    {
        //        bulkCopy.DestinationTableName = t.Name;
        //        foreach (var col in columns)
        //        {
        //            if (col == "PeriodStart" || col == "PeriodEnd")
        //                continue;
        //            bulkCopy.ColumnMappings.Add(col, col);
        //        }

        //        using (var reader = ObjectReader.Create(entities))
        //        {
        //            DataTable table = new DataTable();
        //            table.Load(reader);

        //            await bulkCopy.WriteToServerAsync(table.CreateDataReader());
        //        }
        //    }
        //}
    }
}
