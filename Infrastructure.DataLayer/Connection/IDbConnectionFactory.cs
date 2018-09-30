using MongoDB.Driver;

namespace Infrastructure.DataLayer.Connection
{
    public interface IDbConnectionFactory
    {
        IMongoDatabase Create();
        IMongoDatabase GetDbConnection();
    }
}