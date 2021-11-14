using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace IBLL
{
    public interface IAdminService
    {
        Task<ResponseViewModel<ApplicantViewModel>> GetApplicantById(int id);
        Task<ResponseViewModel<bool>> AddApplicant(int userId, string firstName, string lastName, string lastEmployer, string lastDesignation, int appliedFor, int referedBy, string medicalStatus, int noticePeriod, string resume);
        Task<ResponseViewModel<bool>> PromoteApplicant(int applicantId, int interviewId);
        Task<ResponseViewModel<List<UserViewModel>>> GetAllUser();
        Task<ResponseViewModel<List<DesignationViewModel>>> GetAllDesignation();
    }
}
