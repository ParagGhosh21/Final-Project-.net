using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public interface IRepository<T, ID>
    {
        void Add(T obj);
        T Get(ID id);
        List<T> Get();
        void Edit(T obj);
        void Delete(ID id);

        // get by user Id
        List<T> GetByUserId(ID id);
    }
}
