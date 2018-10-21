using System.Data.Entity;
using ImageManagement.Database;

namespace ImageManagement.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ImageContext _context;

        protected Repository(ImageContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Clear()
        {
            _context.Set<TEntity>().RemoveRange(_context.Set<TEntity>());
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
