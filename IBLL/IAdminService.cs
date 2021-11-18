using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;

namespace IBLL
{
    public interface IAdminService
    {
        Task<ResponseViewModel<List<DashboardApplicantViewModel>>> GetAllCandidateList();

        Task<ResponseViewModel<bool>> EditCandidate(UpdateCandidateViewModel data);

        Task<ResponseViewModel<bool>> RejectApplicant(int InterviewId);

        Task<ResponseViewModel<bool>> AddInterviewer(AddInterviewerViewModel data);

        Task<ResponseViewModel<bool>> ScheduleInterviewDate(ScheduleInterviewViewModel model);

        Task<ResponseViewModel<ApplicantViewModel>> GetApplicantById(int id);

        Task<ResponseViewModel<bool>> AddApplicant(AddApplicantViewModel applicant);

        Task<ResponseViewModel<bool>> PromoteApplicant(PromoteApplicantViewModel model);

        Task<ResponseViewModel<List<UserViewModel>>> GetAllUser();

        Task<ResponseViewModel<List<DesignationViewModel>>> GetAllDesignation();
    }
}
