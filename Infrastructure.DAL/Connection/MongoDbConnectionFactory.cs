using MongoDB.Driver;

namespace Infrastructure.DAL.Connection
{
    /// <summary>
    /// Factory for connection to MongoDb database.
    /// </summary>
    public class MongoDbConnectionFactory : DbConnectionFactory
    {
        private readonly string _connectionString;
        private readonly string _dbName;

        public MongoDbConnectionFactory(string connectionString, string dbName)
        {
            _connectionString = connectionString;
            _dbName = dbName;
        }

        public override IMongoDatabase Create()
        {
            if (DbConnection != null)
                return DbConnection;

            var client = new MongoClient(_connectionString);
            return DbConnection = client.GetDatabase(_dbName);
        }
    }
}
