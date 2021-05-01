using Northwind.DataAccess.Abstract;
using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> //arabirimi uygulayın
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext()) //Add için böyle 
            {
                var addedEntity = context.Entry(entity); //çalışcağımız kısmı gir demek
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) //Delete için böyle için böyle 
            {
                var deletedEntity = context.Entry(entity); //çalışcağımız kısmı gir demek
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext()) //buraları artık TContext olarak alıyoruz çünkü artık diğer kodlarla uğraşmak istemiyoruz (getbycategoryId gibi vs.)
            {
                return filter == null?  //filtre varsa demek
                    context.Set<TEntity>().ToList :
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) //Update için böyle için böyle 
            {
                var updatedEntity = context.Entry(entity); //çalışcağımız kısmı gir demek
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
