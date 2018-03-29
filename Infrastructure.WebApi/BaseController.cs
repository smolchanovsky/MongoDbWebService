using System.Collections.Generic;
using Infrastructure.BLL;
using Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.WebApi
{
    /// <summary>
    /// The base controller that implements a common functional for entities of web service.
    /// </summary>
    /// <typeparam name="TDto">Type of data transfer object.</typeparam>
    public class BaseController<TDto> : Controller where TDto: IEntity
    {
        private readonly IBaseService<TDto> _baseService;

        public BaseController(IBaseService<TDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public IList<TDto> GetAll()
        {
            return _baseService.GetAll();
        }

        [HttpGet("Page")]
        public IList<TDto> GetPage(int no, int size)
        {
            return _baseService.GetPage(no, size);
        }

        [HttpGet("{id}")]
        public TDto Get(string id)
        {
            return _baseService.GetById(id);
        }

        [HttpPost]
        public TDto Post([FromBody]TDto value)
        {
            return _baseService.Insert(value);
        }

        [HttpPut("{id}")]
        public bool Put(long id, [FromBody]TDto value)
        {
            return _baseService.Update(value);
        }

        [HttpDelete("{id}")]
        public bool Delete(string id)
        {
            return _baseService.Delete(id);
        }
    }
}
