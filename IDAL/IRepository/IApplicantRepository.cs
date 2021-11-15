using System.Threading.Tasks;
using ViewModel;

namespace IDAL.IRepository
{
    public interface IApplicantRepository
    {
        Task<ResponseViewModel<ApplicantViewModel>> GetApplicantById(int id);
        Task<ResponseViewModel<bool>> AddApplicant(AddApplicantViewModel applicant);
    }
}
