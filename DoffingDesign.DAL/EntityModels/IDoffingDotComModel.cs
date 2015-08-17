using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoffingDesign.DAL.EntityModels
{
    public interface IDoffingDotComModel : IDisposable
    {
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet Set(Type entityType);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbEntityEntry Entry(object entity);

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
