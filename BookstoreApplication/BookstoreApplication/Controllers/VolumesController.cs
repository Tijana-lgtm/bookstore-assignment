using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookstoreApplication.Services;
using BookstoreApplication.DTOs;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolumesController : ControllerBase
    {
        private readonly IVolumeService _volumeService;

        public VolumesController(IVolumeService volumeService)
        {
            _volumeService = volumeService;
        }

        // GET /api/volumes/search?filter=name:Batman
        [HttpGet("search")]
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> SearchVolumesByName(string filter)
        {
            return Ok(await _volumeService.SearchVolumesByName(filter));
        }

        [HttpGet("{volumeId}/issues")]
        [Authorize(Roles="Editor")]

        public async Task<IActionResult> GetIssuesByVolume(int volumeId)
        {
            return Ok(await _volumeService.GetIssuesByVolume(volumeId));
        }

        [HttpPost("issues")]
        [Authorize(Roles = "Editor")]
        public async Task<IActionResult> SaveIssue(SaveIssueDTO dto)
        {
            return Ok(await _volumeService.SaveIssue(dto));
        }
    }
}