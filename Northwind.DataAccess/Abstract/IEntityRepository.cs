using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class ,IEntity,new() //T classlardan alınmalı IEntity kullanılmalı, newlenebilir olmalı demek
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null); //kullanıcı isterse filtre vermek zorunda değil demek
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
