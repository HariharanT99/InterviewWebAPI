using IBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IService _service;

        public AdminController(IService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandidate()
        {
            var response = await this._service.AdminService.GetAllCandidateList();

            if (response.Error.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response.Error);
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicantById(int id)
        {
            var response = await this._service.AdminService.GetApplicantById(id);

            if (response.Error.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response.Error);
        }

        [HttpPost]
        public async Task<IActionResult> AddApplicant(AddApplicantViewModel applicant)
        {
            var response = await this._service.AdminService.AddApplicant(applicant);

            if (response.Error.Succeeded)
            {
                return Ok();
            }
            return BadRequest(response.Error);
        }

        [HttpPost]
        public async Task<IActionResult> EditCandidate(UpdateCandidateViewModel model)
        {
            var response = await this._service.AdminService.EditCandidate(model);

            if (response.Error.Succeeded)
            {
                return Ok();
            }

            return BadRequest(response.Error);
        }

        [HttpPost]
        public async Task<IActionResult> PromoteApplicant(PromoteApplicantViewModel model)
        {
            var response = await this._service.AdminService.PromoteApplicant(model);

            if (response.Error.Succeeded)
            {
                return Ok();
            }
            return BadRequest(response.Error);
        }


        [HttpPost]
        public async Task<IActionResult> RejectCandidate(int interviewId)
        {
            var response = await this._service.AdminService.RejectApplicant(interviewId);

            if (response.Error.Succeeded)
            {
                return Ok();
            }
            return BadRequest(response.Error);
        }

        [HttpPost]
        public async Task<IActionResult> AddInterviewer(AddInterviewerViewModel model)
        {
            var response = await this._service.AdminService.AddInterviewer(model);

            if (response.Error.Succeeded)
            {
                return Ok();
            }

            return BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var response = await this._service.AdminService.GetAllUser();

            if (response.Error.Succeeded)
            {
                return Ok(response.Data);
            }
            return BadRequest(response.Error);
        }


        [HttpPost]
        public async Task<IActionResult> ScheduleInterview(ScheduleInterviewViewModel model)
        {
            var response = await this._service.AdminService.ScheduleInterviewDate(model);

            if (response.Error.Succeeded)
            {
                return Ok();
            }

            return BadRequest(response.Error);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDesignation()
        {
            var response = await _service.AdminService.GetAllDesignation();

            if (response.Error.Succeeded)
            {
                return Ok(response.Data);
            }
            return BadRequest(response.Error);
        }
    }
}
