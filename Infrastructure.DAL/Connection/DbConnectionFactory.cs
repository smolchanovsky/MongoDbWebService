using System;
using MongoDB.Driver;

namespace Infrastructure.DAL.Connection
{
    /// <summary>
    /// Base class for database connection factory.
    /// </summary>
    public abstract class DbConnectionFactory : IDbConnectionFactory
    {
        protected static IMongoDatabase DbConnection;

        public abstract IMongoDatabase Create();

        public IMongoDatabase GetDbConnection()
        {
            if (DbConnection == null)
                throw new InvalidOperationException("Connection not created.");
            return DbConnection;
        }
    }
}
