using AutoMapper;
using CreatorFlowApi.DTOs.Projects;
using CreatorFlowApi.Entities;
using CreatorFlowApi.Repositories.Projects;
using CreatorFlowApi.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreatorFlowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects(
            [FromQuery] string? platform,
            [FromQuery] bool onlyActive = true)
        {
            var userId = User.GetUserId();

            var query = await _projectRepository.FindAsync(p =>
                p.UserId == userId &&
                (platform == null || p.Platform == platform) &&
                (!onlyActive || p.IsActive));

            var dto = _mapper.Map<IEnumerable<ProjectDto>>(query);
            return Ok(dto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            var userId = User.GetUserId();
            var project = await _projectRepository.GetProjectWithContentAsync(id);

            if (project == null || project.UserId != userId)
                return NotFound();

            var dto = _mapper.Map<ProjectDto>(project);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProject(CreateProjectDto dto)
        {
            var userId = User.GetUserId();
            var project = _mapper.Map<Project>(dto);
            project.UserId = userId;

            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveChangesAsync();

            var result = _mapper.Map<ProjectDto>(project);
            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProject(int id, UpdateProjectDto dto)
        {
            var userId = User.GetUserId();
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null || project.UserId != userId)
                return NotFound();

            _mapper.Map(dto, project);
            _projectRepository.Update(project);
            await _projectRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id:int}/archive")]
        public async Task<IActionResult> ArchiveProject(int id)
        {
            var userId = User.GetUserId();
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null || project.UserId != userId)
                return NotFound();

            project.IsActive = false;
            _projectRepository.Update(project);
            await _projectRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var userId = User.GetUserId();
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null || project.UserId != userId)
                return NotFound();

            _projectRepository.Delete(project);
            await _projectRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
