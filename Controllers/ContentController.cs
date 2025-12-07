using AutoMapper;
using CreatorFlowApi.DTOs;
using CreatorFlowApi.DTOs.Contents;
using CreatorFlowApi.Entities;
using CreatorFlowApi.Repositories;
using CreatorFlowApi.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreatorFlowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ContentController : ControllerBase
    {
        private readonly IRepository<ContentItem> _contentRepo;
        private readonly IRepository<Project> _projectRepo;
        private readonly IMapper _mapper;

        public ContentController(
            IRepository<ContentItem> contentRepo,
            IRepository<Project> projectRepo,
            IMapper mapper)
        {
            _contentRepo = contentRepo;
            _projectRepo = projectRepo;
            _mapper = mapper;
        }

        [HttpPost("project/{projectId:int}")]
        public async Task<ActionResult<ContentItemDto>> CreateContent(int projectId, CreateContentItemDto dto)
        {
            var userId = User.GetUserId();
            var project = await _projectRepo.GetByIdAsync(projectId);

            if (project == null || project.UserId != userId)
                return NotFound("Project not found.");

            var content = _mapper.Map<ContentItem>(dto);
            content.ProjectId = projectId;

            await _contentRepo.AddAsync(content);
            await _contentRepo.SaveChangesAsync();

            var result = _mapper.Map<ContentItemDto>(content);
            return Ok(result);
        }

        [HttpPatch("{id:int}/status")]
        public async Task<IActionResult> UpdateStatus(int id, UpdateContentStatusDto dto)
        {
            var userId = User.GetUserId();
            var content = await _contentRepo.GetByIdAsync(id);
            if (content == null) return NotFound();

            var project = await _projectRepo.GetByIdAsync(content.ProjectId);
            if (project == null || project.UserId != userId)
                return NotFound();

            content.Status = dto.Status;
            _contentRepo.Update(content);
            await _contentRepo.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("schedule")]
        public async Task<ActionResult<IEnumerable<ContentItemDto>>> GetSchedule(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to)
        {
            var userId = User.GetUserId();

            var items = await _contentRepo.FindAsync(ci =>
                ci.PlannedDate >= from &&
                ci.PlannedDate <= to &&
                ci.Project.UserId == userId);

            var dto = _mapper.Map<IEnumerable<ContentItemDto>>(items);
            return Ok(dto);
        }
    }
}
