using Dapper;
using IDAL.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace DAL.Repository
{
    public class InterviewRepository: GenericRepository, IInterviewRepository
    {
        public InterviewRepository(IDbConnection connection): base(connection){ } 

        public async Task<ResponseViewModel<bool>> PromoteCandidate(int applicantId, int interviewId)
        {
            ResponseViewModel<bool> result = new();
            try
            {
                var param = new DynamicParameters();
                param.Add("ApplicantId", applicantId);
                param.Add("InterviewId", interviewId);

                var sp = "uspPromoteApplicant @ApplicantId, @InterviewId";

                var response = await Connection.ExecuteScalarAsync<string>(sp, param);
                if(response == "Success")
                {
                    result.Data = true;
                }
            }
            catch (Exception)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
            }
            return result;
        }
    }
}
