using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using IDAL.IRepository;
using Microsoft.Data.SqlClient;
using ViewModel;

namespace DAL.Repository
{
    public class InterviewerReviewRepository : GenericRepository, IInterviewerReviewRepository
    {
        public InterviewerReviewRepository(IDbConnection connection) : base(connection)
        {
        }

        public async Task<ResponseViewModel<bool>> AddInterviewer(AddInterviewerViewModel data)
        {
            ResponseViewModel<bool> result = new ResponseViewModel<bool>();

            try
            {
                string query = "Exec spAddInterviewer @InterviewId,@InterviewerIdList";

                var parameters = new DynamicParameters(data);

                var response = await Connection.QueryAsync<string>(query, parameters);

                if (response.FirstOrDefault() == "Success")
                {
                    result.Data = true;
                }
            }
            catch (SqlException sqlError)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = sqlError.Message;
            }
            catch (System.Exception)
            {
                result.Error.Succeeded = false;
                result.Error.ErrorMsg = "Something went wrong";
                result.Error.ErrorCode = 500;
            }

            return result;
        }
    }
}