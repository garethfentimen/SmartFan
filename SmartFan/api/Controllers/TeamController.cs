namespace SmartFan.api.Controllers
{
    using System.Threading.Tasks;
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
        public async Task<IHttpActionResult> Get()
        {
            var teams = await this.teamRepository.AllTeams();
            return this.Ok(teams);
        }

        [HttpPost]
        [Route("api/team/{teamName}")]
        public async Task<IHttpActionResult> Post(string teamName)
        {
            var team = await this.teamRepository.AddTeam(teamName);
            return this.Ok(team);
        }
    }
}