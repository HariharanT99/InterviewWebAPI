using System;
using System.Data;
using DAL.Repository;
using IDAL.IRepository;
using ViewModel;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DAL.Repository
{
    public class ApplicantRepository: GenericRepository, IApplicantRepository
    {
        public ApplicantRepository (IDbConnection connection): base(connection) { }

        public async Task<ResponseViewModel<ApplicantViewModel>> GetApplicantById(int id)
        {
            ResponseViewModel<ApplicantViewModel> result = new();
            ApplicantViewModel applicant = new();
            var param = new DynamicParameters();
            param.Add("Id", id);

            try
            {
                string sp = "uspGetApplicant @Id";
                var data = await Connection.QueryFirstOrDefaultAsync<ApplicantJsonViewModel>(sp,param);

                var interviewJson = JsonConvert.DeserializeObject<List<InterviewViewModel>>(data.Interview);

                applicant.ApplicantID = data.ApplicantId;
                applicant.Name = data.Name;
                applicant.Designation = data.Designation;
                applicant.LastEmployer = data.LastEmployer;
                applicant.MedicalStatus = data.MedicalStatus;
                applicant.NoticePeriod = data.NoticePeriod;
                applicant.Interview = interviewJson;

                result.Data = applicant;
            }
            catch(Exception)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Fetching data failed";
                result.Error.ErrorCode = 500;
                throw;
            }
            return result;
        }

        public async Task<ResponseViewModel<bool>> AddApplicant(AddApplicantViewModel applicant)
        {
            ResponseViewModel<bool> result = new();

            try
            {
                var param = new DynamicParameters(applicant);

                var sp = "uspAddApplicant @UserId," +
                                          "@FirstName," +
                                          "@LastName," +
                                          "@LastEmployer," +
                                          "@LastDesignation," +
                                          "@AppliedFor," +
                                          "@ReferedBy," +
                                          "@MedicalStatus," +
                                          "@NoticePeriod," +
                                          "@Resume";

                var respose = await Connection.ExecuteScalarAsync<string>(sp, param);

                if(respose == "Success")
                {
                    result.Data = true;
                }
            }
            catch (Exception ex)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
            }
            return result;
        }
    }
}