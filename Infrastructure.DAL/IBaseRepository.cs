using System.Collections.Generic;
using Infrastructure.Common;

namespace Infrastructure.DAL
{
    public interface IBaseRepository<TDomain> where TDomain : IEntity
    {
        IList<TDomain> GetAll();
        IList<TDomain> GetPage(int pageNo, int pageSize);
        TDomain GetById(string id);
        TDomain Insert(TDomain domain);
        void BulkInsert(IEnumerable<TDomain> domains);
        bool Update(TDomain domain);
        bool Delete(string id);
    }
}