namespace Model.Persistence
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITeamRepository
    {
        Task<List<Team>> AllTeams();

        Task<Team> AddTeam(string teamName);
    }
}
