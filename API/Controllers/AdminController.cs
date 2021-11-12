using IBLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IService _service;

        public AdminController(IService service)
        {
            this._service = service;
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
        public async Task<IActionResult> AddApplicant(int userId, string firstName, string lastName, string lastEmployer, string lastDesignation, int appliedFor, int referedBy, string medicalStatus, int noticePeriod, string resume)
        {
            var response = await this._service.AdminService.AddApplicant(userId, firstName, lastName, lastEmployer, lastDesignation, appliedFor, referedBy, medicalStatus, noticePeriod, resume);

            if (response.Error.Succeeded)
            {
                return Ok();
            }
            return BadRequest(response.Error);
        }

        [HttpPost]
        public async Task<IActionResult> PromoteCandidate(int applicantId, int interviewId)
        {
            var response = await this._service.AdminService.PromoteCandidate(applicantId, interviewId);

            if (response.Error.Succeeded)
            {
                return Ok();
            }
            return BadRequest(response.Error);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var response = await this._service.AdminService.GetAllUser();

            if (response.Error.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response.Error);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDesignation()
        {
            var response = await _service.AdminService.GetAllDesignation();

            if (response.Error.Succeeded)
            {
                return Ok();
            }
            return BadRequest(response.Error);
        }
    }
}
