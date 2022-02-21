namespace SMS.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Text;
    using System.Threading.Tasks;
    using FootballManager.Data;

    public class Repository : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(FootballManagerDbContext context)
        {
            this.dbContext = context;
        }
        public void Add<T>(T entity) where T : class
        {
            DbSet<T>().Add(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
    }
}
