using BLL.Dto;
using DAL;
using DomainObjects;
using Infrastructure.BLL;
using Infrastructure.Common;
using Infrastructure.DAL;
using Infrastructure.DAL.Connection;
using Microsoft.Extensions.DependencyInjection;

namespace WebService
{
	public static class IoCConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IDbConnectionFactory, CallDbConnectionFactory>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBaseService<CallDto>, BaseService<CallDto, Call>>();

	        services.AddSingleton(_ => MapperFactory.Create());
		}
    }
}
