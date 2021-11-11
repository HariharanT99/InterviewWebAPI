using System.Threading.Tasks;
using ViewModel;

namespace IDAL.IRepository
{
    public interface IInterviewerReviewRepository
    {
        Task<ResponseViewModel<bool>> AddInterviewer(AddInterviewerViewModel data);
    }
}