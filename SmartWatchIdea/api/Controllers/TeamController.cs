namespace SmartWatchIdea.api.Controllers
{
    using System.Web.Http;

    using Model.Persistence;

    public class TeamController : ApiController
    {
        private readonly ITeamRepository teamRepository;

        public TeamController()
        {
            this.teamRepository = new TeamRepository(new DatabaseContext());
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.teamRepository.AllTeams());
        }
    }
}