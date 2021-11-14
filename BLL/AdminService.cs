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

        public async Task<ResponseViewModel<bool>> AddApplicant(int userId, string firstName, string lastName, string lastEmployer, string lastDesignation, int appliedFor, int referedBy, string medicalStatus, int noticePeriod, string resume)
        {
            var result = await this.UnitOfWork.ApplicantRepository.AddApplicant(userId, firstName, lastName, lastEmployer, lastDesignation, appliedFor, referedBy, medicalStatus, noticePeriod, resume);
            return result;
        }

        public async Task<ResponseViewModel<bool>> PromoteApplicant(int applicantId, int interviewId)
        {
            var result = await this.UnitOfWork.InterviewRepository.PromoteApplicant(applicantId, interviewId);
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
