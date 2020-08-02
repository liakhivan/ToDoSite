using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoSite.Domain.Abstruct
{
    public interface IRepository<T>: IDisposable where T: class
    {
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void SaveChanges();
    }
}
