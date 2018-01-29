using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.DAL
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T t);
        bool Update(T t);
        bool Delete(int id);
        void Save();
    }
}
