using AutoMapper;
using BLL.DataTransferObjects;
using DomainObjects;

namespace BLL.Map
{
    /// <summary>
    /// Mapper configuration for domain models and data transfer objects.
    /// </summary>
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Call, CallDto>());
        }
    }
}
