using System.Threading.Tasks;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {

        private readonly IService _service;

        public AdminController(IService service)
        {
            this._service = service;
        }

        [HttpGet("getallcandidate")]
        public async Task<IActionResult> GetAllCandidate()
        {
            var response = await this._service.AdminService.GetAllCandidateList();

            if (response.Error.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response.Error);
        }

        [HttpPost("editcandidate")]
        public async Task<IActionResult> EditCandidate(UpdateCandidateViewModel model)
        {
            var response = await this._service.AdminService.EditCandidate(model);

            if (response.Error.Succeeded)
            {
                return Ok();
            }

            return BadRequest(response.Error);
        }

        [HttpPost("rejectcandidate")]
        public async Task<IActionResult> RejectCandidate(int interviewId)
        {
            var response = await this._service.AdminService.RejectApplicant(interviewId);

            if (response.Error.Succeeded)
            {
                return Ok();
            }
            return BadRequest(response.Error);
        }

        [HttpPost("addinterviewer")]
        public async Task<IActionResult> AddInterviewer(AddInterviewerViewModel model)
        {
            var response = await this._service.AdminService.AddInterviewer(model);

            if (response.Error.Succeeded)
            {
                return Ok();
            }

            return BadRequest(response);
        }

        [HttpPost("scheduleinterview")]
        public async Task<IActionResult> ScheduleInterview(ScheduleInterviewViewModel model)
        {
            var response = await this._service.AdminService.ScheduleInterviewDate(model);

            if (response.Error.Succeeded)
            {
                return Ok();
            }

            return BadRequest(response.Error);
        }
    }
}