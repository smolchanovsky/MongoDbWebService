using Infrastructure.Common;
using Infrastructure.DataLayer;
using Infrastructure.DataLayer.Connection;
using Infrastructure.ServiceLayer;
using Microsoft.Extensions.DependencyInjection;
using MongoDbWebService.DataLayer;
using MongoDbWebService.Models;
using MongoDbWebService.ServiceLayer.Dto;

namespace MongoDbWebService.WebApi
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
