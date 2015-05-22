namespace Model.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Model.Persistence.DataStore;

    using MongoDB.Bson;
    using MongoDB.Driver;

    public class TeamRepository : ITeamRepository
    {
        private readonly IDatabaseContext context;

        public TeamRepository(IDatabaseContext context)
        {
            this.context = context;
        }

        //Team[] teams = new Team[] 
        //{ 
        //    new Team { _id = 1, Name = "Arsenal" },
        //    new Team { _id = 2, Name = "Burnley" },
        //    new Team { _id = 3, Name = "Wycombe Wanderers" }
        //};

        public async Task<List<Team>> AllTeams()
        {
            var teams = new List<Team>();
            //var result = this.context.TeamCollection.Find(o => true);
            //foreach (var team in result)
            //{
            //    teams.Add(team);
            //}
            //return teams;

            //var filter = new Team();
            //var collection = this.context.TeamCollection.Find(o => true);
            var collection = this.context.TeamCollection;
            var filter = new BsonDocument();
            using (var cursor = await collection.Find(filter).ToCursorAsync())
            {
                while (await cursor.MoveNextAsync())
                {
                    teams.AddRange(cursor.Current);
                }
            }

            //using (var cursor = await this.context.TeamCollection.FindAsync(o => true)))
            //{
            //    while (await cursor.MoveNextAsync())
            //    {
            //        var batch = cursor.Current;
            //        foreach (var doc in batch)
            //        {
            //            // do something with the documents
            //            teams.Add(doc);
            //        }
            //    }
            //}

            return teams;
        }

        public async Task<Team> AddTeam(string teamName)
        {
            try
            {
                var teamCount = await this.context.TeamCollection.CountAsync(o => true);
                var team = new Team { _id = (int)teamCount, Name = teamName };
                await this.context.TeamCollection.InsertOneAsync(team);
                return team;
            }
            catch (Exception e)
            {
                Debug.WriteLine("something went wrong: {0}", e);
                return null;
            }
        }

        //public void Save()
        //{
        //    this.context.SaveChanges();
        //}

        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            this.context.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    this.Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
