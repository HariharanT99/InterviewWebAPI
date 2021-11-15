using IBLL;
using IDAL.IConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BLL
{
    public class AdminService: GenericService, IAdminService
    {
        public AdminService(IUnitOfWork uow) : base(uow) { }

        public async Task<ResponseViewModel<ApplicantViewModel>> GetApplicantById(int id)
        {
            var result = await this.UnitOfWork.ApplicantRepository.GetApplicantById(id);
            return result;
        }

        public async Task<ResponseViewModel<bool>> AddApplicant(AddApplicantViewModel applicant)
        {
            var result = await this.UnitOfWork.ApplicantRepository.AddApplicant(applicant);
            return result;
        }

        public async Task<ResponseViewModel<bool>> PromoteApplicant(PromoteApplicantViewModel model)
        {
            var result = await this.UnitOfWork.InterviewRepository.PromoteApplicant(model);
            return result;
        }

        public async Task<ResponseViewModel<List<UserViewModel>>> GetAllUser()
        {
            var result = await this.UnitOfWork.UserRepository.GetAllUser();
            return result;
        }

        public async Task<ResponseViewModel<List<DesignationViewModel>>> GetAllDesignation()
        {
            var result = await this.UnitOfWork.DesignationRepository.GetAllDesignation();
            return result;
        }
    }
}
