using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Instagram.WebApi.Interfaces
{
    public interface IRepositoryService<T> where T : class, new()
    {
        void Update(T obj);
        IEnumerable<T> GetAll();
    }
}
