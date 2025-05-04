using System.Security.Principal;
using Data.Dtos;
using Data.Entities;
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

        [HttpGet("")]
        public async Task<IActionResult> ProjectPage()
        {
            try
            {
                var entities = await _projectService.GetAllProjects();
                var projects = entities.Select(Project.FromEntity).ToList();
                return View(projects);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> AllProjects()
        {
            try
            {
                var entities = await _projectService.GetAllProjects();
                var projects = entities.Select(Project.FromEntity).ToList();
                return View(projects);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpGet("started")]
        public async Task<IActionResult> StartedProjects()
        {
            try
            {
                var entities = await _projectService.GetAllProjects();
                var projects = entities
                    .Where(p => p.StatusId == 1)
                    .Select(Project.FromEntity)
                    .ToList();

                return View(projects);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpGet("completed")]
        public async Task<IActionResult> CompletedProjects()
        {
            try
            {
                var entities = await _projectService.GetAllProjects();
                var projects = entities
                    .Where(p => p.StatusId == 2)
                    .Select(Project.FromEntity)
                    .ToList();

                return View(projects);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProject(Project newProject)
        {

            if (!ModelState.IsValid)
                return View("Error");

            if (string.IsNullOrEmpty(newProject.Id))
                newProject.Id = Guid.NewGuid().ToString();

            if (string.IsNullOrEmpty(newProject.UserId))
                newProject.UserId = "test-user";


            if (newProject.ImageFile != null && newProject.ImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(newProject.ImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await newProject.ImageFile.CopyToAsync(fileStream);
                }

                newProject.ImagePath = "/uploads/" + uniqueFileName;
            }

           
           

            
            var entity = newProject.ToEntity();

            try
            {
                await _projectService.CreateProject(entity);
                TempData["Success"] = "Project created successfully!";
                return RedirectToAction("ProjectPage");
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }



        [HttpPost("edit")]
        public async Task<IActionResult> EditProject(Project updatedProject)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("AllProjects");

            var entity = updatedProject.ToEntity();

            try
            {
                await _projectService.UpdateProject(int.Parse(entity.Id), entity);
                return RedirectToAction("AllProjects");
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}
