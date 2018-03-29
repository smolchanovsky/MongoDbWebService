using MongoDB.Driver;

namespace Infrastructure.DAL.Connection
{
    public interface IDbConnectionFactory
    {
        IMongoDatabase Create();
        IMongoDatabase GetDbConnection();
    }
}