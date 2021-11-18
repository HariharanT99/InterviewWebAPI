using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;

namespace IDAL.IRepository
{
    public interface IApplicantRepository
    {

        Task<ResponseViewModel<List<DashboardApplicantViewModel>>> GetAllCandidateList();

        Task<ResponseViewModel<bool>> EditCandidate(UpdateCandidateViewModel data);

        Task<ResponseViewModel<ApplicantViewModel>> GetApplicantById(int id);

        Task<ResponseViewModel<bool>> AddApplicant(AddApplicantViewModel applicant);
    }
}
