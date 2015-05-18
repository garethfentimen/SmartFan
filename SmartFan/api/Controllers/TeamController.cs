namespace SmartFan.api.Controllers
{
    using System.Web.Http;

    using Model.Persistence;

    public class TeamController : ApiController
    {
        private readonly ITeamRepository teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok(this.teamRepository.AllTeams());
        }
    }
}