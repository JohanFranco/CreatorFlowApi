using AutoMapper;
using CreatorFlowApi.DTOs;
using CreatorFlowApi.DTOs.Contents;
using CreatorFlowApi.Entities;
using CreatorFlowApi.Repositories.Contents;
using CreatorFlowApi.Repositories.Projects;
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
        private readonly IContentItemRepository _contentRepo;
        private readonly IProjectRepository _projectRepo;
        private readonly IMapper _mapper;

        public ContentController(
            IContentItemRepository contentRepo,
            IProjectRepository projectRepo,
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

        [HttpGet("schedule")]
        public async Task<ActionResult<IEnumerable<ContentItemDto>>> GetSchedule(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to)
        {
            var userId = User.GetUserId();
            var items = await _contentRepo.GetScheduleAsync(userId, from, to);
            var dto = _mapper.Map<IEnumerable<ContentItemDto>>(items);
            return Ok(dto);
        }
    }
}
