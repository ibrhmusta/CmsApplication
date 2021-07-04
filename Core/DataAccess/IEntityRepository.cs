using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Func<T, bool> filter = null);
        T Get(Func<T, bool> filter);
        void Add(T t);
        void Delete(T t);
        void Update(T t);
    }
}
