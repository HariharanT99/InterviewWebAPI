using IBLL;
using IDAL.IConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BLL
{
    public class AdminService : GenericService, IAdminService
    {
        public AdminService(IUnitOfWork uow) : base(uow) { }

        public async Task<ResponseViewModel<bool>> AddInterviewer(AddInterviewerViewModel data)
        {
            var result = await this.UnitOfWork.InterviewerReviewRepository.AddInterviewer(data);
            return result;
        }

        public async Task<ResponseViewModel<bool>> EditCandidate(UpdateCandidateViewModel data)
        {
            var result = await this.UnitOfWork.ApplicantRepository.EditCandidate(data);
            return result;
        }

        public async Task<ResponseViewModel<List<DashboardApplicantViewModel>>> GetAllCandidateList()
        {
            var result = await this.UnitOfWork.ApplicantRepository.GetAllCandidateList();
            return result;
        }

        public async Task<ResponseViewModel<bool>> RejectApplicant(int InterviewId)
        {
            var result = await this.UnitOfWork.InterviewRepository.RejectApplicant(InterviewId);
            return result;
        }

        public async Task<ResponseViewModel<bool>> ScheduleInterviewDate(ScheduleInterviewViewModel model)
        {
            var result = await this.UnitOfWork.InterviewRepository.ScheduleInterviewDate(model);
            return result;
        }

        public async Task<ResponseViewModel<ApplicantViewModel>> GetApplicantById(int id)
        {
            var result = await this.UnitOfWork.ApplicantRepository.GetApplicantById(id);
            return result;
        }

        public async Task<ResponseViewModel<bool>> AddApplicant(AddApplicantViewModel applicant)
        {
            var result = await this.UnitOfWork.ApplicantRepository.AddApplicant(applicant);
            return result;
        }

        public async Task<ResponseViewModel<bool>> PromoteApplicant(PromoteApplicantViewModel model)
        {
            var result = await this.UnitOfWork.InterviewRepository.PromoteApplicant(model);
            return result;
        }

        public async Task<ResponseViewModel<List<UserViewModel>>> GetAllUser()
        {
            var result = await this.UnitOfWork.UserRepository.GetAllUser();
            return result;
        }

        public async Task<ResponseViewModel<List<DesignationViewModel>>> GetAllDesignation()
        {
            ResponseViewModel<List<DesignationViewModel>> data = new();

            try
            {
                var result = await this.UnitOfWork.DesignationRepository.GetAllDesignation();
                return result;
            }
            catch (System.Exception ex)
            {
                return data;
            }

        }
    }
}
