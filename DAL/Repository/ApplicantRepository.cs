using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using IDAL.IRepository;
using Mapster;
using ViewModel;

namespace DAL.Repository
{
    public class ApplicantRepository : GenericRepository, IApplicantRepository
    {

        public ApplicantRepository(IDbConnection connection) : base(connection) { }

        public async Task<ResponseViewModel<bool>> EditCandidate(UpdateCandidateViewModel data)
        {
            ResponseViewModel<bool> result = new ResponseViewModel<bool>();

            try
            {
                string query = "Exec uspUpdateApplicant @ApplicantId,@UserId ,@FirstName,@LastName,@LastEmployer,@LastDesignation,@AppliedFor,@ReferredBy,@MedicalStatus,@NoticePeriod ";

                var parameters = new DynamicParameters(data);

                var response = await Connection.QueryAsync<string>(query, parameters);

                if (response.FirstOrDefault() == "Success")
                {
                    result.Data = true;
                }

            }
            catch (System.Exception)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
            }

            return result;
        }

        public async Task<ResponseViewModel<List<DashboardApplicantViewModel>>> GetAllCandidateList()
        {
            ResponseViewModel<List<DashboardApplicantViewModel>> result = new ResponseViewModel<List<DashboardApplicantViewModel>>();

            string queryString = "Exec spGetAllCandidate";

            try
            {

                result.Data = new List<DashboardApplicantViewModel>();

                var conn = await Connection.QueryMultipleAsync(queryString);

                var applicantList = conn.Read<DashboardApplicantViewModel>();

                var applicantInterviewerList = conn.Read<InterviewerViewModel>();

                // mapping the applicant interviewers to single object
                foreach (var applicant in applicantList)
                {
                    DashboardApplicantViewModel applicantViewModel = new DashboardApplicantViewModel();

                    applicantViewModel = applicant.Adapt<DashboardApplicantViewModel>();

                    if (applicant.InterviewAt != null)
                    {
                        foreach (var interviewer in applicantInterviewerList)
                        {
                            if (applicant.ApplicantId == interviewer.ApplicantId && interviewer.InterviewerName != null)
                            {
                                applicantViewModel.InterviewerList.Add(interviewer.InterviewerName);
                            }
                        }
                    }
                    result.Data.Add(applicantViewModel);
                }
            }
            catch (System.Exception ex)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
            }

            return result;
        }


    }
}