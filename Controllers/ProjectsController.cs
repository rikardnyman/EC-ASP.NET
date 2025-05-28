using Data.Contexts;
using Data.Entities;
using Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace EC_ASP.NET.Controllers
{
    [Route("projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;



        private readonly AppDbContext _context;

        public ProjectsController(IProjectService projectService, AppDbContext context)
        {
            _projectService = projectService;
            _context = context;
        }


        [HttpGet("")]
        public async Task<IActionResult> ProjectPage()
        {
            try
            {
                var projects = await _projectService.GetAllProjects();

                if (projects == null)
                {
                    return View();
                }

                return View(projects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> AllProjects()
        {
            try
            {
                var projects = await _projectService.GetAllProjects();

                if (projects == null || !projects.Any())
                {
                    return View();
                }

                return View(projects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("started")]
        public async Task<IActionResult> StartedProjects()
        {
            try
            {
                var projects = (await _projectService.GetAllProjects())
                    .Where(p => p.StatusId == 1)
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
                var projects = (await _projectService.GetAllProjects())
                    .Where(p => p.StatusId == 2)
                    .ToList();

                return View(projects);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddProject(ProjectEntity newProject, IFormFile ImagePath)
        {
            if (!ModelState.IsValid)
                return View("Error", "Invalid project data");

            if (string.IsNullOrEmpty(newProject.Id))
                newProject.Id = Guid.NewGuid().ToString();

            if (newProject.ClientId == 0) newProject.ClientId = 1;

            if (newProject.StatusId == 0) newProject.StatusId = 1;


            if (ImagePath != null && ImagePath.Length > 0)
            {
                if (!ImagePath.ContentType.StartsWith("image/"))
                {
                    return View("Error", "Only image files are allowed.");
                }

                try
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                    Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagePath.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImagePath.CopyToAsync(fileStream);
                    }

                    newProject.ImagePath = "/uploads/" + uniqueFileName;
                }
                catch (Exception ex)
                {
                    return View("Error", $"Image upload failed: {ex.Message}");
                }
            }

            try
            {
                await _projectService.CreateProject(newProject);
                return RedirectToAction("ProjectPage");
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }





        [HttpPost("edit/{id}")]
        public async Task<IActionResult> EditProject(string id, [FromForm] ProjectEntity updatedProject, IFormFile? ImageUpload)
        {
            if (id != updatedProject.Id)
            {
                return BadRequest(new { success = false, message = "ID mismatch" });
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound(new { success = false, message = "Project not found" });
            }

            project.ProjectName = updatedProject.ProjectName;
            project.Description = updatedProject.Description;
            project.StartDate = updatedProject.StartDate;
            project.EndDate = updatedProject.EndDate;
            project.Budget = updatedProject.Budget;
            project.ClientId = updatedProject.ClientId;
            project.StatusId = updatedProject.StatusId;

            if (ImageUpload != null && ImageUpload.Length > 0)
            {

                var imageFileName = Path.GetFileName(ImageUpload.FileName);
                var imagePath = Path.Combine("wwwroot/uploads", imageFileName);

                using var stream = new FileStream(imagePath, FileMode.Create);
                await ImageUpload.CopyToAsync(stream);

                project.ImagePath = "/uploads/" + imageFileName;
            }

            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Project updated" });
        }







        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(string id)
        {
            var project = await _projectService.GetProjectById(id);
            if (project == null)
                return NotFound();

            await _projectService.DeleteProject(id);

            return NoContent();
        }

    }
}
