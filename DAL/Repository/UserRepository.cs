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
    public class UserRepository: GenericRepository, IUserRepository
    {
        public UserRepository(IDbConnection connection): base(connection) { }

        public async Task<ResponseViewModel<List<UserViewModel>>> GetAllUser()
        {
            ResponseViewModel<List<UserViewModel>> result = new();

            try
            {
                var sp = "uspGetUser";

                var response = await Connection.QueryAsync<UserViewModel>(sp);

                result.Data = response.ToList();
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
