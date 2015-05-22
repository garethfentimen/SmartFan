namespace Model.Persistence.DataStore
{
    using System;
    using System.Diagnostics;

    using MongoDB.Driver;

    public class DatabaseContext : IDatabaseContext, IDisposable
    {
        public IMongoDatabase MongoDatabase
        {
            get
            {
                Debug.WriteLine("Connecting to Mongo data store");
                var client = new MongoClient("mongodb://gfentimen:$4XDqXVwd9@ds039211.mongolab.com:39211/smartfan");
                return client.GetDatabase("smartfan");  
            }
            set { }
        }

        public IMongoCollection<Team> TeamCollection
        {
            get
            {
                return this.MongoDatabase.GetCollection<Team>(typeof(Team).Name.ToLower() + "s");
            }
        }

        public void Dispose()
        {
            this.MongoDatabase = null;
        }
    }

    public interface IDatabaseContext
    {
        IMongoDatabase MongoDatabase { get; set; }

        IMongoCollection<Team> TeamCollection { get; }
    }
}