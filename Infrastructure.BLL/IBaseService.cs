using System.Collections.Generic;
using Infrastructure.Common;

namespace Infrastructure.BLL
{
    public interface IBaseService<TDto> where TDto : IEntity
    {
        IList<TDto> GetAll();
        IList<TDto> GetPage(int pageNo, int pageSize);
        TDto GetById(string id);
        TDto Insert(TDto dto);
        bool Update(TDto dto);
        bool Delete(string id);
    }
}