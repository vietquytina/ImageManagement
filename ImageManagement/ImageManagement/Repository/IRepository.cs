using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManagement.Repository
{
    public interface IRepository<TEntity>
    {
        void Clear();
        void Add(TEntity entity);
        void SaveChanges();
    }
}
