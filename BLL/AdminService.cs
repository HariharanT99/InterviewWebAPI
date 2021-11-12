using System.Collections.Generic;
using System.Threading.Tasks;
using IBLL;
using IDAL.IConfiguration;
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
    }
}