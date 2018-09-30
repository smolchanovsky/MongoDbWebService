using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Common;
using Infrastructure.DAL.Connection;
using MongoDB.Driver;

namespace Infrastructure.DAL
{
    /// <summary>
    /// The base  <a href="https://www.mongodb.com">MongoDb</a> repository that implements a common functional.
    /// </summary>
    /// <typeparam name="TDomain">Type of domain model entity.</typeparam>
    public class BaseRepository<TDomain> : IBaseRepository<TDomain> where TDomain : class, IEntity
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        protected IMongoDatabase DbConnection => _dbConnectionFactory.Create();
        protected IMongoCollection<TDomain> Collection => DbConnection.GetCollection<TDomain>(GetCollectionName<TDomain>());

        public BaseRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public virtual IList<TDomain> GetAll()
        {
            return Collection
                .Find(_ => true)
                .ToList();
        }

        public virtual IList<TDomain> GetPage(int pageNo, int pageSize)
        {
            return GetPage(
                Collection.Find(_ => true).ToCursor(),
                pageNo,
                pageSize);
        }

        public virtual TDomain GetById(string id)
        {
            return Collection
                .Find(Builders<TDomain>.Filter.Eq("id", id))
                .FirstOrDefault();
        }

        public virtual TDomain Insert(TDomain domain)
        {
            Collection.InsertOne(domain);
            return domain;
        }

        public virtual void BulkInsert(IEnumerable<TDomain> domains)
        {
            Collection.InsertMany(domains);
        }

        public virtual bool Update(TDomain domain)
        {
            return Collection
                .ReplaceOne(x => x.Id == domain.Id, domain)
                .IsAcknowledged;
        }

        public virtual bool Delete(string id)
        {
            return Collection
                .DeleteOne(Builders<TDomain>.Filter.Eq("id", id))
                .IsAcknowledged;
        }

        protected virtual IList<TDomain> GetPage(IAsyncCursor<TDomain> enumerable, int pageNo, int pageSize)
        {
            return Collection
                .Find(_ => true)
                .Skip(pageNo * pageSize)
                .Limit(pageSize)
                .ToList();
        }

	    public static string GetCollectionName<T>()
	    {
		    return typeof(T)
			    .GetCustomAttributes(true)
			    .OfType<CollectionNameAttribute>()
			    .FirstOrDefault()?
			    .CollectionName;
	    }
	}
}
