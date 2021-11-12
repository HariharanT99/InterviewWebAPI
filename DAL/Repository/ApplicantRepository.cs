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

            var param = new DynamicParameters();
            param.Add("@Id", id);

            try
            {
                string sp = "Exec uspGetApplicant @Id";
                var data = Connection.QueryFirstOrDefault<ApplicantJsonViewModel>(sp,param);

                var interviewJson = JsonConvert.DeserializeObject<List<InterviewViewModel>>(data.Interview);

                //var applicant = data.ReadFirst<ApplicantViewModel>();


                //var interviews = data.ReadAsync<InterviewViewModel>();

                //var app = data.Read<InterviewerReviewViewModel>();

            }
            catch(Exception ex)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Fetching data failed";
                result.Error.ErrorCode = 500;
                throw;
            }
            return result;
        }
    }
}