﻿using ePizzaHub.Repositories.Contracts;
using ePizzHub.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ePizzaHub_ScholarHatContext _dbContext;
        public GenericRepository(ePizzaHub_ScholarHatContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbContext.Set<T>();

            return query.ToList();
        }
    }

}
