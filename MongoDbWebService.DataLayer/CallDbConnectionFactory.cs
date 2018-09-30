using Infrastructure.DataLayer.Connection;

namespace MongoDbWebService.DataLayer
{
    /// <summary>
    /// Connection factory for mongo database - testDb.
    /// </summary>
    public class CallDbConnectionFactory : MongoDbConnectionFactory
    {
        public CallDbConnectionFactory() : base(connectionString: "mongodb://localhost:27017", dbName: "testDb")
        {

        }
    }
}
