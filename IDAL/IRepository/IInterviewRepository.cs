using System.Threading.Tasks;
using ViewModel;

namespace IDAL.IRepository
{
    public interface IInterviewRepository
    {
        Task<ResponseViewModel<bool>> RejectApplicant(int InterviewId);

        Task<ResponseViewModel<bool>> ScheduleInterviewDate(ScheduleInterviewViewModel model);

        Task<ResponseViewModel<bool>> PromoteApplicant(PromoteApplicantViewModel model);
    }
}
