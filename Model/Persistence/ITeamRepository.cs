namespace Model.Persistence
{
    using System.Linq;

    public interface ITeamRepository
    {
        IQueryable<Team> AllTeams();
    }
}
