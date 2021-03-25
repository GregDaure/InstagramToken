using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Instagram.Entity.Context;
using Instagram.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Instagram.WebApi.Services
{
    public class RepositoryService<T> : IRepositoryService<T> where T : class, new()
    {

        private readonly SoFoodMelContext _context;

        public RepositoryService(SoFoodMelContext context)
        {
            _context = context;
        }

        public void Update(T obj)
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                _context.Set<T>().Update(obj);
                _context.SaveChanges();

                transaction.Commit();
            }
            
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable().AsNoTracking();
        }
    }
}
