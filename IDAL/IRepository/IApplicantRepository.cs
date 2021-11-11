using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;

namespace IDAL.IRepository
{
    public interface IApplicantRepository
    {

        Task<ResponseViewModel<List<DashboardApplicantViewModel>>> GetAllCandidateList();

    }
}