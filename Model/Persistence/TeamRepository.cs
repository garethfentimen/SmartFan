namespace Model.Persistence
{
    using System;
    using System.Linq;

    public class TeamRepository : ITeamRepository
    {
        private readonly DatabaseContext context;

        public TeamRepository(DatabaseContext context)
        {
            this.context = context;
        }

        Team[] teams = new Team[] 
        { 
            new Team { ID = 1, Name = "Arsenal" },
            new Team { ID = 2, Name = "Burnley" },
            new Team { ID = 3, Name = "Wycombe Wanderers" }
        };

        public IQueryable<Team> AllTeams()
        {
            return this.teams.AsQueryable();
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

    public class DatabaseContext
    {
    }
}
