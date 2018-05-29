
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentSystem.Initializer
{
    public class DbInitializer
    {
        private readonly DbContext _context;

        public DbInitializer(DbContext context) 
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public DbInitializer AttachSingleEntity<TEntity>(TEntity entity) where TEntity : class 
        {
            _context.Set<TEntity>().Add(entity);
            return this;
        }

        public DbInitializer AttachMultipleEntities<TEntity>(ICollection<TEntity> entities) where TEntity : class
        {
            _context.Set<TEntity>().AddRange(entities);
            return this;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}