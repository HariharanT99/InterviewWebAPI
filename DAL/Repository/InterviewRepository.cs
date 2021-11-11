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
    }
}