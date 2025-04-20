using Microsoft.AspNetCore.Mvc;

namespace EC_ASP.NET.Controllers
{
    [Route("projects")]
    public class ProjectsController : Controller
    {
        [Route("")]
        public IActionResult ProjectPage()
        {
            return View();
        }

        [Route("all")]
        public IActionResult AllProjects()
        {
            return View();
        }

        [Route("started")]
        public IActionResult StartedProjects()
        {
            return View();
        }

        [Route("completed")]
        public IActionResult CompletedProjects()
        {
            return View();
        }
    }
}
