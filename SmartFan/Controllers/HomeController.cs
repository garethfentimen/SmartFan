using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartFan.Controllers
{
    using Model.Persistence;

    public class HomeController : Controller
    {
        private readonly ITeamRepository teamRepository;

        public HomeController(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
            //this.teamRepository = new TeamRepository(new DatabaseContext());
        }

        public ActionResult Index()
        {
            ViewBag.Teams = this.teamRepository.AllTeams();
            return View();
        }
    }
}