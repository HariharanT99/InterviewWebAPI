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
        Task<ResponseViewModel<bool>> AddApplicant(AddApplicantViewModel applicant);
        Task<ResponseViewModel<bool>> PromoteApplicant(PromoteApplicantViewModel model);
        Task<ResponseViewModel<List<UserViewModel>>> GetAllUser();
        Task<ResponseViewModel<List<DesignationViewModel>>> GetAllDesignation();
    }
}
