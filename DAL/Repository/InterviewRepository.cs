using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using IDAL.IRepository;
using Model;
using ViewModel;

namespace DAL.Repository
{
    public class InterviewRepository : GenericRepository, IInterviewRepository
    {
        public InterviewRepository(IDbConnection connection) : base(connection)
        {
        }

        public async Task<ResponseViewModel<bool>> RejectApplicant(int interviewId)
        {
            ResponseViewModel<bool> result = new ResponseViewModel<bool>();
            try
            {
                string query = "Exec spRejectCandidate @InterviewId";

                var entity = new Interview() { InterviewId = interviewId };

                var parameters = new DynamicParameters(entity);

                var response = await Connection.QueryAsync<string>(query, parameters);

                if (response.FirstOrDefault() == "Success")
                {
                    result.Data = true;
                }
                else
                {
                    result.Error.Succeeded = false;
                    result.Error.ErrorMsg = "Applicant not found";
                }
            }
            catch (System.Exception)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
                throw;
            }
            return result;
        }

        public async Task<ResponseViewModel<bool>> ScheduleInterviewDate(ScheduleInterviewViewModel model)
        {
            ResponseViewModel<bool> result = new ResponseViewModel<bool>();

            try
            {
                string query = "Exec spUpdateInterviewDate @InterviewId,@InterviewAt";

                var parameters = new DynamicParameters(model);

                var response = await Connection.QueryFirstOrDefaultAsync<string>(query, parameters);

                if (response == "Success")
                {
                    result.Data = true;
                }
                else
                {
                    result.Error.Succeeded = false;
                    result.Error.ErrorMsg = "something went wrong";
                }
            }
            catch (System.Exception)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "something went wrong";
            }

            return result;
        }
    }
}