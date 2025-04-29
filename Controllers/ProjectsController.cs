using Data.Services;
using EC_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace EC_ASP.NET.Controllers
{
    [Route("projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [Route("")]
        public IActionResult ProjectPage()
        {
            try
            {

                {

                    return View();
                }


            }
            catch (Exception ex)
            {


                ModelState.AddModelError(string.Empty, "An error occurred while fetching projects: " + ex.Message);
                return View("Error");
            }
        }

        [Route("all")]
        public IActionResult AllProjects()
        {
            try
            {
                //var projects = await _projectService.GetAllProjects();
                //return View(projects);
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while fetching projects: " + ex.Message);
                return View("Error");
            }
        }

        [Route("started")]
        public IActionResult StartedProjects()
        {
            //try
            //{
            //    var projects = await _projectService.GetAllProjects();
            //    var startedProjects = projects.Where(p => p.Status == "Started").ToList();
            //    return View(startedProjects);
            //}
            //catch (Exception ex)
            //{
            //    ModelState.AddModelError(string.Empty, "An error occurred while fetching started projects: " + ex.Message);
            //    return View("Error");
            //}
            return View();
        }

        [Route("completed")]
        public IActionResult CompletedProjects()
        {
            //try
            //{
            //    var projects = await _projectService.GetAllProjects();
            //    var completedProjects = projects.Where(p => p.Status == "Completed").ToList();
            //    return View(completedProjects);
            //}
            //catch (Exception ex)
            //{
            //    ModelState.AddModelError(string.Empty, "An error occurred while fetching completed projects: " + ex.Message);
            //    return View("Error");
            //}
            return View();
        }

        [Route("add")]
        public IActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddProject(ProjectEntity newProject)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        await _projectService.CreateProject(newProject);
            //        return RedirectToAction("AllProjects");
            //    }

            //    return View(newProject);
            //}
            //catch (Exception ex)
            //{

            //    ModelState.AddModelError(string.Empty, "An error occurred while creating the project: " + ex.Message);
            //    return View(newProject);
            //}
            return View();
        }
    }
}
