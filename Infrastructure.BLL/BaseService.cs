using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Infrastructure.Common;
using Infrastructure.DAL;

namespace Infrastructure.BLL
{
    /// <summary>
    /// The base service that implements a common functional.
    /// </summary>
    /// <typeparam name="TDto">Type of data transfer object.</typeparam>
    /// <typeparam name="TDomain">Type of domain model entity.</typeparam>
    public class BaseService<TDto, TDomain> : IBaseService<TDto>
        where TDomain : class, IEntity
        where TDto : class, IEntity
    {
        private readonly IBaseRepository<TDomain> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TDomain> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public virtual IList<TDto> GetAll()
        {
            return _baseRepository.GetAll()
                .Select(x => _mapper.Map<TDto>(x))
                .ToList();
        }

        public virtual IList<TDto> GetPage(int pageNo, int pageSize)
        {
            if (pageNo <= 0)
                throw new ArgumentException(ExceptionMessages.PageNoLessZero, nameof(pageNo));
            if (pageSize <= 0)
                throw new ArgumentException(ExceptionMessages.PageSizeLessZero, nameof(pageSize));

            return _baseRepository
                .GetPage(pageNo, pageSize)
                .Select(x => _mapper.Map<TDto>(x))
                .ToList();
        }

        public virtual TDto GetById(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id), ExceptionMessages.IdIsEmpty);

            return _mapper.Map<TDto>(_baseRepository.GetById(id));
        }

        public virtual TDto Insert(TDto dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto), ExceptionMessages.DtoIsNull);

            var domain = _mapper.Map<TDomain>(dto);
            return _mapper.Map<TDto>(_baseRepository.Insert(domain));
        }

        public virtual bool Update(TDto dto)
        {
            if (dto is null)
                throw new ArgumentNullException(nameof(dto), ExceptionMessages.DtoIsNull);

            return _baseRepository.Update(_mapper.Map<TDomain>(dto));
        }

        public virtual bool Delete(string id)
        {
            if (String.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id), ExceptionMessages.IdIsEmpty);

            return _baseRepository.Delete(id);
        }
    }
}
