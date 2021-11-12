using System.Threading.Tasks;
using ViewModel;

namespace IDAL.IRepository
{
    public interface IApplicantRepository
    {
        Task<ResponseViewModel<ApplicantViewModel>> GetApplicantById(int id);
        Task<ResponseViewModel<bool>> AddApplicant(int userId, string firstName, string lastName, string lastEmployer, string lastDesignation, int appliedFor, int referedBy, string medicalStatus, int noticePeriod, string resume);
    }
}
